
render(
    function () {
        var cfg = [];
        cfg.push(hide('questionnaireid', q.id));
        cfg.push(html('<div id="questionnaire"></div>'));
        cfg.push(html('<div id="testBox" style="width: 600px;height:400px;"></div> '));
        return cfg;
    }
   ,
"",
"",
"问卷预览");

function formReady() {
    var width = 150;
    var height = 150;
    var id = "#" + "questionnaire";
    var index, question, i, newQuestion, aOption;
    $.Ajax({
        url: "/twxt2/Open/GetAllRecord?quesid=" + $("#questionnaireid").val(),
        success: function (obj) {
            console.log(obj);
            if (obj.answeraccount == 0) {

                alert("暂无人答题");
                return;
            }
            else {
                $(id).append('<p id="title">' + obj.Title + '</p>');
                $(id).append('<p id="totalanswer">' + "参与调查人数：" + obj.answeraccount + '</p>');
                for (index = 0, i = 1; index < obj.Questions.length; index++, i++) { //根据问题个数做循环  
                    if (obj.Questions[index].QuestionType == 1 || obj.Questions[index].QuestionType == 0) {//单选题则建立图标

                        $(id).append('<p id=qustion-' + i + ' class="qustion-sty">' + i + "." + obj.Questions[index].Title + "( )" + '</p>');//添加一个p标签
                        $(id).append('<div id=answerGraph-' + i + ' style="width:200px;height:300px;">' + '</div>');
                        //生成饼状图
                        var myChart = echarts.init(document.getElementById('answerGraph-' + i + ''));
                        var testdata = new Array();
                        for (var m = 0; m < obj.Questions[index].Options.length; m++) {
                            testdata[m] = new Object();
                            testdata[m].name = obj.Questions[index].Options[m].Title;
                            testdata[m].value = obj.Questions[index].Options[m].answercount;

                        }
                        option = {
                            tooltip:
                                {
                                    trigger: 'item',
                                    formatter: "{a} <br/>{b} : {c} ({d}%)"
                                },

                            series: [
                                {
                                    name: '具体数据',
                                    type: 'pie',
                                    radius: '55%',
                                    center: ['50%', '60%'],
                                    data: testdata
                                }
                            ]
                        };

                        $(id).append('<div class="clear"></div>');

                        myChart.setOption(option);

                        //生成表          
                        tableNode = document.createElement("table");//获得对象 
                        tableNode.setAttribute("class", "tableStyle");
                        var row = 3;//获得行号
                        var cols = obj.Questions[index].Options.length + 1;
                        //上面确定了 现在开始创建 
                        //var header = ["选项", "选中次数", "所占比例"];
                        for (var x = 0; x < row; x++) {
                            if (x == 0) {
                                var trNode = tableNode.insertRow();
                                for (var y = 0; y < cols; y++) {
                                    var tdNode = trNode.insertCell();
                                    if (y == 0) {
                                        tdNode.innerHTML = "选项";
                                    }
                                    else
                                        tdNode.innerHTML = obj.Questions[index].Options[y - 1].Title;
                                }
                            }
                            if (x == 1) {
                                var trNode = tableNode.insertRow();
                                for (var y = 0; y < cols; y++) {
                                    var tdNode = trNode.insertCell();
                                    if (y == 0) {
                                        tdNode.innerHTML = "选中次数";
                                    }
                                    else
                                        tdNode.innerHTML = obj.Questions[index].Options[y - 1].answercount;
                                }
                            }
                            if (x == 2) {
                                var trNode = tableNode.insertRow();
                                for (var y = 0; y < cols; y++) {
                                    var tdNode = trNode.insertCell();
                                    if (y == 0) {
                                        tdNode.innerHTML = "所占比例";
                                    }
                                    else {
                                        if (obj.Questions[index].QuestionType == 1)
                                            tdNode.innerHTML = parseFloat((obj.Questions[index].Options[y - 1].answercount / obj.answeraccount * 100)).toFixed(2) + "%";
                                        else {
                                            var totalanswer = 0;
                                            for (m = 0; m < obj.Questions[index].Options.length; m++) {
                                                totalanswer += obj.Questions[index].Options[m].answercount;

                                            }
                                            tdNode.innerHTML = parseFloat((obj.Questions[index].Options[y - 1].answercount / totalanswer * 100)).toFixed(2) + "%";

                                        }

                                    }

                                }
                            }
                        }
                        document.getElementById('answerGraph-' + i + '').appendChild(tableNode);//添加到新生成的div里面 
                        $(id).append('<hr />');
                    }


                    if (obj.Questions[index].QuestionType == 2) {
                        //自定义回答则展示答案
                        $(id).append('<p id=qustion-' + i + ' class="qustion-sty">' + i + "." + obj.Questions[index].Title + "( )" + '</p>');//添加一个p标签
                        $(id).append('<div id=answerGraph-' + i + ' style="width:100%;height:400px;overflow-y:auto;">' + '<div id =concent' + i + ' ></div> ' +
                            '</div>');
                        for (k = 0; k < obj.Questions[index].CustomizeAnswer.length; k++)
                            $("#concent" + i).append('<p id=answer-' + k + ' class="answer-sty" style=" border-bottom:1px dashed #999; ">' + obj.Questions[index].CustomizeAnswer[k].Customize + '</p>');//添加一个p标签

                    }

                }
            }
        },
        async: true
    });
}




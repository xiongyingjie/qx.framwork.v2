
render(
    function () {
        var cfg = [];
        cfg.push(hide('questionnaireid', q.id));
        cfg.push(hide('uid', q.uid));
        cfg.push(html('<div id="questionnaire"></div>'));

        return cfg;
    }
   ,
"",
"",
"问卷预览");

function formReady() {
    var id = "#" + "questionnaire";
    var index, questionID, options, i, newQuestion, aOption, radiocount = 0, customizecount = 0;
    var radioquestion = new Array();
    var customizequestion = new Array();
    var aQuestion = {}, result = {};

    $.Ajax({
        url: "/twxt2/Open/GetQuestionnaire?Id=" + $("#questionnaireid").val(),
        success: function (data) {
            if (!$.hasValue(data.Questions)) {
                $.msg("问卷不存在", 2);
                return;
            }

            //构造result对象数组用于回传填写的数据
            result.QuestionnaireId = data.QuestionnaireId;
            result.Questions = new Array();
            for (var i = 0; i < data.Questions.length; i++) {
                result.Questions.push(i);
                result.Questions[i] = new Object();
                result.Questions[i].OptionID = new Array();
            }

            //构造result对象数组用于回传填写的数据

            //将数据库取到的问卷数据展示出来
            $(id).append('<p id="title">' + data.Title + '</p>');
            for (index = 0, i = 1; index < data.Questions.length; index++, i++) {//根据问题个数进行循环
                questionID = data.Questions[index].QuestionId;
                newQuestion = "#" + questionID;

                $(id).append('<div id="' + questionID + '" class="question"></div>');
                var questionimg = "";
                if (data.Questions[index].ImgUrl != "") {
                    questionimg = '<img class="questionimg" src=' + $.url(data.Questions[index].ImgUrl) + '>';
                }
                aQuestion.title = '<p><span>' + i + '.</span>' + data.Questions[index].Title
								+ '&nbsp&nbsp(&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp)&nbsp?' +questionimg+'</p>';
                $(newQuestion).append(aQuestion.title);
                if (data.Questions[index].QuestionType == 0) {
                    for (options = 0; options < data.Questions[index].Options.length; options++) {
                        var optionimg = "";
                        if (data.Questions[index].Options[options].OpImgUrl != "") {
                            optionimg = '<img  class="optionimg" src=' + $.url(data.Questions[index].Options[options].OpImgUrl) + '>';
                        }
                        aOption = '<div><input type="checkbox" name="' + questionID + '" value="'
                                + data.Questions[index].Options[options].OptionId
                                + '"/>&nbsp&nbsp' + data.Questions[index].Options[options].Title
                                + optionimg + '</div>';
                        $(newQuestion).append(aOption);

                    }
                }
                if (data.Questions[index].QuestionType == 1) {
                    radioquestion[radiocount] = index;//记录单选回答的题号
                    radiocount++;
                    for (options = 0; options < data.Questions[index].Options.length; options++) {
                        var optionimg = "";
                        if (data.Questions[index].Options[options].OpImgUrl != "") {
                            optionimg = '<img class="optionimg" src=' + $.url(data.Questions[index].Options[options].OpImgUrl) + '>';
                        }
                        aOption = '<div><input type="radio" name="' + questionID + '" value="'
                                + data.Questions[index].Options[options].OptionId
                                + '"/>&nbsp&nbsp' + data.Questions[index].Options[options].Title
                                + optionimg + '</div>';
                        $(newQuestion).append(aOption);

                    }
                }
                if (data.Questions[index].QuestionType == 2) {
                    customizequestion[customizecount] = index;//记录自定义回答的题号
                    customizecount++;
                    aOption = '<div><input type="text" id="question' + index + '"/></div>';
                    $(newQuestion).append(aOption);
                }
            }
            //将数据库取到的问卷数据展示出来
            $(id).append('<div id="submit"><input  type="submit" value="提交"/></div>');
            $("#submit").click(function () {
                var checkboxitem = $(":checkbox:checked");
                console.log(checkboxitem);
                var radioitem = $(":radio:checked");//获取所有单选选中的选项
                console.log(radioitem);
                var customizeitem = $(":text");//获取所有intput框填写的内容
                var customizelength = 0;
                for (k = 0; k < data.Questions.length; k++) {
                    if (data.Questions[k].type == 1)
                        customizelength++;//获取单选回答的数量
                }
                var len = radioitem.length;
                if (len == customizelength)
                    alert("所有题目均须作答！");
                else {


                    for (index = 0; index < customizequestion.length; index++) {
                        result.Questions[customizequestion[index]].CustomizeAnswer = customizeitem[index].value;
                        result.Questions[customizequestion[index]].QuestionId = data.Questions[customizequestion[index]].QuestionId;
                        result.Questions[customizequestion[index]].OptionID = null;
                    }
                    for (index = 0; index < radioquestion.length; index++) {
                        result.Questions[radioquestion[index]].OptionID.push(radioitem.eq(index).val());
                        result.Questions[radioquestion[index]].QuestionId = data.Questions[radioquestion[index]].QuestionId;
                        result.Questions[radioquestion[index]].CustomizeAnswer = null;
                    }
                    for (k = 0; k < data.Questions.length; k++) {
                        for (m = 0; m < checkboxitem.length; m++) {
                            if (data.Questions[k].QuestionId == checkboxitem[m].name) {

                                result.Questions[k].CustomizeAnswer = null;
                                result.Questions[k].QuestionId = data.Questions[k].QuestionId;
                                result.Questions[k].OptionID.push(checkboxitem[m].value);
                            }

                        }
                    }
                    $.Ajax({
                        url: "/twxt2/Questionnaire/GetAnswerRecord",
                        data: { jsonitems: JSON.stringify(result) },//将数据转为json 数据格式
                        success: function (result1) {
                            alert("提交成功");
                          //  window.location.href = "/twxt2/Questionnaire/AnswerQuestionnaireList";
                        },
                        error: function (result1) {
                            alert("提交失败");
                           // window.location.href = "/twxt2/Questionnaire/AnswerQuestionnaireList";
                        }
                    });
                }

            });
        },
        async: true
    });
}




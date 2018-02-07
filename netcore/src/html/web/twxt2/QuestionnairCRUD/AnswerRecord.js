
render(
    function () {
        var cfg = [];
        cfg.push(hide('questionnaireid', q.id));
        cfg.push(hide('id', '13003933381'));
        cfg.push(html('<div id="questionnaire"></div>'));
        return cfg;
    }
   ,
"",
"",
"问卷预览");

function formReady() {
    var id = "#" + "questionnaire";
    var index, question, i, newQuestion, aOption;
    $.Ajax({
        url: "/twxt2/Open/GetMyRecord?quesid=" + $("#questionnaireid").val() + "&id=" + $("#id").val(),
        success: function (data) {
            if (data.length == 0) {
                $.alert('您未填写过该问卷');
                return;
            }
            //该数组存放所有题目（包括重复的多选题）
            var answertitle = new Array();
            for (x = 0; x < data.length; x++) {
                answertitle.push(data[x].QuestionTitle);
            }
            //该书组存放唯一的题目
            var tmp = new Array();
            for (var i in answertitle) {
                //该元素在tmp内部不存在才允许追加
                if (tmp.indexOf(answertitle[i]) == -1) {
                    tmp.push(answertitle[i]);
                }
            }
            //该数组存放处理过后的答题记录（将多选题的回答分组）
            var M = new Array();
            for (q = 0; q < tmp.length; q++) {
                M[q] = new Array();
                for (w = 0; w < data.length; w++) {
                    if (tmp[q] == data[w].QuestionTitle) {

                        M[q].push(data[w]);
                    }
                }
            }

            var time =  new Date(data[0].AnsweTime);
            var result = time.getFullYear() + '-' + time.getMonth() + '-' + time.getDate();
            $(id).append('<p id="title">' + data[0].Title + '</p>');
            $(id).append('<p id="username">' + "回答者：" + data[0].UserName + '</p>');
            $(id).append('<p id="answertime">' + "回答时间：" + result + '</p>');

            for (index = 0, i = 1; index < M.length-2; index++, i++) {
                    question = M[index][0].QuestionTitle;
                if (M[index][0].QuestionType == 0) {

                    $(id).append('<p id=qustion-' + i + ' class="qustion-sty">' + i + "." + question + '(<span class="span-sty"' + 'id=span-sty' + index + '>' + '</span>)' + '</p>'); + '</div>';//添加一个DIV     
                    for (y = 0; y < M[index].length; y++) {
                        $("#span-sty" + index).append('<span>' + M[index][y].OptionTitle + '、</span>');

                    }

                }
                if (M[index][0].QuestionType == 1) {
                    $(id).append('<p id=qustion-' + i + ' class="qustion-sty">' + i + "." + question + '(<span class="span-sty">' + M[index][0].OptionTitle + '</span>)' + '</p>'); + '</div>';//添加一个DIV
                }
                if (M[index][0].QuestionType == 2) {
                    $(id).append('<p id=qustion-' + i + ' class="qustion-sty">' + i + "." + question + '(<span class="span-sty">' + M[index][0].CustomizeAnswer + '</span>)' + '</p>'); + '</div>';//添加一个DIV
                }

            }
            $(newQuestion).append(aOption);
        },

        async: true
    });
}




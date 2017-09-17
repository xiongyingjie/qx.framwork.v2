
render(function () {
    return[
    group([
    showinput("学生姓名", "nick_name"),
    //只读
    time("上传时间", "exp_submit_time", ""),
    select("等级", "exp_score_level", [{ text: "优秀", value: "优秀" },
        { text: "良好", value: "良好" }, { text: "中等", value: "中等" },
        { text: "及格", value: "及格" }, { text: "差", value: "差" }
    ], "请输入等级", 2),
      //下载文件
               html('<div class="col-lg-3">' +
                '<div class="form-group">' +
                  '<label>下载实验报告</label>' +
                 // '<input type="text" readonly="readonly" class="form-control" name="syll_author" id="syll_author" value="">'+
                 "<a style='display:block;color:blue'  class='form-control'   href='" + $.url(model.exp_report_files) + "'>" + $.getFileName(model.exp_report_files) + "</a>" +
                    '<p class="help-block warning-block">' +
                      '<span id="msg-syll_author">&nbsp;</span>' +
                   '</p>' +
              '</div>' +
        '</div>'),
    ], "查看实验报告", 1)
    ]
}, "*", "/IEET/Experiment/EpxerimentDivsportListFind","查看实验报告");
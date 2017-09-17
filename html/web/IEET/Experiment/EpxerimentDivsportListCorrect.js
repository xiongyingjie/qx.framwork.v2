
render(function () {
    return[
    group([
    showinput("学生姓名", "nick_name"),
    //只读
    showinput("上传时间", "exp_submit_time", model.exp_submit_time),
	 select("等级", "exp_score_level","/IEET/Exercises/LevelSelect", "请选择等级", 2),
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
        hide("exp_reports_id", model.exp_reports_id),

       
    ], "查看实验报告", 1)
    ]
}, "/IEET/Experiment/EpxerimentDivsportListUpdate", "/IEET/Experiment/EpxerimentDivsportListFind","查看实验报告"); 

render(function () {
    return [
        group([
showinput("第几次作业", "exp_number_of_times"),
showinput("发布时间", "exp_public_time"),
showinput("截止时间", "exp_finish_time"),
showinput("提交时间", "exp_submit_time"),
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
area("本次实验说明", "exp_note"),
hide("exp_reports_id"),
hide("experiment_div_id"),
hide("exp_operator")
        ], "上传实验报告", 1)
]
},
 "", "/IEET/Experiment/EpxerimentDivsport_stuCheck","查看实验报告");


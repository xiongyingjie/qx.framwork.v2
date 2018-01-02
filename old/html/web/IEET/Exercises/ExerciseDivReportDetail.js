render(function() {
	return [
		group([
//下载文件
showinput("学号","stu_id", model.stu_id),
showinput("提交时间","exc_submit_time", model.exc_submit_time),
           html('<div class="col-lg-3">'+
            '<div class="form-group">'+
              '<label>下载作业文件</label>'+
             // '<input type="text" readonly="readonly" class="form-control" name="syll_author" id="syll_author" value="">'+
			 "<a style='display:block;color:blue'  class='form-control'   href='"+$.url(model.exc_report_file)+"'>"+$.getFileName(model.exc_report_file)+"</a>"+
                '<p class="help-block warning-block">'+
                  '<span id="msg-syll_author">&nbsp;</span>'+
               '</p>'+
          '</div>'+ 
    '</div>') ,
			
		 select("等级", "excScoreLevel","/IEET/Exercises/LevelSelect", "请选择等级",1)
		], "查看并批改作业", 1),

		hide("excerciseDivReportId",model.exe_div_report_id),
		hide("excercise_div_id",model.excercise_div_id)
	

	];
}, "/IEET/Exercises/UpdateExerciseDivReportLevel", "/IEET/Exercises/ExerciseDivReportDetail","查看并批改作业");
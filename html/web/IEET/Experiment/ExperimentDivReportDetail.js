render(function() {
	return [
		group([

      showinput("学号","stu_id", model.stu_id),
	  		showinput("提交时间","exp_submit_time", model.exp_submit_time),
	  //下载文件
           html('<div class="col-lg-3">'+
            '<div class="form-group">'+
              '<label>下载作业文件</label>'+
             // '<input type="text" readonly="readonly" class="form-control" name="syll_author" id="syll_author" value="">'+
			 "<a style='display:block;color:blue'  class='form-control'   href='"+$.url(model.exp_report_files)+"'>"+$.getFileName(model.exp_report_files)+"</a>"+
                '<p class="help-block warning-block">'+
                  '<span id="msg-syll_author">&nbsp;</span>'+
               '</p>'+
          '</div>'+ 
    '</div>') ,
	
		 select("等级", "expScoreLevel","/IEET/Exercises/LevelSelect", "请选择等级",1)
		], "查看并批改作业", 1),

		hide("expReportsId",model.exp_reports_id),
		hide("experiment_div_id",model.experiment_div_id)
	

	];
}, "/IEET/Experiment/UpdateExperimentDivReportLevel", "/IEET/Experiment/ExperimentDivReportDetail","查看并批改作业");
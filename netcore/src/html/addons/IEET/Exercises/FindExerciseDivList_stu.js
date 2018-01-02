render(function() {	
   		subSetTitle( "作业文件");
	return [
		group([
			showinput("提交时间","exc_submit_time", model.exc_submit_time),

				     //下载文件
           html('<div class="col-lg-3">'+
            '<div class="form-group">'+
              '<label>下载作业文件</label>'+
             // '<input type="text" readonly="readonly" class="form-control" name="syll_author" id="syll_author" value="">'+
			 "<a style='display:block;color:blue'  class='form-control'   href='"+$.url(model.exc_report_file)+"'>"+$.getFileName(model.exc_report_file)+"</a>"+
                '<p class="help-block warning-block">'+
                  '<span id="msg-syll_author">&nbsp;</span>'+
               '</p>'+
          '</div>'+ 
    '</div>'),



		  //下载文件
        // showfile("作业文件","exc_report_file",model.exc_report_file)
	
		], model.course_name + "作业详情", 1)
	];
},
 "", "/IEET/Exercises/FindExerciseDivList_stu");


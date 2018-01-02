render(function() {
	return [
		group([
			select("作业次数","number_of_times_id", "ecampus.IEET.number_of_times@items&name=times_of_name",model.number_of_times_id,4,true),
			showinput("发布时间","exc_public_time", model.exc_public_time),
			showinput("截止时间","exc_finish_time", model.exc_finish_time),
			     //下载文件
           html('<div class="col-lg-3">'+
            '<div class="form-group">'+
              '<label>下载作业文件</label>'+
             // '<input type="text" readonly="readonly" class="form-control" name="syll_author" id="syll_author" value="">'+
			 "<a style='display:block;color:blue'  class='form-control'   href='"+$.url(model.excercise_content_file)+"'>"+$.getFileName(model.excercise_content_file)+"</a>"+
                '<p class="help-block warning-block">'+
                  '<span id="msg-syll_author">&nbsp;</span>'+
               '</p>'+
          '</div>'+ 
    '</div>'),
 // editor("本次作业说明","exc_note",model.exc_note,1,200)
       			
		], "作业详情", 1)
	];
}, "", "/IEET/Exercises/ExerciseDivDetail","作业详情");
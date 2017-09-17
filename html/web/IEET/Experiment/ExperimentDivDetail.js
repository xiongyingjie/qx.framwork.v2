render(function() {
	return [
		group([
			select("实验次数","number_of_times_id", "/IEET/CodeApi/GetNumberOfTimes",model.number_of_times_id,4,true),
			showinput("发布时间","exp_public_time", model.exp_public_time),
			showinput("截止时间","exp_finish_time", model.exp_finish_time),
			     //下载文件
           html('<div class="col-lg-3">'+
            '<div class="form-group">'+
              '<label>下载实验文件</label>'+
             // '<input type="text" readonly="readonly" class="form-control" name="syll_author" id="syll_author" value="">'+
			 "<a style='display:block;color:blue'  class='form-control'   href='"+$.url(model.exp_content_file)+"'>"+$.getFileName(model.exp_content_file)+"</a>"+
                '<p class="help-block warning-block">'+
                  '<span id="msg-syll_author">&nbsp;</span>'+
               '</p>'+
          '</div>'+ 
    '</div>'),
 // editor("本次实验说明","exc_note",model.exc_note,1,200)
       			
		], "实验详情", 1)
	];
}, "", "/IEET/Experiment/ExperimentDivDetail","实验详情");
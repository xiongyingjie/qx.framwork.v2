render(function() {	
   		subSetTitle(model.course_name + "练习要求详情");
	return [
		group([
			showinput("练习名称","excercise_name", model.excercise_name),
			showinput("年级","grade_no", model.grade_no),
			showinput("课程", "course_name",model.course_name),
			showinput("班级", "class_name",model.class_name),
            area("练习说明", "exc_summery", model.exc_summery, 4, 100),
		  //下载文件
           html('<div class="col-lg-3">'+
            '<div class="form-group">'+
              '<label>下载练习指导书</label>'+
             // '<input type="text" readonly="readonly" class="form-control" name="syll_author" id="syll_author" value="">'+
			 "<a style='display:block;color:blue'  class='form-control'   href='"+$.url(model.exc_guide_book)+"'>"+$.getFileName(model.exc_guide_book)+"</a>"+
                '<p class="help-block warning-block">'+
                  '<span id="msg-syll_author">&nbsp;</span>'+
               '</p>'+
          '</div>'+ 
    '</div>'), 
		//	hide("curr_schedule_id",q.id),
		//	hide("excercise_id",model.excercise_id)			
		], model.course_name + "练习要求详情", 1)
	];
},
 "", "/IEET/Exercises/FindExerciseFile");


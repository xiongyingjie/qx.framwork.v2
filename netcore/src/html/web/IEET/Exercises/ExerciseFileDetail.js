render(function() {
		subSetTitle(model.course_name + "练习要求详情");
	return [
		group([

			showinput("练习名称","excercise_name", model.excercise_name),
			showinput("年级","grade_no", model.grade_no),
			showinput("课程", "course_name",model.course_name),
			showinput("班级", "class_name",model.class_name),
            area("练习说明", "exc_summery", "请输入练习说明", 4,100),
			file("练习指导书", "exc_guide_book", 2,"/UserFile/IEET/ExerciseFile/"),
			hide("curr_schedule_id",q.id),
			hide("excercise_id",model.excercise_id)			
		], model.course_name + "练习要求详情", 1)
	];
},
 "/IEET/Exercises/UploadExerciseFile", "/IEET/Exercises/ExerciseFileDetail");
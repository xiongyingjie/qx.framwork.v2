//上传作业指导书
render(function() {
		subSetTitle("上传"+ model.course_name + "作业要求");
	return [
		group([
			showinput("年级","grade_no", model.grade_no),
			showinput("课程", "course_name",model.course_name),
			showinput("班级", "class_name",model.class_name),
			input("作业名称", "excercise_name","", 4, {max:20,min:2}, "请输入作业名称"),
            area("作业说明", "exc_summery", "请输入练习说明", 1, "", 120),
			file("作业指导书", "exc_guide_book", 2,"/UserFile/IEET/ExerciseFile/"),
			 hide("curr_schedule_id", q.id)
		],"上传"+ model.course_name + "作业要求", 1)
	];
	
},
 "/IEET/Exercises/AddExerciseFile", "/IEET/Exercises/AddExerciseFileDetail");
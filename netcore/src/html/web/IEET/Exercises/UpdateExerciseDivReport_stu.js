render(function() {
	return [
		group([
			select("作业次数","number_of_times_id","/IEET/CodeApi/GetNumberOfTime", model.number_of_times_id,4,true),
			//showinput("作业次数","number_of_times_id1", model.exc_public_time),
			showinput("发布时间","exc_public_time", model.exc_public_time),
			showinput("截止时间","exc_finish_time", model.exc_finish_time),
			file("作业文件", "excReportFile", 2,"/UserFile/IEET/ExerciseFile/"), 
			// editor("作业额外要求说明","exc_note", model.exc_note,1,200),
		
			hide("excerciseDivId",model.excercise_div_id)		
		], "上传作业", 1)
	];
}, "/IEET/Exercises/SubmiteExerciseDivReport", "/IEET/Exercises/UpdateExerciseDivReport_stu","上传作业");
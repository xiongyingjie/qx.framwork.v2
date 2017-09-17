render(function() {		
	return [
		group([
		select("作业次数", "number_of_times_id","/IEET/CodeApi/GetNumberOfTimes",""), 
		input("作业名称","excercise_div_name","",4, {max:20,min:3}),
		time("截至时间", "exc_finish_time"),
		file("作业文件", "excercise_content_file", 4,"/UserFile/IEET/ExerciseFile/"),		
      //  editor("本次作业说明","exc_note","请补充完整本次作业要求",1,350),
	  	hide("excercise_id",q.excercise_id)	
		],  "添加作业", 1)
	];
}, "/IEET/Exercises/ExerciseDivAdd", "","添加作业");


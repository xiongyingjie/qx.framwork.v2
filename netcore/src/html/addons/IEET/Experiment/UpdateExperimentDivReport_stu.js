render(function() {
	return [
		group([
			select("实验次数","number_of_times_id","/IEET/CodeApi/GetNumberOfTime", model.number_of_times_id,4,true),
			//showinput("实验次数","number_of_times_id1", model.exc_public_time),
			showinput("发布时间","exp_public_time", model.exp_public_time),
			showinput("截止时间","exp_finish_time", model.exp_finish_time),
			file("实验文件", "expReportFile", 2,"/UserFile/IEET/ExerciseFile/"), 
			// editor("作业额外要求说明","exc_note", model.exc_note,1,200),
		
			hide("experciseDivId",model.experiment_div_id)		
		], "上传实验", 1)
	];
}, "/IEET/Experiment/SubmiteExperimentDivReport", "/IEET/Experiment/UpdateExperimentDivReport_stu","上传实验报告");
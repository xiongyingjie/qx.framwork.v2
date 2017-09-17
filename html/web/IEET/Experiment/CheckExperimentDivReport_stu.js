//上传作业指导书
render(function() {
		subSetTitle("学号："+ model.stu_id);
	return [
		group([
			select("等级","exp_score_level","/IEET/Exercises/LevelSelect",model.exp_score_level,4,true),
			showinput("提交时间", "exp_submit_time",model.exp_submit_time),
		    showfile("作业文件","exp_report_files",model.exp_report_files)
		],"", 1)
	];
},
 "", "/IEET/Experiment/CheckExperimentDivReport_stu");
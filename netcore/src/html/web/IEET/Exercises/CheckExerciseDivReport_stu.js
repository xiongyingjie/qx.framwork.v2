//上传作业指导书
render(function() {
		subSetTitle("学号："+ model.stu_id);
	return [
		group([
			select("等级","exc_score_level","/IEET/Exercises/LevelSelect",model.exc_score_level,4,true),
			showinput("提交时间", "exc_submit_time",model.exc_submit_time),
		    showfile("作业文件","exc_report_file",model.exc_report_file)
		],"", 1)
	];
},
 "", "/IEET/Exercises/CheckExerciseDivReport_stu");
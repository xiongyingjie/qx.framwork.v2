
	 render(function() {		
	return [
		group([
		select("实验次数", "number_of_times_id","/IEET/CodeApi/GetNumberOfTimes",""), 
	
		input("实验名称","experiment_div_name","",4, {max:20,min:3}),
		time("截止时间", "exp_finish_time"),
		file("实验文件", "exp_content_file", 2,"/UserFile/IEET/ExperimentFile/"),		
        //editor("本次实验说明","exp_note","请补充完整本次实验要求",1,350),
	  	hide("experiment_id",q.id)	
		],  "添加实验", 1)
	];
}, "/IEET/Experiment/AddExperiment_div", "","添加分次实验");


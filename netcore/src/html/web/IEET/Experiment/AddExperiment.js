
render([
group([
hide( "curr_schedule_id",q.id),
input("实验名称", "experiment_name","",4,{max:20,min:3},""),
area("说明", "exp_summery"),
file("实验指导书", "exp_guide_book", 2, "/UserFile/IEET/ExperimentFile/")
], "", 1)
], "/IEET/Experiment/AddExperiment", "","开设实验");
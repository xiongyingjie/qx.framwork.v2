
render([
group([
input("实验名称", "experiment_name"),
area("说明", "exp_summery"),
file("实验指导书", "exp_guide_book", 4, "/UserFile/IEET/ExperimentFile/"),
], "上传实验", 1)
], "", "/IEET/Experiment/EpxerimentListcheck_stu");
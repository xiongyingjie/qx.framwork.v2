
render([
group([
input("本次实验题目", "experiment_div_name"),
input("第几次实验", "exp_number_of_times"),
time("截止时间", "exp_finish_time", ""),
area("实验指导说明", "exp_note"),
hide("exp_public_time"),
hide("experiment_div_id"),
hide("experiment_id", q.id)
], "实验分次添加", 1)
], "/IEET/Experiment/ExperimentDivAdd", "");
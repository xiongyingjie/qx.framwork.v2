
render(function () {
    return [
        group([
showinput("第几次作业", "exp_number_of_times"),
showinput("发布时间", "exp_public_time"),
showinput("截止时间", "exp_finish_time"),
area("本次实验说明", "exp_note"),
file("实验报告", "exp_report_files", 4, "/UserFile/IEET/ExperimentFile/"),
hide("experiment_id", model.experiment_id),
hide("experiment_div_id", model.experiment_div_id),
hide("experiment_div_name", model.experiment_div_name)
        ], "上传实验报告", 1)
    ]
},
 "/IEET/Experiment/EpxerimentDivsport_stuUpdate", "/IEET/Experiment/EpxerimentDivsport_stuFind","上传实验报告");
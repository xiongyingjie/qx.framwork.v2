
render(function () {
    return [
        group([
            hide("test_paper_id", q.id),
            select("分数等级", "s_test_grade", "/IEET/Test/Getgrade_level", "", 4),
            file("学生答卷上传", "stu_test_paper_file", 2, "/UserFile/IEET/test_paper_file/"),

        ], "试卷上传", 1)
    ];
}, "/IEET/Test/AddStu_Test","","试卷上传");
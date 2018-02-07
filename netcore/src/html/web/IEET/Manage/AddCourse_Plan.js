
render(function () {
    return [
        group([
            hide("curr_schedule_id",q.id),
            input("作者", "plan_author","",4, {max:10,min:2},"请输入作者"),
            input("版本", "plan_version","",4, {max:10,min:2},"请输入版本"),
            file("文件上传", "course_plan_file", 2, "/UserFile/IEET/CoursePlanFile/")
        ], "教案上传",1)
    ];
}, "/IEET/Manage/AddCourse_Plan","","教案上传");
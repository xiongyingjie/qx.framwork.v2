
render(function () {
    return [
        group([
            hide("course_plan_id"),
            hide("curr_schedule_id"),
            showinput("课程:", "course_name"),
            showinput("作者：", "plan_author"),
            showinput("上次提交时间：", "plan_submit_time"),
            showinput("版本：", "plan_version"),
            showfile("教案文件", "course_plan_file")
        ],  "查看教案", 1)
    ];
}, "", "/IEET/Manage/FindCourse_Plan","查看教案");
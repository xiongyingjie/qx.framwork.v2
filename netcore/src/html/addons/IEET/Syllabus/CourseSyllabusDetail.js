render(function() {
	var cfg = [];
	cfg.push(group([
		showinput("课程", "course_name"),
		showinput("大纲名称", "syllabus_name"),
		showinput("大纲版本", "syllabus_version"),
		showinput("提交时间", "syll_submit_time"),
		showinput("大纲作者", "syll_author"),
		showinput("使用年限", "year_in_use"),
		showinput("提交人", "syll_operator"),
		showfile("下载大纲", "syllabus_file"),
		hide("syllabus_id")
	], model.course_name + "大纲详情", 1));
	subSetTitle(model.course_name + "大纲详情");
	return cfg;
}, "*", "/IEET/Syllabus/CourseSyllabusDetail",  "");




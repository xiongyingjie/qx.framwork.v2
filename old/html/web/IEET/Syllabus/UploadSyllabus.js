
render([
group([
showinput("课程", "course_name"),
//只读
input("版本", "syllabus_version","", 4, {max:20,min:2}),
input("大纲名称", "syllabus_name","", 4,{max:20,min:2}),
input("大纲作者", "syll_author","", 4, {max:20,min:2}),
input("使用年限", "year_in_use", "", 4, "", "比如:2017.4-2017.6"),
file("大纲文件", "syllabus_file", 2,"/UserFile/IEET/SyllabusFile/"),
hide("course_id",q.id),

hide("syllabus_id","#id"),
hide("syll_operator","#uid"),
hide("syll_submit_time","#now")
],"上传大纲",1)
], "/IEET/Syllabus/UploadSyllabus", "/IEET/Syllabus/FindCourse","上传大纲");



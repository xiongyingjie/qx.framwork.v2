render(function() {
	return [
		group([
		
		   select("年级", "xn", "/IEET/CodeApi/GetSchool_year", "xn", 4),
		  select("所属专业", "zy", "/IEET/ImportData/specialty", "zy", 4),     
           select("课程类型", "course_type", "/IEET/ImportData/CourseType", "zy", 4),
		    input("课程名称", "course_name","",4, {max:20,min:1},"请输入课程名称")      
		], "添加课程", 1)
	];
}, "/IEET/ImportData/AddCourse", "","添加课程");
	
 function formReady() {
 $.bindSelect("xn", "zy", "/IEET/CodeApi/GetSpecialty",true);
}      
   
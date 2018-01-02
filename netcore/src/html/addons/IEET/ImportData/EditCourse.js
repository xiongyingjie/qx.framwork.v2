render(function() {
	return [
		group([
		 input("课程名称", "course_name",model.course_name),
		  select("年级", "xn", "/IEET/CodeApi/GetSchool_year", model.grade_no),
		   select("所属专业", "specilty", "", model.year_specialty_id),       
           select("课程类型", "course_type", "/IEET/ImportData/CourseType",model.course_type),
		   hide("course_id",q.id)     
		], "编辑课程", 1)
	];
}, "/IEET/ImportData/UpdateCourse", "/IEET/ImportData/EditCourse?course_id="+q.id,"编辑课程");
	
 function formReady() {
 $.bindSelect("xn", "specilty", "/IEET/CodeApi/GetSpecialty",true);
}  

render(function() {
	return [
		group([			
		    select("年级", "xn", "/IEET/CodeApi/GetSchool_year", "", 4),
			 select("专业", "zy", "", "", 4), 
            select("班级", "bj", "", "", 4), 
			 select("学期", "term","/IEET/ImportData/GetTerm"),	
             select("课程", "kc", "", "", 4),  
		     select("教师", "teacher_id", "/IEET/ImportData/GetCourseTable_Teacher", "zy", 4), 
			 input("起止周数", "from_end_week","比如:1-18周",4, {max:20,min:2},"比如:1-18周"), 
		     input("上课时间", "class_date","比如:周三，周四",4, {max:20,min:2},"比如:周三，周四"), 
		     select("上课节数", "class_time", "/IEET/ImportData/GetCourseTable_ClassTime", "zy", 4),  
			 select("教室", "class_room", "/IEET/ImportData/GetCourseTable_ClassRoom", "zy", 4)  		    
		], "添加课表", 1)
	];
}, "/IEET/ImportData/AddCourseTable", "","添加课表");

function formReady() {
 $.bindSelect("xn", "zy", "/IEET/CodeApi/GetSpecialty",true);
  $.bindSelect("zy", "bj", "/IEET/CodeApi/GetClass");
    $.bindSelect("zy", "kc", "/IEET/CodeApi/GetCourse");
}

       
   
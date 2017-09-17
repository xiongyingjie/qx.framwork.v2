render(function() {
	return [
		group([
           select("年级", "grade_no", "/IEET/CodeApi/GetSchool_year"),  
           select("专业", "specilty_no", "/IEET/ImportData/SpecialtyName")
          
		], "添加年级专业", 1)
	];
}, "/IEET/ImportData/AddGradeSpecialty", "","添加年级专业");


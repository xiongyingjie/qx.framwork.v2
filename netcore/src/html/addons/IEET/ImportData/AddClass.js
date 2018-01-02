render(function() {
	return [
		group([
           select("年级", "xn", "/IEET/CodeApi/GetSchool_year"),  
           select("专业", "zy", ""), 
           input("班级", "class_name","",4,{max:20,min:3},"请输入班级")
		], "添加班级", 1)
	];
}, "/IEET/ImportData/AddClass", "","添加班级");
function formReady() {
  $.bindSelect("xn", "zy", "/IEET/CodeApi/GetSpecialty",true);
}

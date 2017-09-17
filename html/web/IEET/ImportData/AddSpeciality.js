render(function() {
	return [
		group([
           input("专业名称", "speciality_name", "",4,{max:20,min:3},"请输入专业名称"), 
           input("专业编号", "specilty_no","",4,"^[0-9]*$","请输入专业编号")
		], "添加专业", 1)
	];
}, "/IEET/ImportData/AddSpeciality", "","添加专业");


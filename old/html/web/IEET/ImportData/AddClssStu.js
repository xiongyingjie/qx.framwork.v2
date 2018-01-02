render(function() {
	return [
		group([

           input("学号", "user_id", "", 4, "^.{3,20}$","请输入学号"),
		    input("姓名", "nick_name", "", 4, "^.{2,20}$","请输入姓名"),
			 input("电话", "phone", "", 4, "^.{3,20}$","请输入电话"),
			hide("id",q.id)
		], "添加班级学生", 1)
	];
}, "/IEET/ImportData/AddClssStu", "","添加班级学生");

           
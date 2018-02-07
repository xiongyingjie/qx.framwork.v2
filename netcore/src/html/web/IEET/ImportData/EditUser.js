render(function() {
	return [
		group([
	    showinput("用户ID","user_id", model.user_id),
		showinput("用户名","nick_name", model.nick_name),
	  //input("密码", "user_pwd",model.user_pwd, 4,  "比如:1525121002", "^.{3,20}$"),
      input("手机号", "phone",model.phone, 4),
	  hide("email",model.email),
	   hide("user_pwd",model.user_pwd),
	   hide("user_type_id",model.user_type_id),
	    hide("register_date",model.register_date),
		 hide("note",model.note),
		  hide("last_login_date",model.last_login_date)
		], "", 1)
	];
}, "/IEET/ImportData/UpdateUser", "/IEET/ImportData/EditUser","编辑用户");
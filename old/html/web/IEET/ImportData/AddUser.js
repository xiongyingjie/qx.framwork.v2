render(function() {
	return [
		group([
		 input("用户ID", "user_id","",4, {max:20,min:3},"请输入用户ID"),
		  input("用户名", "nick_name","",4, {max:20,min:2},"请输入用户名"),  
		   select("用户类型", "user_type_id", "/IEET/ImportData/UserType"),   
			  input("密码", "user_pwd","",4, {max:20,min:3},"请输入密码"),    
			    input("手机号", "phone","",4,"^[0-9]*$","请输入手机号")             
		], "添加用户", 1)
	];
}, "/IEET/ImportData/AddUser", "","添加用户");

       
   
render([
  group([
        input("员工号", "employee_no", "", "2", "请输入员工号"),
        input("员工姓名", "employee_name", "", "2", "请输入员姓名"),
        input("用户密码", "user_psw", "", "2", "请输入用户密码"),
        input("联系电话", "phone_num", "", "2", "请输入员联系电话", "^[0-9]*$"),
        input("员工地址", "employee_address", "", "2", "请输入员工地址"),
        input("员工电邮", "employee_email", "", "2", "请输入员工电邮")
  ], "查看详情", 1)
], '');
render([
    input("用户id", "uid", "", "3", "请输入用户id"),
    input("密码", "psw", "", "3", "请输入密码"),
    select("用户类型", "usertypeid", "[{\"text\":\"管理员\",\"value\":\"1\"},{\"text\":\"普通会员\",\"value\":\"2\"}]", "请输入男或女", "3")
   
] ,"home/add" );
render([

input("学习id", "SchoolId", "", 4, "123524", ""),
input("学习地址", "SchoolAddress", "", 4, "厦门市集美区集美大道668号", "^[0-9]*$"),

input("联系方式", "Cell", "", 4, "13252457946", "^[0-9]*$"),

input("官方邮件", "Emal", "", 4, "4564545@qq.com", ""),

image("学校Logo", "http://www.runoob.com/wp-content/uploads/2014/06/download.png", 3, ""),

input("更换logo", "Emaldsfd", "", 4, "要重新写", ""),

button("提交修改", 6, Color.blue,function(){})

]);
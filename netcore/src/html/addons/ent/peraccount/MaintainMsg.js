render([



    image({
        type: "circle",
        num: "4",
        value: "http://www.runoob.com/wp-content/uploads/2014/06/download.png",
        tip: "华大酒店"
    }),


    input("学号", "Student_ID", "学号", "2"),
    input("姓名", "Name", "姓名", "2"),
    radio("性别", "sex",  [{ text: '男', value: '1' }, { text: '女', value: '2' },] ,1,2),
    input("电话", "PhoneNumber", "电话", "2"),
    input("邮箱", "Email", "邮箱", "2"),



    input("年级", "Grade", "年级", "2"),
    input("专业", "Major", "专业", "2"),
    input("班级", "Class", "班级", "2"),
    input("QQ", "QQid", "QQ", "2"),
    input("体重", "Weight", "体重", "1"),//这里“2”会空出一个，只能把体重，身高调为“1”了
    input("身高", "Height", "身高", "1"),


    area({
        label: "个人简介",
        name: "desc",
        value: "请输入简介",
        num: "1",
        tip: "请输入简介",
        height: "120"
    }),


    button("保存", 6, Color.blue, function () { }),


























]);
render([
    input("资源标题：", "zy_title", "", 4, "", "^[0-9]*$"),
    input("资源发布人：", "zy_person", "", 4, "", "^[0-9]*$"),
    input("日期输入：", "date_input", "", 4, "", "^[0-9]*$"),
    time("日期输入：", "time", "2017-7-17 16：05", 4),
    select("发布栏目：", "fblm", "[{\"text\":\"企业Logo\",\"value\":\"1\"},{\"text\":\"[电脑]企业介绍图集\",\"value\":\"2\"}]", "--请选择--", 4),
    
    button("提交", 6, Color.blue, function () {  }),
]);
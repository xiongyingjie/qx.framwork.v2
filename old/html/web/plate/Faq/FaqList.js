render([
input("FOQ列表：", "FOQ_ line","请输入要查询的文章标题",2),
select("性别", "sex", "[{\"text\":\"男\",\"value\":\"1\"}]", "全部", 4),
button("查询", 1, Color.bule),

], "*");
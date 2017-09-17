render([
input("标题", "title", "",2),
select("选择父级分类", "select_father_sort", "[{\"text\":\"男\",\"value\":\"1\"}]", "学生微信端使用教程", "为帮助文章选择父分类", 2),
select("选择子级分类", "select_sublevel _sort", "[{\"text\":\"男\",\"value\":\"1\"}]", "", "（必填项）为帮助文章选择子级分类，若没有子级分类，请去分类列表添加", 2),
editor("2017-07-01","note","今天我很开心",1,350),
input("摘要", "abstract", "",2),
input("视频链接", "video_ link","","请填写优酷视频地址",2),
], "*");
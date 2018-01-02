render([


select({
    label: "单位类型",
    name: "Company_Type",
    option: "[{\"text\":\"酒店\",\"value\":\"1\"},{\"text\":\"企业\",\"value\":\"2\"},{\"text\":\"餐厅\",\"value\":\"3\"},{\"text\":\"度假村\",\"value\":\"4\"}]",
    value: "1",
    tip: "",
    num: 1
}),


input("搜索单位", "search_CompanyName", "请输入公司名称", "1"),


button("搜索", 1, Color.red,function(){}),


image({
    type:"circle",
    num:"4",
    value:"http://www.runoob.com/wp-content/uploads/2014/06/download.png",
    tip:"华大酒店"
}),
image({
    type: "circle",
    num: "4",
    value: "http://www.runoob.com/wp-content/uploads/2014/06/download.png",
    tip: "华大可浓餐厅"
}),
image({
    type: "circle",
    num: "4",
    value: "http://www.runoob.com/wp-content/uploads/2014/06/download.png",
    tip: "泰国曼谷猜犹披亚公园酒店"
}),
image({
    type: "circle",
    num: "4",
    value: "http://www.runoob.com/wp-content/uploads/2014/06/download.png",
    tip: "美国塞班悦泰度假村酒店"
}),
image({
    type: "circle",
    num: "4",
    value: "http://www.runoob.com/wp-content/uploads/2014/06/download.png",
    tip: "美国关岛悦泰酒店"
}),
image({
    type: "circle",
    num: "4",
    value: "http://www.runoob.com/wp-content/uploads/2014/06/download.png",
    tip: "法国实习企业"
}),
image({
    type: "circle",
    num: "4",
    value: "http://www.runoob.com/wp-content/uploads/2014/06/download.png",
    tip: "晋江爱乐国际酒店"
}),
image({
    type: "circle",
    num: "4",
    value: "http://www.runoob.com/wp-content/uploads/2014/06/download.png",
    tip: "美国塞班卡诺亚度假村"
}),


button("1", 6, Color.blue, function () { }),

button("2", 6, Color.blue, function () { }),

button("3", 6, Color.blue, function () { }),

button("下一页", 6, Color.blue, function () { }),

button("下一页", 6, Color.blue, function () { }),








]);

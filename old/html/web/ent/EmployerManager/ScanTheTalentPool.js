render([
   
    tab([
        {
            title: "选择学校/专业/年级：",
            content: [
                select("学校：", "xx", "[{\"text\":\"华侨大学\",\"value\":\"1\"}]", "华侨大学", 4),
                select("年级：", "nj", "[{\"text\":\"2013\",\"value\":\"1\"}]", "2013", 4),
                select("专业：", "zy", "[{\"text\":\"旅游管理\",\"value\":\"1\"}]", "旅游管理", 4),
                button("查询", 6, Color.blue, function () { }),
            ]
        },
    ], 1),
    tab([
        {
            title: "人才库列表：",
            content: [
               
            ]
        },
    ], 1),

]);
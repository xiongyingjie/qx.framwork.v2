render([
    tab([
        {
            title: "选择学校：",
            content: [
                select("学校：", "xzgw", "[{\"text\":\"华侨大学\",\"value\":\"1\"}]", "华侨大学", 4),
                button("查询", 6, Color.blue, function () { }),
            ]
        },
    ], 1),
    tab([
        {
            title: "批次列表：",
           
            content: [
               
            ]
        },
    ], 1)

]);
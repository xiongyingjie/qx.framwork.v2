$.msg(q.id);

render(tab([
    {
        title: "图片",
        content:
        [
            image("circle", "http://www.runoob.com/wp-content/uploads/2014/06/download.png", 3, "错误输入"),
            image("circle", "http://www.runoob.com/wp-content/uploads/2014/06/download.png", 3, "错误输入")
        ]
    },
    {
        title: "日期时间",
        content:
        [
            date("日期", "data", "2117-5-3", 3, "错误输入"),
            input("姓名", "name", "我", 3, "错误输入"),
            select("性别", "sex", "[{\"text\":\"aaaa\",\"value\":\"bbbb\"}]", "aaaa", 3, "错误输入")
        ]
    },
    {
        title: "按钮",
        content:
        [
            button("提交", 3, Color.red, function() { $.alert('哈哈'); })
        ]
    },
    {
        title: "富文本",
        content:
        [
            richBox("富文本框", "msg", "啊实打实大苏打实打实的啊实打实大苏打", 3, "错误输入")
        ]
    }
], 1));


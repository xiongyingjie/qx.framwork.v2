
render([
    group([
            tab([
       {
           title: "表单",
           content:
           [
               showInput("姓名", "name"),
               input("年龄", "age", "", 4, "^[0-9]*$", "请输入数字"),
               select("性别", "sex", [{ text: "男", value: "1" }], "aaaa", 4),

                //select("测试", "sex", " hqu.scsxxt.v2.demo_dayoff@items", "TEST-DAYOFF-401-1-R3MDKNDR7SQ", 4, true),

               time("时间", "time", "2010-2-11 11：00", 4),
               date("日期", "date", "2010-2-11", 4, "请输入时间"),
               area("简介", "desc", "请输入简介", 4, "请输入简介", 120),
       
               checkbox('冬季水果', 'winnerfruit',
                   [{ text: '苹果', value: '3' },
                       { text: '苹果', value: '2' },
                       { text: '梨子', value: '1' }
                   ], 4),
               radio('夏季水果', 'summerfriut',
                   [{ text: '芒果', value: '4' },
                   { text: '西瓜', value: '3' },
                   { text: '香蕉', value: '2' },
                   { text: '地瓜', value: '1' }
                   ], 4,false,3),
                _switch('自动登录', "autologin", 4, 1, 'kai', 'guan'),
                editor("个人总结", "note", "今天我很开心", 1, 350),
                file("身份证", "idCard",  2),
                showfile("下载营业执照","fdfadfasd",
                     [{ name: "f1.xls", url: "/userfiles/uploads/files/RNJNKP7QDXU-split-test3-template.xls", size: "15kb", remove: "htkdfja" },
                     { name: "f2.xls", url: "/userfiles/uploads/files/RNJNKP7QDXU-split-test3-template.xls"}])
           ]
       }
       ,{
           title: "输入验证",
           content:
           [
               input("不验证", "t0", "", 4),
               input("验证必填", "t1", "", 4, ""),
               input("验证长度", "t2", "", 4, { max: 10, min: 3 }),
               input("验证邮箱", "t3", "", 4, { email: true }),
               input("自定义错误信息", "t4", "", 4, { max: 11, min: 11 },"大陆手机号只有11位"),
               input("多条件组合验证", "t5", "", 4, { email: true, max: 10, min: 3 }),
               input("自定义", "t6", "", 4, "^[0-9]*$", "请输入0-9的数字")
             
           ]
       }, {
           title: "详情页",
           content:
           [
               showInput("年龄", "age2", "", 4),
           
               showSelect("测试", "sex2", [{ text: "苹果", value: '3' },
                   { text: '苹果', value: '2' },
                   { text: '梨子', value: '1' }
               ], "2", 4, true),

                showTime("时间", "time2", "2010-2-11 11：00", 4),
                showDate("日期", "date2", "2010-2-11", 4, "请输入时间"),
                showArea("简介", "desc2", "请输入简介", 4, "请输入简介", 120),

                showCheckbox("冬季水果", 'winnerfruit2',
                   [{ text: "苹果", value: '3' },
                       { text: '苹果', value: '2' },
                       { text: '梨子', value: '1' }
                   ], 4),
                showRadio('夏季水果', 'summerfriut2',
                   [{ text: '芒果', value: '4' },
                   { text: '西瓜', value: '3' },
                   { text: '香蕉', value: '2' },
                   { text: '地瓜', value: '1' }
                   ], 4, false, 3),
                 showSwitch('自动登录', "autologin2", 4, 1, 'kai', 'guan'),
                 showEditor("个人总结", "note2", "今天我很开心", 1, 350),
                showFile("下载营业执照", "fdfadfasd2",
                     [{ name: "f1.xls", url: "/userfiles/uploads/files/RNJNKP7QDXU-split-test3-template.xls", size: "15kb", remove: "htkdfja" },
                     { name: "f2.xls", url: "/userfiles/uploads/files/RNJNKP7QDXU-split-test3-template.xls" }])

           ]
       },
       {
           title: "表格",
           content:
           [
             table(["用户名", "密码", "邮箱", "操作"],
                 [["1", "1", "1", "<a href='baidu.com'>详情</a>"],
                 ["2", "2", "2", "<a href='baidu.com'>详情</a>"],
                 ["3", "3", "3", "<a href='baidu.com'>详情</a>"]])
           ]
       }
     ,
       {
           title: "按钮",
           content:
           [
               button("我是红色", 6, Color.red),
               button("我是蓝色", 6, Color.blue),
               button("我是橙色", 6, Color.orange),
               button("我是白色", 6, Color.white),
               button("我是绿色", 6, Color.green)
           ]
       }
    ,
        {
            title: "图片",
            content:
            [
                 carousel(
                [{
                    imgurl: "http://www.runoob.com/wp-content/uploads/2014/07/carousalpluginsimple_demo.jpg"

                }, {
                    imgurl: "http://www.runoob.com/wp-content/uploads/2014/07/carousalpluginsimple_demo.jpg"

                }], 2),
                image("circle", "http://www.runoob.com/wp-content/uploads/2014/06/download.png", 2, "我是圆的"),
                image("rounded", "http://www.runoob.com/wp-content/uploads/2014/06/download.png", 2, "我是方的")
                         ]
        },
   
    {
        title: "其他",
        content:
        [
            
             pre('input("姓名", "name")<br/>input("年龄", "age", "", 4, "请输入数字", "^[0-9]*$")', 2),
             pageheader("标题", "sub标题", 1),
            thumbnail("http://www.runoob.com/wp-content/uploads/2014/06/download.png", "内容", 1),
            _alert("内容", 1, Color.red),
             panel("标题", "内容", 1, Color.red, "注脚"),
             listgroup("主标题",
                [
                    { title: "题目", body: "内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容" },
                    { title: "题目", body: "内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容" }],
                1,
                Color.red
                ),
                media("http://www.runoob.com/wp-content/uploads/2014/06/download.png", "标题", "内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容", 1),
                html("<hr/>"),
           dropdown('跳转',[{text:'百度',value:'http://baidu.com'},{text:'新浪',value:'http://sina.cn'}], 3)
        ]
    }],1)
    ], "测试", 1)], "*");





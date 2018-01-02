
render([

         //ptr(),
     searchbar(),
    button("查看控件id", 6, "default", function() {
        $.log(g_formIdArray);
        $.alert("打开控制台查看查看控件id");
    }),
    html("<br/>"),
    button("取值", 6, "primary", function() {
        getFormData();
        $.alert("打开控制台查看取值结果");
    }),
    html("<br/>"),
    button("自动赋值", 6, "warn", function() {
        var data = {
            text1: 5678,
            text2: 8888,
            select1: 1,
            select2: 2,
            time1: "2016-01-11T16:00:00",
            time2: "2017-08-11T16:40:00",
            date1: "2017-08-21",
            date2: "2017-11-06",
            summerfriut2: 4,
            summerfriut1: 2,
            winnerfruit1: [1, 2],
            winnerfruit2: [3, 2],
            autologin1: 1,
            autologin2: 0,
            note1: "今天我不开心",
            note2: "今天怎么开心啊",
            popupdate1: "2017-12-17",
            popupdate2: "2017-8-17",
            popupcitypicker1: "福建省 厦门市 集美区",
            popupcitypicker2: "福建省 三明市 三元区",
            showText1: "呵呵",
            showText2: "嘿嘿",
            showDropDown1: 2,
            showDropDown2: 1,
            showArea1: "哈哈哈哈哈",
            showArea2: "嘿嘿嘿嘿嘿",
            showtime1: "2016-12-08T16:05:10",
            showtime2: "2017-02-24T06:10:45",
            showdate1: "2016-12-08",
            showdate2: "2017-02-24",

            showwinnerfruit1: [1, 2],
            showwinnerfruit2: [3, 2],
            showsummerfriut1: 1,
            showsummerfriut2: 3
        };
        //input赋值
        $("#text1").val(data.text1);
        $("#text2").val(data.text2);
        $("#time1").val(data.time1);
        $("#time2").val(data.time2);
        $("#date1").val(data.date1);
        $("#date2").val(data.date2);
        $("#select1").val(data.select1);
        $("#select2").val(data.select2);
        $("#note1").html(data.note1);
        $("#note2").html(data.note2);
        $(" [name='NONE'][value='" + data.summerfriut1 + "']").parents(".weui-check__label").click();
        $(" [name='summerfriut1'][value='" + data.summerfriut1 + "']").parents(".weui-check__label").click();
        $(" [name='summerfriut2'][value='" + data.summerfriut2 + "']").parents(".weui-check__label").click();
        $(".weui-cells_checkbox .weui-check").each(function() {
            for (i = 0; i < data.winnerfruit1.length; i++) {
                if ($(this).val() == data.winnerfruit1[i] && $(this).attr('name') == "winnerfruit1") {
                    $(this).parents("label").click();
                }
            }

        });
        $(".weui-cells_checkbox .weui-check").each(function() {
            for (i = 0; i < data.winnerfruit2.length; i++) {
                if ($(this).val() == data.winnerfruit2[i] && $(this).attr('name') == "winnerfruit2") {
                    $(this).parents("label").click();
                }
            }

        });

        $("#popupdate1").val(data.popupdate1);
        $("#popupdate2").val(data.popupdate2);
        $("#popupcitypicker1").val(data.popupcitypicker1);
        $("#popupcitypicker2").val(data.popupcitypicker2);
        $("#showText1").val(data.showText1);
        $("#showText2").val(data.showText2);
        $("#showDropDown1").val(data.showDropDown1);
        $("#showDropDown2").val(data.showDropDown2);
        $("#showArea1").html(data.showArea1);
        $("#showArea2").html(data.showArea2);
        $("#autologin1").val(data.autologin1);
        $("#autologin2").val(data.autologin2);
        $("#showtime1").val(data.showtime1);
        $("#showtime2").val(data.showtime2);
        $("#showdate1").val(data.showdate1);
        $("#showdate2").val(data.showdate2);

        $(".weui-cells_checkbox .weui-check").each(function() {
            for (i = 0; i < data.showwinnerfruit1.length; i++) {
                if ($(this).val() == data.showwinnerfruit1[i] && $(this).attr('name') == "showwinnerfruit1") {
                    $(this).parents("label").click();
                }
            }
        });
        $(".weui-cells_checkbox .weui-check").each(function() {
            for (i = 0; i < data.showwinnerfruit2.length; i++) {
                if ($(this).val() == data.showwinnerfruit2[i] && $(this).attr('name') == "showwinnerfruit2") {
                    $(this).parents("label").click();
                }
            }
        });
        $(".weui-check").each(function() {
            if ($(this).val() == data.showsummerfriut1 && $(this).attr('name') == "showsummerfriut1") {
                // $.alert($(this).val());
                $(this).parents(".weui-check__label").click();
                //$.alert($(this).attr('name'));
            }
        });
        $(".weui-check").each(function() {
            if ($(this).val() == data.showsummerfriut2 && $(this).attr('name') == "showsummerfriut2") {
                // $.alert($(this).val());
                $(this).parents(".weui-check__label").click();
                //$.alert($(this).attr('name'));
            }
        });

        $.log(data);
        //$.alert("打开控制台查看赋值原始数据");
    }),
    input("文本1", "text1", "4845", 4, "^[0-9]*$", "请输入0-9的数字"),
    input("文本2", "text2", "", 4, "^[0-9]*$", "请输入0-9的数字"),
    time("时间1", "time1", "2016-02-11T16:00:00", 4),
    time("时间2", "time2", "2016-01-11T16:10:00", 4),
    date("日期1", "date1", "2010-02-11", 4, "请输入时间"),
    date("日期2", "date2", "2010-02-11", 4, "请输入时间"),
    select("下拉1", "select1", [{ text: "男", value: "1" }, { text: "女", value: "2" }], "2", 4),
    select("下拉2", "select12", [{ text: "男", value: "1" }, { text: "女", value: "2" }], "2", 4),
    //date，time，select默认值设置无反应
    radio('单选1', 'summerfriut1',
    [
        { text: '芒果', value: '4' },
        { text: '西瓜', value: '3' },
        { text: '香蕉', value: '2' },
        { text: '地瓜', value: '1' }
    ], 4, false),
    radio('单选2', 'summerfriut2',
    [
        { text: '芒果', value: '4' },
        { text: '西瓜', value: '3' },
        { text: '香蕉', value: '2' },
        { text: '地瓜', value: '1' }
    ], 4, false),
    checkbox('多选1', 'winnerfruit1',
    [
        { text: '苹果', value: '3' },
        { text: '苹果', value: '2' },
        { text: '梨子', value: '1' }
    ], 4, false),
    checkbox('多选2', 'winnerfruit2',
    [
        { text: '苹果', value: '3' },
        { text: '苹果', value: '2' },
        { text: '梨子', value: '1' }
    ], 4, false),
    _switch('开关1', "autologin1", 4, 0, 'kai', 'guan'),
    _switch('开关2', "autologin2", 4, 1, 'kai', 'guan'),
    area("多行1", "note1", "今天我很开心", 1, 6),
    area("多行2", "note2", "今天我很开心", 1, 4),
    popupdate("日期", "popupdate1"),
    popupdate("日期2", "popupdate2"),
    popupcitypicker("出发地", "popupcitypicker1"),
    popupcitypicker("目的地", "popupcitypicker2"),
    html("<hr/>下方为只读控件<hr/>"),
    showinput("显示文本1", "showText1", "哈哈"),
    showinput("显示文本1", "showText2", "哈哈"),
    showSelect("显示下拉1", "showDropDown1", [{ text: "男", value: "2" }], 1, true),
    showSelect("显示下拉2", "showDropDown2", [{ text: "男", value: "1" }], 1, true),
    showTime("显示时间", "showtime1", "2016-02-11T16:00:00", 4),
    showTime("显示时间2", "showtime2", "2015-02-11T16:00:00", 4),
    showDate("显示日期1", "showdate1", "2010-02-11", 4, "请输入时间"),
    showDate("显示日期2", "showdate2", "2010-03-11", 4, "请输入时间"),
    showArea("显示简介1", "showArea1", "请输入简介", 4, "请输入简介", 120),
    showArea("显示简介2", "showArea2", "请输入简介", 4, "请输入简介", 120),
    showCheckbox("显示冬季水果", 'showwinnerfruit1',
    [
        { text: "苹果", value: '3' },
        { text: '苹果', value: '2' },
        { text: '梨子', value: '1' }
    ], 4, false),
    showCheckbox("显示冬季水果", 'showwinnerfruit2',
    [
        { text: "苹果", value: '3' },
        { text: '苹果', value: '2' },
        { text: '梨子', value: '1' }
    ], 4, false),
    showRadio('显示夏季水果1', 'showsummerfriut1',
    [
        { text: '芒果', value: '4' },
        { text: '西瓜', value: '3' },
        { text: '香蕉', value: '2' },
        { text: '地瓜', value: '1' }
    ], 4, false),
    showRadio('显示夏季水果2', 'showsummerfriut2',
    [
        { text: '芒果', value: '4' },
        { text: '西瓜', value: '3' },
        { text: '香蕉', value: '2' },
        { text: '地瓜', value: '1' }
    ], 4, false),
    showSwitch('显示自动登录', "showautologin2", 4, 0, 'kai', 'guan'),
    preview('preview', [
        { title: '付款金额', body: '2400' },
        { title: '商品', body: '电动打蛋机' },
         { title: '商品2', body: '电动打蛋机' }
    ], [{ href: '#', name: '操作一' }, { href: '#', name: '操作二' }]),
    preview('preview2', [
        { title: '付款金额', body: '1999' },
        { title: '商品', body: '电动打蛋机' },
        { title: '详情', body: '不只是打蛋机，是打蛋机中的战斗机' }
        ], []),
    icon('成功','真的成功', 1),
    //icon_b('成功', '真的成功', 2),
    //icon_b('成功', '真的成功', 3),
    //icon_s('success'),
    icon('', '真的成功', 'success'),
    icon('', '警告', 'warn'),
    //icon_s('warn'),
    //icon_s('warn'),
    //icon_s('search'),
    cell('标题文字', 'id1', '说明文字'),
    cell('标题文字', 'id2', '说明文字', '', '#'),
    cell('标题文字', 'id3', '说明文字', '#'),
    cell('标题文字', 'id4', '说明文字', '#', '#'),
    flex('flex1', [1, 2, 3]),
    flex('flex2', [1, 2, 3]),
    flex('flex3', [1, 2, 3, 4]),
    flex('flex4', [1, 2, 3, 4, 5]),
   button("操作成功", 6, "primary", function () {
       $.toast("操作成功", function () {
           console.log('close');
       });
   }),
   button("取消操作", 6, "primary", function () {
       $.toast("取消操作", "cancel", function (toast) {
           console.log(toast);
       });
   }),
   button("取消操作", 6, "primary", function () {
       $.toast("禁止操作", "forbidden");
   }),
    button("显示confirm", 6, "primary", function () {
        $.confirm("您确定要删除文件&lt;&lt;毛泽东语录吗?", "确定", function () {
            $.toast("删除成功");
        }, function () {
            $.toast("删除失败");
        });
     }),
    //confirm('显示confirm', 'conf', '#', '您确定要删除文件<<毛泽东语录>>吗?', '确认删除', '文件已经删除'),
    button("显示prompt", 6, "primary", function () {
        $.prompt({
            text: "输入姓名",
            title: "名字不能超过6个字符，不得出现不和谐文字",
            onOK: function (text) {
                $.alert("您的名字是:" + text, "4");
            },
            onCancel: function () {
                console.log("取消了");
            },
            input: 'Mr Noone'
        });
    }),
    button("显示登录弹窗", 6, "primary", function () {
        $.login({
            title: '登录',
            text: '输入用户名和密码',
            onOK: function (username, password) {
                console.log(username, password);
                $.toast('角色设定成功!');
            },
            onCancel: function () {
                $.toast('取消!');
            }
        });
    }),
     button("显示自定义对话框", 6, "primary", function () {
         $.modal({
             title: "标题",
             text: "自定义",
             buttons: [
                 { text: "支付宝", onClick: function() { $.alert("你选择了支付宝"); } },
                 { text: "微信支付", onClick: function() { $.alert("你选择了微信支付"); } },
                 { text: "取消", className: "default" }
             ]
         });
     }),
     button("显示actionsheet", 6, "primary", function () {
         $.actions({
             title: "选择操作",
             onClose: function() {
                 console.log("close");
             },
             actions: [
                 {
                     text: "发布",
                     className: "color-primary",
                     onClick: function() {
                         $.alert("发布成功");
                     }
                 },
                 {
                     text: "编辑",
                     className: "color-warning",
                     onClick: function() {
                         $.alert("你选择了“编辑”");
                     }
                 },
                 {
                     text: "删除",
                     className: 'color-danger',
                     onClick: function() {
                         $.alert("你选择了“删除”");
                     }
                 }
             ]
         });
     }),
     button("显示成功", 6, "primary", function () {
         $.toptip('成功', 'success');
     }),
     button("显示失败", 6, "primary", function () {
         $.toptip('失败', 'error');
     }),
     button("显示警告", 6, "primary", function () {
         $.toptip('警告', 'warning');
     }),
    bottom_menu('half', '标题', [{ title: '发布', href: '#', icon: 'images/icon_nav_dialog.png' },
    { title: '编辑', href: '#', icon: 'images/icon_nav_dialog.png' }]),
     button("显示bottom-menu",6,"primary",function() {
         $(this).addClass('open-popup');
         $(this).attr('data-target', '#half');
     }),
    //prompt('显示prompt', 'prompt', '#', '名字不能超过6个字符，不得出现不和谐文字', '输入姓名', '您的名字是', '角色设定成功'),
    //_login('显示登录弹窗', 'login', '#', '登录', '输入用户名和密码', '您的名字是', '角色设定成功'),
   // customdialog('显示自定义对话框', 'customdialog', '#', 'hello', '自定义'),
    process('proce', '37%'),
    process('proce2', '68%'),
   // actionsheet('acts1', '显示actionsheet1'),
   // actionsheet('acts2', '显示actionsheet2'),
   // tabbar(),
  //  navbar(),
    //toptip('显示成功', 'toptipsuc', '操作成功', 'success'),
    //toptip('显示失败', 'toptipfail', '操作成功', 'error'),
    //toptip('显示警告', 'toptipwarm', '操作成功', 'warning'),
    slider('slider', 50),
    swiper('swiper-container', [
        {
            name: 'swiper1',
            skipsrc: './images/swiper-1.jpg'
        }, {
            name: 'swiper2',
            skipsrc: './images/swiper-2.jpg'
        }, {
            name: 'swiper3',
            skipsrc: './images/swiper-3.jpg'
        }
    ]),
    list('图文组合列表',  [{ link: '#', img: 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAHgAAAB4CAMAAAAOusbgAAAAeFBMVEUAwAD///+U5ZTc9twOww7G8MYwzDCH4YcfyR9x23Hw+/DY9dhm2WZG0kbT9NP0/PTL8sux7LFe115T1VM+zz7i+OIXxhes6qxr2mvA8MCe6J6M4oz6/frr+us5zjn2/fa67rqB4IF13XWn6ad83nxa1loqyirn+eccHxx4AAAC/klEQVRo3u2W2ZKiQBBF8wpCNSCyLwri7v//4bRIFVXoTBBB+DAReV5sG6lTXDITiGEYhmEYhmEYhmEYhmEY5v9i5fsZGRx9PyGDne8f6K9cfd+mKXe1yNG/0CcqYE86AkBMBh66f20deBc7wA/1WFiTwvSEpBMA2JJOBsSLxe/4QEEaJRrASP8EVF8Q74GbmevKg0saa0B8QbwBdjRyADYxIhqxAZ++IKYtciPXLQVG+imw+oo4Bu56rjEJ4GYsvPmKOAB+xlz7L5aevqUXuePWVhvWJ4eWiwUQ67mK51qPj4dFDMlRLBZTqF3SDvmr4BwtkECu5gHWPkmDfQh02WLxXuvbvC8ku8F57GsI5e0CmUwLz1kq3kD17R1In5816rGvQ5VMk5FEtIiWislTffuDpl/k/PzscdQsv8r9qWq4LRWX6tQYtTxvI3XyrwdyQxChXioOngH3dLgOFjk0all56XRi/wDFQrGQU3Os5t0wJu1GNtNKHdPqYaGYQuRDfbfDf26AGLYSyGS3ZAK4S8XuoAlxGSdYMKwqZKM9XJMtyqXi7HX/CiAZS6d8bSVUz5J36mEMFDTlAFQzxOT1dzLRljjB6+++ejFqka+mXIe6F59mw22OuOw1F4T6lg/9VjL1rLDoI9Xzl1MSYDNHnPQnt3D1EE7PrXjye/3pVpr1Z45hMUdcACc5NVQI0bOdS1WA0wuz73e7/5TNqBPhQXPEFGJNV2zNqWI7QKBd2Gn6AiBko02zuAOXeWIXjV0jNqdKegaE/kJQ6Bfs4aju04lMLkA2T5wBSYPKDGF3RKhFYEa6A1L1LG2yacmsaZ6YPOSAMKNsO+N5dNTfkc5Aqe26uxHpx7ZirvgCwJpWq/lmX1hA7LyabQ34tt5RiJKXSwQ+0KU0V5xg+hZrd4Bn1n4EID+WkQdgLfRNtvil9SPfwy+WQ7PFBWQz6dGWZBLkeJFXZGCfLUjCgGgqXo5TuSu3cugdcTv/HjqnBTEMwzAMwzAMwzAMwzAMw/zf/AFbXiOA6frlMAAAAABJRU5ErkJggg==', title: '标题一', article: '由各种物质组成的巨型球状天体，叫做星球。星球有一定的形状，有自己的运行轨道。' },
    { link: '#', img: 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAHgAAAB4CAMAAAAOusbgAAAAeFBMVEUAwAD///+U5ZTc9twOww7G8MYwzDCH4YcfyR9x23Hw+/DY9dhm2WZG0kbT9NP0/PTL8sux7LFe115T1VM+zz7i+OIXxhes6qxr2mvA8MCe6J6M4oz6/frr+us5zjn2/fa67rqB4IF13XWn6ad83nxa1loqyirn+eccHxx4AAAC/klEQVRo3u2W2ZKiQBBF8wpCNSCyLwri7v//4bRIFVXoTBBB+DAReV5sG6lTXDITiGEYhmEYhmEYhmEYhmEY5v9i5fsZGRx9PyGDne8f6K9cfd+mKXe1yNG/0CcqYE86AkBMBh66f20deBc7wA/1WFiTwvSEpBMA2JJOBsSLxe/4QEEaJRrASP8EVF8Q74GbmevKg0saa0B8QbwBdjRyADYxIhqxAZ++IKYtciPXLQVG+imw+oo4Bu56rjEJ4GYsvPmKOAB+xlz7L5aevqUXuePWVhvWJ4eWiwUQ67mK51qPj4dFDMlRLBZTqF3SDvmr4BwtkECu5gHWPkmDfQh02WLxXuvbvC8ku8F57GsI5e0CmUwLz1kq3kD17R1In5816rGvQ5VMk5FEtIiWislTffuDpl/k/PzscdQsv8r9qWq4LRWX6tQYtTxvI3XyrwdyQxChXioOngH3dLgOFjk0all56XRi/wDFQrGQU3Os5t0wJu1GNtNKHdPqYaGYQuRDfbfDf26AGLYSyGS3ZAK4S8XuoAlxGSdYMKwqZKM9XJMtyqXi7HX/CiAZS6d8bSVUz5J36mEMFDTlAFQzxOT1dzLRljjB6+++ejFqka+mXIe6F59mw22OuOw1F4T6lg/9VjL1rLDoI9Xzl1MSYDNHnPQnt3D1EE7PrXjye/3pVpr1Z45hMUdcACc5NVQI0bOdS1WA0wuz73e7/5TNqBPhQXPEFGJNV2zNqWI7QKBd2Gn6AiBko02zuAOXeWIXjV0jNqdKegaE/kJQ6Bfs4aju04lMLkA2T5wBSYPKDGF3RKhFYEa6A1L1LG2yacmsaZ6YPOSAMKNsO+N5dNTfkc5Aqe26uxHpx7ZirvgCwJpWq/lmX1hA7LyabQ34tt5RiJKXSwQ+0KU0V5xg+hZrd4Bn1n4EID+WkQdgLfRNtvil9SPfwy+WQ7PFBWQz6dGWZBLkeJFXZGCfLUjCgGgqXo5TuSu3cugdcTv/HjqnBTEMwzAMwzAMwzAMwzAMw/zf/AFbXiOA6frlMAAAAABJRU5ErkJggg==', title: '标题二', article: '由各种物质组成的巨型球状天体，叫做星球。星球有一定的形状，有自己的运行轨道。' }, ], '#'),
    //menu('小图文组合列表', [{ link: '#', img: 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAC4AAAAuCAMAAABgZ9sFAAAAVFBMVEXx8fHMzMzr6+vn5+fv7+/t7e3d3d2+vr7W1tbHx8eysrKdnZ3p6enk5OTR0dG7u7u3t7ejo6PY2Njh4eHf39/T09PExMSvr6+goKCqqqqnp6e4uLgcLY/OAAAAnklEQVRIx+3RSRLDIAxE0QYhAbGZPNu5/z0zrXHiqiz5W72FqhqtVuuXAl3iOV7iPV/iSsAqZa9BS7YOmMXnNNX4TWGxRMn3R6SxRNgy0bzXOW8EBO8SAClsPdB3psqlvG+Lw7ONXg/pTld52BjgSSkA3PV2OOemjIDcZQWgVvONw60q7sIpR38EnHPSMDQ4MjDjLPozhAkGrVbr/z0ANjAF4AcbXmYAAAAASUVORK5CYII=', title: '文字标题一' }, { link: '#', img: 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAC4AAAAuCAMAAABgZ9sFAAAAVFBMVEXx8fHMzMzr6+vn5+fv7+/t7e3d3d2+vr7W1tbHx8eysrKdnZ3p6enk5OTR0dG7u7u3t7ejo6PY2Njh4eHf39/T09PExMSvr6+goKCqqqqnp6e4uLgcLY/OAAAAnklEQVRIx+3RSRLDIAxE0QYhAbGZPNu5/z0zrXHiqiz5W72FqhqtVuuXAl3iOV7iPV/iSsAqZa9BS7YOmMXnNNX4TWGxRMn3R6SxRNgy0bzXOW8EBO8SAClsPdB3psqlvG+Lw7ONXg/pTld52BjgSSkA3PV2OOemjIDcZQWgVvONw60q7sIpR38EnHPSMDQ4MjDjLPozhAkGrVbr/z0ANjAF4AcbXmYAAAAASUVORK5CYII=', title: '文字标题二' }], '#', ''),
    newslist('文字列表附来源',  [{ title: '标题一', article: '由各种物质组成的巨型球状天体，叫做星球。星球有一定的形状，有自己的运行轨道。', from: '文字来源', time: '时间', other_info: '其他信息' }]),
   //popup(),
    loadmore('正在加载', '无更多数据'),
    footer('foot', [{ skiphref: '#', title: '底部链接' }, { skiphref: '#', title: '底部链接' }], 'Copyright © 2008-2016 weui.io')
   // infinite()
    //gallery('img','./images/pic_article.png')



], "", "", "", true
    );

//function input(id) {
//    var value = $('#' + id).val();
//    console.log(value);//文本框
//};
//function time(id) {
//    var value = $('#' + id).val();
//    console.log(value);//时间
//};
//function date(id) {
//    var value = $('#' + id).val();
//    console.log(value);//日期
//};

//function select(id) {
//    var value = $('#' + id + ' option:selected').text();
//    console.log(value);//下拉框
//}

//function radio(id) {
//    var length = $('#' + id + ' .weui-check__label').length
//    var str = ""
//    for (var i = 0; i < length; i++) {
//        if ($('#' + id + ' .weui-check__label').eq(i).find('input[type=radio]').is(':checked')) {
//            str = $('#' + id + ' .weui-check__label').eq(i).find('.weui-cell__bd p').text()
//            break;
//        }
//    }
//    console.log(str);
//    //单选框
//}
////    function f(){
////    	//编辑器
////    }
//function checkbox(id) {
//    var length = $('#' + id + ' .weui-check__label').length
//    var str = ""
//    for (var i = 0; i < length; i++) {
//        if ($('#' + id + ' .weui-check__label').eq(i).find('input[type=checkbox]').is(':checked')) {
//            str += $('#' + id + ' .weui-check__label').eq(i).find('.weui-cell__bd p').text();
//        }
//    }
//    console.log(str);
//    //console.log(str);
//    //多选框
//}
//function _switch() {
//    if ($('#switchCP').is(':checked')) console.log('on')
//    else console.log('off')
//    //开关
//}
//function area(id) {
//    var value = $('#' + id).val()
//    console.log(value)
//    //多行文本框
//}
////    function j(){
////    	$('#j')
////    	//文件上传
////    }

//$('.demos-header').click(function () {
//    input('a');//文本框
//    time('b');//时间
//    date('c');//日期
//    select('d');//下拉框
//    radio('e');//单选框
//    //f();//编辑器
//    checkbox('g');//复选框
//    _switch();//开关
//    area('i');//多行文本框
//    //    	j();//文件
//})

//$('.weui-vcode-btn').click(function () {
//    var arr = new Array()
//    arr[0] = '1'
//    arr[1] = '2'
//    arr[2] = '3'
//    _input('a', '123');//文本框
//    _time('b', '2017-10-20T12:03');//时间
//    _date('c', '2017-10-20');//日期
//    _select('d', arr);//下拉框
//    _radio('e', arr)//单选框
//    _checkbox('g', arr)//复选框
//    __switch(true);//开关
//    _area('i', '123')//多行文本框
//})



//function _input(id, x) {
//    $('#' + id).val(x);//文本框
//};
//function _time(id, x) {
//    $('#' + id).val(x);//时间
//};
//function _date(id, x) {
//    $('#' + id).val(x);//日期
//};

//function _select(id, x) {
//    var length = x.length;
//    $('#' + id).html("");
//    var str = ""
//    for (var i = 0; i < length; i++) {
//        str += '<option value="' + (i + 1) + '">' + x[i] + '</option>'
//    }
//    $('#' + id).html(str);
//    var value = $('#' + id + ' option:selected').text();

//}

//function _radio(id, x) {
//    var length = x.length
//    $('#' + id).html("");
//    var str = ""
//    for (var i = 0; i < length; i++) {
//        if (i == 0)
//            str += '<label class="weui-cell weui-check__label" for="x' + i + '">' +
//                            '<div class="weui-cell__bd">' +
//                              '<p>' + x[i] + '</p>' +
//                            '</div>' +
//                            '<div class="weui-cell__ft">' +
//                              '<input type="radio" class="weui-check" name="radio1" checked="checked" id="x' + i + '">' +
//                              '<span class="weui-icon-checked"></span>' +
//                            '</div>' +
//                          '</label>'
//        else
//            str += '<label class="weui-cell weui-check__label" for="x' + i + '">' +
//                            '<div class="weui-cell__bd">' +
//                              '<p>' + x[i] + '</p>' +
//                            '</div>' +
//                            '<div class="weui-cell__ft">' +
//                              '<input type="radio" class="weui-check" name="radio1" id="x' + i + '">' +
//                              '<span class="weui-icon-checked"></span>' +
//                            '</div>' +
//                          '</label>'
//    }

//    $('#' + id).html(str);
//    //单选框
//}
////    function ff(x){
////    	//编辑器
////    }
//function _checkbox(id, x) {
//    var length = x.length
//    $('#' + id).html("");
//    var str = ""
//    for (var i = 0; i < length; i++) {
//        str += '<label class="weui-cell weui-check__label" for="s' + i + '">' +
//                        '<div class="weui-cell__hd">' +
//                          '<input type="checkbox" class="weui-check" name="checkbox1" id="s' + i + '">' +
//                          '<i class="weui-icon-checked"></i>' +
//                        '</div>' +
//                        '<div class="weui-cell__bd">' +
//                          '<p>' + x[i] + '</p>' +
//                        '</div>' +
//                      '</label>'
//    }
//    $('#' + id).html(str);
//    //多选框
//}
//function __switch(x) {
//    if (x)
//        $('#switchCP').prop('checked', true)
//    else $('#switchCP').prop('checked', false)

//    //开关
//}
//function _area(id, x) {
//    $('#' + id).val(x);
//    //多行文本框
//}
////    function jj(x){
////    	$('#j')
////    	//文件上传
////    }

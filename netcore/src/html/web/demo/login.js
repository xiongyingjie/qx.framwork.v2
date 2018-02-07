render([

input("用户id", "uid", "请输入用户id", "3", "请输入用户id"),
input("密码", "psw", "请输入密码", "3", "请输入密码"),
input("再次输入密码", "xpsw", "请重新输入密码", "3", "请重新输入密码"),



button("查询", 6, Color.red, function () {
    var uid = document.getElementById('uid').value;
    var psw = document.getElementById('psw').value;
    var url = "http://localhost:43611/User/search";

    
    if (uid == "") {
        $.alert('请输入用户名');
        return;
    }
    $.ajax({
        type: "POST",
        url: url,
        data: "uid=" + uid + "&psw=" + psw + "&action=search" ,
        success: function (data) {
            //console.log(data);
            var obj = JSON.parse(data);
            if (obj.code == 1) {
                $.alert('加载成功');
                document.getElementById('psw').value = obj.psw;//--------???为什么赋值？
            }
            else if (obj.code == 3) {
                $.alert('参数错误');
            }
            else { $.alert('用户名不存在'); }
            // $("#tip").html('<h2>'+data+'</h2>');
        }
    });
}),


button("修改", 6, Color.red, function () {
    var uid = document.getElementById('uid').value;
    var psw = document.getElementById('psw').value;
    var url = "http://localhost:43611/User/change";

    if (uid == "") {
        $.alert('请输入用户名');
        return;
    }
    $.ajax({
        type: "POST",
        url: url,
        data: "uid=" + uid + "&psw=" + psw + "&action=change",
        success: function (data) {
            var obj = JSON.parse(data);
            if (obj.code == 1) {
                $.alert('修改成功');
            }
            else if (obj.code == 3) {
                $.alert('参数错误');
            }
            else { $.alert('用户名不存在'); }
            // $("#tip").html('<h2>'+data+'</h2>');
        }
    });
 
}),

button("删除", 6, Color.red, function () {
    var uid = document.getElementById('uid').value;
    var psw = document.getElementById('psw').value;
    var url = "http://localhost:43611/User/delete";

    if (uid == "" || psw == "") {
        $.alert('参数输入不完整');
        return;
    }
    $.ajax({
        type: "POST",
        url: url,
        data: "uid=" + uid + "&psw=" + psw,
        success: function (data) {
            var obj = JSON.parse(data);
            if (obj.code == 1) {
                $.alert('删除成功');
            }
            else if (obj.code == 3) {
                $.alert('参数错误');
            }
            else { $.alert('用户名或者密码错误'); }
            // $("#tip").html('<h2>'+data+'</h2>');
        }
    });

}),

button("登录", 6, Color.red, function () {
    var uid = document.getElementById('uid').value;
    var psw = document.getElementById('psw').value;
    var url = "http://localhost:43611/User/login";
    //加token
    //url = url + "&token=123";------------------------------------------------------记得将数据库的uid改为userID 以后好辨认

    $.ajax({
        type: "POST",
        url: url,
        data: "uid=" + uid + "&psw=" + psw,
        success: function (data) {
            var obj = JSON.parse(data);
            if (obj.code == 1)
            { $.alert('登陆成功') }
            else { $.alert('登陆失败') }
            // $("#tip").html('<h2>'+data+'</h2>');
        }
    });

}),

button("注册", 6, Color.red, function () {
    var uid = document.getElementById('uid').value;
    var psw = document.getElementById('psw').value;
    var xpsw = document.getElementById('xpsw').value;
    var url = "http://localhost:43611/User/register";
    if (psw == "" || xpsw == "" || psw == "") {
        $.alert('参数不完整');
        return;
    }
    if (psw != xpsw) {
        $.alert('两次密码不一样') ;
        return ;





    }
    $.ajax({
        type: "POST",//	 将请求发送到服务器。与 POST 相比，GET 更简单也更快，并且在大部分情况下都能用。然而，在以下情况中，请使用 POST 请求：无法使用缓存文件（更新服务器上的文件或数据库）向服务器发送大量数据（POST 没有数据量限制）发送包含未知字符的用户输入时，POST 比 GET 更稳定也更可靠
        url: url,//url：文件在服务器上的位置
        data: "uid=" + uid + "&psw=" + psw,//传入的数据这里的userid是后台的属性这里的data相当于传给后台的值------------sql的插入语句 是将输入的uid 和psw 加入到数据库吗？
        success: function (data) {   //当成功的时候执行的动作（这里的data实现前后端的数据传送）这里的 data相当于后端返回的值    
            var obj = JSON.parse(data);//json是存储和交换文本信息的语法，前台的数据类型转换
            if (obj.code == 1)
            { $.alert('注册成功'); }
            else if (obj.code ==2 ) { $.alert('用户名已经存在'); }
            else if (obj.code == -1) { $.alert('不明错误'); }
            else {$.alert('参数不明');}
            // $("#tip").html('<h2>'+data+'</h2>');
        }
    });
}),
],);
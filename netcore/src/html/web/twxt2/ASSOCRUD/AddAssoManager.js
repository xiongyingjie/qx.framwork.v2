render(function () {
    var cfg = [];
    cfg.push(
        group([
            hide('orgnization_id', q.orgnization_id),
            input('用户账号', 'user_id', '', '4'),
             input('用户名', 'nick_name', '', '4'),
              input('用户密码', 'user_pwd', '', '4'),
    button("提交", '1:5', Color.green, function () {
        var orgnization_id = $('#orgnization_id').val();
        var user_id = $('#user_id').val();
        var nick_name = $('#nick_name').val();
        var user_pwd = $('#user_pwd');
        submitForm("/twxt2/AssoCRUD/AddAssoManager?orgnization_id=" + orgnization_id + "&user_id=" + user_id + "&nick_name=" + nick_name + "&user_pwd=" + user_pwd);
    })
        ], '添加账号'));
    return cfg;
}, '', '', '添加');
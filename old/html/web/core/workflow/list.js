Query();

function Query() {
    render(function () {
        var body = [];
        for (var i = 0; i < model.All.length; i++) {
            var item = model.All[i];
            body.push([item.Title, $.parsetime(item.Time), item.Note, '<a class="qx-menu workflow-op" data-title="' + item.Title + '" data-url="' + item.Url + '">审批</a>']);
        }
        var cfg = [
            table(body,["任务", "提交时间", "详情", "操作"]),
            button("刷新", "1:5", Color.blue, function () {
                location.reload();
            }),
            button("关闭", "6:0", Color.blue, function () {
                // debugger
                subClose();
            })
        ];
        return cfg;
    }, "", "/WorkFlow/GetToDo", "待办列表",true);
}

function formReady() {
    InitMenuEvent(".workflow-op", "f", true);
}
render(
    function () {
        var cfg = [];
        var groupContent = [];
        $.log(model.data);
        groupContent.push(hide("batchinstanceid", model.batchinstanceid));
        groupContent.push(hide("markListLength", model.data.length));
        for (var i = 0; i < model.data.length; i++) {
            var item = model.data[i];
            groupContent.push(hide("applyid_" + i, item.applyid));
            groupContent.push(showinput("学号", "userid_" + i, item.userid, 4));
            groupContent.push(showinput("姓名", "name_" + i, item.name, 4));
            groupContent.push(input("分数", "mark_" + i, item.mark, 2, "请输入分数", "^[0-9]*$"));
        }
        cfg.push(group(groupContent, "评分"));
        return cfg;
    }
   ,
"/QxJzxt/CRUD/SpecialistExamine",
"/QxJzxt/CRUD/SpecialistExamineMarkList",
"*");
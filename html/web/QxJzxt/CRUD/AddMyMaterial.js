render(
    function () {
        var cfg = [];
        //cfg.push(hide("batchinstanceid", model.batchinstanceid));
        cfg.push(hide("materialtypeid", model.materialtypeid));
        cfg.push(hide("AttrCount", model.List.length));
        var groupContent = [];
        if (model.List.length > 0) {
            groupContent.push(input("材料名称", "user_material_name", "", 4,"", "请填写材料名"));
            for (var i = 0; i < model.List.length; i++) {
                var item = model.List[i];
                switch (item.infodatatype) {
                    case "001"://文本
                        groupContent.push(hide("materialtypeattrid_" + i, item.materialtypeattrid));
                        groupContent.push(input(item.attrname, "attrValue_" + i, item.value, 4));
                        break;
                    case "002"://文本域
                        groupContent.push(hide("materialtypeattrid_" + i, item.materialtypeattrid));
                        groupContent.push(area(item.attrname, "attrValue_" + i, item.value, 1));
                        break;
                    case "003"://时间
                        groupContent.push(hide("materialtypeattrid_" + i, item.materialtypeattrid));
                        groupContent.push(time(item.attrname, "attrValue_" + i, "", 4));
                        break;
                    default: //附件
                        groupContent.push(hide("materialtypeattrid_" + i, item.materialtypeattrid));
                        groupContent.push(file(item.attrname, "attrValue_" + i, 2, "/UserFiles/Test/"));
                        break;
                }
            }
            cfg.push(group(groupContent, "填写材料", 1));

            cfg.push(button("保存草稿", 6, Color.green, function () {
                submitForm("/QxJzxt/CRUD/Draft_AddMyMaterial");
            }));
            cfg.push(button("提交", 6, Color.orange, function () {
                submitForm("/QxJzxt/CRUD/Submit_AddMyMaterial");
            }));
        } else {
            groupContent.push(showinput("提示", "user_material_name", "请联系管理员设置该材料的相关字段", 4));
            cfg.push(group(groupContent, "填写材料", 1));
        }
        return cfg;
    }
   ,
"",
"/QxJzxt/CRUD/AddMyMaterial"
);

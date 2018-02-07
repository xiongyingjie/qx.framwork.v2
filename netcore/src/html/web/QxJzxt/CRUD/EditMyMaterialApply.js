render(
    function () {
        var cfg = [];
        //cfg.push(hide("batchinstanceid", model.batchinstanceid));
        cfg.push(hide("usermaterialid", model.id));
        cfg.push(hide("materialApplyLength", model.materialApply.length));
        var groupContent = [];

        if (model.materialApply.length > 0) {
            groupContent.push(input("材料名称", "user_material_name", model.materialApply[model.materialApply.length-1].name, 4, "请填写材料名"));

            for (var i = 0; i < model.materialApply.length; i++) {
                var item = model.materialApply[i];
                switch (item.infodatatype) {
                    case "001"://文本
                        groupContent.push(hide("infodatatype_" + i, item.infodatatype));
                        groupContent.push(hide("marterialvaluesid_" + i, item.marterialvaluesid));
                        groupContent.push(input(item.attrname, "attrValue_" + i, item.materialvalue, 4));
                        break;
                    case "002"://文本域
                        groupContent.push(hide("infodatatype_" + i, item.infodatatype));
                        groupContent.push(hide("marterialvaluesid_" + i, item.marterialvaluesid));
                        groupContent.push(area(item.attrname, "attrValue_" + i, item.materialvalue, 1));
                        break;
                    case "003"://时间
                        groupContent.push(hide("infodatatype_" + i, item.infodatatype));
                        groupContent.push(hide("marterialvaluesid_" + i, item.marterialvaluesid));
                        groupContent.push(time(item.attrname, "attrValue_" + i, item.materialvalue, 4));
                        break;
                    default: //附件
                        groupContent.push(hide("infodatatype_" + i, item.infodatatype));
                        groupContent.push(hide("marterialvaluesid_" + i, item.marterialvaluesid));
                        if (item.materialvalue != null) { //之前有上传过附件，现在把它显示出来可以下载
                            // groupContent.push(html("marterialvaluesid_" + i, item.marterialvaluesid));
                            groupContent.push(hide("oldFile", item.materialvalue));
                            groupContent.push(html('<div class="col-lg-3">' +
                                '<div class="form-group">' +
                                '<label>历史' + item.attrname + '</label>' +
                                // '<input type="text" readonly="readonly" class="form-control" name="materialvalue_"'+i+' id="materialvalue_"'+i+' value=" ">' +
                                '<a style="overflow:hidden;white-space: nowrap; text-overflow: ellipsis" class="form-control"  href=" ' + $.url(item.materialvalue) + ' ">' + $.getFileName(item.materialvalue) + '</a>' +
                                '<p class="help-block warning-block">' +
                                '<span id="msg-materialvalue_"' + i + '>&nbsp;</span>' +
                                '</p>' +
                                '</div> ' +
                                '</div>'
                            ));
                            groupContent.push(file(item.attrname, "attrValue_" + i, 2, "/UserFiles/Test/"));//重新上传
                        } else {
                            groupContent.push(file(item.attrname, "attrValue_" + i, 2, "/UserFiles/Test/"));
                        }
                        break;
                }
            }
            cfg.push(group(groupContent, "修改材料", 1));

            cfg.push(button("保存草稿", 6, Color.green, function () {
                submitForm("/QxJzxt/CRUD/Draft_EditMyMaterialApply");
            }));
            cfg.push(button("提交", 6, Color.orange, function () {
                submitForm("/QxJzxt/CRUD/Submit_EditMyMaterialApply");
            }));

        } else {
            groupContent.push(showinput("提示", "user_material_name", "请联系管理员设置该材料的相关字段", 4));
            cfg.push(group(groupContent, "修改材料", 1));
        }

        return cfg;
    }
   ,
"",
"/QxJzxt/CRUD/EditMyMaterialApply"
);

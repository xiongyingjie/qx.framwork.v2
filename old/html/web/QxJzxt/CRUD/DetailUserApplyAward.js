﻿render(
    function () {
        var cfg = [];
        var groupContent1 = [];
        var groupContent2 = [];
        var groupContent3 = [];
        var groupContent4 = [];
        var tabContent = [];
        groupContent1.push(hide("id", q.id));
        groupContent1.push(hide("instanceid", model.instanceid));
        groupContent1.push(hide("batchinstanceid", model.batchinstanceid));
      //  groupContent.push(showinput("状态", "statusname", model.data.apply_status.statusname, 4));
        for (var i = 0; i < model.BaseInfoList.length; i++) {
            var item = model.BaseInfoList[i];
            switch (item.infodatatype) {
                case "001"://文本
                    groupContent1.push(showinput(item.infoname, "value_" + i, item.value, 4));
                    break;
                case "002"://文本域
                    groupContent1.push(area(item.infoname, "value_" + i, item.value, 1));
                    break;
                default ://时间
                    groupContent1.push(showinput(item.infoname, "value_" + i, item.value, 4));
                    break;
            }
        }
        tabContent.push({ title: "基本信息", content: groupContent1 });

        for (var i = 0; i < model.UserAwardMaterialList.length; i++) {
            var item = model.UserAwardMaterialList[i];
            groupContent2.push(html('<div class="col-lg-3">' +
                '<div class="form-group">' +
                '<label>' + item.typename + '</label>' +
                '<a class="form-control"  href="' + $.parseurl("/QxJzxt/CRUD/DetailMaterialApply?id=" + item.usermaterialid, "f").destUrl + '"  target="_blank">' + item.material_name + '</a>' +
                '<p class="help-block warning-block">' +
                '<span id="msg-usermaterialid"' + i + '>&nbsp;</span>' +
                '</p>' +
                '</div> ' +
                '</div>'
            ));
        }
        tabContent.push({ title: "材料", content: groupContent2 });

        groupContent3.push(showinput("学院审核时间", "college_examine_time", model.data.college_examine_time, 4));
        groupContent3.push(area("学院意见", "college_opinion", model.data.college_opinion, 1));
        tabContent.push({ title: "学院意见", content: groupContent3 });

        groupContent4.push(showinput("学校审核时间", "school_examine_time", model.data.school_examine_time, 4));
        groupContent4.push(area("学校意见", "attrValue", model.data.school_opinion, 1));

        tabContent.push({ title: "学校意见", content: groupContent4 });
        switch (model.data.statusid) {
            case 0: //草稿
                cfg.push(group([tab(tabContent, 1)], "奖项申请详情  申请状态：草稿"));
                break;
            case 1: //待学院审核
                cfg.push(group([tab(tabContent, 1)], "奖项申请详情  申请状态：待学院审核"));
                break;
            case 2: //学院审核通过
                cfg.push(group([tab(tabContent, 1)], "奖项申请详情  申请状态：学院审核通过"));
                break;
            case 3: //学院审核不通过
                cfg.push(group([tab(tabContent, 1)], "奖项申请详情  申请状态：学院审核不通过"));
                break;
            case 4: //待学校审核
                cfg.push(group([tab(tabContent, 1)], "奖项申请详情  申请状态：待学校审核"));
                break;
            case 5: //学校审核通过
                cfg.push(group([tab(tabContent, 1)], "奖项申请详情  申请状态：学校审核通过"));
                break;
            default: //学校审核不通过
                cfg.push(group([tab(tabContent, 1)], "奖项申请详情  申请状态：学校审核不通过"));
                break;
        }
        return cfg;
    }
   ,
"",
"/QxJzxt/CRUD/DetailUserApplyAward",
"*");
//$(document).ready(function () {
//    setTimeout(function () {
//        $("#statusid").css("color", "red");
//    }, 300);
//})
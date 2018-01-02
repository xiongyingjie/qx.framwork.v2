render(
    function () {
        var cfg = [];
        var groupContent = [];
        groupContent.push(showinput("材料名称", "name", model.MaterialApplyDetail.name, 4));
        for (var i=0; i < model.MaterialAttrAndValue.length; i++) {
            var item = model.MaterialAttrAndValue[i];
            switch (item.infodatatype) {
                case "001"://文本
                    groupContent.push(showinput(item.attrname, "materialvalue_"+i, item.materialvalue, 4));
                    break;
                case "002"://文本域
                    groupContent.push(area(item.attrname, "materialvalue_"+i, item.materialvalue, 1));
                    break;
                case "003"://时间
                    groupContent.push(showinput(item.attrname, "materialvalue_"+i, item.materialvalue, 4));
                    break;
                default://附件
                    groupContent.push(html('<div class="col-lg-3">' +
                        '<div class="form-group">' +
                        '<label>' + item.attrname + '</label>' +
                       // '<input type="text" readonly="readonly" class="form-control" name="materialvalue_"'+i+' id="materialvalue_"'+i+' value=" ">' +
                        '<a style="overflow:hidden;white-space: nowrap; text-overflow: ellipsis" class="form-control"  href=" ' + $.url(item.materialvalue) + ' ">' + $.getFileName(item.materialvalue) + '</a>' +
                        '<p class="help-block warning-block">' +
                        '<span id="msg-materialvalue_"'+i+'>&nbsp;</span>' +
                        '</p>' +
                        '</div> ' +
                        '</div>' 
                       ));
                    break;
            }
        }
        groupContent.push(showinput("审核时间","examine_time", model.MaterialApplyDetail.examine_time, 4));
        switch (model.MaterialApplyDetail.statusid) {
            case 0://草稿
                groupContent.push(showinput("状态", "statusid","草稿"));
                break;
            case 1://待审核
                groupContent.push(showinput("状态", "statusid","待审核"));
                break;
            case 2://审核通过
                groupContent.push(showinput("状态","statusid", "审核通过"));
                break;
            default://审核不通过
                groupContent.push(showinput("状态", "statusid","审核不通过"));
                break;
        }
        groupContent.push(area("审核意见", "opinion", model.MaterialApplyDetail.opinion, 1));
        cfg.push(group(groupContent,"材料详情", 1));
        return cfg;
    }
   ,
"",
"/QxJzxt/CRUD/DetailMaterialApply",
"*");
$(document).ready(function () {
    setTimeout(function() {
        $("#statusid").css("color", "red");
    },300);
})
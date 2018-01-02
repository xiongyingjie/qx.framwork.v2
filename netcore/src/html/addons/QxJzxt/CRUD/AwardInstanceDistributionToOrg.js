render(
    function () {
       
        var cfg = [];
        cfg.push(hide("awardinstanceleveid", q.awardinstanceleveid));
        cfg.push(hide("total_count", model.total_count));
        cfg.push(hide("allCollegeLength", model.allCollege.length));
        var groupContent = []; 
        if (model.DistributionList.length > 0) //已经填写了名额分配，将数据反填
        {
            groupContent.push(showinput("剩余名额", "last"));
            for (var i = 0; i < model.allCollege.length; i++) //所有的组织机构（学院）
            {
                var item = model.allCollege[i];
                for (var j = 0; j < model.DistributionList.length; j++) //已经填写的名额分配情况
                {
                    var item2 = model.DistributionList[j];
                    if (item.orgnization_id == item2.unit_id) {
                        groupContent.push(hide("orgid_"+j, item.orgnization_id));
                        groupContent.push(hide("orgawardinstanceid_" + j, item2.orgawardinstanceid));
                        groupContent.push(input(item.name, "count_" + j, item2.count, 4, "^[0-9]*$", "请填写数量"));
                        $.log(item2.count);
                    } else {
                        continue;
                    }
                }
            }
        } else //没有填写名额分配
        {
            groupContent.push(showinput("剩余名额", "last"));
            for(var k=0;k<model.allCollege.length; k++) {
                var _item = model.allCollege[k];
                groupContent.push(hide("orgid_"+k, _item.orgnization_id));
                groupContent.push(input(_item.name, "count_" + k, 0, 4, "^[0-9]*$", "请填写数量"));
            }
        }
        cfg.push(group(groupContent, model.level_name + "总名额： " + model.total_count, 1));
        return cfg;
    }

   ,
"/QxJzxt/CRUD/AwardInstanceDistributionToOrg2",
"/QxJzxt/CRUD/AwardInstanceDistributionToOrg",
"名额分配");
$(document).keyup(function () {
    $("#last").css("color", "black");
    var sum = $("#allCollegeLength").val();
    var last = $("#total_count").val();
    for (var i = 0; i < sum; i++) {
        last = last-$("#count_" + i).val();
    }
    if (last < 0) {
        last = 0;
        $("#last").val("超出报名人数");
        $("#last").css("color", "red");
    } else {
        $("#last").val(last);
    }
});
function formReady()
{
    var sum = $("#allCollegeLength").val();
    var last = $("#total_count").val();
    for (var i = 0; i < sum; i++) {
        last = last - $("#count_" + i).val();  
    }
    $("#last").val(last);

};
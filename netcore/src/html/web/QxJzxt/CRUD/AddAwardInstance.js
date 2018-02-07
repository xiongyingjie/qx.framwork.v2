//render([
//     group([
//         hide('awardtypeid', q.awardtypeid),
//         input('奖项实例名称', 'instancename','','2'),
//         input('奖金(元)', 'bonus', '', '2', '^[0-9]*$', '请输入数字'),
//         time("开始时间", "starttime", "", 4),
//         time("结束时间", "endtime", "", 4)
         
//     ],
//        "创建奖项",
//        1)],
//        "/QxJzxt/CRUD/AddAwardInstance",
//        "",
//        //"/QxJzxt/CRUD/FindAwardIsBaseInfo",
//        //"创建奖项",
//        "*");

        render(
            function () {
                var cfg = [];
                var groupContent = [];
                groupContent.push(hide('awardtypeid', q.awardtypeid));
                groupContent.push(hide('awardinstancenum', q.awardinstancenum));
                for (var i = 0; i < q.awardinstancenum; i++) {
                    groupContent.push( input('奖项等级名称', 'instancename_'+i,'','2','',"请输入奖项等级名称"));
                    groupContent.push( input('奖金(元)', 'bonus_'+i, '', '2', '^[0-9]*$', '请输入数字'));
                }
                groupContent.push(time("开始时间", "starttime", "", 4));
                groupContent.push(time("结束时间", "endtime", "", 4));
                cfg.push(group(groupContent, "创建奖项等级", 1));
                return cfg;
            }
           ,
        "/QxJzxt/CRUD/AddAwardInstance",
        "",
        "*");
        //$(document).ready(function () {
        //    setTimeout(function() {
        //        $("#statusid").css("color", "red");
        //    },300);
        //})
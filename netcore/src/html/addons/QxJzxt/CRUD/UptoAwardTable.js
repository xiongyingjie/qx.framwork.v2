
render(
    function () {
        var cfg = [];
        var group1 = [];
        var tabContent = [];
        var sum = 0;
        var flag = 0;
        var county = 0;
        var node;
        for (var i = 0; i < model.data.length; i++) {
            var numoftotal = 0;
            group1[i] = [];
            for (var j = 0; j < model.item.length; j++) {
                for (var k = 0; k < model.item[j].length; k++) {
                    node = model.item[j][k];
                    if (model.item[j][k].awardinstanceleveid == model.data[i].awardinstanceleveid) {       
                        sum++;
                        numoftotal++;
                        group1[i].push(html('<div class="col-lg-3">' +
                            '<div class="form-group">' +
                            '<label>姓名</label>' +
                            '<a class="form-control"  href="' + $.parseurl("QxJzxt/CRUD/UptoSchoolListExamineDetail?id=" + node.applyid, "f").destUrl + '"  target="_blank">' + node.nick_name + '</a>' +
                            '<p class="help-block warning-block">' +
                            '<span id="name_"' + i + k + '>&nbsp;</span>' +
                            '</p>' +
                            '</div> ' +
                            '</div>'));
                        cfg.push(hide('applyid_' + flag, node.applyid));
                        flag++;
                    }
                }
            }
            var total = 0;//先这么写着
            if (model.item[i][0]!=null) {
                total = model.item[i][0].count;
            }
            tabContent.push({ title: model.data[i].instancename + '(可报：' +  total+ '/已报：' + numoftotal + ')', content: group1[i] });
        }
        cfg.push(hide('sum', sum));

          for (var t = 0; t < model.item.length; t++) {
            county = county + model.item[t].length;
          }
        if (county == 0) {
        } else {
            if (node.statusid == 2) {
              cfg.push(group([tab(tabContent, 1)], "上报状态:(未上报)"));
                cfg.push(button("上报学校", '1:5', Color.green, function () {
                   // $.alert("请确保所有学生都已添加到名单");  
                    submitForm("/QxJzxt/CRUD/UptoSchoolAwardTable");
                }));
            } else {
                cfg.push(group([tab(tabContent, 1)], "上报状态:(已上报)"));
            }
        }
      
        return cfg;
    }
   ,
"",
"/QxJzxt/CRUD/AwardUptoSchoolTable1",
"上报名单人员列表");
///QxJzxt/CRUD/UptoSchoolAwardTable
//SchoolExamineFromGroup
render(
    function () {
        var cfg = [];
        var group1 = [];
        var sum = 0;
        cfg.push(hide('id', q.id));
        for (var i = 0; i <model.item.length; i++) {
            var node =model.item[i];
                        group1.push(html('<div class="col-lg-3">' +
                            '<div class="form-group">' +
                            '<label>姓名</label>' +
                            '<a class="form-control"  href="' + $.parseurl("QxJzxt/CRUD/UptoSchoolListExamineDetail?id=" + model.item[i].applyid, "f").destUrl + '"  target="_blank">' + model.item[i].nick_name + '</a>' +
                            '<p class="help-block warning-block">' +
                            '<span id="name_"' + i + '>&nbsp;</span>' +
                            '</p>' +
                            '</div> ' +
                            '</div>'));
                        cfg.push(hide('applyid_' + i, node.applyid));
                      sum++;
            //tabContent.push({ title: model.data[i].instancename + '(可报：' + total + '/已报：' + numoftotal + ')', content: group1[i] });
        }
        cfg.push(hide('sum' ,sum));
        if (node.status_id == 4) {
            cfg.push(group(group1, "审核状态:(未审核)", 1));
                cfg.push(button("通过", '1:5', Color.green, function () {
                    submitForm("/QxJzxt/CRUD/SchoolExamUptoTable");
                }));
                cfg.push(button("驳回", '6:0', Color.green, function () {
                    submitForm("/QxJzxt/CRUD/FishExamUptoTable");
                }));
            } else {
                cfg.push(group(group1,"审核状态:(已审核)",1));
            }
        
        return cfg;
    }
   ,
"",
"/QxJzxt/CRUD/SchoolExamineFromGroup",
"学院上报请款");

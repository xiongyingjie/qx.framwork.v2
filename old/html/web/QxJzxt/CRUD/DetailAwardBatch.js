render(
    function () {
        var cfg = [];
        var groupContent = [];
        groupContent.push(hide('awardid'));
        groupContent.push( showinput('奖项名称', 'awardname', '', '3'));
        groupContent.push(select("奖项类型", "awardtypeid", "/QxJzxt/CRUD/AwardTypeSelect", "", 3));
        groupContent.push(showinput('奖项级数', 'levelnum', '', '3'));
        groupContent.push( //下载文件
           html('<div class="col-lg-4">'+
            '<div class="form-group">'+
              '<label>评奖文件</label>'+
			 "<a style='display:block;color:blue'  class='form-control'   href='"+$.url(model.awardfile)+"'>"+$.getFileName(model.awardfile)+"</a>"+
                '<p class="help-block warning-block">'+
                  '<span id="awardfile">&nbsp;</span>'+
               '</p>'+
          '</div>'+ 
    '</div>')
);
        groupContent.push(showinput("开始时间", "starttime", "", 3));
        groupContent.push(showinput("结束时间", "endtime", "", 3));
        groupContent.push( area('奖项描述', 'description'));
        cfg.push(group(groupContent, "奖项详情", 1));
        return cfg;
    }
   ,
"",
"/QxJzxt/CRUD/FindAwardBatch2",
"*");

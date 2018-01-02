
render(function () {
 return    [
group([
showinput("课程", "course_name"),
showinput("实验名称", "experiment_name"),
showinput("年级", "school_year"),
//showinput("学期", "term"),
showinput("班级", "class_name"),
 //下载文件
           html('<div class="col-lg-3">' +
            '<div class="form-group">' +
              '<label>下载大纲文件</label>' +
             // '<input type="text" readonly="readonly" class="form-control" name="syll_author" id="syll_author" value="">'+
    		 "<a style='display:block;color:blue'  class='form-control'   href='" + $.url(model.exp_guide_book) + "'>" + $.getFileName(model.exp_guide_book) + "</a>" +
                '<p class="help-block warning-block">' +
                  '<span id="msg-syll_author">&nbsp;</span>' +
               '</p>' +
          '</div>' +
    '</div>'),
area("说明", "exp_summery", "", 1),

hide("course_id", "q.id")
], "查看实验要求", 1)
    ]
}, "", "/IEET/Experiment/EpxerimentListcheck_stu","查看实验要求");
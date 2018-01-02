NS.Register("qx.form");
qx.form = new QxForm();
function QxForm() {

    var canSubmitTpl = function () {
        return $.qx_tpl({}, function () {/*
 
       <div class="col-lg-12">
                    <div class="col-lg-6">
                        <button class="col-lg-offset-10 btn btn-primary" id="bt_submit" type="submit">提交</button>
                    </div>
                    <div class="col-lg-6">
                        <button class="col-offset-6 btn btn-deafult" onclick="subClose()" id="bt_close" type="button">关闭</button>
                    </div>
                </div><hr/>

 */});
    }

    var InputTpl = function (label, name, value, num, reg) {
        var number = 12 / check(num, 4);
        value = check(value, "");
        label = (reg == undefined ? "" : "*") + label;
        var tip = label.replace("*", "");
        //debugger 
        return $.qx_tpl({ reg: reg, label: ($.hasValue(label) ? " <label>" + label + "</label>" : ""), name: name, value: value, number: number, tip: ($.hasValue(tip) ? tip : "id") }, function () {/*

    <div class="col-lg-{number}">
        <div class="form-group">
           {label}
            <input class="form-control"   id="{name}" name="{name}" placeholder="请输入{tip}" type="text" value="{value}">
        </div> 
    </div>
  
 */});
    }

    var ShowInputTpl = function (label, name, value, num) {
        var number = 12 / check(num);
        value = check(value, "");
        return $.qx_tpl({ name: name, label: label, value: value, number: number }, function () {/*

    <div class="col-lg-{number}">
        <div class="form-group">
            <label>{label}</label>
            <input type="text" disabled style="background-color:#FFFFFF" class="form-control" name="{name}" id="{name}" value="{value}" />
         
        </div> 
    </div>
 */});
    }

    var TimeTpl = function (label, name, value, num, tip) {
        var number = 12 / check(num);
        value = check(value, getNowFormatTime());
        tip = check(tip, "");

        return $.qx_tpl({ label: label, name: name, value: value, number: number, tip: tip }, function () {/*

    <div class="col-lg-{number}">
         <div class="form-group">
             <label>{label}</label>
             <div class="input-group date form_datetime">
                <input type="text" style="background-color:#FFFFFF" id="{name}" name="{name}"  placeholder="请设置{label}"  value="{value}" readonly="" class="form-control">
                <span class="input-group-btn">
                    <button class="btn btn-success date-set" type="button">
                       <i class="fa fa-calendar"></i>
                    </button>
                </span>
            </div>
          
          
         </div> 
     </div>

 */});
    }

    var ShowTimeTpl = function (label, name, value, num) {
        var number = 12 / check(num);
        value = check(value, "");

        return $.qx_tpl({ label: label, name: name, value: value, number: number }, function () {/*

    <div class="col-lg-{number}">
         <div class="form-group">
             <label>{label}</label>
             <div class="input-group date form_datetime">
                <input type="text" disabled style="background-color:#FFFFFF" id="{name}" name="{name}"  placeholder="请设置{label}"  value="{value}" readonly="" class="form-control">
                <span class="input-group-btn">
                    <button disabled class="btn btn-success date-set" type="button">
                       <i class="fa fa-calendar"></i>
                    </button>
                </span>
            </div>
          
       
         </div> 
     </div>

 */});
    }

    var DateTpl = function (label, name, value, num, tip) {
        var number = 12 / check(num);
        value = check(value, getNowFormatTime("onlyDate"));
        tip = check(tip, "");

        return $.qx_tpl({ label: label, name: name, value: value, number: number, tip: tip }, function () {/*

    <div class="col-lg-{number}">
         <div class="form-group">
             <label>{label}</label>
             <div class="input-group date form_date">
                <input type="text"style="background-color:#FFFFFF" id="{name}" name="{name}" value="{value}" readonly="" class="form-control">
                <span class="input-group-btn">
                    <button class="btn btn-success date-set" type="button">
                       <i class="fa fa-calendar"></i>
                    </button>
                </span>
            </div>
         </div> 
     </div>

 */});
    }

    var ShowDateTpl = function (label, name, value, num) {
        var number = 12 / check(num);
        value = check(value, "");

        return $.qx_tpl({ label: label, name: name, value: value, number: number }, function () {/*

    <div class="col-lg-{number}">
         <div class="form-group">
             <label>{label}</label>
             <div class="input-group date form_date">
                <input  disabled type="text"style="background-color:#FFFFFF" id="{name}" name="{name}" value="{value}" readonly="" class="form-control">
                <span class="input-group-btn">
                    <button  disabled class="btn btn-success date-set" type="button">
                       <i class="fa fa-calendar"></i>
                    </button>
                </span>
            </div>
         </div> 
     </div>

 */});
    }

    var SelectTpl = function (label, name, option, value, num, readonly) {

        value = check(value, "");
        option = check(option, "");
        readonly = check(readonly, false);
        var number = 12 / check(num);
        var optionHtml = "";
        var optionScript = "";
        if ($.isArray(option)) {
            
            for (var i = 0; i < option.length; i++) {
                optionHtml += '<option ' + ((option[i].value == value) ? "selected='selected'" : "") + '  value="' + option[i].value + '">' + option[i].text + '</option>';
            }
        } else {
            if (option.indexOf("{") > 0) {
                $.alert("select函数已升级，option参数应该为Array或Url,请修改原有函数!");
            }
            optionScript = "<script>head.ready(function(){$.fillSelect('" + name + "','" + option + "','" + value + "',false)})</script>";
        }



        return $.qx_tpl({ label: label, name: name, value: value, number: number, readonly: readonly ? "disabled" : "", option: optionHtml, optionScript: optionScript }, function () {/*

   <div class="col-lg-{number}">
      <div class="form-group">
         <label>{label}</label>
         <select class="form-control" {readonly} id="{name}" name="{name}">
              <option selected="selected" value=";">请选择{label}</option>
              {option}
         </select>
      
       </div> 
   </div>
   {optionScript}  
 */});
    }

    var ShowSelectTpl = function (label, name, option, value, num) {
        return SelectTpl(label, name, option, value, num, true);
    }

    var array_contain = function (array, obj) {
        for (var i = 0; i < array.length; i++) {
            if (array[i] == obj)//如果要求数据类型也一致,这里可使用恒等号===
                return true;
        }
        return false;
    }

    var RadioTpl = function (label, name, items, num, vertical, value) {
        value = check(value, "");
        vertical = check(vertical, true);
        if (vertical) {
            vertical = "float:left;";
        }
        var number = 12 / check(num);
        var itemHtml = "";
        for (var i = 0; i < items.length; i++) {
            itemHtml += ('<div class=""   style="' + vertical + 'margin-right:10px;padding:2px 0;"><input  type="radio" '
                + ((value == items[i].value) ? 'checked=""' : '') + ' value="' + items[i].value + '" name="'
                + name + '"><span>' + items[i].text + '</span></div>');
        }

        return $.qx_tpl({ label: label, number: number, itemHtml: itemHtml }, function () {/*
      
       <div class="col-lg-{number}" style="overflow:hidden;">
        <div class="form-group">
            <label>{label}</label><br />
            {itemHtml}
        </div> 
    </div>       
  
 */});
    }

    var ShowRadioTpl = function (label, name, items, num, vertical, value) {
        value = check(value, "");
        vertical = check(vertical, true);
        if (vertical) {
            vertical = "float:left;";
        }
        var number = 12 / check(num);
        var itemHtml = "";
        for (var i = 0; i < items.length; i++) {
            itemHtml += ('<div class=""   style="' + vertical + 'margin-right:10px;padding:2px 0;"><input disabled type="radio" '
                + ((value == items[i].value) ? 'checked=""' : '') + ' value="' + items[i].value + '" name="'
                + name + '"><span>' + items[i].text + '</span></div>');
        }

        return $.qx_tpl({ label: label, number: number, itemHtml: itemHtml }, function () {/*
      
       <div class="col-lg-{number}" style="overflow:hidden;">
        <div class="form-group">
            <label>{label}</label><br />
            {itemHtml}
        </div> 
    </div>       
  
 */});
    }

    var CheckBoxTpl = function (label, name, items, num, vertical, valueArray) {

        if (valueArray == undefined) {
            valueArray = [];
        }
        if (vertical) {
            vertical = "float:left;";
        }
        var number = 12 / check(num);
        var itemHtml = "";
        for (var i = 0; i < items.length; i++) {
            itemHtml += ('<div class=""   style="' + vertical + 'margin-right:10px;padding:2px 0;"><input  type="checkbox" '
                + (array_contain(valueArray, (items[i].value)) ? 'checked=""' : '') + ' value="' + items[i].value + '" name="'
                + name + '"><span>' + items[i].text + '</span></div>');
        }

        return $.qx_tpl({ label: label, number: number, itemHtml: itemHtml }, function () {/*
      
       <div class="col-lg-{number}" style="overflow:hidden;">
        <div class="form-group">
            <label>{label}</label><br />
            {itemHtml}
        </div> 
    </div>       
  
 */});
    }

    var ShowCheckBoxTpl = function (label, name, items, num, vertical, valueArray) {

        if (valueArray == undefined) {
            valueArray = [];
        }
        if (vertical) {
            vertical = "float:left;";
        }
        var number = 12 / check(num);
        var itemHtml = "";
        for (var i = 0; i < items.length; i++) {
            itemHtml += ('<div class=""   style="' + vertical + 'margin-right:10px;padding:2px 0;"><input  disabled type="checkbox" '
                + (array_contain(valueArray, (items[i].value)) ? 'checked=""' : '') + ' value="' + items[i].value + '" name="'
                + name + '"><span>' + items[i].text + '</span></div>');
        }

        return $.qx_tpl({ label: label, number: number, itemHtml: itemHtml }, function () {/*
      
       <div class="col-lg-{number}" style="overflow:hidden;">
        <div class="form-group">
            <label>{label}</label><br />
            {itemHtml}
        </div> 
    </div>       
  
 */});
    }

    var SwitchTpl = function (label, name, num, value, onText, offText) {

        var number = 12 / check(num);
        if (!$.hasValue(value)) {
            value = 1;
        }
        if (!$.hasValue(onText)) {
            onText = '开';
        }
        if (!$.hasValue(offText)) {
            offText = '关';
        }

        return $.qx_tpl({ name: name, label: label, number: number, value: value, onText: onText, offText: offText }, function () {/*
           
        <div class="col-lg-{number}">
            <div class="form-group">
                <label>{label}</label><br />
                <input id="{name}"  type="checkbox"/>
            </div> 
        </div>       

           <script>
                head.ready(function() {
                var obj=$('#{name}');

                obj.wrap('<div class="make-switch" />').parent().bootstrapSwitch();
                obj.bootstrapSwitch('setOnLabel', '{onText}');
                obj.bootstrapSwitch('setOffLabel', '{offText}');
                obj.bootstrapSwitch('setState', {value} === 1); // true || false
                obj.on('switch-change', function (e, data) {
                        var $el = $(data.el), value = data.value;
                        if (!value) {
                           obj.val('0');
                        } else {
                           obj.val('1');
                        }
                    });
                })
            </script>
            
  
 */});
    }

    var ShowSwitchTpl = function (label, name, num, value, onText, offText) {

        var number = 12 / check(num);
        if (!$.hasValue(value)) {
            value = 1;
        }
        if (!$.hasValue(onText)) {
            onText = '开';
        }
        if (!$.hasValue(offText)) {
            offText = '关';
        }

        return $.qx_tpl({ name: name, label: label, number: number, value: value, onText: onText, offText: offText }, function () {/*
           
        <div class="col-lg-{number}">
            <div class="form-group">
                <label>{label}</label><br />
                <input id="{name}" disabled type="checkbox"/>
            </div> 
        </div>       

           <script>
                head.ready(function() {
                var obj=$('#{name}');

                obj.wrap('<div class="make-switch" />').parent().bootstrapSwitch();
                obj.bootstrapSwitch('setOnLabel', '{onText}');
                obj.bootstrapSwitch('setOffLabel', '{offText}');
                obj.bootstrapSwitch('setState', {value} === 1); // true || false
                obj.on('switch-change', function (e, data) {
                        var $el = $(data.el), value = data.value;
                        if (!value) {
                           obj.val('0');
                        } else {
                           obj.val('1');
                        }
                    });
                })
            </script>
            
  
 */});
    }

    var AreaTpl = function (label, name, value, num, tip, height) {
        tip = check(tip, "");
        value = check(value, "");
        height = check(height, 200);
        var number = 12 / check(num, 1);
        return $.qx_tpl({ height: height, label: label, name: name, value: value, number: number, tip: tip }, function () {/*

    <div class="col-lg-{number}">
        <div class="form-group">
            <label>{label}</label>
            <textarea  style="height:{height}px" class="form-control" id="{name}" name="{name}" >{value}</textarea>
            
        </div> 
    </div>
   


 */});
    }

    var ShowAreaTpl = function (label, name, value, num, height) {

        value = check(value, "");
        height = check(height, 200);
        var number = 12 / check(num, 1);
        return $.qx_tpl({ height: height, label: label, name: name, value: value, number: number }, function () {/*

    <div class="col-lg-{number}">
        <div class="form-group">
            <label>{label}</label>
            <textarea disabled style="background-color:#FFFFFF;height:{height}px" readonly="readonly" class="form-control" id="{name}" name="{name}" >{value}</textarea>
            
        </div> 
    </div>
   


 */});
    }

    var ShowRichBoxTpl = function (label, name, value, num, tip) {
        tip = check(tip, "");
        var number = 12 / check(num, 1);
        return $.qx_tpl({ label: label, name: name, value: value, number: number, tip: tip }, function () {/*

   <div class="col-lg-{number}">
      <div class="form-group">
         <label>{label}</label>
         <div class="form-control" rows="3" name="{name}" style="height:auto">
            <div id="{name}" class="q_content">
                <p>
                   {value}
                </p>
            </div> 
         </div>
      </div>
    </div>


 */});
    }

    var RichBoxTpl = function (label, name, value, num, height) {
        value = check(value, "");
        //$.log(value);
        height = check(height, 300);
        var number = 12 / check(num, 1);
        return $.qx_tpl({ label: label, name: name, value: value, number: number, height: height }, function () {/*

  <div class='col-lg-{number}'>
       <div class='form-group'>
        <label>{label}</label>
         <script id="{name}" type="text/plain" style="width:100%;height:{height}px;">{value}</script>
    
       </div>
       <script>   
        head.ready(["umeditor-config","umeditor","umeditor-zh"],function() {
             var ue = UM.getEditor('{name}');         
                ue.ready(function () {
            
                var old= ue.getContent();
                if(!$.hasValue(old))
                {
                 value = ue.setContent('{value}');
                }          
               });
        })
       </script>
 </div>

 */});
    }

    var ImageTpl = function (type, value, num, tip) {
        tip = check(tip, "");
        var number = 12 / check(num, 3);
        return $.qx_tpl({ type: type, value: value, number: number, tip: tip }, function () {/*

  <div class="col-lg-{number}">
           <img src="{value}" class="img-{type}">    
  </div>

 */});
    }

    var ButtonTpl = function (id, label, num, color, onclick) {
        //debugger
        color = check(color, Color.red);
        if (!$.hasValue(onclick)) {
            onclick = function () { };
        }

        var offset = 0;
        var number = 1;
        //debugger
        if (("" + num).indexOf(':') > -1) {
            var temp = num.split(':');

            number = temp[0];
            offset = temp[1];
        } else {
            number = num;
            number = 12 / number;
        }
        return $.qx_tpl({ id: id, label: label, number: number, offset: offset, color: color, onclick: (onclick !== undefined) ? onclick.toString() : "" }, function () {/*

     <div class="col-lg-{number} col-lg-offset-{offset}">
            <button type="button" class="btn btn-{color}" id="{id}">{label}</button>
     </div>
     <script type="text/javascript">
      var bObj=document.getElementById("{id}");
      bObj.onclick={onclick};
     </script>

 */});
    }

    var TabTpl = function (tabId, cfg, num) {
        var subTitle = "";
        var subContent = "";
        for (var i = 0; i < cfg.length; i++) {
            var id = $.random();
            subTitle += '<li class="' + (i === 0 ? 'active' : '') + '"><a href="#' + id + '" data-toggle="tab" aria-expanded="false">' + cfg[i].title + '</a></li>';
            subContent += ' <div class="tab-pane fade ' + (i === 0 ? 'active in' : '') + '" id="' + id + '">' + _render(cfg[i].content) + '</div>';
        }

        var number = 12 / check(num, 1);
        return $.qx_tpl({ id: tabId, subTitle: subTitle, subContent: subContent, number: number }, function () {/*
 
             <div id="{id}" class="col-lg-{number}">
                   <ul class="nav nav-tabs">
                        {subTitle}
                    </ul>
                    <div class="tab-content">
                        
                             {subContent}
                    </div>
             </div>

 */});
    }

    var GroupTpl = function (id, html, title, num) {
        var formContent = "";
        formContent += _render(html);
        var number = 12 / check(num, 1);

        return $.qx_tpl({ id: id, title: title, formContent: formContent, number: number }, function () {/*
 
             <div id="{id}" class="col-lg-{number}">
                   <div class="row">  
                        <div class="list-group">
                               <a href="#" class="list-group-item active">
                                  <h4 class="list-group-item-heading">
                                    {title}
                                   </h4>
                               </a>
                              <div class="list-group-item list-group-item-heading">
                                  <div class="row">  
                                       {formContent}
                                  </div>
                              </div>
                          </div>
                    </div>  
             </div>

 */});
    }

    var PreTpl = function PreTpl(id, code, num) {
        var number = 12 / check(num, 1);
        return $.qx_tpl({ id: id, code: code, number: number }, function () {/*
 
         <div id="{id}" class="col-lg-{number}">
              <div class="form-group">
                 <label>代码</label>
                 <pre>{code}</pre>
              </div>
         </div>

 */});
    }

    var DropDownTpl = function (id, label, li, num, color) {
        var number = 12 / check(num, 6);
        color = check(color, Color.blue);
        var liHtml = new Array();

        for (var i = 0; i < li.length; i++) {
            liHtml.push('<li role="presentation"><a role="menuitem" data-baseurl="' +
                li[i].value + '" id="' +
                li[i].id + '" data-url="' +
                li[i].value + '" class="qx-menu" data-title="' +
                li[i].text + '">' + li[i].text + '</a></li>');
        }

        //$.log(liHtml)
        return $.qx_tpl({ id: id, label: label, liHtml: liHtml.join(''), color: color, number: number }, function () {/*

    <div  id="{id}" class="col-lg-{number}">
       <div class="btn-group">
	    <button type="button" class="btn btn-{color} dropdown-toggle" 
			    data-toggle="dropdown">
		    {label} <span class="caret"></span>
	    </button>
	    <ul class="dropdown-menu" role="menu">
		    {liHtml}
	    </ul>
       </div>
    </div>

       <script>
            InitMenuEvent('#{id} .qx-menu')
       </script>

 */});
    }

    var PanelTpl = function (id, title, body, footer, color, num) {
        color = check(color, Color.red);
        footer = check(footer, "");
        var number = 12 / check(num, 1);
        //debugger 
        return $.qx_tpl({ id: id, title: title, body: _render(body), footer: footer, color: color, number: number }, function () {/*
 
            
    <div  id="{id}" class="col-lg-{number}">
         <div class="panel panel-{color}">
            <div class="panel-heading">
                <h3 class="panel-title">
                    {title}
                </h3>
            </div>
            <div class="panel-body">
                {body}
            </div>
            <div class="panel-footer">
                {footer}
            </div>
        </div>
    </div>

 */});
    }

    var ListGroupTpl = function (id, title, libody, num) {
        var number = 12 / check(num);
        var liHtml = new Array();
        for (var i = 0; i < libody.length; i++) {
            liHtml.push('<a href="#" class="list-group-item"><h4 class="list-group-item-heading">' + libody[i].title +
                '</h4><p class="list-group-item-text">' + libody[i].body + '</p></a>');
        }
        return $.qx_tpl({ id: id, title: title, liHtml: liHtml.join(""), number: number }, function () {/*
 
            
    <div id="{id}" class="col-lg-{number}">
         <div class="list-group">
            <a href="#" class="list-group-item active">
                <h4 class="list-group-item-heading">
                    {title}
                </h4>
            </a>
            {liHtml}
        </div>
    </div>

 */});
    }

    var MediaTpl = function (id, imgurl, header, text, num) {
        var number = 12 / check(num);
        return $.qx_tpl({ id: id, imgurl: imgurl, header: header, text: text, number: number }, function () {/*
 
            
    <div id="{id}" class="col-lg-{number}">
         <div class="media">
            <a class="media-left" href="#">
                <img class="media-object" src="{imgurl}"
                     alt="媒体对象">
            </a>
            <div class="media-body">
                <h4 class="media-heading">{header}</h4>
                {text}
            </div>
        </div>
    </div>

 */});
    }

    var AlertTpl = function (id, text, num, color) {
        var number = 12 / check(num, 1);
        return $.qx_tpl({ id: id, text: text, number: number, color: color }, function () {/*
 
            
    <div id="{id}" class="col-lg-{number}">
         <div class="alert alert-{color} alert-dismissable">
	        <button type="button" class="close" data-dismiss="alert"
			        aria-hidden="true">
		        &times;
	        </button>
	        {text}
        </div>
    </div>

 */});
    }

    var ThumbNailTpl = function (id, imgurl, body, num) {
        var number = 12 / check(num);
        return $.qx_tpl({ id: id, imgurl: imgurl, body: body, number: number }, function () {/*
 
            
    <div id="{id}" class="col-lg-{number}">
         <div class="thumbnail">
            <img src="{imgurl}"
             alt="通用的占位符缩略图"/>
            <div class="caption">
                {body}
            </div>
         </div>
    </div>

 */});
    }

    var PageHeaderTpl = function (id, title, subtitle, num) {
        var number = 12 / check(num);
        return $.qx_tpl({ id: id, title: title, subtitle: subtitle, number: number }, function () {/*
 
            
    <div id="{id}" class="col-lg-{number}">
         <div class="page-header">
            <h1>{title}
                <small>{subtitle}</small>
            </h1>
        </div>
    </div>

 */});
    }

    var CarouselTpl = function (id, imageUrl, num) {
        //console.log(imageUrl);
        var number = 12 / check(num, 1);
        var liHtml = new Array();
        var imgHtml = new Array();
        for (var i = 0; i < imageUrl.length; i++) {
            liHtml.push('<li data-target="#myCarousel" data-slide-to="' + i + '" class="' + (i === 0 ? "active" : "") + '"></li>');
            imgHtml.push('<div class="item ' + (i === 0 ? "active" : "") + '"><img src="' + imageUrl[i].imgurl + '"><div class="carousel-caption">标题' + (i) + ' </div></div>  ');
        }

        return $.qx_tpl({ id: id, liHtml: liHtml.join(""), imgHtml: imgHtml.join(""), number: number }, function () {/*
 
            
    <div id="{id}"  class="col-lg-{number}">
        <div id="myCarousel" class="carousel slide">
            <!-- 轮播（Carousel）指标 -->
            <ol class="carousel-indicators">
               {liHtml}
            </ol>
            <!-- 轮播（Carousel）项目 -->
            <div class="carousel-inner">
                {imgHtml}
            </div>
            <!-- 轮播（Carousel）导航 -->
            <a class="carousel-control left" href="#myCarousel"
               data-slide="prev">
                &lsaquo;
            </a>
            <a class="carousel-control right" href="#myCarousel"
               data-slide="next">
                &rsaquo;
            </a>
        </div>
    </div>

 */});
    }
    var FileUploadTpl3rd = function (label, name, num, folder, url) {
        folder = check(folder, "/userfiles/uploads/files/");
        url = check(url, "http://upload.qiniu.com/");
        var number = 12 / check(num, 2);
        return $.qx_tpl({ label: label, name: name, url: url, folder: folder, number: number }, function () {/*
       <input type="hidden" name="{name}" id="{name}">
      <div class="col-lg-{number}" style="">
        <div class="form-group">
            <label>{label}</label>
            
        <div class="hide" id="closeBox-{name}">
            <div class="row fileupload-buttonbar">
                <div class="col-lg-12">
            
                    <button type="button" class="btn btn-info" id="showButton-{name}">
                        <i class="glyphicon glyphicon-chevron-down"></i>
                        <span>展开{label}</span>
                    </button>
                </div>
                <!-- The global progress state -->
            </div>
        </div>

        <div class="" id="mainBox-{name}">
            <form id="fileupload-{name}" action="http://upload.qiniu.com/" method="post" enctype="multipart/form-data">
              <input name="key" type="hidden" value="<resource_key>">
              <input name="x:<custom_name>" type="hidden" value="<custom_value>">
              <input name="token" type="hidden" value="<upload_token>">
              <input name="crc32" type="hidden" />
              <input name="accept" type="hidden" />
             

               <input type="hidden" name="folder"  value="{folder}">
               <input type="hidden" name="controlName" value="{name}">

                <div class="row fileupload-buttonbar">
                    <div class="col-lg-12">
                 
                        <span class="btn btn-success fileinput-button">
                            <i class="glyphicon glyphicon-plus"></i>
                            <span>添加{label}</span>
                             <input name="file" type="file" />
                        </span>
                        <button type="submit" class="btn btn-primary start hide" id="startButton-{name}">
                            <i class="glyphicon glyphicon-upload"></i>
                            <span>开始上传</span>
                        </button>
                        <button type="button" class="btn btn-info hide" id="tagButton-{name}">
                            <i class="glyphicon glyphicon-chevron-up"></i>
                            <span>全部折叠</span>
                        </button>
                        <input type="checkbox" class="toggle hide" id="checkboxButton-{name}">
                        <!-- The global file processing state -->
                        <span class="fileupload-process"></span>
                    </div>
              
                   
                </div>
              
                <table role="presentation" class="table table-striped"><tbody class="files"></tbody></table>
            </form>


        </div>
      
        <div id="blueimp-gallery" class="blueimp-gallery blueimp-gallery-controls" data-filter=":even">
            <div class="slides"></div>
            <h3 class="title"></h3>
            <a class="prev">‹</a>
            <a class="next">›</a>
            <a class="close">×</a>
            <a class="play-pause"></a>
            <ol class="indicator"></ol>
        </div>
   

        </div> 
    </div>    
    <script>
         //初始化
         initFile('{name}','{url}','{folder}');
    </script>

 */});
    }
    var FileUploadTpl = function (label, name, num, folder, url) {
        folder = check(folder, "/userfiles/uploads/files/");
        url = check(url, "/open/upload");
        var number = 12 / check(num, 2);
        return $.qx_tpl({ label: label, name: name, url: url, folder: folder, number: number }, function () {/*
       <input type="hidden" name="{name}" id="{name}">
      <div class="col-lg-{number}" style="">
        <div class="form-group">
            <label>{label}</label>
            
        <div class="hide" id="closeBox-{name}">
            <div class="row fileupload-buttonbar">
                <div class="col-lg-12">
            
                    <button type="button" class="btn btn-info" id="showButton-{name}">
                        <i class="glyphicon glyphicon-chevron-down"></i>
                        <span>展开{label}</span>
                    </button>
                </div>
                <!-- The global progress state -->
            </div>
        </div>

        <div class="" id="mainBox-{name}">
            <form id="fileupload-{name}" action="" method="POST" enctype="multipart/form-data">
               <input type="hidden" name="folder"  value="{folder}">
             <input type="hidden" name="controlName" value="{name}">
                <div class="row fileupload-buttonbar">
                    <div class="col-lg-12">
                 
                        <span class="btn btn-success fileinput-button">
                            <i class="glyphicon glyphicon-plus"></i>
                            <span>添加{label}</span>
                            <input type="file" name="files[]" multiple>
                        </span>
                        <button type="submit" class="btn btn-primary start hide" id="startButton-{name}">
                            <i class="glyphicon glyphicon-upload"></i>
                            <span>开始上传</span>
                        </button>
                        <button type="button" class="btn btn-info hide" id="tagButton-{name}">
                            <i class="glyphicon glyphicon-chevron-up"></i>
                            <span>全部折叠</span>
                        </button>
                        <input type="checkbox" class="toggle hide" id="checkboxButton-{name}">
                        <!-- The global file processing state -->
                        <span class="fileupload-process"></span>
                    </div>
              
                   
                </div>
              
                <table role="presentation" class="table table-striped"><tbody class="files"></tbody></table>
            </form>


        </div>
      
        <div id="blueimp-gallery" class="blueimp-gallery blueimp-gallery-controls" data-filter=":even">
            <div class="slides"></div>
            <h3 class="title"></h3>
            <a class="prev">‹</a>
            <a class="next">›</a>
            <a class="close">×</a>
            <a class="play-pause"></a>
            <ol class="indicator"></ol>
        </div>
   

        </div> 
    </div>    
    <script>
         //初始化
         initFile('{name}','{url}','{folder}');
    </script>

 */});
    }

    var FileItemTpl = function (item, name, canDelete) {
        item.remove = true;
        //$.warn(item);
        var savedUrl = item.url; var id = $.random();
        item.url = $.url((item.url.indexOf("-split-") > -1) ? encodeURI(item.url) : "");
        item.name = $.hasValue(item.name) ? item.name : $.getFileName(item.url);
        return ' <tr id="' + id + '" class="template-download fade in">' +
                '<td><input type="checkbox" name="delete" value="1" class="toggle"><span class="preview"> </span></td>' +//复选框
                '<td><p class="name"><a target="_blank" href="' + item.url + '" download="' + item.name + '">' + item.name + '</a></p></td>' +//文件名
                '<td><span class="size">' + ($.hasValue(item.size) ? item.size : "") + '</span></td>' +//文件大小
                '<td><a href="' + item.url + '" download="' + item.name + '" class="btn btn-primary"><i class="glyphicon glyphicon-download-alt"></i><span>下载</span></a>&nbsp;' +//下载按钮
                (canDelete ? '<a onclick=\'deleteFile("/open/Delete?savedPath=' + savedUrl + '","' + id + '","' + name + '", "' + savedUrl + '")\' class="btn btn-danger"><i class="fa fa-remove"></i><span>删除</span></a>' : '') +//删除按钮
                '</td></tr>';//deleteFile(fileUrl, selector, controlName, savedPath)
    }

    var FileItemsTpl = function (files, name, canDelete) {
        //debugger 
        if (!$.hasValue(files)) {
            files = [];
        }
        if (!$.isArray(files)) {
            var temp = [];	//自动转换字符串为数组
            var fileArray = files.split(';');
            for (var i = 0; i < fileArray.length; i++) {
                if ($.hasValue(fileArray[i])) {
                    temp.push({ url: fileArray[i], name: $.getFileName(fileArray[i]) });
                }
            }
            files = temp;
        }
        var bodyHtml = "";
        for (var i = 0; i < files.length; i++) {
            bodyHtml += FileItemTpl(files[i], name, canDelete);
        }
        return bodyHtml;
    }

    var ShowFileTpl = function (id, label, files, num) {
        var oldValue = files;
        //没有文件直接终止
        //if (($.isArray(files)&&files.length == 0)||!$.hasValue(files)) {
        //	return "";
        //}
        //读取旧值
        if ($.isArray(files)) {
            oldValue = files.join(';');
        }
        //debugger
        var number = 12 / check(num, 2); $.log(files);
        return $.qx_tpl({ id: id, label: label, bodyHtml: FileItemsTpl(files, id), number: number, oldValue: oldValue }, function () {/*
 
 <div class="col-lg-{number}">
    <div class="form-group">
    <input  value="{oldValue}"  id="{id}" name="{id}" type="hidden"  >
        <label>{label}</label>
        <div class="hide" id="closeBox-busyness-{id}">
            <div class="row fileupload-buttonbar">
                <div class="col-lg-12">
                    <button type="button" class="btn btn-info" id="showButton-busyness">
                        <i class="glyphicon glyphicon-chevron-down"></i>
                        <span>展开{label}</span>
                    </button>
                </div>
            </div>
        </div>
        <div  id="mainBox-busyness-{id}">       
           
                <table role="presentation" class="table table-striped" id="fileupload-{id}">
                    <tbody class="files" >
                   {bodyHtml}
                    </tbody>
                </table>
        </div>
     </div>
    </div>
 */});
    }

    var HideTpl = function (name, value) {

        value = check(value, "");

        return $.qx_tpl({ name: name, value: value }, function () {/*

          <input class="form-control" value="{value}"  id="{name}" name="{name}" type="hidden"  >

 */});
    }

    var TableTpl = function (header, body, num, id) {
        //debugger 
        id = check(id, $.random());
        var number = 12 / check(num, 1);
        var tableScript = "";

        var bodyHtml = "";
        var headerHtml = "";
        if ($.hasValue(body) && $.isString(body) && !$.hasValue(header)) {
            //传入的是url
            tableScript = "<script>head.ready(function(){$.fillTable('" + id + "','" + body + "')})</script>";
        } else {
            header = check(header, []);


            if ($.hasValue(body) && !$.isArray(body)) {
                body = [body];
            }
            bodyHtml = "<tbody>";
            for (var j = 0; j < body.length; j++) {
                bodyHtml += '<tr>';
                if (!$.isArray(body[j])) {//兼容非数组的对象
                    var _arr = $.toArray(body[j]);
                    body[j] = _arr.v;//对象转数组
                    if (header.length === 0) {
                        header = _arr.p;//自动给标题赋值
                    }
                }
                for (var k = 0; k < body[j].length; k++) {
                    bodyHtml += '<td>' + body[j][k] + '</td>';
                }
                bodyHtml += '</tr>';
            }
            bodyHtml += "</tbody>";

            headerHtml = "<thead> <tr>";
            if (header.length === 0 && body.length === 0) {
                header.push("无数据");
            }
            for (var i = 0; i < header.length; i++) {
                headerHtml += '<th>' + header[i] + '</th>';
            }
            headerHtml += "</tr></thead>";
        }


        return $.qx_tpl({ id: id, bodyHtml: bodyHtml, headerHtml: headerHtml, number: number, tableScript: tableScript }, function () { /*
   
   <div class="col-lg-{number}" id="{id}">
                <div class="table-responsive">
                    <table class="table table-bordered table-hover table-striped">
                        {headerHtml}
                       <div id="{id}-content">
					    {bodyHtml}
					   </div>
                    </table>
                </div>
    </div>
	{tableScript}
        */ });
    }

    var CovertToUI = function (src) {
        var data = {};
        data.model = {};
        data.fields = [];
        data.option = {};
        data.option.title = src.TypeName;
        data.option.source = "";

        for (var i = 0; i < src.Columns.length; i++) {
            data.fields.push({
                type: src.Columns[i].PageControlName,
                label: src.Columns[i].ColumnName,
                name: src.Columns[i].ColumnID,
                value: src.Columns[i].Value,
                num: 4,//数据源无
                tip: "输入" + src.Columns[i].ColumnName
                //validators: { int:true}
            });
        }
        return data;

    }


    this.FileItemsTpl = function (files, name, canDelete) {

        if (!$.hasValue(files)) {
            files = [];
        }
        if (!$.isArray(files)) {
            var temp = [];	//自动转换字符串为数组
            var fileArray = files.split(';');
            for (var i = 0; i < fileArray.length; i++) {
                if ($.hasValue(fileArray[i])) {
                    temp.push({ url: fileArray[i], name: $.getFileName(fileArray[i]) });
                }
            }
            files = temp;
        }



        var bodyHtml = "";
        for (var i = 0; i < files.length; i++) {
            bodyHtml += FileItemTpl(files[i], name, canDelete);
        }
        return bodyHtml;
    }

    this.ShowFileTpl = function (id, label, files, num) {
        var oldValue = files;
        //没有文件直接终止
        //if (($.isArray(files)&&files.length == 0)||!$.hasValue(files)) {
        //	return "";
        //}
        //读取旧值
        if ($.isArray(files)) {
            oldValue = files.join(';');
        }
        //debugger
        var number = 12 / check(num, 2); $.log(files);
        return $.qx_tpl({ id: id, label: label, bodyHtml: FileItemsTpl(files, id), number: number, oldValue: oldValue }, function () {/*
 
 <div class="col-lg-{number}">
    <div class="form-group">
    <input  value="{oldValue}"  id="{id}" name="{id}" type="hidden"  >
        <label>{label}</label>
        <div class="hide" id="closeBox-busyness-{id}">
            <div class="row fileupload-buttonbar">
                <div class="col-lg-12">
                    <button type="button" class="btn btn-info" id="showButton-busyness">
                        <i class="glyphicon glyphicon-chevron-down"></i>
                        <span>展开{label}</span>
                    </button>
                </div>
            </div>
        </div>
        <div  id="mainBox-busyness-{id}">       
                <div class="row fileupload-buttonbar">
                    <div class="col-lg-12">
                     <input type="checkbox" class="toggle" id="checkboxButton-busyness-{id}">
                        <span class="btn btn-success fileinput-button">
                                    <i class="glyphicon glyphicon-cloud-download"></i>
                                    <span>批量下载</span>
                                </span>
                        <button type="button" class="btn btn-info" id="tagButton-busyness-{id}">
                            <i class="glyphicon glyphicon-chevron-up"></i>
                            <span>全部折叠</span>
                        </button>
                       
                    </div>
                </div>
                <table role="presentation" class="table table-striped" id="fileupload-{id}">
                    <tbody class="files" >
                   {bodyHtml}
                    </tbody>
                </table>
        </div>
     </div>
    </div>
 */});
    }

  

    this.input = function (label, name, value, num, validators, tip) {
        var dest = InputTpl(label, name, value, num, validators);
        if (!$.hasValue(tip)) {
            //默认提示
            tip = "请输入正确的" + label;
        }
        return push({ id: name, label: label, type: 201, tip: tip, html: dest, validators: validators });

    }

    this.showInput = function (label, name, value, num) {
        var dest = ShowInputTpl(label, name, value, num);
        return push({ id: name, type: 211, html: dest });
    }

    this.time = function (label, name, value, num, tip) {
        var dest = TimeTpl(label, name, value, num, tip);
        return push({ id: name, type: 202, html: dest });
    }

    this.showTime = function (label, name, value, num) {
        var dest = ShowTimeTpl(label, name, value, num);
        return push({ id: name, type: 216, html: dest });
    }

    this.date = function (label, name, value, num, tip) {
        var dest = DateTpl(label, name, value, num, tip);
        return push({ id: name, type: 203, html: dest });
    }

    this.showDate = function (label, name, value, num) {
        var dest = ShowDateTpl(label, name, value, num);
        return push({ id: name, type: 217, html: dest });
    }

    this.select = function (label, name, option, value, num, readonly) {
        var dest = SelectTpl(label, name, option, value, num, readonly);
        return push({ id: name, type: 204, html: dest });
    }

    this.showSelect = function (label, name, option, value, num) {
        var dest = ShowSelectTpl(label, name, option, value, num);
        return push({ id: name, type: 218, html: dest });
    }

    this.radio = function (label, name, items, num, vertical, value) {

        var dest = RadioTpl(label, name, items, num, vertical, value);
        return push({ id: name, type: 205, html: dest });
    }

    this.showRadio = function (label, name, items, num, vertical, value) {

        var dest = ShowRadioTpl(label, name, items, num, vertical, value);
        return push({ id: name, type: 219, html: dest });
    }

    this.editor = function (label, name, value, num, height) {
        var dest = RichBoxTpl(label, name, value, num, height);
        return push({ id: name, type: 206, html: dest });
    }

    this.showEditor = function (label, name, value, num, height) {
        var dest = ShowRichBoxTpl(label, name, value, num, height);
        return push({ id: name, type: 220, html: dest });
    }

    this.checkbox = function (label, name, items, num, vertical, valueArray) {
        var dest = CheckBoxTpl(label, name, items, num, vertical, valueArray);
        return push({ id: name, type: 207, html: dest });
    }

    this.showCheckbox = function (label, name, items, num, vertical, valueArray) {
        var dest = ShowCheckBoxTpl(label, name, items, num, vertical, valueArray);
        return push({ id: name, type: 221, html: dest });
    }

    this._switch = function (label, name, num, value, onText, offText) {
        var dest = SwitchTpl(label, name, num, value, onText, offText);
        return push({ id: name, type: 208, html: dest });
    }

    this.showSwitch = function (label, name, num, value, onText, offText) {
        var dest = ShowSwitchTpl(label, name, num, value, onText, offText);
        return push({ id: name, type: 208, html: dest });
    }

    this.area = function (label, name, value, num, height, validators, tip) {
        var dest = AreaTpl(label, name, value, num, tip, height);
        //  return push({ id: name, type: 209, html: dest });
        return push({ id: name, type: 209, html: dest, label: label, tip: tip, validators: validators });

    }

    this.showArea = function (label, name, value, num, height, validators, tip) {
        var dest = ShowAreaTpl(label, name, value, num, tip, height);
        return push({ id: name, type: 215, html: dest, label: label, tip: tip, validators: validators });

    }

    this.file = function (label, name, num, folder, url) {
        var dest = FileUploadTpl(label, name, num, folder, url);
        return push({ id: name, type: 210, html: dest });
    }
    this.file3rd = function (label, name, num, folder, url) {
        var dest = FileUploadTpl3rd(label, name, num, folder, url);
        return push({ id: name, type: 210, html: dest });
    }
    
    this.hide = function (name, value) {

        var dest = HideTpl(name, value);


        return push({ id: name, type: 212, html: dest });

    }

    this.hides = function (nameArray, valueArray) {

        var hideArray = [];
        for (var i = 0; i < nameArray.length; i++) {
            hideArray.push(hide(nameArray[i]));
        }
        return push({ id: $.random(), type: 115, html: _render(hideArray) });

    }

    this.hideTime = function (name, value) {
        if (arguments.length > 2 && _c.isDebug) {
            $.alert("警告:请检查页面中hideTime参数是否正确:" + name);
        }
        var dest = (HideTpl(name, value));


        return push({ id: name, type: 223, html: dest });

    }

    this.hideTimes = function (nameArray, valueArray) {

        var hideArray = [];
        for (var i = 0; i < nameArray.length; i++) {
            hideArray.push(hideTime(nameArray[i]));
        }
        return push({ id: $.random(), type: 116, html: _render(hideArray) });

    }

    this.showRichBox = function (label, name, value, num, tip) {
        alert("请修改");
        var dest = ShowRichBoxTpl(label, name, value, num, tip);
        return { id: name, type: 213, html: dest };
    }

    this.showfile = function (label, name, files, num, folder, url) {

        name = $.hasValue(name) ? name : $.random();
        var dest = ShowFileTpl(name, label, files, num);

        return push({ id: name, type: 214, html: dest });
    }

    this.showFile = function (label, name, files, num) {
        return showfile(label, name, files, num);
    }

    this.table = function (body, head, num) {
        var dest = "";
        var id = $.random();
        dest = TableTpl(head, body, num, id);
        return push({ id: id, type: 100, html: dest });
    }

    this.tab = function (contents, num) {
        var id = $.random();
        var dest = TabTpl(id, contents, num);
        return { id: id, type: 104, html: dest };
    }

    this.group = function (html, title, num) {
        var id = $.random();
        var dest = GroupTpl(id, html, title, num);
        return { id: id, type: 105, html: dest };
    }

    this.renderTable = function (cfgArray) {
         
        if (!$.isArray(cfgArray)) {
            cfgArray = [cfgArray];
        }

        $.each(cfgArray, function (i, o) {
            var cfg = o;
            debugger
            //参数
            var id = cfg.id;
            var head = cfg.head;
            var store = cfg.store;
            var row = cfg.row;

            var num = cfg.num;
            var destBody = [];
            store.query(function (data) {//请求数据
                if (!$.isArray(data)) {
                    data = [data];
                }
                $.each(data, function (i, o) {

                    if ($.hasValue(row)) {
                        var processedRow = row(o, i, data);
                        //解析操作列-最后一个是数组
                        var op = processedRow[processedRow.length - 1];
                        if ($.isArray(op)) {

                            if (head.length === processedRow.length - 1) {
                                head.push("操作");//自动添加操作列
                            }
                            var opHtml = "";
                            $.each(op, function (index, opObj) {
                                opHtml += "<a class='qx-popup operate' data-url='" + opObj.url + "'>" + opObj.text + "</a>&nbsp;&nbsp;";
                            });
                            processedRow.pop(op);
                            processedRow.push(opHtml);
                        }



                        //
                        /*if(!$.hasValue(processedRow)||!$.isArray(processedRow)){
                            $.warn("table的body函数没有返回正确的数组,已跳过索引为"+i+"的数据");
                            continue;
                        }else{
                            o=processedRow;
                        }*/
                        o = processedRow;
                    }
                    destBody.push(o);
                });
                $("#" + id).html(_render(table(destBody, head, num)));

                if (i === cfgArray.length - 1) {
                    // debugger
                    InitPopup(cfg);//最后一个，初始化弹窗 
                }
            });
        });
    }

    //id管理器
    var g_formIdArray = [];

    //初始化页面控件
    this.InitFormControl = function (htmlArray, submiturl, dataUrl, title, overWrite, data) {

        //设置标题
        if ($.hasValue(title)) {
            subSetTitle(title);
        } else {
            //$.alert("请为Form页设置标题,语法如下:<br/>render(htmlArray, submiturl, dataUrl, <span class='red'>title</span>)",2);
        }

        //渲染HTML
        var htmlString = "";
        //debugger
        if (typeof (htmlArray) == "function") {
            htmlString = _render(htmlArray());
        } else {
            htmlString = $.isArray(htmlArray) ? _render(htmlArray) : htmlArray;
        }

        if ($.hasValue(submiturl)) {
            htmlString += canSubmitTpl();
        }
        var body = $('#body');
        if (overWrite === undefined || !overWrite) {
            //debugger
            body.append(htmlString);
        }
        else {
            body.empty();
            body.html(htmlString);
        }

        //-----渲染结束
        var idArray = [];
        for (var k = 0; k < g_formIdArray.length; k++) {
            idArray.push(g_formIdArray[k].id);
        }
        //重复id检测
        var repeatedId = idArray.getdistinct();
        if (repeatedId.length > 0) {
            if (_c.isDebug) {
                $.confirm("检测到表单中存在重复id,是否查看重复id？", function () {
                    $.diy(repeatedId.join("<br/>") + "<br/><p style='color:red'>提示：请务必更正重复id,否则数据提交会出现未知错误!<p>", "重复id如下");
                    return true;
                });
            }
        }
        //赋初值
        if ($.hasValue(data)) {
            //debugger 
            for (var i = 0; i < g_formIdArray.length; i++) {
                var currentId = g_formIdArray[i].id;
                //debugger 
                $.set(currentId, g_formIdArray[i].type, data[currentId]);
            }
        }

        //时间控件
        $(".form_datetime").datetimepicker({
            autoclose: true,
            language: 'zh',
            todayBtn: true,
            initialDate: new Date(),
            todayHighlight: true,
            format: "yyyy-mm-dd hh:ii",
            pickerPosition: 'bottom-left'

        });
        //$.log($(".form_datetime"))
        //日期控件
        $('.form_date').datetimepicker({
            weekStart: 1,
            language: 'zh',
            todayHighlight: true,
            todayBtn: true,
            autoclose: 1,
            initialDate: new Date(),
            startView: 2,
            minView: 2,
            forceParse: 0,
            format: 'yyyy-mm-dd',
            pickerPosition: 'bottom-left'
        });
        //返回按钮
        // $("#back").click(back);
        //初始化验证
        InitValidation(submiturl);
        $.doFunction("formReady");
        //var sb = $("#submit");
        //sb.click(function (e) {
        //    //sb.submit();
        //    submitForm(submiturl);
        //    //setTimeout(function () {
        //    //   // sb.attr("class", ($("#submit").attr("class").replace("disabled", "")));
        //    //    //sb.removeAttr("disabled");

        //    //    e.preventDefault();
        //    //}, 100);       
        //});


    }

    this.getFormData = function () {

        var json = "{";
        for (var i = 0; i < g_formIdArray.length; i++) {
            var currentId = g_formIdArray[i].id;
            var value = $.val(currentId, g_formIdArray[i].type);
            json += "\"" + currentId + "\":" + "\"" + value + "\"";
            if (i === g_formIdArray.length - 1) {
                json += "}";
            } else {
                json += ",";
            }
        }

        var obj = JSON.parse(json);
        obj._json = JSON.stringify(obj);
        $.log(obj);
        return obj;

    }

    /*
    http://www.cnblogs.com/huangcong/p/5335376.html
    http://bv.doc.javake.cn/validators/
    notEmpty：非空验证；
    
    stringLength：字符串长度验证；
    
    regexp：正则表达式验证；
    
    emailAddress：邮箱地址验证（都不用我们去写邮箱的正则了~~）
    
    除此之外，在文档里面我们看到它总共有46个验证类型，我们抽几个常见的出来看看：
    
    base64：64位编码验证；
    
    between：验证输入值必须在某一个范围值以内，比如大于10小于100；
    
    creditCard：身份证验证；
    
    date：日期验证；
    
    ip：IP地址验证；
    
    numeric：数值验证；
    
    phone：电话号码验证；
    
    uri：url验证；
    
    fields= {
                syllabus_version: {
                    message: 'The username is not valid',
                    validators: {
                        notEmpty: {
                            message: 'The username is required and can\'t be empty'
                        },
                        stringLength: {
                            min: 6,
                            max: 30,
                            message: 'The username must be more than 6 and less than 30 characters long'
                        },
                        regexp: {
                            regexp: /^[a-zA-Z0-9_\.]+$/,
                            message: 'The username can only consist of alphabetical, number, dot and underscore'
                        },
                        different: {
                            field: 'password',
                            message: 'The username and password can\'t be the same as each other'
                        }
                    }
                },
                syllabus_name: {
                    validators: {
                        notEmpty: {
                            message: 'The email address is required and can\'t be empty'
                        },
                        emailAddress: {
                            message: 'The input is not a valid email address'
                        }
                    }
                },
                syll_author: {
                    validators: {
                        notEmpty: {
                            message: 'The password is required and can\'t be empty'
                        },
                        identical: {
                            field: 'confirmPassword',
                            message: 'The password and its confirm are not the same'
                        },
                        different: {
                            field: 'username',
                            message: 'The password can\'t be the same as username'
                        }
                    }
                },
                confirmPassword: {
                    validators: {
                        notEmpty: {
                            message: 'The confirm password is required and can\'t be empty'
                        },
                        identical: {
                            field: 'password',
                            message: 'The password and its confirm are not the same'
                        },
                        different: {
                            field: 'username',
                            message: 'The password can\'t be the same as username'
                        }
                    }
                },
                captcha: {
                    validators: {
                        callback: {
                            message: 'Wrong answer',
                            callback: function (value, validator) {
                                var items = $('#captchaOperation').html().split(' '), sum = parseInt(items[0]) + parseInt(items[2]);
                                return value == sum;
                            }
                        }
                    }
                }
            }
    */

    this.InitValidation = function (submiturl) {
        //debugger 
        if (g_valitacionString.length > 0) { //清除最后一个,
            //debugger
            g_valitacionString = g_valitacionString.substring(0, g_valitacionString.length - 1);
            g_valitacionString = '{' + g_valitacionString + '}';
            var fields = JSON.parse(g_valitacionString);
            $.log(fields);
            $('#form').bootstrapValidator({
                message: '输入不正确',
                feedbackIcons: {
                    valid: 'glyphicon glyphicon-ok',
                    invalid: 'glyphicon glyphicon-remove',
                    validating: 'glyphicon glyphicon-refresh'
                },
                submitButtons: '#bt_submit',
                fields: fields
            }).on('success.form.bv', function (e) {
                // Prevent form submission
                e.preventDefault();
                submitForm(submiturl);
            });;
        } else {
            $("#form").attr('novalidate', 'novalidate').on('submit', function (e) {
                // //debugger
                e.preventDefault();
                submitForm(submiturl);
                //return false; 
            });
        }

        //重写提交事件onsubmit="return check()"
        //$("#form").
        //    attr('novalidate', 'novalidate')//.
        //attr('onsubmit', 'return submitForm("'+submiturl+'")');

        //document.getElementById("form").
        //   addEventListener("submit", function () {
        //      //debugger
        //        return false;
        //        submitForm(submiturl);
        //    });
    };

    this.submitForm = function (submiturl, doAfterSuccess) {
        //var validItems = $("small");
        //for (var i = 0; i < validItems.length; i++) {
        //    if ($(validItems[i]).css("display") == "block")
        //    {
        //        $.alert("输入不符合要求，请根据页面提示进行修改");
        //        return false;
        //    }  
        //}
        //抓取页面数据
        var fdata = getFormData();

        //解析提交地址
        //debugger
        var url = "";
        if (submiturl === "*") {
            url += $.getsubmiturl();
        } else {
            url += $.hasValue(submiturl) ? submiturl : $.getsubmiturl();
        }
        $.Ajax({
            url: url, //调用WebService的地址和方法名称组合 ---- WsURL/方法名
            data: fdata,         //这里是要传递的参数,格式为 data: "{paraName:paraValue}",下面将会看到      
            success: function (data, code, msg, url) {     //回调函数,result,返回值
                if ($.hasValue(doAfterSuccess)) {
                    if (code == 2 || code == -1) {
                        $.alert(msg);
                    } else {
                        doAfterSuccess(data, code, msg, url);
                    }
                  
                    return;
                }
                $.dealAjax(data, code, msg, url);
                InitWorkFlow();//刷新待办
                //debugger 
            }
        });
        $("#bt_close").focus();
    }

    //验证规则串
    var g_valitacionString = "";

    this.push = function (obj) {
        if (obj.type > 200 && obj.type < 300) {
            if (obj.type == 201 || obj.type == 202 || obj.type == 203 || obj.type == 209) {
                //判断是否需要验证
                if (typeof obj.validators != "undefined") {
                    //处理FastConfig同时兼容旧版本
                    if (typeof obj.validators == "string") {
                        var reg = obj.validators;
                        obj.validators = {};
                        if (reg.length > 0) {
                            obj.validators.regexp = {
                                regexp: reg,
                                message: obj.tip
                            }
                        }

                    }
                    //自动添加非空验证
                    obj.validators.notEmpty = {
                        message: $.hasValue(obj.tip) ? obj.tip : obj.label + ' 是必填项'
                    }

                    if (obj.validators.max != undefined) {
                        obj.validators.stringLength = {
                            max: obj.validators.max,
                            message: $.hasValue(obj.tip) ? obj.tip : obj.label + '输入的最大长度为' + obj.validators.max + '个字符'
                        }
                    }
                    if (obj.validators.min != undefined) {
                        obj.validators.stringLength = {
                            min: obj.validators.min,
                            message: $.hasValue(obj.tip) ? obj.tip : obj.label + '要求至少输入' + obj.validators.max + '个字符'
                        }
                    }
                    if (obj.validators.max != undefined && obj.validators.min != undefined) {
                        obj.validators.stringLength = {
                            min: obj.validators.min,
                            max: obj.validators.max,
                            message: $.hasValue(obj.tip) ? obj.tip : obj.label + '要求输入' + obj.validators.min + '-' + obj.validators.max + '个字符'
                        }
                    }
                    if (obj.validators.email != undefined) {
                        obj.validators.emailAddress = {
                            message: $.hasValue(obj.tip) ? obj.tip : obj.label + '要求输入正确邮箱地址,如：123@sever.com'
                        }
                    }
                    if (obj.validators.idno != undefined) {
                        obj.validators.regexp = {
                            regexp: "^(\\d{6})(\\d{4})(\\d{2})(\\d{2})(\\d{3})([0-9]|X)$",
                            message: obj.tip + ",必须为18位"
                        }
                    }
                    if (obj.validators.float != undefined) {
                        obj.validators.regexp = {
                            regexp: "^(-?\\d+)(\\.\\d+)?$",
                            message: obj.tip + ",如1.2"
                        }
                    }
                    if (obj.validators.pfloat != undefined) {
                        obj.validators.regexp = {
                            regexp: "^[1-9]\\d*\\.\\d*|0\\.\\d*[1-9]\\d*$",
                            message: obj.tip + ",如1.2"
                        }
                    }
                    if (obj.validators.nfloat != undefined) {
                        obj.validators.regexp = {
                            regexp: "^-[1-9]\\d*\\.\\d*|-0\\.\\d*[1-9]\\d*$",
                            message: obj.tip + ",如-1.2"
                        }
                    }
                    if (obj.validators.int != undefined) {
                        obj.validators.regexp = {
                            regexp: "^-?[1-9]\\d*$",
                            message: obj.tip + ",如6"
                        }
                    }
                    if (obj.validators.pint != undefined) {
                        obj.validators.regexp = {
                            regexp: "^[1-9]\\d*$",
                            message: obj.tip + ",如6"
                        }
                    }
                    if (obj.validators.nint != undefined) {
                        obj.validators.regexp = {
                            regexp: "^-[1-9]\\d*$",
                            message: obj.tip + ",如-6"
                        }
                    }
                    if (obj.validators.mobile != undefined) {
                        obj.validators.regexp = {
                            regexp: "^(13[0-9]|14[5|7]|15[0|1|2|3|5|6|7|8|9]|18[0|1|2|3|5|6|7|8|9])\\d{8}$",
                            message: obj.tip + ",如155****7595"
                        }
                    }
                    //拼接对象
                    g_valitacionString += '"' + obj.id + '":' +
                                                '{"validators":' +
                                                JSON.stringify(obj.validators) +
                                                '},';
                }

            }
            g_formIdArray.push({ id: obj.id, type: obj.type });
        }
        return obj;
    }

    //form界面渲染入口
    this.render = function (htmlArray, submiturl, dataUrl, title, overWrite) {
        if ($.isFunction(htmlArray)) {
            htmlArray = htmlArray();
        }
        if ($.isObject(htmlArray) && !$.hasValue(submiturl)) {
            //debugger
            render2(htmlArray);
            return;
        }

        if ($.isString(htmlArray) && !$.hasValue(submiturl)) {

            $.ajax({
                url: $.url("/open/gettable?id=" + htmlArray,true),
                success: function (data) {
                    //debugger
                    render2(CovertToUI(data));
                }
            });
            return;
        }

        //是否有绑定值
        if ($.hasValue(dataUrl)) {
            // var url = $.url($.getsubmiturl());
            $.Ajax({
                url: dataUrl, //参数1
               // data: q,
                success: function (data, code, msg, url) {
                   //debugger
                    if ($.isArray(data) && data.length > 0) {
                        data = data[0]; //取单行记录
                    } else if (!$.hasValue(data) ) {
                        $.warn("从" + url+"获取的数据为空");
                    }
                    $.log(data);
                    model = data;

                    InitFormControl(htmlArray, submiturl, dataUrl, title, overWrite, data);
                }
            });
        } else {
            InitFormControl(htmlArray, submiturl, dataUrl, title, overWrite);
        }
    }

    function render2(formConfig) {
        //debugger
        var htmlArray = [];
        var fields = formConfig.fields;
        var option = formConfig.option;
        var dataUrl = option.source;
        for (var i = 0; i < fields.length; i++) {
            var htmlObj = "";
            var cfg = fields[i];
            switch (cfg.type) {
                case "input":
                    {
                        htmlObj = qx.form.input(cfg.label, cfg.name, cfg.value, cfg.num, cfg.tip, cfg.reg);
                    }
                    break;
                case "showinput":
                    {
                        htmlObj = qx.form.showInput(cfg.label, cfg.name, cfg.value, cfg.num);
                    }
                    break;
                case "time":
                    {
                        htmlObj = qx.form.time(cfg.label, cfg.name, cfg.value, cfg.num, cfg.tip);
                    }
                    break;
                case "showTime":
                    {
                        htmlObj = qx.form.showTime(cfg.label, cfg.name, cfg.value, cfg.num);
                    }
                    break;
                case "date":
                    {
                        htmlObj = qx.form.date(cfg.label, cfg.name, cfg.value, cfg.num, cfg.tip);
                    }
                    break;
                case "showDate":
                    {
                        htmlObj = qx.form.showDate(cfg.label, cfg.name, cfg.value, cfg.num);
                    }
                    break;
                case "select":
                    {
                        htmlObj = qx.form.select(cfg.label, cfg.name, cfg.option, cfg.value, cfg.num, cfg.readonly);
                    }
                    break;
                case "showSelect":
                    {
                        htmlObj = qx.form.showSelect(cfg.label, cfg.name, cfg.option, cfg.value, cfg.num);
                    }
                    break;
                case "radio":
                    {
                        htmlObj = qx.form.radio(cfg.label, cfg.name, cfg.items, cfg.num, cfg.vertical, cfg.value);
                    }
                    break;
                case "showRadio":
                    {
                        htmlObj = qx.form.showRadio(cfg.label, cfg.name, cfg.items, cfg.num, cfg.vertical, cfg.value);
                    }
                    break;
                case "editor":
                    {
                        htmlObj = qx.form.editor(cfg.label, cfg.name, cfg.value, cfg.num, cfg.height);
                    }
                    break;
                case "showEditor":
                    {
                        htmlObj = qx.form.showEditor(cfg.label, cfg.name, cfg.value, cfg.num, cfg.height);
                    }
                    break;
                case "checkbox":
                    {
                        htmlObj = qx.form.checkbox(cfg.label, cfg.name, cfg.items, cfg.num, cfg.vertical, cfg.valueArray);
                    }
                    break;
                case "showCheckbox":
                    {
                        htmlObj = qx.form.showCheckbox(cfg.label, cfg.name, cfg.items, cfg.num, cfg.vertical, cfg.valueArray);
                    }
                    break;
                case "_switch":
                    {
                        htmlObj = qx.form._switch(cfg.label, cfg.name, cfg.num, cfg.value, cfg.onText, cfg.offText);
                    }
                    break;
                case "showSwitch":
                    {
                        htmlObj = qx.form.showSwitch(cfg.label, cfg.name, cfg.num, cfg.value, cfg.onText, cfg.offText);
                    }
                    break;
                case "area":
                    {
                        htmlObj = qx.form.area(cfg.label, cfg.name, cfg.value, cfg.num, cfg.height, cfg.validators, cfg.tip);
                    }
                    break;
                case "showArea":
                    {
                        htmlObj = qx.form.showArea(cfg.label, cfg.name, cfg.value, cfg.num, cfg.height, cfg.validators, cfg.tip);
                    }
                    break;
                case "file":
                    {
                        htmlObj = qx.form.file(cfg.label, cfg.name, cfg.num, cfg.folder, cfg.url);
                    }
                    break;
                case "showfile":
                    {
                        htmlObj = qx.form.showfile(cfg.label, cfg.name,cfg.files, cfg.num, cfg.folder, cfg.url);
                    }
                    break;
                case "image":
                    {
                        htmlObj = qx.form.image(cfg.imType, cfg.value, cfg.num, cfg.tip);
                    }
                    break;
                case "button":
                    {
                        htmlObj = qx.form.button(cfg.label, cfg.num, cfg.color, cfg.onclick);
                    }
                    break;
                case "tab":
                    {
                        htmlObj = qx.form.tab(cfg.contents, cfg.num);
                    }
                    break;
                case "pre":
                    {
                        htmlObj = qx.form.pre(cfg.code, cfg.num);
                    }
                    break;
                case "dropdown ":
                    {
                        htmlObj = qx.form.dropdown(cfg.label, cfg.li, cfg.color, cfg.num);
                    }
                    break;
                case "panel":
                    {
                        htmlObj = qx.form.panel(cfg.title, cfg.body, cfg.num, cfg.color, cfg.footer);
                    }
                    break;
                case "listgroup":
                    {
                        htmlObj = qx.form.listgroup(cfg.title, cfg.libody, cfg.num);
                    }
                    break;
                case "media":
                    {
                        htmlObj = qx.form.media(cfg.imgurl, cfg.header, cfg.text, cfg.num);
                    }
                    break;
                case "_alert":
                    {
                        htmlObj = qx.form.alert(cfg.text, cfg.num, cfg.color);
                    }
                    break;
                case "thumbnail":
                    {
                        htmlObj = qx.form.thumbnail(cfg.imgurl, cfg.body, cfg.num);
                    }
                    break;
                case "pageheader":
                    {
                        htmlObj = qx.form.pageheader(cfg.title, cfg.subtitle, cfg.num);
                    }
                    break;
                case "carousel":
                    {
                        htmlObj = qx.form.carousel(cfg.imgUrl, cfg.num);
                    }
                    break;
                case "html":
                    {
                        htmlObj = qx.form.html(cfg.html);
                    }
                    break;
                case "hide":
                    {
                        htmlObj = qx.form.hide(cfg.name, cfg.value);
                    }
                    break;
                case "hides":
                    {
                        htmlObj = qx.form.hides(cfg.nameArray, cfg.valueArray);
                    }
                    break;
                case "hideTime":
                    {
                        htmlObj = qx.form.hideTime(cfg.name, cfg.value);
                    }
                    break;
                case "hideTimes":
                    {
                        htmlObj = qx.form.hideTimes(cfg.nameArray, cfg.valueArray);
                    }
                    break;
            }
            htmlArray.push(htmlObj);
        }

        //是否有绑定值
        if ($.hasValue(dataUrl)) {

            $.Ajax({
                url: dataUrl, //参数1
                data: q,
                success: function (data, code, msg, url) {

                    formConfig.model = data;
                    $.log(formConfig.model);
                    InitFormControl(htmlArray, formConfig.model.target, dataUrl, option.title, option.overWrite, formConfig.model);
                }
            });
        } else {
            InitFormControl(htmlArray, formConfig.model.target, dataUrl, option.title, option.overWrite);
        }

    }

    this._render = function (htmlArray) {
        var htmlString = "";
        if (!$.isArray(htmlArray) && $.isObject(htmlArray)) {
            htmlArray = [htmlArray];
        }
        for (var i = 0; i < htmlArray.length; i++) {
            var _html = htmlArray[i].html;
            htmlString += _html == undefined ? htmlArray[i] : _html;

        }
        return htmlString;
    }

    //form入口
    this.InitForm = function (id) {

        if (!$.hasValue(id)) {
            $.warn("参数错误:没有指定目标form！"); return;
        }
        var jsurl = id;//页面
        if (id.indexOf("?") > -1) {
            jsurl = id.substring(0, id.indexOf("?"));
            var param = id.substring(id.indexOf("?"));//取出参数部分
            q = $.qall(param);//给form页赋参数
        }
        $.log(srcurl(jsurl + ".js", "/web/"));
        $.ajax({
            url: srcurl(jsurl + ".js", "/web/"),
            success: function () {
                //head.load($.res(jsurl + ".js"));
            },
            error: function () {
                if (_c.isDebug) {
                    $.alert("未能正确加载界面,请检查项目的web目录下是否存在" + (jsurl + ".js"), 2, back);
                } else {
                    $.alert("加载界面出错,即将返回上一页", 5, back);
                }
            }
        });
        //css
        var cssurl = "";
        var actionName = "";
        if (jsurl.indexOf('/') > -1) {
            for (var i = jsurl.length - 1; i >= 0; i--) {

                if (jsurl[i] == '/') {
                    cssurl = jsurl.substring(0, i);
                    actionName = jsurl.substring(i, jsurl.length + 1);
                    cssurl = cssurl + "/css" + actionName;

                    break;
                }
            }

            $.ajax({
                url: srcurl(cssurl + ".css", "/web/"),
                success: function (data) {
                    //塞入html中
                    $("body").append("<style>" + data + "</style>");
                    //head.load($.res(jsurl + ".js"));
                },
                error: function () {
                    $.log("未能正确加载界面css,请检查项目的web目录下是否存在" + (cssurl + ".css"));
                }
            });
        }

    }

    //输入验证
    this.checkReg = function (reg, Id, tip) {
        //不验证
        if (!$.hasValue(reg)) {
            return;
        }
        var reg = new RegExp(reg);
        var obj = $('#' + Id);
        var msgobj = $('#msg-' + Id);
        var value = obj.val();
        var Null = true;
        var illegal = true;
        //如果没值
        Null = !$.hasValue(value);
        illegal = !reg.test(obj.val());

        if (Null) {
            obj.addClass('warning');
            msgobj.html("该值为必填项！");
            return;

        } else {
            obj.removeClass('warning');
            if (illegal) {
                obj.addClass('warning');
                msgobj.html(tip);

            } else {
                obj.removeClass('warning');
                msgobj.html("&#12288;&#12288;&#12288;");

            }

        }

    }

    //file初始化
    this.initFile = function (id, url, folder) {
        if (folder.length > 0 && folder[0] == '/') {
            folder = folder.substring(1, folder.length - 1);
        }
        url = $.url(url + "?folder=" + folder + "&uid=" + $.uid() + "&unitid=" + $.unitid(),true);//转换地址
        var contentId = '#fileupload-' + id;
        var startButton = "#startButton-" + id;
        var cancelButton = "#cancelButton-" + id;
        var deleteButton = '#deleteButton-' + id;
        var checkboxButton = "#checkboxButton-" + id;
        var tagButton = "#tagButton-" + id;
        var mainBox = '#mainBox-' + id;
        var closeBox = "#closeBox-" + id;
        var showButton = "#showButton-" + id;




        //$(contentId).fileupload('option', {
        //    url: url,
        //    // Enable image resizing, except for Android and Opera,
        //    // which actually support image resizing, but fail to
        //    // send Blob objects via XHR requests:
        //    disableImageResize: /Android(?!.*Chrome)|Opera/
        //        .test(window.navigator.userAgent),
        //    maxFileSize: 999000//,
        //   // acceptFileTypes: /(\.|\/)(gif|jpe?g|png)$/i
        //});

        $(contentId).fileupload({
            url: url,
            //disableImageResize: /Android(?!.*Chrome)|Opera/
            //.test(window.navigator && navigator.userAgent),
            //redirect: "http://" + window.location.host + "/pages/result.html?",//回调页面
            add: function (e, data) {
                if (e.isDefaultPrevented()) {
                    return false;
                }
                $(startButton).removeClass("hide");
                $(cancelButton).removeClass("hide");
                $(deleteButton).removeClass("hide");
                $(checkboxButton).removeClass("hide");
                $(tagButton).removeClass("hide");
                var $this = $(this),
                    that = $this.data('blueimp-fileupload') ||
                        $this.data('fileupload'),
                    options = that.options;
                data.context = that._renderUpload(data.files)
                    .data('data', data)
                    .addClass('processing');
                options.filesContainer[
                    options.prependFiles ? 'prepend' : 'append'
                ](data.context);
                that._forceReflow(data.context);
                that._transition(data.context);
                data.process(function () {
                    return $this.fileupload('process', data);
                }).always(function () {
                    data.context.each(function (index) {
                        $(this).find('.size').text(
                            that._formatFileSize(data.files[index].size)
                        );
                    }).removeClass('processing');
                    that._renderPreviews(data);
                }).done(function () {

                    data.context.find('.start').prop('disabled', false);
                    if ((that._trigger('added', e, data) !== false) &&
                            (options.autoUpload || data.autoUpload) &&
                            data.autoUpload !== false) {
                        data.submit();
                    }
                }).fail(function () {
                    if (data.files.error) {
                        data.context.each(function (index) {
                            var error = data.files[index].error;
                            if (error) {
                                $(this).find('.error').text(error);
                            }
                        });
                    }
                });
            }
        });
        //跨域
        //$(contentId).fileupload(
        // 'option',
        // 'redirect',
        // window.location.href.replace(
        //     /\/[^\/]*$/,
        //     '/pages/result.html?%s'
        // )
        //);

        $(contentId).addClass('fileupload-processing');

        $.ajax({
            // Uncomment the following to send cross-domain cookies:
            //xhrFields: {withCredentials: true},
            url: $(contentId).fileupload('option', 'url'),
            dataType: 'json',
            context: $(contentId)[0]
        }).always(function () {
            $(this).removeClass('fileupload-processing');

        }).done(function (result) {
            $(this).fileupload('option', 'done')
                .call(this, $.Event('done'), { result: result });

        });



        $(tagButton).click(function () {
            $(mainBox).slideUp();
            setTimeout(function () {
                $(closeBox).removeClass('hide');
            }, 500);

        });

        $(showButton).click(function () {
            $(mainBox).slideDown();
            setTimeout(function () {
                $(closeBox).addClass('hide');
            }, 500);

        });

    };

    //删除文件
    this.deleteFile = function (fileUrl, selector, controlName, savedPath) {
        $.Ajax({//删除文件的api地址，div选择器，文件name属性，文件存储的实际相对路径
            url: fileUrl,
            data: { controlName: controlName, savedPath: savedPath },
            success: function (data, code, msg) {
                if (code != 1) {
                    $.msg("删除失败，请刷新页面后重试", code);
                    return;
                }
                var old = $("#" + data.controlName);
                var newPath = old.val().replace(data.savedPath + ";", "").replace(data.savedPath, "");
                old.val(newPath);
                $("#" + selector).remove();
                $.msg("文件已删除", code);
            }
        });

    }

    this.pre = function (code, num) {
        var id = $.random();
        var dest = PreTpl(id, code, num);
        return { id: id, type: 106, html: dest };
    }

    this.dropdown = function (label, li, color, num) {
        var id = $.random();
        var dest = DropDownTpl(id, label, li, num, color);
        return { id: id, type: 107, html: dest };
    }

    this.panel = function (title, body, num, color, footer) {
        
        var id = $.random();
        var dest = PanelTpl(id, title, body, footer, color, num);
        return { id: id, type: 108, html: dest };
    }

    this.listgroup = function (title, libody, num) {
        var id = $.random();
        var dest = ListGroupTpl(id, title, libody, num);
        return { id: id, type: 109, html: dest };
    }

    this.media = function (imgurl, header, text, num) {
        var id = $.random();
        var dest = MediaTpl(id, imgurl, header, text, num);
        return { id: id, type: 110, html: dest };
    }

    this.alert = function (text, num, color) {
        var id = $.random();
        var dest = AlertTpl(id, text, num, color);
        return { id: id, type: 111, html: dest };
    }

    this.thumbnail = function (imgurl, body, num) {
        var id = $.random();
        var dest = ThumbNailTpl(id, imgurl, body, num);
        return { id: id, type: 112, html: dest };
    }

    this.pageheader = function (title, subtitle, num) {
        var id = $.random();
        var dest = PageHeaderTpl(id, title, subtitle, num);
        return { id: id, type: 113, html: dest };
    }

    this.carousel = function (imageUrl, num) {
        var id = $.random();
        var dest = CarouselTpl(id, imageUrl, num);
        return { id: id, type: -1, html: dest };
    }

    this.html = function (htmlString) {
        var id = $.random();
        return push({ id: id, type: 101, html: htmlString });

    }

    this.image = function (type, value, num, tip) {
        var dest = ImageTpl(type, value, num, tip);
        return { id: name, type: 102, html: dest };
    }

    this.button = function (label, num, color, onclick) {
        var id = $.random();
        var dest = ButtonTpl(id, label, num, color, onclick);
        return { id: id, type: 103, html: dest };
    }
}

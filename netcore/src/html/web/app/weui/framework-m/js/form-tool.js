/// <reference path="../../msg.html" />
function CanSubmitTpl() {
    return $.qx_tpl({ }, function () {/*
 
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



function InputTpl(label, name, value, num, reg) {
    var number = 12 / check(num,4);
    value = check(value, "");
    label = (reg == undefined ? "" : "*") + label;
    var tip= label.replace("*", "");
    //debugger 
    return $.qx_tpl({ reg: reg, label: ($.hasValue(label) ? " <label>" + label + "</label>" : ""), name: name, value: value, number: number, tip: ($.hasValue(tip) ? tip : "id") }, function () {/*

    <div class="weui-cell">
        <div class="weui-cell__hd"><label class="weui-label">{label}</label></div>
        <div class="weui-cell__bd">
          <input class="weui-input" type="text" id="{name}" name="{name}" value="{value}" placeholder="请输入{tip}">
        </div>
      </div>
   


 */});
}

function ShowInputTpl(label, name, value, num) {
    var number = 12 / check(num);
    value = check(value, "");
    return $.qx_tpl({ name: name, label: label, value: value, number: number }, function () {/*
     <div class="weui-cell">
        <div class="weui-cell__hd"><label class="weui-label">{label}</label></div>
        <div class="weui-cell__bd">
          <input class="weui-input" type="text" id="{name}" name="{name}" value="{value}" readonly="true">
        </div>
      </div>
 */});
}

function TimeTpl(label, name, value, num, tip) {
    var number = 12 / check(num);
    value = check(value, getNowFormatTime());
    tip = check(tip, "");

    return $.qx_tpl({ label: label, name: name, value: value, number: number, tip: tip }, function () {/*

      <div class="weui-cell">
        <div class="weui-cell__hd"><label for="" class="weui-label">{label}</label></div>
        <div class="weui-cell__bd">
          <input class="weui-input"  type="datetime-local" id="{name}" name="{name}"  placeholder="{tip}"  value="{value}" >
        </div>
      </div>
        
 */});
}

function ShowTimeTpl(label, name, value, num) {
    var number = 12 / check(num);
    value = check(value, "");

    return $.qx_tpl({ label: label, name: name, value: value, number: number }, function () {/*
      <div class="weui-cell">
        <div class="weui-cell__hd"><label for="" class="weui-label">{label}</label></div>
        <div class="weui-cell__bd">
          <input class="weui-input"  type="datetime-local" id="{name}" name="{name}"  placeholder="请设置{label}"  value="{value}" readonly="true">
        </div>
      </div>
   
 */});
}

function DateTpl(label, name, value, num, tip) {
    var number = 12 / check(num);
    value = check(value, getNowFormatTime("onlyDate"));
    tip = check(tip, "");

    return $.qx_tpl({ label: label, name: name, value: value, number: number, tip: tip }, function () {/*
      <div class="weui-cell">
        <div class="weui-cell__hd"><label for="" class="weui-label">{label}</label></div>
        <div class="weui-cell__bd">
          <input class="weui-input" type="date" id="{name}" name="{name}" value="{value}">
        </div>
      </div>
 */});
}

function ShowDateTpl(label, name, value, num) {
    var number = 12 / check(num);
    value = check(value, "");

    return $.qx_tpl({ label: label, name: name, value: value, number: number }, function () {/*

    <div class="weui-cell">
        <div class="weui-cell__hd"><label for="" class="weui-label">{label}</label></div>
        <div class="weui-cell__bd">
          <input class="weui-input" type="date" id="{name}" name="{name}" value="{value}" readonly="true">
        </div>
      </div>
   
 */});
}

function SelectTpl(label, name, option, value, num, readonly) {
   
    value = check(value, "");
    readonly = check(readonly, false);
    var number = 12 / check(num);
    var optionHtml = "";
    var optionScript = "";
    if ($.isArray(option)) {
        for (var i = 0; i < option.length; i++) {
            optionHtml += ('<option value="' + option[i].value + '">' + option[i].text + '</option>');
        }
    } else {
        if (option.indexOf("{")>0) {
            $.alert("select函数已升级，option参数应该为Array或Url,请修改原有函数!");
        }
        optionScript = "<script>head.ready(function(){$.fillSelect('"+name+"','" + option + "','" + value + "')})</script>";
    }
   
    

    return $.qx_tpl({ label: label, name: name, value: value, number: number, readonly: readonly?"disabled":"", option: optionHtml, optionScript: optionScript }, function () {/*
   <div class="weui-cells__title">{label}</div>
    <div class="weui-cells">
      <div class="weui-cell weui-cell_select">
        <div class="weui-cell__bd">
          <select class="weui-select" {readonly} id="{name}" name="{name}">
             <option >全部</option>
              {option}
          </select>
        </div>
      </div>
   {optionScript}  
   <script>
                document.getElementById("{name}")[{value}].selected=true;
   </script>
 */});
}

function ShowSelectTpl(label, name, option, value, num) {
    return SelectTpl(label, name, option, value, num, true);
}

function array_contain(array, obj) {
    for (var i = 0; i < array.length; i++) {
        if (array[i] == obj)//如果要求数据类型也一致,这里可使用恒等号===
            return true;
    }
    return false;
}

function RadioTpl(label, name, items, num, vertical, value) {
    value = check(value, "");
    vertical = check(vertical, true);
    if (vertical) {
        vertical = "float:left;";
    }
    var number = 12 / check(num);
    var itemHtml = "";
    for (var i = 0; i < items.length; i++) {
        itemHtml += (
              '<label class="weui-cell weui-check__label" for="'+name+i+'">'+
                '<div class="weui-cell__bd">'+
                  '<p>'+items[i].text+'</p>' +
                '</div>'+
                '<div class="weui-cell__ft">'+
                  '<input type="radio" class="weui-check" ' + ((value == items[i].value) ? 'checked="checked"' : '') + ' value="' + items[i].value + '" name="' + name + '" id="' + name + i + '">' +
                  '<span class="weui-icon-checked"></span>'+
                '</div>'+
              '</label>');
    }

    return $.qx_tpl({ label: label, number: number, itemHtml: itemHtml }, function () {/*
   <div class="weui-cells__title">{label}</div>
    <div class="weui-cells weui-cells_radio">
       {itemHtml}
    </div>
 */});
}

function ShowRadioTpl(label, name, items, num, vertical, value) {
    value = check(value, "");
    vertical = check(vertical, true);
    if (vertical) {
        vertical = "float:left;";
    }
    var number = 12 / check(num);
    var itemHtml = "";
    for (var i = 0; i < items.length; i++) {
        itemHtml += (
             '<label class="weui-cell weui-check__label" for="' + name + i + '">' +
               '<div class="weui-cell__bd">' +
                 '<p>' + items[i].text + '</p>' +
               '</div>' +
               '<div class="weui-cell__ft">' +
                 '<input type="radio" class="weui-check" ' + ((value == items[i].value) ? 'checked="checked"' : '') + ' value="' + items[i].value + '" name="' + name + '" id="' + name + i + '" disabled>' +
                 '<span class="weui-icon-checked"></span>' +
               '</div>' +
             '</label>');
    }

    return $.qx_tpl({ label: label, number: number, itemHtml: itemHtml }, function () {/*
      
         <div class="weui-cells__title">{label}</div>
    <div class="weui-cells weui-cells_radio">
       {itemHtml}
    </div> 
  
 */});
}

function CheckBoxTpl(label, name, items, num, vertical,valueArray) {

    if (valueArray == undefined) {
        valueArray = [];
    }
    if (vertical) {
        vertical = "float:left;";
    }
    var number = 12 / check(num);
    var itemHtml = "";
    for (var i = 0; i < items.length; i++) {
        itemHtml += ('<label class="weui-cell weui-check__label" id="'+name + i + '">' +
                        '<div class="weui-cell__hd">'+
                          '<input type="checkbox" class="weui-check" '
            + (array_contain(valueArray, (items[i].value)) ? 'checked="checked"' : '') + ' value="' + items[i].value + '" name="'
            + name + '" id="' + name + i + '">' +
                          '<i class="weui-icon-checked"></i>'+
                         '</div>'+
                        '<div class="weui-cell__bd">'+
                         ' <p>' + items[i].text + '</p>'+
                       ' </div>'+
                     '</label>');
    }

    return $.qx_tpl({ label: label, number: number, itemHtml: itemHtml }, function () {/*
     <div class="weui-cells__title">{label}</div>
     <div class="weui-cells weui-cells_checkbox">
     {itemHtml}
    </div>
  
 */});
}
function ShowCheckBoxTpl(label, name, items, num, vertical, valueArray) {

    if (valueArray == undefined) {
        valueArray = [];
    }
    if (vertical) {
        vertical = "float:left;";
    }
    var number = 12 / check(num);
    var itemHtml = "";
    for (var i = 0; i < items.length; i++) {
        itemHtml += ('<label class="weui-cell weui-check__label" id="'+name + i + '">' +
                         '<div class="weui-cell__hd">' +
                           '<input type="checkbox" class="weui-check" '
             + (array_contain(valueArray, (items[i].value)) ? 'checked="checked"' : '') + ' value="' + items[i].value + '" name="'
             + name + ' id="' + name + i + '" readonly="readonly" disabled>' +
                           '<i class="weui-icon-checked"></i>' +
                          '</div>' +
                         '<div class="weui-cell__bd">' +
                          ' <p>' + items[i].text + '</p>' +
                        ' </div>' +
                      '</label>');
    }

    return $.qx_tpl({ label: label, number: number, itemHtml: itemHtml }, function () {/*
      
         <div class="weui-cells__title">{label}</div>
     <div class="weui-cells weui-cells_checkbox">
     {itemHtml}
    </div>  
  
 */});
}

function SwitchTpl( label,name, num, value, onText, offText) {
   
    var number = 12 / check(num);
    var name1 = name + 1;
    if (!$.hasValue(onText)) {
        onText = '开';
    }
    if (!$.hasValue(offText)) {
        offText = '关';
    }
    var checked = "checked";
    
   
    return $.qx_tpl({ name: name, label: label, number: number, value: value, onText: onText, offText: offText, name1: name1, checked: checked }, function () {/*
     
      <div class="weui-cell weui-cell_switch">
        <div class="weui-cell__bd">{label}</div>
        <div class="weui-cell__ft">
          <label for="{name1}" class="weui-switch-cp">
            <input hidden="hidden" id="{name}" name="{name}" type="radio" value="{value}" />   
            <input  class="weui-switch-cp__input" id="{name1}"type="checkbox" checked="checked" >
            <div class="weui-switch-cp__box"></div>
          </label>
        </div>
      </div>
        <script>  
        
            $(function () {
            if ({value}==1) {
                    $("#{name}").val("1");
        
                }
                else {
                    $("#{name}").val("0");
                       document.getElementById("{name1}").checked=false;
                   
                }
                $("#{name1}").click(function () {
                     
                    if($("#{name}").val()==0){

                        $("#{name}").val("1");
                      

                    }else{

                        $("#{name}").val("0");
                    
                    }

                });
            });
        </script>
        
 */});
}
function ShowSwitchTpl(label, name, num, value, onText, offText) {

    var number = 12 / check(num);

    if (!$.hasValue(onText)) {
        onText = '开';
    }
    if (!$.hasValue(offText)) {
        offText = '关';
    }
    var name1 = name + 1;
    return $.qx_tpl({ name: name, label: label, number: number, value: value, name1: name1, onText: onText, offText: offText }, function () {/*
     <div class="weui-cell weui-cell_switch">
        <div class="weui-cell__bd">{label}</div>
        <div class="weui-cell__ft">
          <label for="{name}" class="weui-switch-cp">
            <input  class="weui-switch-cp__input" id="{name}"type="checkbox" checked="checked" disabled>
            <input hidden="hidden" id="{name1}" name="{name1}" type="radio" value="{value}" />     
            <div class="weui-switch-cp__box"></div>
          </label>
        </div>
      </div>
        <script>  
        
            $(function () {
            if ({value}==1) {
                    $("#{name1}").val("1");
        
                }
                else {
                    $("#{name1}").val("0");
                        document.getElementById("{name}").checked=false;
                   
                }
            });
        </script>
    
 */});
}
function AreaTpl(label, name, value, num, tip, height) {
    tip = check(tip, "");
    value = check(value, "");
    height = check(height,3);
    var number = 12 / check(num,1);
    return $.qx_tpl({ height: height, label: label, name: name, value: value, number: number, tip: tip }, function () {/*
   <div class="weui-cells__title">{label}</div>
    <div class="weui-cells weui-cells_form">
      <div class="weui-cell">
        <div class="weui-cell__bd">
          <textarea class="weui-textarea"id="{name}" name="{name}" rows="{height}">{value}</textarea>
        </div>
      </div>
    </div>


 */});
}
function ShowAreaTpl(label, name, value, num, height) {

    value = check(value, "");
    height = check(height, 200);
    var number = 12 / check(num, 1);
    return $.qx_tpl({ height: height, label: label, name: name, value: value, number: number }, function () {/*
     <div class="weui-cells__title">{label}</div>
    <div class="weui-cells weui-cells_form">
      <div class="weui-cell">
        <div class="weui-cell__bd">
          <textarea class="weui-textarea"id="{name}" name="{name}"  readonly="readonly">{value}</textarea>
        </div>
      </div>
    </div>

 */});
}
function ShowRichBoxTpl(label, name, value, num, tip) {
    tip = check(tip, "");
    var number = 12 / check(num,1);
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

function RichBoxTpl(label, name, value, num, height) {
    value = check(value, "");
    //$.log(value);
    height = check(height, 300);
    var number = 12/check(num, 1);
    return $.qx_tpl({ label: label, name: name, value: value, number: number, height: height }, function () {/*

  <div class='col-lg-{number}'>
       <div class='form-group'>
        <label>{label}</label>
         <script id="{name}" type="text/plain" style="width:100%;height:{height}px;">{value}</script>
       </div>
       <script>   
        head.ready(["ueditor-config","ueditor","ueditor-zh"],function() {
             var ue = UE.getEditor('{name}');         
                ue.ready(function () {
                var old= ue.setContent();
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

function ImageTpl(type, value, num, tip) {
    tip = check(tip, "");
    var number = 12 / check(num,3);
    return $.qx_tpl({ type: type, value: value, number: number, tip: tip }, function () {/*

  <div class="col-lg-{number}">
           <img src="{value}" class="img-{type}">    
  </div>

 */});
}

function ButtonTpl(id, label, num, color, onclick) {
    color = check(color, "primary");
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
       <a href="javascript:;" class="weui-btn weui-btn_{color}" id="{id}">{label}</a>
     <script type="text/javascript">
      var bObj=document.getElementById("{id}");
      bObj.onclick={onclick};
     </script>

 */});
}

function TabTpl(tabId,cfg, num) {
    var subTitle = "";
    var subContent="";
    for (var i = 0; i < cfg.length; i++)
    {
        var id=$.random();
        subTitle += '<li class="' + (i === 0 ? 'active' : '') + '"><a href="#' + id + '" data-toggle="tab" aria-expanded="false">' + cfg[i].title + '</a></li>';
        subContent += ' <div class="tab-pane fade ' + (i === 0 ? 'active in' : '') + '" id="' + id + '">' + _render(cfg[i].content) + '</div>';
    }

    var number = 12 / check(num,1);
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

function GroupTpl(id,html, title, num) {
    var formContent = "";
    formContent += _render(html);
    var number = 12 / check(num, 1);
 
    return $.qx_tpl({ id: id,title: title, formContent: formContent, number: number }, function () {/*
 
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

function PreTpl(id,code, num) {
    var number = 12 / check(num, 1);
    return $.qx_tpl({ id:id,code: code, number: number }, function () {/*
 
         <div id="{id}" class="col-lg-{number}">
              <div class="form-group">
                 <label>代码</label>
                 <pre>{code}</pre>
              </div>
         </div>

 */});
}

function DropDownTpl(id, label, li, num, color) {
    var number = 12 / check(num,6);
    color = check(color, Color.blue);
    var liHtml = new Array();
   
    for (var i = 0; i < li.length; i++) {
        liHtml.push('<li role="presentation"><a role="menuitem" data-baseurl="' +
            li[i].value + '" id="' +
            li[i].id + '" data-url="' +
            li[i].value + '" class="qx-menu" data-title="' +
            li[i].text  + '">' + li[i].text + '</a></li>');
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

function PanelTpl(id, title, body, footer, color, num) {
    color = check(color, Color.red);
    var number = 12 / check(num, 1);
    return $.qx_tpl({ id: id, title: title, body: body, footer: footer, color: color, number: number }, function () {/*
 
            
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

function ListGroupTpl(id, title, libody, num) {
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

function MediaTpl(id, imgurl, header, text, num) {
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

function AlertTpl(id, text, num, color) {
    var number = 12 / check(num,1);
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

function ThumbNailTpl(id, imgurl, body, num) {
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

function PageHeaderTpl(id, title, subtitle, num) {
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

function CarouselTpl(id, imageUrl, num) {
    //console.log(imageUrl);
    var number = 12 / check(num,1);
    var liHtml = new Array();
    var imgHtml = new Array();
     for (var i = 0; i < imageUrl.length; i++) {
        liHtml.push('<li data-target="#myCarousel" data-slide-to="' + i + '" class="' + (i === 0?"active":"") + '"></li>');
        imgHtml.push('<div class="item ' + (i === 0 ? "active" : "") + '"><img src="' + imageUrl[i].imgurl + '"><div class="carousel-caption">标题' + (i) + ' </div></div>  ');
    }
    
     return $.qx_tpl({ id: id, liHtml: liHtml.join(""), imgHtml:  imgHtml.join("") , number: number }, function () {/*
 
            
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


function FileUploadTpl(label, name, num,folder, url) {
    folder = check(folder, "/userfiles/uploads/files/");
    url = check(url, "/open/upload");
    var number = 12 / check(num, 2);
    return $.qx_tpl({ label: label, name: name, url: url, folder: folder, number: number }, function () {/*
    <div class="container js_container">
            <!--图片放大容器 style的透明度一定是0.8-->
            <div class="weui-gallery" id="galleryy" style="opacity:0.8; display: none;">
                <span class="weui-gallery__img" id="galleryImgg" style="background-image:url(../img/doctor/55.jpg)"></span>
                <div class="weui-gallery__opr">
                    <a href="javascript:" class="weui-gallery__del">
                        <i class="weui-icon-delete weui-icon_gallery-delete"></i>
                    </a>
                </div>
            </div>
            <div class="weui-cell">
                <div class="weui-cell__bd">
                    <div class="weui-uploader">
                        <div class="weui-uploader__hd">
                            <p class="weui-uploader__title">{label}</p>
                          
                        </div>
                        <div class="weui-uploader__bd">
                            <ul class="weui-uploader__files" id="uploaderFiles">
                            
                            </ul>
                            <div class="weui-uploader__input-box">
                                <input id="uploaderInput" class="weui-uploader__input" type="file" accept="image/*" multiple="">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
           
         </div>



 */});
}
/*缺fastclick.js*/

function FileItemTpl(item, name, canDelete) {
    item.remove = true;
	//$.warn(item);
    var savedUrl = item.url; var id = $.random();
    item.url = $.url((item.url.indexOf("-split-") > -1) ? encodeURI(item.url) : "");
    item.name = $.hasValue(item.name) ? item.name : $.getFileName(item.url);
    return ' <tr id="'+id+'" class="template-download fade in">' +
            '<td><input type="checkbox" name="delete" value="1" class="toggle"><span class="preview"> </span></td>' +//复选框
            '<td><p class="name"><a target="_blank" href="'+item.url+'" download="'+item.name+'">'+item.name+'</a></p></td>' +//文件名
            '<td><span class="size">' +($.hasValue(item.size)? item.size:"") + '</span></td>' +//文件大小
            '<td><a href="' + item.url + '" download="' + item.name + '" class="btn btn-primary"><i class="glyphicon glyphicon-download-alt"></i><span>下载</span></a>&nbsp;' +//下载按钮
            (canDelete ? '<a onclick=\'deleteFile("/open/Delete?savedPath=' + savedUrl + '","' + id + '","' + name + '", "' + savedUrl + '")\' class="btn btn-danger"><i class="fa fa-remove"></i><span>删除</span></a>' : '') +//删除按钮
            '</td></tr>';//deleteFile(fileUrl, selector, controlName, savedPath)
}

function FileItemsTpl(files, name,canDelete) {

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

function ShowFileTpl(id, label, files, num) {
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
    var number = 12 / check(num,2);$.log(files);
    return $.qx_tpl({ id: id, label: label, bodyHtml: FileItemsTpl(files, id), number: number, oldValue: oldValue }, function () {/*
 
 <div class="container js_container">
            <!--图片放大容器 style的透明度一定是0.8-->
            <div class="weui-gallery" id="galleryy" style="opacity:0.8; display: none;">
                <span class="weui-gallery__img" id="galleryImgg" style="background-image:url(../img/doctor/55.jpg)"></span>
                <div class="weui-gallery__opr">
                    <a href="javascript:" class="weui-gallery__del">
                        <i class="weui-icon-delete weui-icon_gallery-delete"></i>
                    </a>
                </div>
            </div>
            <div class="weui-cell">
                <div class="weui-cell__bd">
                    <div class="weui-uploader">
                        <div class="weui-uploader__hd">
                            <p class="weui-uploader__title">{label}</p>
                          
                        </div>
                        <div class="weui-uploader__bd">
                            <ul class="weui-uploader__files" id="uploaderFiles">
                            
                            </ul>
                            <div class="weui-uploader__input-box">
                                <input id="uploaderInput" class="weui-uploader__input" type="file" accept="image/*" multiple="">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
           
         </div>

 */});
}




function HideTpl(name, value) {

    value = check(value, "");

    return $.qx_tpl({ name: name, value: value }, function () {/*

          <input class="form-control" value="{value}"  id="{name}" name="{name}" type="hidden"  >

 */});
}


function MsgTpl(url, title, time, note) {
    return $.qx_tpl({ url: url, title: title, time: time, note: note }, function () {/*

 <li>
       <a class="qx-menu" data-title="{title}" data-url="{url}">
         <div>
           <strong>{title}</strong>
                <span class="pull-right text-muted">
                      <em>{time}</em>
                </span>
         </div>
      <div>
        {note}
      </div>
     </a>
 </li>
  <li class="divider"></li>
 */});
}
function TableTpl(header, body, num, id) {
    header = check(header, []);
    id = check(id, $.random());
    var number = 12 / check(num,1);
   
    var bodyHtml = "<tbody>";
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

    var headerHtml = "<thead> <tr>";
    if (header.length === 0 && body.length === 0) {
        header.push("无数据");
    }
    for (var i = 0; i < header.length; i++) {
        headerHtml += '<th>' + header[i] + '</th>';
    }
    headerHtml += "</tr></thead>";
    return $.qx_tpl({ id: id, bodyHtml: bodyHtml, headerHtml: headerHtml, number: number }, function () { /*
   
   <div class="col-lg-{number}" id="{id}">
                <div class="table-responsive">
                    <table class="table table-bordered table-hover table-striped">
                        {headerHtml}
                        {bodyHtml}
                    </table>
                </div>
    </div>

        */ });
}
function TaskTpl(url, title, time, note, progress) {
   
    return $.qx_tpl({ url: url, title: title, time: time, note: note, progress: progress == 0 ? progress + 1 : progress }, function () { /*

<li>
     <a class="qx-menu" data-title="{title}" data-url="{url}">
         <div>
             <p>
                 <strong>{title}</strong>
                 <span class="pull-right text-muted">{progress}% Complete</span>
             </p>
            <div class="progress progress-striped active">
                <div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="{progress}" aria-valuemin="0" aria-valuemax="100" style="width: {progress}%">
                 <span class="sr-only">{progress}% Complete (success)</span>
                </div>
            </div>
             <p>
                 {note}
             </p>
         </div>
      </a>
</li>
<li>
<hr/>
</li>
*/ });
}
function PopUpRadioTpl(label, id, items) {
   
    return $.qx_tpl({ label: label, id: id, items: '"' + items.join('","') + '"' }, function () {/*
     <div class="weui-cell">
        <div class="weui-cell__hd"><label for={id} class="weui-label">{label}</label></div>
        <div class="weui-cell__bd">
          <input class="weui-input" id="{id}" type="text" value="">
        </div>
    </div>
     <script>
      $("#{id}").select({
        title: "选择{label}",
        items: [{items}],
        onChange: function(d) {
          console.log(this, d);
        },
        onClose: function() {
          console.log("close");
        },
        onOpen: function() {
          console.log("open");
        },
      });
      </script>

   


 */});
}
function PopUpCheckBox(label, id, items) {

   return $.qx_tpl({ label: label, id: id, items: '[{title: "画画", value: 1,description: "额外的数据1" },{title: "打球", value: 2,description: "额外的数据2" }]' }, function () {/*
  
     <div class="weui-cell">
        <div class="weui-cell__hd"><label for="{id}" class="weui-label">{label}</label></div>
        <div class="weui-cell__bd">
          <input class="weui-input" id="{id}" type="text" value="">
        </div>
      </div>
     <script>
      $("#{id}").select({
        
        title: "选择{label}",
        multi: true,
        min: 2,
        max: 3,
        items: {items},
        onChange: function(d) {
          console.log(this, d);
        },
        onClose: function() {
          console.log("close");
        },
        onOpen: function() {
          console.log("open");
        },
      });
   </script>


 */});
}

function PopUpTimeTpl(label, name, value, num, tip) {
    
    var number = 12 / check(num);
    value = check(value, getNowFormatTime("onlyDate"));
    tip = check(tip, "");

    return $.qx_tpl({ label: label, name: name, value: value, number: number, tip: tip }, function () {/*
      <div class="weui-cell">
        <div class="weui-cell__hd"><label for="" class="weui-label">{label}</label></div>
        <div class="weui-cell__bd">
          <input class="weui-input" id="{name}" type="text" value="{value} ">
        </div>
      </div>
      <script>
      $("#{name}").datetimePicker({
        title: '选择{label}',
        min: "1990-12-12",
        max: "2022-12-12 12:12",
        onChange: function (picker, values, displayValues) {
          
        }
      });
      </script>
 */});
}
function PopUpDateTpl(label, name, value, num, tip) {
    var number = 12 / check(num);
    value = check(value, getNowFormatTime("onlyDate"));
    tip = check(tip, "");

    return $.qx_tpl({ label: label, name: name, value: value, number: number, tip: tip }, function () {/*
      <div class="weui-cell">
        <div class="weui-cell__hd"><label for="" class="weui-label">{label}</label></div>
        <div class="weui-cell__bd">
          <input class="weui-input" id="{name}" type="text" value="{value} ">
        </div>
      </div>
      <script>
      
      $("#{name}").calendar({
        onChange: function (p, values, displayValues) {
          console.log(values, displayValues);
        }
      });
      </script>
 */});
}
function PopUpCityPickerTpl(label, name, value, num, tip) {
    var number = 12 / check(num);
   
    tip = check(tip, "");

    return $.qx_tpl({ label: label, name: name, value: value, number: number, tip: tip }, function () {/*
      <div class="weui-cell">
        <div class="weui-cell__hd"><label class="weui-label">{label}</label></div>
       
        <div class="weui-cell__bd">
          <input class="weui-input" id="{name}" type="text" value="湖北省 武汉市 武昌区"  data-code="420106" data-codes="420000,420100,420106">
        </div>
      </div>
      <script>
        $("#{name}").cityPicker({
            title: "选择{label}"
          });
      </script>
 */});
}


function input(label, name, value, num, validators,tip ) {
    var dest = "";
    if (name == undefined)
    {
        dest = (InputTpl(label.label, label.name, label.value, label.num,  label.valitation));
    } else {
        dest = (InputTpl(label, name, value, num, validators));
    }
    if (!$.hasValue(tip)) {
        //默认提示
        tip = "请输入正确的" + label;
    }
    return push({ id: name, label: label, type: 201,tip:tip, html: dest, validators: validators });
 
}


function showinput(label, name, value, num) {

    var dest = "";
    if (name == undefined) {
        dest = (ShowInputTpl(label.label, label.name, label.value, label.num));
    } else {
        dest = (ShowInputTpl(label, name, value, num));
    }
    return push({ id: name, type: 211, html: dest });

}

function showInput(label, name, value, num) { return showinput(label, name, value, num); }

function time(label, name, value, num, tip) {
    var dest = "";

    if (name == undefined) {
        dest =(TimeTpl(label.label, label.name, label.value, label.num, label.tip));
    } else {
        dest =(TimeTpl(label, name, value, num, tip));
    }
    return push({ id: name, type: 202, html: dest });
}

function showTime(label, name, value, num) {
    var dest = "";

    if (name == undefined) {
        dest = (ShowTimeTpl(label.label, label.name, label.value, label.num));
    } else {
        dest = (ShowTimeTpl(label, name, value, num));
    }
    return push({ id: name, type: 216, html: dest });
}

function date(label, name, value, num, tip) {
    var dest = "";

    if (name == undefined) {
        dest =(DateTpl(label.label, label.name, label.value, label.num, label.tip));
    } else {
        dest =(DateTpl(label, name, value, num, tip));
    }
    return push({ id: name, type: 203, html: dest });
}
function showDate(label, name, value, num) {
    var dest = "";

    if (name == undefined) {
        dest = (ShowDateTpl(label.label, label.name, label.value, label.num));
    } else {
        dest = (ShowDateTpl(label, name, value, num));
    }
    return push({ id: name, type: 217, html: dest });
}
function select(label, name, option, value, num, readonly) {
    var dest = "";
   
    if (name == undefined) {
        dest = (SelectTpl(label.label, label.name, label.option, label.value, label.num, label.readonly));
    } else {
        dest = (SelectTpl(label, name, option, value, num, readonly));
    }
    return push({ id: name, type: 204, html: dest });
}

function showSelect(label, name, option, value, num) {
    var dest = "";

    if (name == undefined) {
        dest = (ShowSelectTpl(label.label, label.name, label.option, label.value, label.num));
    } else {
        dest = (ShowSelectTpl(label, name, option, value, num));
    }
    return push({ id: name, type: 218, html: dest });
}


function radio(label, name, items, num, vertical, value) {
    
    var dest = "";
    if (name == undefined) {
        dest = (RadioTpl(label.label, label.name, label.items, label.num, label.vertical, label.value));
    } else {
        dest = RadioTpl(label, name, items, num, vertical, value);
    }
    return push({ id: name, type: 205, html: dest });
}

function showRadio(label, name, items, num, vertical, value) {

    var dest = "";
    if (name == undefined) {
        dest = (ShowRadioTpl(label.label, label.name, label.items, label.num, label.vertical, label.value));
    } else {
        dest = ShowRadioTpl(label, name, items, num, vertical, value);
    }
    return push({ id: name, type: 219, html: dest });
}

function editor(label, name, value, num, height) {
    var dest = "";
    if (name == undefined) {
        dest = (RichBoxTpl(label.label, label.name, label.value, label.num, label.height));
    } else {
        dest = (RichBoxTpl(label, name, value, num, height));
    }
    return push({ id: name, type: 206, html: dest });
}
function showEditor(label, name, value, num, height) {
    var dest = "";
    if (name == undefined) {
        dest = (ShowRichBoxTpl(label.label, label.name, label.value, label.num, label.height));
    } else {
        dest = (ShowRichBoxTpl(label, name, value, num, height));
    }
    return push({ id: name, type: 220, html: dest });
}
function checkbox(label, name, items, num, vertical,valueArray) {
    var dest = "";
    if (name == undefined) {
        dest = (CheckBoxTpl(label.label, label.name, label.items, label.num, label.vertical, label.valueArray));
    } else {
        dest = CheckBoxTpl(label, name, items, num,vertical, valueArray);
    }
    return push({ id: name, type: 207, html: dest });
}
function showCheckbox(label, name, items, num, vertical, valueArray) {
    var dest = "";
    if (name == undefined) {
        dest = (ShowCheckBoxTpl(label.label, label.name, label.items, label.num, label.vertical, label.valueArray));
    } else {
        dest = ShowCheckBoxTpl(label, name, items, num, vertical, valueArray);
    }
    return push({ id: name, type: 221, html: dest });
}
function _switch(label,name, num, value, onText, offText) {
    var dest = "";
    if (num == undefined) {
        dest = (SwitchTpl(label.label, label.name, label.num, label.value, label.onText, label.offText));
    } else {
        dest = (SwitchTpl(label, name, num, value, onText, offText));
    }
    return push({ id: name, type: 208, html: dest });
}
function showSwitch(label, name, num, value, onText, offText) {
    var dest = "";
    if (num == undefined) {
        dest = (ShowSwitchTpl(label.label, label.name, label.num, label.value, label.onText, label.offText));
    } else {
        dest = (ShowSwitchTpl(label, name, num, value, onText, offText));
    }
    return push({ id: name, type: 208, html: dest });
}
function area(label, name, value, num,height, validators,tip ) {
    var dest = "";

    if (name == undefined) {
        dest = (AreaTpl(label.label, label.name, label.value, label.num, label.tip, label.height));
    } else {
        dest = (AreaTpl(label, name, value, num, tip, height));
    }
  //  return push({ id: name, type: 209, html: dest });
    return push({ id: name, type: 209, html: dest, label: label, tip: tip, validators: validators });

}
function showArea(label, name, value, num, height, validators, tip) {
    var dest = "";

    if (name == undefined) {
        dest = (ShowAreaTpl(label.label, label.name, label.value, label.num, label.tip, label.height));
    } else {
        dest = (ShowAreaTpl(label, name, value, num, tip, height));
    }
    return push({ id: name, type: 215, html: dest, label: label, tip: tip, validators: validators });

}
function file(label, name, num,folder, url) {
    var dest = "";
    if (name == undefined) {
        dest = (FileUploadTpl(label.label, label.name, label.num, label.folder,  label.url));
    } else {
        dest = (FileUploadTpl(label, name,  num,folder, url));
    }
    return push({ id: name, type: 210, html: dest });
}



function hide(name, value) {

    var dest = (HideTpl(name, value));


    return push({ id: name, type: 212, html: dest });

}

function hides(nameArray, valueArray) {

    var hideArray = [];
    for (var i = 0; i < nameArray.length; i++) {
        hideArray.push(hide(nameArray[i]));
    }
    return push({ id: $.random(), type: 115, html: _render(hideArray) });

}

function showRichBox(label, name, value, num, tip) {
    alert("请修改");
    var dest = "";

    if (name == undefined) {
        dest = (ShowRichBoxTpl(label.label, label.name, label.value, label.num, label.tip));
    } else {
        dest = (ShowRichBoxTpl(label, name, value, num, tip));
    }
    return { id: name, type: 213, html: dest };
}

function showfile(label, name, files, num, folder, url) {
    var dest = "";
    name = $.hasValue(name) ? name : $.random();
    if (name == undefined) {
        dest = (ShowFileTpl(name, label.label, label.files, label.num));
    } else {
        dest = (ShowFileTpl(name, label, files, num));
    }
   
    return push({ id: name, type: 214, html: dest });
}

function showFile(label, name, files, num) {
    return showfile(label, name, files, num);
}

function table(body, head, num) {
    var dest = "";
    var id = $.random();
    dest = (TableTpl(head, body, num, id));
    return push({ id: id, type: 100, html: dest });
}



function tab(contents, num) {
    var dest = "";
    var id = $.random();
    if (num == undefined) {
        dest = (TabTpl(id, contents.contents, contents.num));
    } else {
        dest = (TabTpl(id, contents, num));
    }
    return { id: id, type: 104, html: dest };
}

function group(html,title, num) {
    var dest = "";
    var id = $.random();
    if (title == undefined) {
        dest = (GroupTpl(id, html.html, html.title, html.num));
    } else {
        dest = (GroupTpl(id, html, title, num));
    }
    return { id: id, type: 105, html: dest };
}

function popupradio(label, id, items) {

    var dest = "";
    if (id == undefined) {
        dest = (PopUpRadioTpl(label.label, label.name, label.items));
    } else {
        dest = PopUpRadioTpl(label, id, items);
    }
    return push({ id: id, type: 222, html: dest });
}
function popupcheckbox(label, id, items) {

    var dest = "";
    if (id == undefined) {
        dest = (PopUpCheckBox(label.label, label.name, label.items));
    } else {
        dest = PopUpCheckBox(label, id, items);
    }
    return push({ id: id, type: 223, html: dest });
}
function popuptime(label, name, value, num, tip) {
    var dest = "";

    if (name == undefined) {
        dest = (PopUpTimeTpl(label.label, label.name, label.value, label.num, label.tip));
    } else {
        dest = (PopUpTimeTpl(label, name, value, num, tip));
    }
    return push({ id: name, type: 224, html: dest });
}
function popupdate(label, name, value, num, tip) {
    var dest = "";
    if (name == undefined) {
        dest = (PopUpDateTpl(label.label, label.name, label.value, label.num, label.tip));
    } else {
        dest = (PopUpDateTpl(label, name, value, num, tip));
    }
    return push({ id: name, type: 225, html: dest });
}

function popupcitypicker(label, name, value, num, tip) {
    var dest = "";
    if (name == undefined) {
        dest = (PopUpCityPickerTpl(label.label, label.name, label.value, label.num, label.tip));
    } else {
        dest = (PopUpCityPickerTpl(label, name, value, num, tip));
    }
    return push({ id: name, type: 226, html: dest });
}



//id管理器
var g_formIdArray = [];
//初始化页面控件
function InitFormControl(htmlArray, submiturl, dataUrl, title, overWrite, data) {
  
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
        htmlString += CanSubmitTpl();
    }
    var body = $('body');
    if (overWrite === undefined || !overWrite) {
	//debugger
        body.append("<hr/>下方为测试代码<hr/><br/>" + htmlString);
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
        if (g_debug) {
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
    //$(".form_datetime").datetimepicker({
    //    autoclose: true,
    //    language: 'zh',
    //    todayBtn:true,
    //    initialDate: new Date(),
    //    todayHighlight:true,
    //    format: "yyyy-mm-dd hh:ii",
    //    pickerPosition: 'bottom-left'
      
    //});
    ////$.log($(".form_datetime"))
    ////日期控件
    //$('.form_date').datetimepicker({
    //    weekStart: 1,
    //    language: 'zh',
    //    todayHighlight: true,
    //    todayBtn: true,
    //    autoclose: 1,
    //    initialDate: new Date(),
    //    startView: 2,
    //    minView: 2,
    //    forceParse: 0,
    //    format: 'yyyy-mm-dd',
    //    pickerPosition: 'bottom-left'
    //});
    //返回按钮
   // $("#back").click(back);
    //初始化验证
   // InitValidation(submiturl);
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
function getFormData() {
     
    var json = "{";
    for (var i = 0; i < g_formIdArray.length; i++) {
        var currentId = g_formIdArray[i].id;
        var value = $.val(currentId, g_formIdArray[i].type, "weui");
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
function InitValidation(submiturl) {
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
        }).on('success.form.bv', function(e) {
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

function submitForm(submiturl) {
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
            $.dealAjax(data, code, msg, url);
            InitWorkFlow();//刷新待办
            //debugger 
        }
    });
    $("#bt_close").focus();
}
//验证规则串
var g_valitacionString = "";
function push(obj) {
    if (obj.type > 200 && obj.type < 300) {
        if (obj.type == 201 || obj.type == 202 || obj.type == 203 || obj.type == 209) {
            //判断是否需要验证
            if (typeof obj.validators != "undefined") {
                //处理FastConfig同时兼容旧版本
                if (typeof obj.validators == "string") {
                    var reg = obj.validators;
                    obj.validators = {};
                    if (reg.length > 0) {
                        obj.validators.regexp= {
                            regexp: reg,
                            message: obj.tip
                        }
                    }
                   
                }
                //自动添加非空验证
                obj.validators.notEmpty = {
                    message:$.hasValue(obj.tip)?obj.tip:obj.label + ' 是必填项'
                }
              
                if (obj.validators.max != undefined) {
                    obj.validators.stringLength = {
                        max: obj.validators.max,
                        message:$.hasValue(obj.tip)?obj.tip: obj.label + '输入的最大长度为' + obj.validators.max + '个字符'
                }
                }
                if (obj.validators.min != undefined) {
                    obj.validators.stringLength = {
                        min: obj.validators.min,
                        message: $.hasValue(obj.tip)?obj.tip:obj.label + '要求至少输入' + obj.validators.max + '个字符'
                    }
                }
                if (obj.validators.max != undefined && obj.validators.min != undefined) {
                    obj.validators.stringLength = {
                        min: obj.validators.min,
                        max: obj.validators.max,
                        message: $.hasValue(obj.tip)?obj.tip:obj.label + '要求输入' + obj.validators.min + '-' + obj.validators.max + '个字符'
                    }
                }
                if (obj.validators.email != undefined) {
                    obj.validators.emailAddress = {
                        message: $.hasValue(obj.tip)?obj.tip:obj.label + '要求输入正确邮箱地址,如：123@sever.com'
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
                        message: obj.tip+",如1.2"
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
function render(htmlArray, submiturl, dataUrl, title, overWrite) {
     
    //是否有绑定值
    if ($.hasValue(dataUrl)) {
       // var url = $.url($.getsubmiturl());
        $.Ajax({
            url: dataUrl, //参数1
            data: q,
            success: function (data, code, msg, url) {
                $.log(data);
                //debugger
                model = data;
                InitFormControl(htmlArray, submiturl, dataUrl, title, overWrite, data);
            }
        });
    } else {
        InitFormControl(htmlArray, submiturl, dataUrl, title, overWrite);
    }  
}



function _render(htmlArray)
{
    var htmlString = "";
    for (var i = 0; i < htmlArray.length; i++) {
        var _html = htmlArray[i].html;
        htmlString += _html == undefined ? htmlArray[i] : _html;
       
    }
    return htmlString;
}
//form入口
function InitForm(id) {

    if (!$.hasValue(id)) {
        $.warn("参数错误:没有指定目标form！"); return;
    }
    var jsurl = id;//页面
    if (id.indexOf("?") > -1) {
        jsurl = id.substring(0, id.indexOf("?"));
        var param = id.substring(id.indexOf("?"));//取出参数部分
        q = $.qall(param);//给form页赋参数
    }
    $.log(srcurl(jsurl + ".js","/web/"));
    $.ajax({
        url: srcurl(jsurl + ".js","/web/"),
        success: function () {
            //head.load($.res(jsurl + ".js"));
        },
        error: function () {
            if (g_debug) {
                $.alert("未能正确加载界面,请检查项目的web目录下是否存在" + (jsurl + ".js"), 2, back);
            } else {
                $.alert("加载界面出错,即将返回上一页", 5,back);
            }
        }
    });
  
}

//输入验证
function checkReg(reg, Id,tip) {
    //不验证
    if (!$.hasValue(reg))
    {
        return;
    }
      var reg = new RegExp(reg);
      var obj = $('#' + Id);
      var msgobj = $('#msg-' + Id);
      var value = obj.val();
      var Null = true;
      var illegal = true;
    //如果没值
      Null=!$.hasValue(value);
      illegal=!reg.test(obj.val());

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
function initFile(id, url, folder) {
if (folder.length>0&&folder[0]=='/') {
	folder = folder.substring(1, folder.length - 1);
}
    url = $.url(url+"?folder="+folder+"&uid="+$.uid()+"&unitid="+$.unitid());//转换地址
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
function deleteFile(fileUrl, selector, controlName, savedPath) {
    $.Ajax({//删除文件的api地址，div选择器，文件name属性，文件存储的实际相对路径
        url: fileUrl,
        data: { controlName: controlName, savedPath: savedPath },
        success: function (data, code, msg) {
            var old = $("#" + data.controlName);
			 
            var newPath = old.val().replace(data.savedPath , "").replace(data.savedPath + ";", "");
            old.val(newPath);
            $("#" + selector).remove();
            $.msg("文件已删除", code);
        }
    });

}




function pre(code, num) {
    var dest = "";
    var id = $.random();
    if (num == undefined) {
        dest = (PreTpl(id, code.code, code.num));
    } else {
        dest = (PreTpl(id, code, num));
    }
    return { id: id, type: 106, html: dest };
}

function dropdown(label, li, color, num) {
    var dest = "";
    var id = $.random();
    if (li == undefined) {
        dest = (DropDownTpl(id, label.label, label.li, label.num, label.color));
    } else {
        dest = (DropDownTpl(id, label, li, num, color));
    }
    return { id: id, type: 107, html: dest };
}

function panel(title, body, num, color, footer) {
    var dest = "";
    var id = $.random();
    if (body == undefined) {
        dest = (PanelTpl(id, title.title, title.body, title.footer, title.color, title.num));
    } else {
        dest = (PanelTpl(id, title, body, footer, color, num));
    }
    return { id: id, type: 108, html: dest };
}

function listgroup(title, libody, num) {
    var dest = "";
    var id = $.random();
    if (libody == undefined) {
        dest = (ListGroupTpl(id, title.title, title.libody, title.num));
    } else {
        dest = (ListGroupTpl(id, title, libody, num));
    }
    return { id: id, type: 109, html: dest };
}

function media(imgurl, header, text, num) {
    var dest = "";
    var id = $.random();
    if (header == undefined) {
        dest = (MediaTpl(id, imgurl.imgurl, imgurl.header, imgurl.text, imgurl.num));
    } else {
        dest = (MediaTpl(id, imgurl, header, text, num));
    }
    return { id: id, type: 110, html: dest };
}

function _alert(text, num, color) {
    var dest = "";
    var id = $.random();
    if (num == undefined) {
        dest = (AlertTpl(id, text.text, text.num, text.color));
    } else {
        dest = (AlertTpl(id, text, num, color));
    }
    return { id: id, type: 111, html: dest };
}

function thumbnail(imgurl, body, num) {
    var dest = "";
    var id = $.random();
    if (body == undefined) {
        dest = (ThumbNailTpl(id, imgurl.imgurl, imgurl.body, imgurl.num));
    } else {
        dest = (ThumbNailTpl(id, imgurl, body, num));
    }
    return { id: id, type: 112, html: dest };
}

function pageheader(title, subtitle, num) {
    var dest = "";
    var id = $.random();
    if (subtitle == undefined) {
        dest = (PageHeaderTpl(id, title.title, title.subtitle, title.num));
    } else {
        dest = (PageHeaderTpl(id, title, subtitle, num));
    }
    return { id: id, type: 113, html: dest };
}

function carousel(imageUrl, num) {
    var dest = "";
    var id = $.random();
    if (num == undefined) {
        dest = (CarouselTpl(id, imageUrl.imageUrl, imageUrl.num));
    } else {
        dest = (CarouselTpl(id, imageUrl, num));
    }
    return { id: id, type: -1, html: dest };
}
function html(htmlString) {
    var id = $.random();
    return push({ id: id, type: 101, html: htmlString });

}

function image(type, value, num, tip) {
    var dest = "";

    if (value == undefined) {
        dest = (ImageTpl(type.type, type.value, type.num, type.tip));
    } else {
        dest = (ImageTpl(type, value, num, tip));
    }
    return { id: name, type: 102, html: dest };
}

function button(label, num, color, onclick) {
    var dest = "";
    var id = $.random();
    if (num == undefined) {
        dest = (ButtonTpl(id, label.label, label.num, label.color, label.onclick));
    } else {
        dest = (ButtonTpl(id, label, num, color, onclick));
    }
    return { id: id, type: 103, html: dest };
}
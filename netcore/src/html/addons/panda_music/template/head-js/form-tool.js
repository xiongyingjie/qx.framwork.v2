function CanSubmitTpl() {
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


function FileItemsTpl(files, name, canDelete) {
    return qx.form.FileItemsTpl(files, name, canDelete);
}

function ShowFileTpl(id, label, files, num) {
    return qx.form.ShowFileTpl(id, label, files, num);
}


function input(label, name, value, num, validators, tip) {
    return qx.form.input(label, name, value, num, validators, tip);
}

function showinput(label, name, value, num) {

    return qx.form.showInput(label, name, value, num);

}

function showInput(label, name, value, num) {
     return showinput(label, name, value, num);
}

function time(label, name, value, num, tip) {
    return qx.form.time(label, name, value, num, tip);
}

function showTime(label, name, value, num) {
    return qx.form.showTime(label, name, value, num);
}

function date(label, name, value, num, tip) {
    return qx.form.date(label, name, value, num, tip);
}

function showDate(label, name, value, num) {
    return qx.form.showDate(label, name, value, num);
}

function select(label, name, option, value, num, readonly) {
    return qx.form.select(label, name, option, value, num, readonly)
}

function showSelect(label, name, option, value, num) {
    return qx.form.showSelect(label, name, option, value, num);
}

function radio(label, name, items, num, vertical, value) {
    return qx.form.radio(label, name, items, num, vertical, value);
}

function showRadio(label, name, items, num, vertical, value) {
    return qx.form.showRadio(label, name, items, num, vertical, value);
}

function editor(label, name, value, num, height) {
    return qx.form.editor(label, name, value, num, height);
}

function showEditor(label, name, value, num, height) {
    return qx.form.showEditor(label, name, value, num, height);
}

function checkbox(label, name, items, num, vertical, valueArray) {
    return qx.form.checkbox(label, name, items, num, vertical, valueArray);
}

function showCheckbox(label, name, items, num, vertical, valueArray) {
    return qx.form.showCheckbox(label, name, items, num, vertical, valueArray);
}

function _switch(label, name, num, value, onText, offText) {
    return qx.form._switch(label, name, num, value, onText, offText);
}

function showSwitch(label, name, num, value, onText, offText) {
    return qx.form.showSwitch(label, name, num, value, onText, offText);
}

function area(label, name, value, num, height, validators, tip) {
    return qx.form.area(label, name, value, num, height, validators, tip);

}

function showArea(label, name, value, num, height, validators, tip) {
    return qx.form.showArea(label, name, value, num, height, validators, tip);

}

function file(label, name, num, folder, url) {
    return qx.form.file(label, name, num, folder, url);
}

function file3rd(label, name, num, folder, url) {
    return qx.form.file3rd(label, name, num, folder, url);
}

function hideTime(name, value) {
    return qx.form.hideTime(name, value);

}

function hide(name, value) {
    return qx.form.hide(name, value);

}

function hides(nameArray, valueArray) {
    return qx.form.hides(nameArray, valueArray);

}

function hideTimes(nameArray, valueArray) {
    return qx.form.hideTimes(nameArray, valueArray);

}

function showRichBox(label, name, value, num, tip) {
    return qx.form.showRichBox(label, name, value, num, tip);
}

function showfile(label, name, files, num, folder, url) {
    return qx.form.showfile(label, name, files, num, folder, url);
}

function showFile(label, name, files, num) {
    return qx.form.showFile(label, name, files, num);
}

function table(body, head, num) {
    return qx.form.table(body, head, num);
}

function renderTable(cfgArray) {
    return qx.form.renderTable(cfgArray);
}

function tab(contents, num) {
    return qx.form.tab(contents, num);
}

function group(html, title, num) {
    return qx.form.group(html, title, num);
}

//初始化页面控件
function InitFormControl(htmlArray, submiturl, dataUrl, title, overWrite, data) {
    return qx.form.InitFormControl(htmlArray, submiturl, dataUrl, title, overWrite, data);
}

function getFormData() {
    return qx.form.getFormData();
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
    return qx.form.InitValidation(submiturl);
};

function submitForm(submiturl, doAfterSuccess) {
    return qx.form.submitForm(submiturl, doAfterSuccess);
}

function push(obj) {
    return qx.form.push(obj);
}

//form界面渲染入口
function render(htmlArray, submiturl, dataUrl, title, overWrite) {
    return qx.form.render(htmlArray, submiturl, dataUrl, title, overWrite);
}

function _render(htmlArray) {
    return qx.form._render(htmlArray);
}

//form入口
function InitForm(id) {
    return qx.form.InitForm(id);
}

//输入验证
function checkReg(reg, Id, tip) {
    return qx.form.checkReg(reg, Id, tip);
}

//file初始化
function initFile(id, url, folder) {
    return qx.form.initFile(id, url, folder);
};

//删除文件
function deleteFile(fileUrl, selector, controlName, savedPath) {
    return qx.form.deleteFile(fileUrl, selector, controlName, savedPath);
}

function pre(code, num) {
    return qx.form.pre(code, num);
}

function dropdown(label, li, color, num) {
    return qx.form.dropdown(label, li, color, num);
}

function panel(title, body, num, color, footer) {
    return qx.form.panel(body, title, num, color, footer);
}

function listgroup(title, libody, num) {
    return qx.form.listgroup(title, libody, num);
}

function media(imgurl, header, text, num) {
    return qx.form.media(imgurl, header, text, num);
}

function _alert(text, num, color) {
    return qx.form.alert(text, num, color);
}

function thumbnail(imgurl, body, num) {
    return qx.form.thumbnail(imgurl, body, num);
}

function pageheader(title, subtitle, num) {
    return qx.form.pageheader(title, subtitle, num);
}

function carousel(imageUrl, num) {
    return qx.form.carousel(imageUrl, num);
}

function html(htmlString) {
    return qx.form.html(htmlString);

}

function image(type, value, num, tip) {
    return qx.form.image(type, value, num, tip);
}

function button(label, num, color, onclick) {
    return qx.form.button(label, num, color, onclick);
}
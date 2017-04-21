
    function getNowFormatDate() {
        var date = new Date();
        var seperator1 = "-";
        var seperator2 = ":";
        var month = date.getMonth() + 1;
        var strDate = date.getDate();
        if (month >= 1 && month <= 9) {
            month = "0" + month;
        }
        if (strDate >= 0 && strDate <= 9) {
            strDate = "0" + strDate;
        }
        var currentdate = date.getFullYear() + seperator1 + month + seperator1 + strDate
                + " " + date.getHours() + seperator2 + date.getMinutes()
                + seperator2 + date.getSeconds();
        return currentdate;
    }
    function _v(v, msg) {
        if (v == "") {
            if (msg == undefined || msg == "") {
                alert("请填写完整的信息" + v);
            } else {
                alert(msg);
            }
            exit();
        }
        return v;
    }

    function v_i(id, msg) {
        var v = f_i(id);
        _v(v, msg);
        return v;
    }

    function v_r(id, msg) {
        var v = f_r(id);
        _v(v, msg);
        return v;
    }

    function f_i(id) {
        return document.getElementById(id).value;
    }

    function f_r(name) {
        var obj;
        obj = document.getElementsByName(name);
        if (obj != null) {
            var i;
            for (i = 0; i < obj.length; i++) {
                if (obj[i].checked) {
                    return obj[i].value;
                }
            }
        }
        return null;
    }

    function log_i(id) {
        console.log(id + "=>" + f_i(id));
        return f_i(id);
    }

    function log_r(name) {
        console.log(name + "=>" + f_r(name));
        return f_r(name);
    }
    function log_flag_0(text) {
        console.log(getNowFormatDate() + "=>" + text);
        return text;
    }
    function log_flag_1(text, flag) {
        console.log(getNowFormatDate() + "[" + flag + "]" + "=>" + text);
        return text;
    }
    function log(text, flag) {
        if (flag == undefined || flag == "") {
            log_flag_0(text);
        } else {
            log_flag_1(text, flag);
        }
        return text;
    }
 
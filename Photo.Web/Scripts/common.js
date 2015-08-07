//从中获取参数值
function getQueryString(name) {
    //    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    //    var r = window.location.search.substr(1).match(reg);
    //    if (r != null) return unescape(r[2]); return '';
    if (window.location.href.indexOf('?') <= 0) return '';
    var paras = window.location.href.split('?')[1];
    paras = paras.split('&');
    for (var i = 0, j = paras.length; i < j; i++) {
        if (paras[i].indexOf(name) > -1) {
            return paras[i].split('=')[1];
        }
    }
    return '';
}
//根据名称读取一个Cookie值
function getCookie(c_name) {
    if (document.cookie.length > 0) {
        c_start = document.cookie.indexOf(c_name + "=")
        if (c_start != -1) {
            c_start = c_start + c_name.length + 1
            c_end = document.cookie.indexOf(";", c_start)
            if (c_end == -1) c_end = document.cookie.length
            return unescape(document.cookie.substring(c_start, c_end))
        }
    }
    return ""
}
//设置一个Cookie值
function setCookie(c_name, value, expiredays) {
    if (expiredays && expiredays != null && expiredays > 0) {
        var exdate = new Date()
        exdate.setDate(exdate.getDate() + expiredays)
        document.cookie = c_name + "=" + escape(value) + "; expires=" + exdate.toGMTString()
    }
    else {
        document.cookie = c_name + "=" + escape(value);
    }
}

function removeCookie(name) {
    setCookie(name, "", -1);
}

//返回上一页
function pageBack() {
    // var returnurl = getCookie('returnurl');
    // if(returnurl && returnurl.length>0){
    // document.location.href = returnurl;
    // return false;
    // }
    var a = window.location.href;
    if (/#top/.test(a)) {
        window.history.go(-2);
        window.location.load(window.location.href);
        return false;
    } else {
        window.history.back();
        window.location.load(window.location.href);
        return false;
    }
    return true;
}

/* 时间初始化
 * strTime {String} 字符串类型时间，必须是 yyyy-MM-dd HH:mm:ss格式的字符串
 */
Date.StrToDate = function (strTime) {
    
    return new Date(strTime.replace(/-/g, "/"));
}
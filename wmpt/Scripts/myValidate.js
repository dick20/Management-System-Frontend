var aCity = { 11: "北京", 12: "天津", 13: "河北", 14: "山西", 15: "内蒙古", 21: "辽宁", 22: "吉林", 23: "黑龙江", 31: "上海", 32: "江苏", 33: "浙江", 34: "安徽", 35: "福建", 36: "江西", 37: "山东", 41: "河南", 42: "湖北", 43: "湖南", 44: "广东", 45: "广西", 46: "海南", 50: "重庆", 51: "四川", 52: "贵州", 53: "云南", 54: "西藏", 61: "陕西", 62: "甘肃", 63: "青海", 64: "宁夏", 65: "新疆", 71: "台湾", 81: "香港", 82: "澳门", 91: "国外" }

function isCardID(sId) {
    var iSum = 0;
    var info = "";
    if (!/^\d{17}(\d|x)$/i.test(sId)) return "你输入的身份证长度或格式错误";
    sId = sId.replace(/x$/i, "a");
    if (aCity[parseInt(sId.substr(0, 2))] == null) return "你的身份证地区非法";
    sBirthday = sId.substr(6, 4) + "-" + Number(sId.substr(10, 2)) + "-" + Number(sId.substr(12, 2));
    var d = new Date(sBirthday.replace(/-/g, "/"));
    if (sBirthday != (d.getFullYear() + "-" + (d.getMonth() + 1) + "-" + d.getDate())) return "身份证上的出生日期非法";
    for (var i = 17; i >= 0; i--) iSum += (Math.pow(2, i) % 11) * parseInt(sId.charAt(17 - i), 11);
    if (iSum % 11 != 1) return "你输入的身份证号非法";
    return true; //aCity[parseInt(sId.substr(0,2))]+","+sBirthday+","+(sId.substr(16,1)%2?"男":"女")
}

//--身份证号码验证-支持新的带x身份证
function isIdCardNo(num) {
    var factorArr = new Array(7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2, 1);
    var error;
    var varArray = new Array();
    var intValue;
    var lngProduct = 0;
    var intCheckDigit;
    var intStrLen = num.length;
    var idNumber = num;
    // initialize
    if ((intStrLen != 15) && (intStrLen != 18)) {
        //error = "输入身份证号码长度不对！";
        //alert(error);
        //frmAddUser.txtIDCard.focus();
        return false;
    }
    // check and set value
    for (i = 0; i < intStrLen; i++) {
        varArray[i] = idNumber.charAt(i);
        if ((varArray[i] < '0' || varArray[i] > '9') && (i != 17)) {
            //error = "错误的身份证号码！.";
            //alert(error);
            //frmAddUser.txtIDCard.focus();
            return false;
        } else if (i < 17) {
            varArray[i] = varArray[i] * factorArr[i];
        }
    }
    if (intStrLen == 18) {
        //check date
        var date8 = idNumber.substring(6, 14);
        if (isDate8(date8) == false) {
            //error = "身份证中日期信息不正确！.";
            //alert(error);
            return false;
        }
        // calculate the sum of the products
        for (i = 0; i < 17; i++) {
            lngProduct = lngProduct + varArray[i];
        }
        // calculate the check digit
        intCheckDigit = 12 - lngProduct % 11;
        switch (intCheckDigit) {
            case 10:
                intCheckDigit = 'X';
                break;
            case 11:
                intCheckDigit = 0;
                break;
            case 12:
                intCheckDigit = 1;
                break;
        }
        // check last digit
        if (varArray[17].toUpperCase() != intCheckDigit) {
            //error = "身份证效验位错误!...正确为： " + intCheckDigit + ".";
            //alert(error);
            return false;
        }
    }
    else {        //length is 15
        //check date
        var date6 = idNumber.substring(6, 12);
        if (isDate6(date6) == false) {
            //alert("身份证日期信息有误！.");
            return false;
        }
    }
    //alert ("Correct.");
    return true;
}
function isDate6(sDate) {
    if (!/^[0-9]{6}$/.test(sDate)) {
        return false;
    }
    var year, month, day;
    year = sDate.substring(0, 4);
    month = sDate.substring(4, 6);
    if (year < 1700 || year > 2500) return false
    if (month < 1 || month > 12) return false
    return true
}

function isDate8(sDate) {
    if (!/^[0-9]{8}$/.test(sDate)) {
        return false;
    }
    var year, month, day;
    year = sDate.substring(0, 4);
    month = sDate.substring(4, 6);
    day = sDate.substring(6, 8);
    var iaMonthDays = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31]
    if (year < 1700 || year > 2500) return false
    if (((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0)) iaMonthDays[1] = 29;
    if (month < 1 || month > 12) return false
    if (day < 1 || day > iaMonthDays[month - 1]) return false
    return true
}
$.extend($.fn.validatebox.defaults.rules, {
    equalsUserName: {
        validator: function (value, param) {
            var bool = false;
            $.ajax({
                url: '../handler/RegistHandler.ashx?Entity=user&OPRAction=equalsUserName',
                data: { "userName": value },
                type: 'post',
                dataType: 'json',
                async: false,
                success: function (data) {
                    if (data.ErrCode == 1) {
                        alert(data.ErrMessage);
                        top.location.href = "login.aspx";
                    }
                    else if (data.ErrCode == 2) {
                        alert(data.ErrMessage);
                    }
                    else {
                        if (data.msg == "false") {
                            bool = true;
                        }
                    }
                }
            })
            return bool;
        },
        message: '您所填写的用户名重复'
    },
    equalTo: {
        validator: function (value, param) {
            return value == $(param[0]).val();
        },
        message: '两次密码不一致'
    },
    //移动手机号码验证
    mobile: {//value值为文本框中的值
        validator: function (value) {
            var reg = /^1[3|4|5|8|9]\d{9}$/;
            return reg.test(value);
        },
        message: '输入手机号码格式不准确.'
    },
    number: {
        validator: function (value, param) {
            return /^[0-9]*$/.test(value);
        },
        message: '请输入数字'
    },
    //验证邮编
    zipcode: {
        validator: function (value) {
            var reg = /^[1-9]\d{5}$/;
            return reg.test(value);
        },
        message: '邮编必须是非0开始的6位数字.'
    },
    idcard: {
        validator: function (value, param) {
            //var flag = isCardID(value);
            var flag = isIdCardNo(value);
            return flag == true ? true : false;
        },
        message: '不是有效的身份证号码'
    },

    phone: {// 验证电话号码
        validator: function (value) {
            return /^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$/i.test(value);
        },
        message: '格式不正确,请使用下面格式:029-88888888'
    },
    qq: {// 验证QQ,从10000开始
        validator: function (value) {
            return /^[1-9]\d{4,9}$/i.test(value);
        },
        message: 'QQ号码格式不正确'
    },

    integer: {// 验证整数
        validator: function (value) {
            return /^[+]?[1-9]+\d*$/i.test(value);
        },
        message: '请输入整数'
    },

    faxno: {// 验证传真
        validator: function (value) {
            return /^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$/i.test(value);
        },
        message: '传真号码不正确'
    },

    enstr: {// 验证之只能输入英文
        validator: function (value) {
            return /^([u4e00-u9fa5]|[ufe30-uffa0]|[a-za-z0-9_])*$/i.test(value);
        },
        message: '只能输入英文'
    },

    zhstr: {// 验证之只能输入中文
        validator: function (value) {
            return /^[u4E00-u9FA5]+$/i.test(value);
        },
        message: '只能输入中文'
    },
    passstrength: {// 验证之只能输入中文
        validator: function (value) {
            var strongRegex = new RegExp("^(?=.{8,})(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*\\W).*$", "g");
            var mediumRegex = new RegExp("^(?=.{7,})(((?=.*[A-Z])(?=.*[a-z]))|((?=.*[A-Z])(?=.*[0-9]))|((?=.*[a-z])(?=.*[0-9]))).*$", "g");
            var enoughRegex = new RegExp("(?=.{6,}).*", "g");
            var bool = true;

            if (false == enoughRegex.test(value)) {
                bool = false;
                msg = "密码强度：过弱";
            } else if (strongRegex.test(value)) {
                bool = true;
                msg = "密码强度：强";
            } else if (mediumRegex.test(value)) {
                bool = false;
                msg = "密码强度：中";
            } else {
                bool = false;
                msg = "密码强度：弱";
            }

            return b;
        },
        message: "密码强度不够"
    },

    loginName: {
        validator: function (value, param) {
            return /^[\u0391-\uFFE5\w]+$/.test(value)
        },
        message: '用户名称只允许汉字、英文字母、数字及下划线'
    },
    //时间区间验证
    isAfter: {
        validator: function (value, param) {
            var dateA = $.fn.datebox.defaults.parser(value);
            var dateB = $.fn.datebox.defaults.parser($(param[0]).datebox('getValue'));
            var n = dateA.getTime() - dateB.getTime();

            return n > 0;
        },
        message: '结束时间不能小于开始时间'
    },
    isEqualOrAfter: {
        validator: function (value, param) {
            var dateA = $.fn.datebox.defaults.parser(value);
            var dateB = $.fn.datebox.defaults.parser($(param[0]).datebox('getValue'));
            var n = dateA.getTime() - dateB.getTime();
            return n >= 0;
        },
        message: '结束时间不能小于开始时间'
    },
    isLaterToday: {
        validator: function (value, param) {
            var date = $.fn.datebox.defaults.parser(value);
            return date > new Date();
        },
        message: '开始时间不能小于今天'
    },
    zzjgdm: {//组织机构代码证
        validator: function (value) {
            return /^[a-zA-Z0-9]{8}-[a-zA-Z0-9]$/i.test(value);
        },
        message: '请输入中文正确的组织机构代码'
    },
    max: {
        validator: function (value, param) {
            return param[0] >= value;
            alert(param);
        },
        message: '学时数不能大于{0}小时'
    }
});



/* 显示遮罩层 */
function showOverlay() {
    $("#overlay").height(pageHeight());
    $("#overlay").width(pageWidth());

    $("#overlay").show();
    // fadeTo第一个参数为速度，第二个为透明度
    // 多重方式控制透明度，保证兼容性，但也带来修改麻烦的问题
//    $("#overlay").fadeTo(200, 0.5);
}

/* 隐藏覆盖层 */
function hideOverlay() {
//    $("#overlay").fadeOut(200);
    $("#overlay").hide();
}

/* 当前页面高度 */
function pageHeight() {
    return $(window).height();
}

/* 当前页面宽度 */
function pageWidth() {
    return $(window).width();
}




function loginOut(flag) {

    var msgs = "确定要";
    if (flag == 1)
        msgs += "注销吗？";
    else
        msgs += "退出系统吗？";

    if (!confirm(msgs)) {
        return;
    }

    $.ajax({
        url: '../handler/CommonHandler.ashx?Entity=common&OPRAction=loginout',
        data: null,
        type: 'post',
        dataType: "json",
        success: function (data) {
            if (data.ErrCode == 1) {
                alert(data.ErrMessage);
                top.location.href = "login.aspx";
            }
            else if (data.ErrCode == 2) {
                alert(data.ErrMessage);
            }
            else {
                if (flag == 1) {
                    alert(data.msg);
                    top.location.href = "login.aspx";
                }
                else {
                    alert("成功退出系统！")
                    //window.opener=null;
                    window.open('', '_self', '');
                    window.close();

                }
            }

        }

    });


}
String.prototype.trim = function () {
    return this.replace(/(^\s*)|(\s*$)/g, '');
};
function ValidCheck() {
   // alert("aaaaaaaaaaaaa");
   // var mstr = "AAA";
   // mstr = mstr.trim();
    //alert("mstr=" + mstr);
    //debugger;
    var arrAll = document.all;
   // alert("all=" + arrAll.length);
    var i = 0;
    // alert("arrAll.length=" + arrAll.length);
    var mValid = true;
    for (i = 0; i < arrAll.length; i++) {
        //alert("i=" + i);
        var mobj = arrAll[i];
       // debugger;
     // alert(mobj);
        var mAttr = mobj.getAttribute('DataSource');
        var mIsEdit = mobj.getAttribute("isEdit");
        var mValue = mobj.getAttribute('value');
        if (mValue == null)
            mValue = mobj.value;
        var mErrHint = "";

        var id = mobj.getAttribute('id');
//        if(id=="Text56")
//         debugger;
        if (mobj.getAttribute('ErrHint') != null) {
            mErrHint = mobj.getAttribute('ErrHint');   }
        var mLen = 0;
        if (mIsEdit == "1") {
            var mIsControl = mobj.getAttribute("IsControl");
           // alert("mIsControl" + mIsControl);
            if (mIsControl!=null&&mIsControl.trim()!= "") {
                //alert("enter!");
                if (mobj.getAttribute('StrLen')) {
                    mLen = parseInt(mobj.getAttribute('StrLen'));
                }
            // debugger;
                var mMess = CheckValue(mValue, mIsControl.trim(), mLen);
                if (mMess != "") {
                    alert(mErrHint + " " + mMess);
                    mValid = false;
                    // mobj.focus();
                    mobj.onfocus = "";
                    mobj.focus();
                    break;
                }
            }
        }
    }


    return mValid;
}
function CheckValue(Value, CtrType, StrLen) {
    var mMess = "";
    CtrType = CtrType.toUpperCase();
    switch (CtrType) {
        case "INT":
            if (!isInt(Value)) {
                mMess = Value + "不是整数!";

            }
            break;
        case "STRING":
            if (!sMaxStrleng(Value, StrLen)) {
                mMess = Value + "字符串长度超出" + StrLen + "!";
            }


            break;
        case "DECIMAL":
            if (!isFloat(Value)) {
                mMess = Value + "不是数字!";
            }
            break;
        case "DATE":
            if (!shorDateCheck(Value)) {
                mMess = Value + "不是正确的日期!";
            }

            break;
        default:
            break;


    }
    return mMess;
}

function DataSave() {
//alert("start.....");
//debugger;
 
if (!ValidCheck()) {
           return;

    }
    var AllDataSource = new Array();
    var AllDataInfo = new Array();
    var arrAll = document.all;
    var i, j;
 // alert("arrAll="+arrAll.length);
    for (i = 0; i < arrAll.length; i++) {

        var mobj = arrAll[i];
    // alert("id="+arrAll[i].id);
        //              alert("fieldIDValue="+mobj.getAttribute('FieldIDValue'));
        var mAttr = mobj.getAttribute('DataSource');
        var mSubmit = mobj.getAttribute("isSubmit");
        var mExist = false;
        var k = -1;
        var nObj;
        if (mAttr != null && mSubmit == "1") {
            mExist = false;
            k = -1;
            for (j = 0; j < AllDataSource.length; j++) {
                if (AllDataSource[j].SourceName == mAttr) {
                    k = j;
                    break;
                }
            }
            //----------------------------//
  //         alert("k=" + k);
            if (k == -1) {
                nObj = new Object();
                nObj.SourceName = mAttr;
                nObj.Columns = new Array();
                AllDataSource[AllDataSource.length] = nObj;

                k = AllDataSource.length - 1;
                // alert("k1=" + k);
            }
            var kk = -1;
            var mFieldName = mobj.getAttribute('FieldName');
            var mFieldType = mobj.getAttribute('FieldType');
            for (j = 0; j < AllDataSource[k].Columns.length; j++) {
                if (AllDataSource[k].Columns[j].FieldName == mFieldName) {
                    kk = j;
                    break;
                }

            }
            //alert("kk=" + kk);
            if (kk == -1) {
                kk = AllDataSource[k].Columns.length;
                nobj = new Object();
                nobj.FieldName = mFieldName;
                nobj.FieldType = mFieldType;
                //alert("kk1=" + kk);

                AllDataSource[k].Columns[kk] = nobj;
                //alert("AllDataSource[k].Columns[kk] fieldName=" + AllDataSource[k].Columns[kk].FieldName);

            }
        }
    }

    //alert("ok over!");
    //----------------------------------------------------------------------//
    AllDataInfo = new Array(AllDataSource.length);
    //alert("ok1111 over!=" + AllDataInfo.length);
    for (i = 0; i < AllDataInfo.length; i++) {
        //alert(" start..... !");
        AllDataInfo[i] = new Object();
        AllDataInfo[i].datas = new Array();
    }
    // alert(" start !");

    for (i = 0; i < arrAll.length; i++) {
        var mobj = arrAll[i];
        var mAttr = mobj.getAttribute('DataSource');
        var mSubmit = mobj.getAttribute("isSubmit");
        var mFieldName = mobj.getAttribute('FieldName');
        var mFieldIDName = mobj.getAttribute('FieldIDName');
        var mFieldIDValue = mobj.getAttribute('FieldIDValue');
        var mFieldType = mobj.getAttribute('FieldType');
        var mIDName = mobj.getAttribute('IDName');
        var mIDValue = mobj.getAttribute('IDValue');

        var mSourceId = -1;
        if (mAttr != null && mSubmit == "1") {
            //  var mFieldValue = mobj.getAttribute('value');
            //debugger;
            var mFieldValue = mobj.value;
           
            //
            //alert("value=" + mFieldValue);
            for (j = 0; j < AllDataSource.length; j++) {
                //alert();
                if (AllDataSource[j].SourceName == mAttr) {
                    mSourceId = j;
                    break;
                }
            }
            // alert("mSourceId=" + mSourceId);
            var mRowIndex = -1;
            for (j = 0; j < AllDataInfo[mSourceId].datas.length; j++) {

                //alert("1=" + AllDataInfo[mSourceId].datas[j][1].Fieldvalue + "   2=" + mFieldIDValue);
                if (AllDataInfo[mSourceId].datas[j][1].FieldValue == mFieldIDValue)  //code 业务关键字
                {
                    mRowIndex = j;
                    break;
                }
            }
            // alert("mRowIndex=" + mRowIndex);
            if (mRowIndex == -1) {
                AllDataInfo[mSourceId].datas[AllDataInfo[mSourceId].datas.length] = new Array(AllDataSource[mSourceId].Columns.length + 2); //第1个记录 2013-12-25

                mRowIndex = AllDataInfo[mSourceId].datas.length - 1;
                //                      alert("row1=" + mFieldIDName);
                //                      alert("row length=" + AllDataInfo[mSourceId].datas[mRowIndex].length);
                AllDataInfo[mSourceId].datas[mRowIndex][0] = new Object();
                AllDataInfo[mSourceId].datas[mRowIndex][0].FieldName = mIDName;
                AllDataInfo[mSourceId].datas[mRowIndex][0].FieldValue = mIDValue;
                AllDataInfo[mSourceId].datas[mRowIndex][0].FieldType = "int";

                AllDataInfo[mSourceId].datas[mRowIndex][1] = new Object();
                AllDataInfo[mSourceId].datas[mRowIndex][1].FieldName = mFieldIDName;
                AllDataInfo[mSourceId].datas[mRowIndex][1].FieldValue = mFieldIDValue;
                AllDataInfo[mSourceId].datas[mRowIndex][1].FieldType = "string";
                //                      alert("row2=" + mFieldIDName);
                //                      alert("row3="+AllDataInfo[mSourceId].datas[mRowIndex].length);
                for (j = 2; j < AllDataInfo[mSourceId].datas[mRowIndex].length; j++) {
                    AllDataInfo[mSourceId].datas[mRowIndex][j] = new Object();
                    //                          alert("row4=" + AllDataInfo[mSourceId].datas[mRowIndex].length);
                    //                          alert("j=" + j);
                    //                          alert("length=" + AllDataSource[mSourceId].Columns.length);
                    //                          var mm=AllDataSource[mSourceId].Columns[j];
                    //                          for (var p in mm) {
                    //                             alert("p="+mm[p]);
                    //                          }
                    //                          alert("row4 FieldName=" + AllDataSource[mSourceId].Columns[j-1].FieldName);
                    AllDataInfo[mSourceId].datas[mRowIndex][j].FieldName = AllDataSource[mSourceId].Columns[j - 2].FieldName;  //-1
                    //                          alert("row5=" + AllDataInfo[mSourceId].datas[mRowIndex].length);

                    AllDataInfo[mSourceId].datas[mRowIndex][j].FieldType = AllDataSource[mSourceId].Columns[j - 2].FieldType;      // mFieldType;
                    //                          alert("row6=" + AllDataInfo[mSourceId].datas[mRowIndex].length);

                    if (mFieldType.toUpperCase() != "string".toUpperCase() && mFieldType.toUpperCase() != "date".toUpperCase()) {
                        AllDataInfo[mSourceId].datas[mRowIndex][j].FieldValue = 0;
                    }
                    else {
                        AllDataInfo[mSourceId].datas[mRowIndex][j].FieldValue = "";
                    }
                }
            }
            var k = -1;
            for (j = 0; j < AllDataInfo[mSourceId].datas[mRowIndex].length; j++) {
                if (AllDataInfo[mSourceId].datas[mRowIndex][j].FieldName.toUpperCase() == mFieldName.toUpperCase()) {
                    k = j;
                    break;
                }
            }
            mFieldType = AllDataInfo[mSourceId].datas[mRowIndex][k].FieldType;
            if (AllDataInfo[mSourceId].datas[mRowIndex][k].FieldName.toUpperCase() == "ReportDate".toUpperCase()) {
            }
            if (mFieldType.toUpperCase() != "string".toUpperCase() && mFieldType.toUpperCase() != "date".toUpperCase()) {
                AllDataInfo[mSourceId].datas[mRowIndex][k].FieldValue = Number(mFieldValue);
            }
            else {
                AllDataInfo[mSourceId].datas[mRowIndex][k].FieldValue = mFieldValue;
            }
        }

    }
   //  alert("finished !");
    //---------------------------导出Json格式--------------------------------------------//
    var mJsstr = "";
    var OutObj = new Object();
    for (i = 0; i < AllDataInfo.length; i++) {
        mJsstr = '{"rows":[';

        //  alert("i=" + i);
        for (j = 0; j < AllDataInfo[i].datas.length; j++) {
            mJsstr += "{";
            //   alert("j=" + j);

            for (k = 0; k < AllDataInfo[i].datas[j].length; k++) {
                if (AllDataInfo[i].datas[j][k].FieldType.toUpperCase() != "string".toUpperCase()) {
                    mJsstr += "" + AllDataInfo[i].datas[j][k].FieldName + ":" + AllDataInfo[i].datas[j][k].FieldValue;
                }
                else {
                    mJsstr += "" + AllDataInfo[i].datas[j][k].FieldName + ":\"" + AllDataInfo[i].datas[j][k].FieldValue + "\"";

                }
                //   alert("mstr=" + mJsstr);
                if (k != AllDataInfo[i].datas[j].length - 1) {
                    mJsstr += ",";
                }
            }
            mJsstr += "}";

            if (j != AllDataInfo[i].datas.length - 1) {
                mJsstr += ",";
            }

        }
        mJsstr += "]}";
        OutObj[AllDataSource[i].SourceName] = mJsstr;
    }
    var mSourceNamestr = "";
    for (i = 0; i < AllDataSource.length; i++) {
        if (i < AllDataSource.length - 1) {
            mSourceNamestr += AllDataSource[i].SourceName + ",";
        }
        else {
            mSourceNamestr += AllDataSource[i].SourceName;
        }
    }
    OutObj["DataSouceNames"] = mSourceNamestr;
    UPFileIDs = GetUpFileIDS();
   // debugger;
   // alert("UPFileIDs" + UPFileIDs.length);
    SubMit(OutObj, UPFileIDs);
}
function GetUpFileIDS() {
    var arrAll = document.all;
    var i = 0;
    // alert("arrAll.length=" + arrAll.length);
    var UPFileIDs = new Array();
    var k = 0;
    for (i = 0; i < arrAll.length; i++) {
        var mobj = arrAll[i];
        if (mobj.tagName.toUpperCase() == "input".toUpperCase()) {
            var mType = mobj.getAttribute("type");
            if (mType != null && mType.toUpperCase() == "file".toUpperCase()) {
                UPFileIDs[k] = mobj.getAttribute("id");
               // alert("UPFile=" + UPFileIDs[k]);
                k++;
            }
        }
    }
    return UPFileIDs;
}    
 //必需是整数
function isInt(str) {
    //alert("enter!");
    //var reg = "^(-|/+)?/d+$";
    var reg = "^-?\\d+$";
   reg = new RegExp(reg);
  //alert("out");
  return reg.test(str);
 }

//  //必需是小数
 function isFloat(str){
  if(isInt(str))
   return true;
 // var reg = "^(-|/+)?/d+/./d*$";
  var reg = "^(-?\\d+)(\\.\\d+)?$";
  reg = new RegExp(reg);
  return reg.test(str);
 }

////2.2 短日期，形如 (2003-12-05)  
 function shorDateCheck(str) {
//    var re = "^(/d{1,4})(-|//)(/d{1,2})/2(/d{1,2})$";
//    re = new RegExp(re); 
//    var r = str.match(re);   
//    if(r==null)
//       return false;   
//    var d= new Date(r[1], r[3]-1, r[4]);   
     //    return (d.getFullYear()==r[1]&&(d.getMonth()+1)==r[3]&&d.getDate()==r[4]);
//     var r = "^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$";

//     // var r = new RegExp("^[1-2]\\d{3}-(0?[1-9]||1[0-2])-(0?[1-9]||[1-2][1-9]||3[0-1])$");
     //     r = new RegExp(r);
    // var r = /^(?:(?!0000)[0-9]{4}-(?:(?:0[1-9]|1[0-2])-(?:0[1-9]|1[0-9]|2[0-8])|(?:0[13-9]|1[0-2])-(?:29|30)|(?:0[13578]|1[02])-31)|(?:[0-9]{2}(?:0[48]|[2468][048]|[13579][26])|(?:0[48]|[2468][048]|[13579][26])00)-02-29)$/;
     var r ="^(?:(?!0000)[0-9]{4}-(?:(?:0[1-9]|1[0-2])-(?:0[1-9]|1[0-9]|2[0-8])|(?:0[13-9]|1[0-2])-(?:29|30)|(?:0[13578]|1[02])-31)|(?:[0-9]{2}(?:0[48]|[2468][048]|[13579][26])|(?:0[48]|[2468][048]|[13579][26])00)-02-29)$";
     r = new RegExp(r);
    return r.test(str);

 }
//2.3 长时间，形如 (2003-12-05 13:04:06)  
// function longDateCheck(str)
// {
//  var reg = /^(/d{1,4})(-|//)(/d{1,2})/2(/d{1,2}) (/d{1,2}):(/d{1,2}):(/d{1,2})$/;   
//        var r = str.match(reg);   
//        if(r==null)
//   return false;   
//        var d= new Date(r[1], r[3]-1,r[4],r[5],r[6],r[7]);   
//        return (d.getFullYear()==r[1]&&(d.getMonth()+1)==r[3]&&d.getDate()==r[4]&&d.getHours()==r[5]&&d.getMinutes()==r[6]&&d.getSeconds()==r[7]);  
// }
////3.3 多行文本框的值不能超过sMaxStrleng  
 function sMaxStrleng(str,len)
 {
    // if (!isObj(str))
     //return 'undefined';
     //   return false;
   //debugger
  str=$.trim(str);
  if(len>0&&str.length>len)
   return false;
  return true;
}


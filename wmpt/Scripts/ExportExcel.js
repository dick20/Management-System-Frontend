function TableToXmlDemo(tableID, tableType,tableName) {

    if (tableType == "0")  //0:easyuitDatagrid      1:htmlTable
    {
        var tabObj = $("#" + tableID);
        var mfirtcolom = tabObj.datagrid("getPanel");
        var mtable = mfirtcolom.find("TABLE.datagrid-htable");
        var mtable2 = mfirtcolom.find("TABLE.datagrid-btable");

        mtable2 = mtable2[0];
        //                               var innerHTML = mtable2.innerHTML;
        //                               $("#tb2").val(innerHTML);

        //                               document.getElementById("tb2").attributes["value"] = innerHTML;

        //  debugger;


        mtable = mtable[1];

        //   $("#tb1")[0].value = mtable.innerHTML;

        //tabObj.datagrid("getPanel").panel("setTitle", "1111");

        var dataGridTitle = tabObj.datagrid("options").title;

        // mfirtcolom.datagrid("settitle","oooo");
        //alert("dataGridTitle=" + dataGridTitle);

        var str = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";
        str += "<root  title='" + dataGridTitle + "' >";

        //                               //  表头
        for (var i = 0; i < mtable.rows.length; i++) {

            str += "<row >";
            for (var j = 0; j < mtable.rows[i].cells.length; j++) {
                str += "<cloumn ";

                str += " colSpan='" + mtable.rows[i].cells[j].colSpan + "' rowSpan='" + mtable.rows[i].cells[j].rowSpan + "' ";

                str += " >" + "<![CDATA[" + mtable.rows[i].cells[j].innerText + "]]>" + "</cloumn> ";
                ;

            }
            str += "</row >";
        }

        //  正文表

        for (var i = 0; i < mtable2.rows.length; i++) {

            str += "<row >";
            for (var j = 0; j < mtable2.rows[i].cells.length; j++) {
                str += "<cloumn ";

                str += " colSpan='" + mtable2.rows[i].cells[j].colSpan + "' rowSpan='" + mtable2.rows[i].cells[j].rowSpan + "' ";

                str += " >" + "<![CDATA[" + mtable2.rows[i].cells[j].innerText + "]]>" + "</cloumn> ";
                ;

            }
            str += "</row >";
        }

        str += "</root>";
        str += "";
    }

    else if (tableType == "1") {

        var tabObj = $("#" + tableID);
        var mtable = tabObj[0];


        var dataGridTitle = tableName;

       

        var str = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";
        str += "<root  title='" + dataGridTitle + "' >";

     
        for (var i = 0; i < mtable.rows.length; i++) {

            str += "<row >";
            for (var j = 0; j < mtable.rows[i].cells.length; j++) {
                str += "<cloumn ";

                str += " colSpan='" + mtable.rows[i].cells[j].colSpan + "' rowSpan='" + mtable.rows[i].cells[j].rowSpan + "' ";

                str += " >" + "<![CDATA[" + mtable.rows[i].cells[j].innerText + "]]>" + "</cloumn> ";
                ;

            }
            str += "</row >";
        }

        str += "</root>";
        str += "";
    
    
    
    }

    return str;



}


function add_tabRow(mTableID, mBtnID, mMaxNum) {//动态添加表格行
    var tab = document.getElementById(mTableID);
   // debugger;
    if (tab.style.display == "none" || tab.style.display == "") {
        tab.style.display = "block";
        return;
    }
    var oTr = document.getElementById(mTableID).rows[1];
    var newTr = oTr.cloneNode(true);
    document.getElementById(mTableID).getElementsByTagName("tbody")[0].appendChild(newTr);
    newTr.cells[0].firstChild.value = newTr.rowIndex;

    for (var k = 1; k < newTr.cells.length; k++)
        newTr.cells[k].firstChild.value = "";
    document.getElementById(mBtnID).disabled = newTr.rowIndex == mMaxNum;
}

function del_tabRow(mTableID, mRowID,mAddBtnID) {//动态删除表格行
    var tab = document.getElementById(mTableID);
    if (tab.rows.length != 2) {
        //debugger;
        tab.deleteRow(mRowID);  //从table中删除
        document.getElementById(mAddBtnID).disabled = false;
    }
    else
        tab.style.display = "none";
}


using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

/// <summary>
///XmltoExceldemo 的摘要说明
/// </summary>
/// 
namespace Common.Excel
{
    public struct range
    {
        public int FromCol;
        public int ToCol;
        public int FromRow;
        public int ToRow;
    }
    public class XmltoExceldemo
    {
        public XmltoExceldemo()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }




        public string Process(string mXml, string CountryCode)
        {
           
            string excelFile = "";
            List<range> mRangeList = new List<range>();
            range mRange;
            // string mXml = "";
            //mXml = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";
            //mXml += "<Root>";
            XmlDocument mXmlDocument = new XmlDocument();
            mXmlDocument.LoadXml(mXml);
            XmlNode mRoot = mXmlDocument.DocumentElement;
            string dataGridTitle = mRoot.Attributes["title"].Value.ToString();
            string[] valTiltle = dataGridTitle.Split(',');  //多行表头以，隔开
            int RowCount = mRoot.ChildNodes.Count;//行数；
            int i, j, k, l;
            int CurRow;
            int ValidCol = -1;
            bool[] ColArray = new bool[255];
            int mRowSpan = 1, mColSpan = 1;
            string cellValue = "";

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();


            excel.Visible = false;// 后台运行不可见

            // //新增加一个工作簿，Workbook是直接保存，不会弹出保存对话框，加上Application会弹出保存对话框，值为false会报错  
            excel.Application.Workbooks.Add(true);

            Microsoft.Office.Interop.Excel.Worksheet xlSheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.Worksheets[1];
            try
            {
                for (i = 0; i < mRoot.ChildNodes.Count; i++)
                {
                    for (j = 0; j < mRoot.ChildNodes[i].ChildNodes.Count; j++)
                    {
                        cellValue = "";
                        CurRow = i;
                        mRowSpan = int.Parse(mRoot.ChildNodes[i].ChildNodes[j].Attributes["rowSpan"].Value.ToString().Trim());
                        mColSpan = int.Parse(mRoot.ChildNodes[i].ChildNodes[j].Attributes["colSpan"].Value.ToString().Trim());
                        for (k = 0; k < ColArray.Length; k++)
                        {
                            ColArray[k] = false;
                        }
                        for (k = 0; k < mRangeList.Count; k++)
                        {
                            if (mRangeList[k].FromRow <= CurRow + 1 && CurRow + 1 <= mRangeList[k].ToRow)
                            {
                                for (l = mRangeList[k].FromCol; l <= mRangeList[k].ToCol; l++)
                                {
                                    ColArray[l - 1] = true;
                                }
                            }
                        }

                        //获取起始列
                        ValidCol = 1;
                        for (k = 0; k < ColArray.Length; k++)
                        {
                            if (!ColArray[k])
                            {
                                ValidCol = k + 1;
                                break;
                            }
                        }


                        mRange = new range();
                        mRange.FromRow = CurRow + 1;
                        mRange.ToRow = CurRow + mRowSpan;
                        mRange.FromCol = ValidCol;
                        mRange.ToCol = ValidCol + mColSpan - 1;
                        mRangeList.Add(mRange);
                        //处理Excel 合并单元格，并赋值
                        //InnerText
                        cellValue = mRoot.ChildNodes[i].ChildNodes[j].InnerText;
                        if (mRowSpan == 1 && mColSpan == 1)
                        {
                             
                           ((Microsoft.Office.Interop.Excel.Range)xlSheet.Cells[mRange.FromRow, mRange.FromCol]).NumberFormatLocal = "@";//设置为文本
                            xlSheet.Cells[mRange.FromRow, mRange.FromCol] = cellValue;
                           
                            ((Microsoft.Office.Interop.Excel.Range)xlSheet.Cells[mRange.FromRow, mRange.FromCol]).Borders.LineStyle = 1;
                            ((Microsoft.Office.Interop.Excel.Range)xlSheet.Cells[mRange.FromRow, mRange.FromCol]).WrapText = true;
                        }
                        else
                        {
                            Microsoft.Office.Interop.Excel.Range range = xlSheet.get_Range(xlSheet.Cells[mRange.FromRow, mRange.FromCol], xlSheet.Cells[mRange.ToRow, mRange.ToCol]); //合并单元格
                            range.NumberFormatLocal = "@";//设置为文本      
                            range.MergeCells = true;
                            range.Value2 = cellValue;
                            range.Cells.Borders.LineStyle = 1;
                            range.WrapText = true;

                        }
                    }
                }

                //----------插入台头----------//
                int maxCol = 1;
                for (k = 0; k < mRangeList.Count; k++)
                {
                    if (mRangeList[k].ToCol > maxCol)
                    {
                        maxCol = mRangeList[k].ToCol;
                    }
                }
                int index = 1;

                for (int s = valTiltle.Length - 1; s >= 0; s--)
                {

                    Microsoft.Office.Interop.Excel.Range insertrange = (Microsoft.Office.Interop.Excel.Range)xlSheet.Rows[index, Type.Missing];
                    Microsoft.Office.Interop.Excel.Range insertrange1 = (Microsoft.Office.Interop.Excel.Range)xlSheet.Rows[index, Type.Missing];

                    insertrange.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlDirection.xlDown,
                        Microsoft.Office.Interop.Excel.XlInsertFormatOrigin.xlFormatFromLeftOrAbove);

                    insertrange = xlSheet.get_Range(xlSheet.Cells[1, 1], xlSheet.Cells[1, maxCol]); //合并单元格
                    insertrange.MergeCells = true;
                    insertrange.Value2 = valTiltle[s];
                    insertrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                    insertrange.Cells.Borders.LineStyle = 0;
                    insertrange.Font.Bold = true;



                    //设置列宽
                    insertrange.Columns.ColumnWidth = 10;
                    //if (valTiltle.Length > 1)
                    //{
                    //    insertrange.Columns.ColumnWidth = 50;
                    //    insertrange1 = xlSheet.get_Range("a1");
                    //    insertrange1.Columns.ColumnWidth = 7;
                    //}
                    //else
                    //{
                    //    insertrange1 = xlSheet.get_Range("a1");
                    //    insertrange1.Columns.ColumnWidth = 10;

                    //}

                }


                //--------------------------//



                //保存文件

                excel.DisplayAlerts = false;
                excel.AlertBeforeOverwriting = false;
                excel.Visible = true;
                excel.UserControl = false;



                excelFile = CountryCode + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

                // excelFile=System.Web.HttpContext.Current.Server.MapPath("/upload/" + excelFile);

                excel.ActiveWorkbook.SaveCopyAs(System.Web.HttpContext.Current.Server.MapPath("../upload/download/" + excelFile));

            }

            finally
            {
                //确保Excel进程关闭  
                excel.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject((object)excel);
                GC.Collect();

            }
            return excelFile;

        }

    }
}

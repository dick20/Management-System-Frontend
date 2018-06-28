using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Json;
/// <summary>
///JsonHelp 的摘要说明
/// </summary>
/// 
namespace Common.Json
{
    public class JsonHelp
    {
        private JavaScriptSerializer js;
        private  Dictionary<string, object> dic;
        private DataTable dataDS;
        private Object obj;
        public JsonHelp(DataTable ds,bool isTotal)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
       
            dic = new Dictionary<string, object>();
            dataDS = ds;
            if (isTotal)
            {
                dic.Add("total", dataDS.Rows.Count);
            }
          
            int i,j;
            IDictionary<string, object>[] dArray = new Dictionary<string, object>[dataDS.Rows.Count];

            for (i = 0; i < dataDS.Rows.Count; i++)
            {

                IDictionary<string, object>dictionaryArray = new Dictionary<string, object>();
                for (j = 0; j < dataDS.Columns.Count; j++)
                {
                    dictionaryArray.Add(dataDS.Columns[j].ColumnName, dataDS.Rows[i][j].ToString());

                }
                dArray[i] = dictionaryArray;
            }
            dic.Add("rows", dArray);
            dic.Add("ErrCode", 0);

        }
        public JsonHelp(DataTable ds,int rowCount, bool isTotal)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            dic = new Dictionary<string, object>();
            dataDS = ds;
            if (isTotal)
            {
                dic.Add("total", rowCount);
            }

            int i, j;
            IDictionary<string, object>[] dArray = new Dictionary<string, object>[dataDS.Rows.Count];

            for (i = 0; i < dataDS.Rows.Count; i++)
            {

                IDictionary<string, object> dictionaryArray = new Dictionary<string, object>();
                for (j = 0; j < dataDS.Columns.Count; j++)
                {
                    dictionaryArray.Add(dataDS.Columns[j].ColumnName, dataDS.Rows[i][j].ToString());

                }
                dArray[i] = dictionaryArray;
            }
            dic.Add("rows", dArray);
            dic.Add("ErrCode", 0);

        }
        public JsonHelp(Object obj)
        {
            this.obj = obj;
        }
        public JsonHelp(int Errcode,string ErrMessage)
        {
            dic = new Dictionary<string, object>();
            dic.Add("ErrCode",Errcode);
            dic.Add("ErrMessage",ErrMessage);

        }
        public JsonHelp(int Errcode, string ErrMessage, IDictionary<string, object>[] dArray)
        {
            dic = new Dictionary<string, object>();
            dic.Add("ErrCode", Errcode);
            dic.Add("ErrMessage", ErrMessage);
            dic.Add("ErrList", dArray);

        }

        public JsonHelp(int Errcode, string ErrMessage, IDictionary<string, object> dArray)
        {
            dic = new Dictionary<string, object>();
            dic.Add("ErrCode", Errcode);
            dic.Add("ErrMessage", ErrMessage);
            dic.Add("ErrList", dArray);

        }

        public JsonHelp(int Errcode, string ErrMessage, ArrayList dArray)
        {
            dic = new Dictionary<string, object>();
            dic.Add("ErrCode", Errcode);
            dic.Add("ErrMessage", ErrMessage);
            dic.Add("ErrList", dArray);

        }

        public void Add(string ObjName, object value)
        {
            dic.Add(ObjName,value);
        }
        public string Serialize()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            
            return js.Serialize(dic);
        }
        public string SerializeObj()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(obj);
        }
       public static T JosnDeserialize<T>(string input)  
       {  
           //if (string.IsNullOrEmpty(input))  
           //    return default(T);  
           //try  
           {  
               JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
               return jsSerializer.Deserialize<T>(input);
  
           }  
           //catch (InvalidOperationException)  
           //{  
           //    return default;  
           //}  
        }
       public static List<T> isEfect<T>(string json)
       {
           MemoryStream stream2 = new MemoryStream();
           DataContractJsonSerializer ser2 = new DataContractJsonSerializer(typeof(List<T>));
           StreamWriter wr = new StreamWriter(stream2);
           wr.Write(json);
           wr.Flush();
           stream2.Position = 0;
           Object obj = ser2.ReadObject(stream2);
           List<T> list = (List<T>)obj;
           return list;
       }

       public static T isEfect1<T>(string json)//反序列化json对象
       {
           MemoryStream stream3 = new MemoryStream();

           DataContractJsonSerializer ser3 = new DataContractJsonSerializer(typeof(T));

           StreamWriter wr = new StreamWriter(stream3);

           wr.Write(json);
           wr.Flush();
           stream3.Position = 0;
           Object mObj = ser3.ReadObject(stream3);
           T mData = (T)mObj;
           return mData;
       
              
       }
    }

   
}
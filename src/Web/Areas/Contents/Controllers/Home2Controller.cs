using Qx.Contents.Repository;
using System.Web.Mvc;
using Qx.Contents.Interfaces;
using Qx.Contents.Services;
using Web.Controllers.Base;
using Qx.Contents.Exceptions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using System;

namespace Web.Areas.Contents.Controllers
{
    public class Home2Controller : Controller
    {
        ContentTableDesignRepository tablerepository = new ContentTableDesignRepository();
        ColumnDesignRepository columnrepository = new ColumnDesignRepository();
        ColumnTempelateRepository tempelaterepository = new ColumnTempelateRepository();
        // GET: Home2
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult EasyTable()
        {
            return View();
        }

        public ActionResult TableList()
        {
            var model_tableList = tablerepository.All();
            ViewBag.TableList = model_tableList;
            return View();
        }

        public ActionResult TableDataList(string tableid)
        {
            ViewBag.TableID = tableid;
            return View();
        }

        public ActionResult TableLieList(string tableid,string tablename)
        {
            ViewBag.TableID = tableid;
            ViewBag.TableName = tablename;
            return View();
        }

        public ActionResult TableList_High()
        {
            var model_tableList = tablerepository.All();
            ViewBag.TableList = model_tableList;
            return View();
        }

        public ActionResult StartPage()
        {
            var model_cloumn = columnrepository.All();
            //var model_tempelate = tempelaterepository.All();
            ViewBag.columnDesignList = model_cloumn;
            //ViewBag.columnTempelateList = model_tempelate;
            return View();
        }

        public ActionResult NextPage()
        {
            //var model_cloumn = columnrepository.All();
            var model_tempelate = tempelaterepository.All();
            //ViewBag.columnDesignList = model_cloumn;
            ViewBag.columnTempelateList = model_tempelate;
            return View();
        }

        public ActionResult AddEditPage2(string[] lie, string[] type, string tname)
        {
            string templie= string.Empty;
            string temptype= string.Empty;
            
            foreach (var item in lie)
            {
                templie += item + ",";
            }
            foreach (var item in type)
            {
                temptype += item + ",";
            }
            templie = templie.Substring(0, templie.Length - 1);
            temptype = temptype.Substring(0, temptype.Length - 1);
            ViewBag.Tablelie = templie;
            ViewBag.Tabletype = temptype;
            ViewBag.Tablename = tname;
            ViewBag.TableID = "null";
            ViewBag.Tablevalue = "null";
            return View();
        }

        public ActionResult AddEditPage_Edit(string lie, string type, string tid, string value, string relationkeyID)
        {
            string[] tempvalue = value.Split(',');
            string getvalue = string.Empty;
            for (int i = tempvalue.Length - 1; i > 0; i-- )
            {
                getvalue += tempvalue[i] + ",";
            }
            getvalue = getvalue.Substring(0, getvalue.Length - 1);
            ViewBag.Tablelie = lie;
            ViewBag.Tabletype = type;
            ViewBag.Tablename = "null";
            ViewBag.TableID = tid;
            ViewBag.Tablevalue = getvalue;
            ViewBag.RelationKey = relationkeyID;
            return View();
        }


        public ActionResult ProcessTable(string jsonstring)
        {
            //新建表ID
            string CTDID = (new Guid()).ToString();
            if (jsonstring == null)
            {
                jsonstring = Request.Params["data"];
            }

            JArray o = (JArray)JsonConvert.DeserializeObject(jsonstring);
            IList<JToken> oList = (IList<JToken>)o;
            // 处理列名
            List<string> CCDIDList = new List<string>();
            string tableTitles = (oList[0] as JToken).ToString();
            tableTitles.Replace("{", string.Empty);
            tableTitles.Replace("}", string.Empty);
            tableTitles.Replace("[", string.Empty);
            tableTitles.Replace("]", string.Empty);
            string[] titleList = tableTitles.Split(',');
            foreach (var title in titleList)
            {
                //存入列名
                string CCDID = (new Guid()).ToString();
                CCDIDList.Add(CCDID);
                //CCD_ID List CCDIDList.Add();
            }

            for (int i = 1; i < oList.Count; i++)
            {
                string CCVID = (new Guid()).ToString();
                string CCV_RelationKeyValueID = (new Guid()).ToString();
                string tableValues = (oList[i] as JToken).ToString();
                tableValues.Replace("{", string.Empty);
                tableValues.Replace("}", string.Empty);
                tableValues.Replace("[", string.Empty);
                tableValues.Replace("]", string.Empty);
                string[] valueList = tableValues.Split(',');
                for (int ii = 0; ii < valueList.Length; ii++)
                {
                    //存入列值,对应CCDIDList[ii],
                }

            }
            #region 遍历Jarray 舍弃

            //foreach (JToken jt in oList)
            //{
            //    JObject jo = jt as JObject;
            //    //jo.Add(jt);
            //    foreach (JProperty jp in jo.Properties())
            //    {

            //        string a = jp.Name;
            //        string b = jp.Value.ToString();
            //        //获取json中的键  jp.Name 和 值 jp.Value
            //    }
            //}

            #endregion

            return View();
        }
    }
}
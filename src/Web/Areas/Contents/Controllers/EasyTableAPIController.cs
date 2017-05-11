using Qx.Contents.Exceptions;
using Qx.Contents.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using Web.Controllers.Base;

namespace Web.Areas.Contents.Controllers
{
    public class EasyTableAPIController : Controller
    {
        private EasyTableService _eastTableService;

        //---------------------EasyTableAPI
        public EasyTableAPIController(EasyTableService eastTableService)
        {
            _eastTableService = eastTableService;
        }

        [HttpPost]
        [Route("api/json-createTable")]
        public bool CreateEasyTable(string tablename)
        {
            string jsonstring = Request.Params["data"];
            try
            {
                var result = _eastTableService.CreateEasyTable(jsonstring, tablename);
                if (result)
                {
                    return true;
                }
                return false;
            }
            catch (ParamNumberInccorectException)
            {
                throw;
            }
            catch (ParmFlagInccorectException)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("api/json-createSelfTable")]
        public bool CreateSelfTable(string tablename,string type)
        {
            string jsonstring = Request.Params["data"];
            try
            {
                var result = _eastTableService.CreateSelfEasyTable(jsonstring, tablename, type);
                if (result)
                {
                    return true;
                }
                return false;
            }
            catch (ParamNumberInccorectException)
            {
                throw;
            }
            catch (ParmFlagInccorectException)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("api/json-updateTable")]
        public bool UpdateEasyTable(string tableid)
        {
            if (tableid == null || tableid == string.Empty)
            {
                return false;           
            }
            try
            {
                string jsonstring = Request.Params["data"];
                if (jsonstring == null || jsonstring == string.Empty)
                {
                    return false;
                }
                var result = _eastTableService.UpdateEasyTable(jsonstring, tableid);
                if (result)
                {
                    return true;
                }
                return false;
            }
            catch (ParamNumberInccorectException)
            {
                throw;
            }
            catch (ParmFlagInccorectException)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("api/json-deleteTable")]
        public bool DeleteEasyTable(string tableid)
        {
            if (tableid == null || tableid == string.Empty)
            {
                return false;
            }
            try
            {
                var result = _eastTableService.DeleteEasyTable(tableid);
                if (result)
                {
                    return true;
                }
                return false;
            }
            catch (ParamNumberInccorectException)
            {
                throw;
            }
            catch (ParmFlagInccorectException)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("api/json-getTable")]
        public string GetEasyTable(string tableid)
        {
            if (tableid == null || tableid == string.Empty)
            {
                tableid = Request.Params["data"];
            }
            try
            {
                var result = _eastTableService.GetSelfEasyTable(tableid);
                return result;
            }
            catch (TableNotFindException)
            {
                throw;
            }
            catch(GetTableValueFailedException)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("api/json-getTableLie")]
        public string GetEasyTableLie()
        {
            string tableid = Request.Params["data"];
            if (tableid == null || tableid == string.Empty)
            {
                return "[\"error\",\"\",\"\"]";
            }
            try
            {
                var result = _eastTableService.GetEasyTableLie(tableid);
                return result;
            }
            catch (TableNotFindException)
            {
                throw;
            }
            catch (GetTableValueFailedException)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("api/json-saveTableLieEdit")]
        public bool SaveTableLieEdit(string tid,string tname)
        {
            string jsonstring = Request.Params["data"];
            if (tid == null || tid == string.Empty)
            {
                return false;
            }
            try
            {
                var result = _eastTableService.SaveTableLieEdit(jsonstring, tid, tname);
                return result;
            }
            catch (TableNotFindException)
            {
                throw;
            }
            catch (GetTableValueFailedException)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("api/json-saveTableFiles")]
        public bool SaveTableFiles(string filePath)
        {
            //此处也可接入文件保存接口
            #region 文件保存
            //var flist = Request.Files;

            //var form = Request.Form;

            //for (int i = 0; i < flist.Count; i++)
            //{

            //    //string FilePath = "L:\\hooyes\\Files\\";

            //    var c = flist[i];

            //    string FilePath = Path.Combine(filePath, c.FileName);

            //    c.SaveAs(FilePath);

            //}
            #endregion
            
            return true;
        }

        [HttpPost]
        [Route("api/json-deleteTableRow")]
        public bool DeleteTableRow(string relationkeyID)
        {
            if (relationkeyID == null || relationkeyID == string.Empty)
            {
                return false;
            }
            try
            {
                var result = _eastTableService.DeleteTableRow(relationkeyID);
                return result;
            }
            catch (TableNotFindException)
            {
                throw;
            }
            catch (GetTableValueFailedException)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("api/json-editTableRowBefore")]
        public string EditTableRow_Before(string tableid)
        {
            if (tableid == null || tableid == string.Empty)
            {
                return "";
            }
            try
            {
                var result = _eastTableService.EidtTableRow_Before(tableid);
                return result;
            }
            catch (TableNotFindException)
            {
                throw;
            }
            catch (GetTableValueFailedException)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("api/json-editTableRowAfter")]
        public bool EditTableRow_After(string tableid, string relationkeyID)
        {
            string jsonstring = Request.Params["data"];
            if (tableid == null || tableid == string.Empty)
            {
                return false;
            }
            try
            {
                var result = _eastTableService.EidtTableRow_After(jsonstring, tableid, relationkeyID);
                return result;
            }
            catch (TableNotFindException)
            {
                throw;
            }
            catch (UpdateColumnValueFailedException)
            {
                throw;
            }
        }


        //---------------------栏目设计/模板相关API

        [HttpPost]
        [Route("api/json-newContentColumn")]
        [ValidateInput(false)]
        public bool NewColumnDesign()
        {
            string jsonstring = Request.Unvalidated.QueryString["data"];//.Params["data"];
            //string jsonstring = Request.Params["data"];
            if (jsonstring == null || jsonstring == string.Empty)
            {
                return false;
            }
            try
            {
                var result = _eastTableService.NewContentColumnDesign(jsonstring);
                return result;
            }
            catch (TableNotFindException)
            {
                throw;
            }
            catch (UpdateColumnValueFailedException)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("api/json-editContentColumn")]
        [ValidateInput(false)]
        public bool EditColumnDesign()
        {
            string jsonstring = Request.Unvalidated.QueryString["data"];//.Params["data"];
            //string jsonstring = Request.Params["data"];
            if (jsonstring == null || jsonstring == string.Empty)
            {
                return false;
            }
            try
            {
                var result = _eastTableService.EditContentColumnDesign(jsonstring);
                return result;
            }
            catch (TableNotFindException)
            {
                throw;
            }
            catch (UpdateColumnValueFailedException)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("api/json-deleteContentColumn")]
        [ValidateInput(false)]
        public bool DeleteContentColumn(string cdid)
        {
            if (cdid == null || cdid == string.Empty)
            {
                return false;
            }
            try
            {
                var result = _eastTableService.DeleteContentColumnDesign(cdid);
                return result;
            }
            catch (TableNotFindException)
            {
                throw;
            }
            catch (UpdateColumnValueFailedException)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("api/json-getContentColumnInfo")]
        [ValidateInput(false)]
        public string GetContentColumnInfo(string ccdid)
        {
            if (ccdid == null || ccdid == string.Empty)
            {
                return "";
            }
            try
            {
                var result = _eastTableService.GetContentColumnInfo(ccdid);
                return result;
            }
            catch
            {
                return "error";
            }
        }

        [HttpPost]
        [Route("api/json-newColumnTemplate")]
        [ValidateInput(false)]
        public bool NewColumnTemplate()
        {
            string jsonstring = Request.Unvalidated.QueryString["data"];//.Params["data"];
            //string jsonstring = data;
            if (jsonstring == null || jsonstring == string.Empty)
            {
                return false;
            }
            try
            {
                var result = _eastTableService.NewColumnTemplate(jsonstring);
                return result;
            }
            catch (TableNotFindException)
            {
                throw;
            }
            catch (UpdateColumnValueFailedException)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("api/json-editColumnTemplate")]
        [ValidateInput(false)]
        public bool EditColumnTemplate()
        {
            string jsonstring = Request.Unvalidated.QueryString["data"];//.Params["data"];
            if (jsonstring == null || jsonstring == string.Empty)
            {
                return false;
            }
            try
            {
                var result = _eastTableService.EditColumnTemplate(jsonstring);
                return result;
            }
            catch (TableNotFindException)
            {
                throw;
            }
            catch (UpdateColumnValueFailedException)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("api/json-deleteColumnTemplate")]
        [ValidateInput(false)]
        public bool DeleteColumnTemplate(string ctid)
        {
            if (ctid == null || ctid == string.Empty)
            {
                return false;
            }
            try
            {
                var result = _eastTableService.DeleteColumnTemplate( ctid);
                return result;
            }
            catch (TableNotFindException)
            {
                throw;
            }
            catch (UpdateColumnValueFailedException)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("api/json-getColumnTemplateInfo")]
        [ValidateInput(false)]
        public string GetColumnTemplateInfo(string ctid)
        {
            if (ctid == null || ctid == string.Empty)
            {
                return "";
            }
            try
            {
                var result = _eastTableService.GetColumnTemplateInfo(ctid);
                return result;
            }
            catch (TableNotFindException)
            {
                throw;
            }
            catch (UpdateColumnValueFailedException)
            {
                throw;
            }
        }

    }
}
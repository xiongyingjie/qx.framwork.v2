using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Qx.Contents.Entity;
using Qx.Contents.Interfaces;
using Qx.Contents.Models;
using Qx.Tools.CommonExtendMethods;
using Qx.Contents.Repository;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using Qx.Contents.Exceptions;
using System.Text.RegularExpressions;

namespace Qx.Contents.Services
{
    //TableDesign TableColumn TableValue
    public class EasyTableService
    {
        private ContentService _contentservice;
        private ContentTableDesignRepository _contenttable;
        private ContentColumnDesignRepository _contentcolumn;
        private ContentColumnValueRepository _contentvalue;
        private ColumnDesignRepository _columndesign;
        private ColumnTempelateRepository _columntempelate;
        private PageControlTypeRepository _pagecontroltype;
        private IContents _contents;
        //用于回滚
        List<string> AddCTDList = new List<string>();
        List<string> AddCCDList = new List<string>();
        List<string> AddCCVList = new List<string>();
        //结果标识，存表，存列，存值，任何一个步骤出错即视为失败
        bool resultFlag = true;
        Dictionary<string, string> findDataType = new Dictionary<string, string>();


        public EasyTableService(
            IContents contents, 
            ContentTableDesignRepository contenttable, 
            ContentColumnDesignRepository contentcolumn, 
            ContentColumnValueRepository contentvalue, 
            ContentService contentservice, 
            ColumnDesignRepository columndesign,
            ColumnTempelateRepository columntempelate, 
            PageControlTypeRepository pagecontroltype)
        {     
            _contentservice = contentservice;
            _contents = contents;
            _contenttable = contenttable;
            _contentcolumn = contentcolumn;
            _contentvalue = contentvalue;
            _columndesign = columndesign;
            _columntempelate = columntempelate;
            _pagecontroltype = pagecontroltype;

            #region dictionary

            findDataType.Add("datetime", "datetime");
            findDataType.Add("file", "file");
            findDataType.Add("number", "int");
            findDataType.Add("text", "string");
            findDataType.Add("textarea", "string");
            findDataType.Add("checkbox", "bool");

            #endregion
        }

        public bool CreateEasyTable(string jsonstring,string tablename)
        {
            #region 新建表
            content_table_design newTable = CreateTable(tablename);
            try
            {
                _contenttable.Add(newTable);
                AddCTDList.Add(newTable.ctd_id);
            }
            catch
            {
                RollBack();
                return resultFlag;
            }
            #endregion

            JArray o = (JArray)JsonConvert.DeserializeObject(jsonstring);
            IList<JToken> oList = (IList<JToken>)o;
            // 处理列名
            List<string> CCDIDList = new List<string>();
            string[] titleList = processJsonString((oList[0] as JToken).ToString());
            //一张表格的参数 ,列顺序
            int CCDSeq = 1;

            #region 存入列名
            foreach (var title in titleList)
            {
                content_column_design column = CreateColumn(newTable.ctd_id, title, "", CCDSeq, "string");
                
                try
                {
                    _contentcolumn.Add(column);
                    CCDIDList.Add(column.ccd_id);
                    AddCCDList.Add(column.ccd_id);
                }
                catch
                {
                    RollBack();
                    return resultFlag;
                }

                CCDSeq++;
            }
            #endregion

            #region 存值
            for (int i = 1; i < oList.Count; i++)
            {
                string CCV_RelationKeyValueID = Guid.NewGuid().ToString();//每行一个relationKeyValueID
                string[] valueList = processJsonString((oList[i] as JToken).ToString());
                for (int ii = 0; ii < valueList.Length; ii++)
                {
                    //存入列值,对应CCDIDList[ii],
                    content_column_value value = CreateValue(CCDIDList[ii], valueList[ii], CCV_RelationKeyValueID);
                    try
                    {
                        _contentvalue.Add(value);
                        AddCCVList.Add(value.ccv_id);
                    }
                    catch
                    {
                        RollBack();
                        return resultFlag;
                    }              
                }

            }
            #endregion

            return resultFlag;
        }

        public bool CreateSelfEasyTable(string jsonstring, string tablename,string type)
        {
            string[] types = type.Split(',');
            #region 新建表
            content_table_design newTable = CreateTable(tablename);
            try
            {
                _contenttable.Add(newTable);
                AddCTDList.Add(newTable.ctd_id);
            }
            catch
            {
                RollBack();
            }
            #endregion

            JArray o = (JArray)JsonConvert.DeserializeObject(jsonstring);
            IList<JToken> oList = (IList<JToken>)o;
            // 处理列名
            List<string> CCDIDList = new List<string>();
            //string[] titleList = processJsonString((oList[0] as JToken).ToString());
            //一张表格的参数 ,列顺序
            int CCDSeq = 1;

            #region 存入列名+存值
            string CCV_RelationKeyValueID = Guid.NewGuid().ToString();//单行添加数据 - relationKeyValueID
            for (int i = 0; i < oList.Count; i++)
            {
                string[] valueList = processJsonString((oList[i] as JToken).ToString());

                content_column_design column = CreateColumn(newTable.ctd_id, valueList[0], types[i], CCDSeq, findDataType[types[CCDSeq - 1]]);

                try
                {
                    _contentcolumn.Add(column);
                    CCDIDList.Add(column.ccd_id);
                    AddCCDList.Add(column.ccd_id);
                }
                catch
                {
                    RollBack();
                    return resultFlag;
                }

                CCDSeq++;

                //存入列值,对应CCDIDList[ii],
                content_column_value value = CreateValue(CCDIDList[i], valueList[1], CCV_RelationKeyValueID);
                try
                {
                    _contentvalue.Add(value);
                    AddCCVList.Add(value.ccv_id);
                }
                catch
                {
                    RollBack();
                    return resultFlag;
                }

            }
            #endregion

            return resultFlag;
        }
       
        public string GetEasyTable(string tableid)
        {
            //string tableJson = "[[\"c1\",\"c2\"],[\"1\",\"2\"]]";
            StringBuilder result = new StringBuilder("[");
            //拼接列
            try
            {
                content_table_design table = _contenttable.Find(tableid);
                result.Append("[");//jsonArray 开始标志
                foreach (var item in table.content_column_design)
                {
                    result.Append("\"" + item.column_name + "\"" + ",");
                }
                result.Remove(result.Length - 1, 1);//尾部去多余的逗号
                result.Append("],");
            }
            catch
            {
                throw new TableNotFindException("未查找到该表格");
            }
            
            //拼接值
            try
            {
                var rows = _contentservice.GetTableValues(tableid).ToDataRowList();
                foreach (var row in rows)
                {
                    result.Append("[");//一行开始
                    foreach (var cl in row)
                    {
                        result.Append("\"" + cl + "\"" + ",");
                    }
                    result.Remove(result.Length - 1, 1);//尾部去多余的逗号
                    result.Append("],");//一行完
                }
                result.Remove(result.Length - 1, 1);//尾部去多余的逗号
                result.Append("]");//jsonArray 结束标志
            }
            catch
            {
                throw new GetTableValueFailedException("获取表格列值失败");
            }

            return result.ToString();
        }

        public string GetSelfEasyTable(string tableid)
        {
            //string tableJson = "[[\"c1\",\"c2\"],[\"1\",\"2\"]]";
            StringBuilder result = new StringBuilder("[");
            //拼接列
            try
            {
                content_table_design table = _contenttable.Find(tableid);
                result.Append("[");//jsonArray 开始标志

                var columns = (from f in table.content_column_design orderby f.seq select f).ToList();
                foreach (var item in columns)
                {
                    result.Append("\"" + item.column_name + "\"" + ",");
                }
                result.Append("\"RelationkeyID\"");

                //result.Remove(result.Length - 1, 1);//尾部去多余的逗号
                result.Append("],");
            }
            catch
            {
                throw new TableNotFindException("未查找到该表格");
            }

            var relationkeys = _contentservice.GetTableValuesKeys(tableid);
            //拼接值
            try
            {
                var rows = _contentservice.GetTableValues(tableid).ToDataRowList();
                int rowindex = 0;
                foreach (var row in rows)
                {
                    result.Append("[");//一行开始
                    foreach (var cl in row)
                    {
                        result.Append("\"" + cl + "\"" + ",");
                    }
                    result.Append("\"" + relationkeys[rowindex].Key + "\"");
                    //result.Remove(result.Length - 1, 1);//尾部去多余的逗号
                    result.Append("],");//一行完
                    rowindex++;
                }
                result.Remove(result.Length - 1, 1);//尾部去多余的逗号
                result.Append("]");//jsonArray 结束标志
            }
            catch
            {
                throw new GetTableValueFailedException("获取表格列值失败");
            }

            return result.ToString();
        }

        public bool DeleteEasyTable(string tableid)
        {
            return _contenttable.Delete(tableid);
        }

        public bool UpdateEasyTable(string jsonstring, string tableid)
        {
            bool result = true;
            try
            {
                content_table_design table = _contenttable.Find(tableid);
                
                CreateEasyTable(jsonstring, table.table_name);

                _contenttable.Delete(tableid);
            }
            catch
            {
                result = false;
            }
            return result;
        }


        public string GetEasyTableLie(string tableid)
        {
            //string tableJson = "[[\"c1\",\"c2\"],[\"1\",\"2\"]]";
            StringBuilder result = new StringBuilder("[");
            //拼接列
            try
            {
                content_table_design table = _contenttable.Find(tableid);
                

                var columns = (from f in table.content_column_design orderby f.seq select f).ToList();
                foreach (var item in columns)
                {
                    result.Append("[");//jsonArray 开始标志
                    result.Append("\"" + item.ccd_id + "\"" + ",");
                    result.Append("\"" + item.column_name + "\"" + ",");
                    result.Append("\"" + item.pct_id + "\"" + ",");
                    result.Remove(result.Length - 1, 1);//尾部去多余的逗号
                    result.Append("],");
                }
                result.Remove(result.Length - 1, 1);//尾部去多余的逗号
                result.Append("]");
            }
            catch
            {
                throw new TableNotFindException("未查找到该表格");
            }
            return result.ToString();
        }

        public bool SaveTableLieEdit(string jsonstring, string tableid, string tablename)
        {
            JArray o = (JArray)JsonConvert.DeserializeObject(jsonstring);
            IList<JToken> oList = (IList<JToken>)o;
            List<string> CCDIDList = new List<string>();
            List<string> CCDNameList = new List<string>();
            List<string> CCDPCTIDList = new List<string>();
            foreach (var item in oList)
            {
                string [] tempv = getJsonstringValue((item as JToken).ToString());
                CCDIDList.Add(tempv[0]);
                CCDNameList.Add(tempv[1]);
                CCDPCTIDList.Add(tempv[2]);
            }
            try
            {


                content_table_design table = _contenttable.Find(tableid);
                table.table_name = tablename;
                _contenttable.Update(table);
                var columns = (from f in table.content_column_design orderby f.seq select f).ToList();
                foreach (var item in columns)
                {
                    if (!CCDIDList.Contains(item.ccd_id))
                    {
                        _contentcolumn.Delete(item.ccd_id);
                    }
                } 
                int index = 0;
                int lieseq = 1;
                foreach (var item in CCDIDList)
                {
                    content_column_design ccnew = _contentcolumn.Find(item);
                    if(ccnew != null)
                    {
                        ccnew.column_name = CCDNameList[index];
                        ccnew.pct_id = CCDPCTIDList[index];
                        _contentcolumn.Update(ccnew);
                    }
                    else
                    {
                        content_column_design ccnew1 = CreateColumn(table.ctd_id, CCDNameList[index], CCDPCTIDList[index], lieseq, "string");
                        _contentcolumn.Add(ccnew1);
                    }
                    index++;
                    lieseq++;
                }
            
            }
            catch(Exception e)
            {
                throw;
            }
            return true;
        }
        //删除表格--单行
        public bool DeleteTableRow(string relationkeyID)
        {
            return _contentvalue.DeleteByRelationkeyID(relationkeyID);
        }

        //编辑表格--单行//处理列类型并初始化控件
        public string EidtTableRow_Before(string tableid)
        {
            StringBuilder result = new StringBuilder();
            //拼接列类型
            try
            {
                content_table_design table = _contenttable.Find(tableid);
                //result.Append("[");//jsonArray 开始标志
                var columns = (from f in table.content_column_design orderby f.seq select f).ToList();
                foreach (var item in columns)
                {
                    result.Append(item.page_control_type.pct_name + ",");
                }

                result.Remove(result.Length - 1, 1);//尾部去多余的逗号
                //result.Append("]");
            }
            catch
            {
                throw new TableNotFindException("未查找到该表格");
            }
            return result.ToString();
        }

        //编辑表格--单行//保存编辑
        public bool EidtTableRow_After(string jsonstring, string tableid, string relationkeyID)
        {

            content_table_design table = _contenttable.Find(tableid);
            //result.Append("[");//jsonArray 开始标志
            var columns = (from f in table.content_column_design orderby f.seq select f).ToList();

            JArray o = (JArray)JsonConvert.DeserializeObject(jsonstring);
            IList<JToken> oList = (IList<JToken>)o;

            #region 保存值修改

            for (int i = 0; i < oList.Count; i++)
            {
                string[] valueList = processJsonString((oList[i] as JToken).ToString());

                content_column_value tempValue = columns[i].dontent_column_value.FirstOrDefault(b => b.relation_key_value == relationkeyID);
                tempValue.column_value = valueList[1];
                try
                {
                    _contentvalue.Update(tempValue);
                }
                catch {
                    throw new UpdateColumnValueFailedException("更新列值失败");
                }
                
            }
            return true;
            #endregion
        }

        //建表
        public content_table_design CreateTable(string tablename)
        {
            content_table_design table = new content_table_design();
            if (tablename == null || tablename == string.Empty)
            {
                table.table_name = "未命名表格";
            }
            else
            {
                table.table_name = tablename;
            }
                
            table.ct_id = "80";//70文件 80图片 90视频 是否有必要？？？
            return table;
        }

        //建列
        public content_column_design CreateColumn(string tableid, string title, string pcttype, int CCDSeq, string dttype)
        {
            content_column_design column = new content_column_design();
            column.ctd_id = tableid;
            column.column_name = title;
            //DataType dt = new DataType();
            column.dt_id = dttype;
            //column.DataType = dt;
            column.def_value = "#";
            column.is_pk = "否";
            column.pct_id = pcttype;
            column.seq = CCDSeq.ToString();
            return column;
        }

        //建值
        public content_column_value CreateValue(string columnid, string cvalue, string RelationKeyValue)
        {
            content_column_value value = new content_column_value();
            value.ccd_id = columnid;
            value.column_value = cvalue;
            value.relation_key_value = RelationKeyValue;
            return value;
        }

        //回滚操作
        public void RollBack()
        {
            resultFlag = false;
            foreach (var item in AddCCVList)
            {
                _contentvalue.Delete(item);
            }
            foreach (var item in AddCCDList)
            {
                _contentcolumn.Delete(item);
            }
            foreach(var item in AddCTDList)
            {
                _contenttable.Delete(item);
            }
        }

        public string[] processJsonString(string jstring)
        {
            jstring = Regex.Replace(jstring, @"[\r\n]", "");
            jstring = Regex.Replace(jstring, @"[{]", "");
            jstring = Regex.Replace(jstring, @"[}]", "");
            jstring = Regex.Replace(jstring, @"[[]", "");
            jstring = Regex.Replace(jstring, @"[]]", "");
            jstring = Regex.Replace(jstring, @"[\""]", ""); 
            jstring = Regex.Replace(jstring, @"[ ]", "");
            jstring.TrimStart();
            jstring.Trim();
            jstring.TrimEnd();
            //jstring = Regex.Replace(jstring, @"[/n/r]", ""); 
            string[] result = jstring.Split(',');
            return result;
        }

        public string[] getJsonstringValue(string jstring)
        {
            jstring = Regex.Replace(jstring, @"[[]", "");
            jstring = Regex.Replace(jstring, @"[]]", "");
            jstring = Regex.Replace(jstring, @"[\r\n]", "");
            jstring.TrimStart();
            jstring.TrimEnd();
            string[] result = jstring.Split(',');
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = result[i].TrimStart().TrimEnd();
                result[i] = result[i].Remove(0, 1);//头部去引号
                result[i] = result[i].Remove(result[i].Length - 1, 1);//尾部去引号
                result[i] = result[i].Replace("\\\"", "\"");
            }
            return result;
        }


        //-------------栏目设计、模板相关操作
        public bool NewContentColumnDesign(string jsonstring)
        {
            JArray o = (JArray)JsonConvert.DeserializeObject(jsonstring);
            IList<JToken> oList = (IList<JToken>)o;
            // 获取值
            List<string> CCDIDList = new List<string>();
            List<string> ValueList = new List<string>();
            foreach (var item in oList)
            {
                ValueList.Add(getJsonstringValue((item as JToken).ToString())[1]);
            }
            //string[] valueList = processJsonString((oList[0] as JToken).ToString());
            //'栏目设计ID', '栏目设计名称','展示列数','绑定单位ID','更新类型','栏目设计HTML','栏目设计参数','css/js'
            #region 存入值
            column_design columnd = new column_design();
            columnd.column_design_id = ValueList[0];
            columnd.name = ValueList[1];
            try
            {
                columnd.show_count = Convert.ToInt32(ValueList[2]);
            }
            catch
            {
                columnd.show_count = -1;
            }           
            columnd.unit_id = ValueList[3];
            columnd.update_type_id = ValueList[4];
            columnd.html_template = ValueList[5];
            columnd.html_template_params = ValueList[6];
            columnd.library_id = ValueList[7];
            try
            {
                _columndesign.Add(columnd);
            }
            catch
            {

            }

            #endregion

            return true;
        }

        public bool EditContentColumnDesign(string jsonstring)
        {
            JArray o = (JArray)JsonConvert.DeserializeObject(jsonstring);
            IList<JToken> oList = (IList<JToken>)o;
            // 获取值
            List<string> CCDIDList = new List<string>();
            //string[] valueList = processJsonString((oList[1] as JToken).ToString());
            List<string> ValueList = new List<string>();
            foreach (var item in oList)
            {
                ValueList.Add(getJsonstringValue((item as JToken).ToString())[1]);
            }
            //'栏目设计ID', '栏目设计名称','展示列数','绑定单位ID','更新类型','栏目设计HTML','栏目设计参数','css/js'
            #region 存入值
            column_design columnd = _columndesign.Find(ValueList[0]);
            //columnd.column_design_id = ValueList[0];
            columnd.name = ValueList[1];
            try
            {
                columnd.show_count = Convert.ToInt32(ValueList[2]);
            }
            catch
            {
                columnd.show_count = -1;
            }  
            columnd.unit_id = ValueList[3];
            columnd.update_type_id = ValueList[4];
            columnd.html_template = ValueList[5];
            columnd.html_template_params = ValueList[6];
            columnd.library_id = ValueList[7];
            try
            {
                _columndesign.Update(columnd);
            }
            catch
            {

            }

            #endregion
            return true;
        }

        public bool DeleteContentColumnDesign(string ccdid)
        {
            return _columndesign.Delete(ccdid);
        }

        public string GetContentColumnInfo(string ccdid)
        {
            StringBuilder result = new StringBuilder("[");
            //拼接列
            try
            {
                column_design columnd = _columndesign.Find(ccdid);
                var tHtml = processHTMLstring(columnd.html_template);
                //result.Append("[");//jsonArray 开始标志
                result.Append("[\"" + columnd.column_design_id + "\"]" + ",");
                result.Append("[\"" + columnd.name + "\"]" + ",");
                result.Append("[\"" + columnd.show_count + "\"]" + ",");
                result.Append("[\"" + columnd.unit_id + "\"]" + ",");
                result.Append("[\"" + columnd.update_type_id + "\"]" + ",");
                result.Append("[\"" + tHtml + "\"]" + ",");
                result.Append("[\"" + columnd.html_template_params + "\"]" + ",");
                result.Append("[\"" + columnd.library_id + "\"]" + ",");
                result.Remove(result.Length - 1, 1);//尾部去多余的逗号
                result.Append("]");
            }
            catch
            {
                throw new TableNotFindException("未查找到该表格");
            }

            return result.ToString();
        }

        public bool NewColumnTemplate(string jsonstring)
        {
            JArray o = (JArray)JsonConvert.DeserializeObject(jsonstring);
            IList<JToken> oList = (IList<JToken>)o;
            // 获取值
            List<string> CCDIDList = new List<string>();
            List<string> ValueList = new List<string>();
            foreach (var item in oList)
            {
                ValueList.Add(getJsonstringValue((item as JToken).ToString())[1]);
            }
            //string[] valueList = processJsonString((oList[0] as JToken).ToString());
            //'栏目模板ID', '栏目模板HTML'
            #region 存入值
            column_tempelate columnt = new column_tempelate();
            columnt.column_tempelate_id = Guid.NewGuid();
            columnt.column_tempelate_name = ValueList[1];
            columnt.column_tempelate_html = ValueList[2];
            try
            {
                _columntempelate.Add(columnt);
            }
            catch
            {
                return false;
            }

            #endregion
            return true;
        }

        public bool EditColumnTemplate(string jsonstring)
        {
            JArray o = (JArray)JsonConvert.DeserializeObject(jsonstring);
            IList<JToken> oList = (IList<JToken>)o;
            // 获取值
            List<string> CCDIDList = new List<string>();
            List<string> ValueList = new List<string>();
            foreach(var item in oList)
            {
                ValueList.Add(getJsonstringValue((item as JToken).ToString())[1]);
            }
            //string[] valueList = processJsonString((oList[1] as JToken).ToString());
            //'栏目模板ID', '栏目模板HTML'
            column_tempelate columnt = _columntempelate.Find(ValueList[0]);
            columnt.column_tempelate_name = ValueList[1];
            columnt.column_tempelate_html = ValueList[2];
            try
            {
                _columntempelate.Update(columnt);
            }
            catch
            {

            }
            return true;
        }

        public bool DeleteColumnTemplate(string ctid)
        {
            return _columntempelate.Delete(ctid);
        }

        public string GetColumnTemplateInfo(string ctid)
        {
            StringBuilder result = new StringBuilder("[");
            //拼接列
            try
            {
                column_tempelate columnt = _columntempelate.Find(ctid);
                var tHtml = processHTMLstring(columnt.column_tempelate_html);
                //result.Append("[");//jsonArray 开始标志
                result.Append("[\"" + columnt.column_tempelate_id + "\"" + "],");
                result.Append("[\"" + columnt.column_tempelate_name + "\"" + "],");
                result.Append("[\"" + tHtml + "\"" + "],");
                result.Remove(result.Length - 1, 1);//尾部去多余的逗号
                result.Append("]");
            }
            catch
            {
                throw new TableNotFindException("未查找到该表格");
            }

            return result.ToString();
        }


        public string processHTMLstring(string html)
        {
            html = Regex.Replace(html, @"[\r\n]", "");
            //html = Regex.Replace(html, " ", "");
            html = html.Replace("\"","\\\"");
            return html;
        }
    }
}

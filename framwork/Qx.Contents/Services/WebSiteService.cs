using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Qx.Contents.Entity;
using Qx.Contents.Exceptions;
using Qx.Contents.Interfaces;
using Qx.Contents.Models;
using Qx.Contents.Repository;
using Qx.Tools.CommonExtendMethods;

namespace Qx.Contents.Services
{
    public class WebSiteService
    {
        private ColumnDesignRepository _columnDesign;
        private LibrarysRepository _librarys;
        private IContents _contents;
        private List<string> LibsID =new List<string>();
        public WebSiteService(IContents contents, ColumnDesignRepository columnDesign, LibrarysRepository librarys)
        {
            _contents = contents;
            _columnDesign = columnDesign;
            _librarys = librarys;
        }

        public MvcHtmlString GetTemplete(string id)
        {
            var columnDesign = GetColumnDesign(id);
            var tempelete = ProcessTemplate_S(columnDesign.HtmlTemplate, columnDesign.HtmlTemplateParams);
            return MvcHtmlString.Create(tempelete);
        }

        public JsonResult GetSigleColumnDesign(string id)
        {
            var columnDesign = GetColumnDesign(id);
            var tempelete = ProcessTemplate_S(columnDesign.HtmlTemplate, columnDesign.HtmlTemplateParams);
            return new JsonResult()
            {
                Data =  new APIJsonObject(){ Name=id, Content=tempelete },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public JsonResult GetMultipleColumnDesign(string id)
        {
            var columnDesign = GetColumnDesign(id);
            var tempelete = ProcessTemplate_M(columnDesign.HtmlTemplate, columnDesign.HtmlTemplateParams);

            //tempelete.Append(MvcHtmlString.Create("<ul class=\"num\" id=\"idNum2\"><li>1</li><li>2</li><li>3</li></ul>"));
            return new JsonResult()
            {
                Data = new APIJsonObject() { Name = id, Content = tempelete.ToString() },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public JsonResult GetLibrarys()
        {
            var cssBulider =new StringBuilder();
            var jsBuilder =new StringBuilder();
            var tempelete = ProcessLibrarys(cssBulider, jsBuilder);

            return new JsonResult()
            {
                Data = new APIJsonObject() { Name = cssBulider.ToString(), Content = jsBuilder.ToString() },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        /// <summary>
        /// 处理HTML模板(单行)
        /// </summary>
        /// <param name="temp">HTML模板</param>
        /// <param name="configInDb">数据配置项</param>
        /// <returns></returns>
        private string ProcessTemplate_S(string template, string configInDb)
        {
            var configs = configInDb.UnPackString(';');
            if (configs.Count != 4)
            {
                throw new ParamNumberInccorectException("参数个数不正确，当前参数个数=>" + configs.Count + "\n 正确格式/S单行M多行;ContentTableDesign.CTD_ID;ContentColumnValue.RelationKeyValue;要显示的列索引");
                
            }
            if (configs[0] != "S")
            {
                throw new ParmFlagInccorectException("参数标志不正确，标志位应该为S 当前标志位为=>" + configs[0]);
            }
            var tableValue = _contents.GetTableValue(configs[1], configs[2])
                .ToDataRowList()
                .FilterRow(configs[3].UnPackString(':').ToIntList());
            var valueArr = tableValue.ToArray();
            string result = string.Format(template, valueArr);
            return result;
        }

        /// <summary>
        /// 处理HTML模板(多行)
        /// </summary>
        /// <param name="temp">HTML模板</param>
        /// <param name="configInDb">数据配置项</param>
        /// <returns></returns>
        private StringBuilder ProcessTemplate_M(string template, string configInDb)
        {

            var needed = template.UnPackString(';');// 0: 创建元素类型 ;1: 元素模板 ; 2: 待循环的元素模板
            if (needed.Count != 3)
            {
                throw new ParamNumberInccorectException("模板参数个数不正确，当前参数个数=>" + needed.Count + "\n 示例格式:ul;<ul class=\"slider slider2\" id=\"idSlider2\">;<li><a href=\"{0}\"><img src=\"{1}\" /></a></li>");
            }

            HTMLElement ele = new HTMLElement();
            ele = ele.CreatElement(needed[0], needed[1]);

            var tempeleteBuilder = new StringBuilder();
            tempeleteBuilder.Append(ele.Head);

            var configs = configInDb.UnPackString(';');

            if (configs.Count != 4)
            {
                throw new ParamNumberInccorectException("数据项参数个数不正确，当前参数个数=>" + configs.Count + "\n 正确格式/S单行M多行;ContentTableDesign.CTD_ID;ContentColumnValue.RelationKeyValue;要显示的列索引");
            }
            if (configs[0] != "M")
            {
                throw new ParmFlagInccorectException("数据项参数标志不正确，标志位应该为M 当前标志位为=>" + configs[0]);
            }
            var rows = _contents.GetTableValues(configs[1]).Select(a => a.ToDataRowList().
            FilterRow(configs[3].UnPackString(':').
            ToIntList()));
            foreach (var row in rows)
            {
                var valueArr = row.ToArray();

                string temp = string.Format(needed[2], valueArr);

                tempeleteBuilder.Append(MvcHtmlString.Create(temp));
            }


            tempeleteBuilder.Append(ele.Tail);
            return tempeleteBuilder;
        }

        private column_design GetColumnDesign(string id)
        {
            var columnDesign = _columnDesign.Find(id);
            columnDesign.HtmlTemplate = columnDesign.HtmlTemplate.Replace("\r\n", "");
            return columnDesign;
        }

        private void GetAllColumnDesigns()
        {
            var columnDesign = _columnDesign.All();
            foreach(var item in columnDesign)
            {
                var temp = item.LibraryID.UnPackString(';');
                foreach(var l in temp)
                {
                    LibsID.Add(l);
                }          
            }
            LibsID.Distinct().ToList();
        }

        private StringBuilder ProcessLibrarys(StringBuilder cssBulider, StringBuilder jsBuilder)
        {
            GetAllColumnDesigns();
            var tempeleteBuilder = new StringBuilder();
            foreach (var item in LibsID)
            {
                var lib = _librarys.Find(item);
                switch(lib.TypeID)
                {
                    case 1:
                        jsBuilder.Append(lib.FileUrl);
                        break;
                    case 2:
                        cssBulider.Append(lib.FileUrl);
                        break;
                    default:
                        throw new GetLibraryFailException("获取css/js失败!Library 类型未指定");
                }
            }
            return tempeleteBuilder;
        }

    }
}

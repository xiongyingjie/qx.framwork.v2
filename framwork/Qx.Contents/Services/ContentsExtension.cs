using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Qx.Contents.Models;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Web.Mvc.Html;

namespace Qx.Contents.Services
{
    public static class ContentsExtension
    {
        public const string SAVE_DIR = "/UserFiles/Contents";

        public static MvcHtmlString ContentsFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, string tipString)
        {
            var tableId = htmlHelper.DisplayFor(expression).ToString();

            if (!tableId.HasValue())
            {
                throw new Exception("请检查ViewModel中是否给" + htmlHelper.IdFor(expression) + "赋值");
            }
            //获取Table信息
            var service = new ContentService();
            var table = service.GetTableDesign(tableId);

            var dest = new StringBuilder();
            //判断控件类型
            table.Columns.ToList().ForEach(t =>
            {
                var temp=new MvcHtmlString("");
                switch (t.GetPageControlType())
                {
                    case PageControlTypeEnum.File:
                    {
                         temp = htmlHelper.File(t.ColumnName, t.ColumnID, t.ColumnID, SAVE_DIR, "请上传" + t.ColumnName);
                         break;
                    }
                    case PageControlTypeEnum.RichTextBox:
                        {
                            temp = htmlHelper.RichBox(t.ColumnName, t.ColumnID, t.Value);
                            break;
                        }
                    case PageControlTypeEnum.Date:
                    {
                        throw new NotImplementedException("日期时间控件->>>请提醒英杰加入拓展，详见Demo页");
                    }
                    case PageControlTypeEnum.Datetime:
                    {
                        temp= htmlHelper.TimeFor(expression, tipString);
                        break;
                    }
                 
                    case PageControlTypeEnum.Number:
                    {
                        throw new NotImplementedException("数值控件->>>请提醒英杰加入拓展，详见Demo页");
                    }
                    case PageControlTypeEnum.DropDownList:
                    {
                        throw new NotImplementedException("下拉输入框控件->>>请提醒英杰加入拓展，详见Demo页");
                    }
                    case PageControlTypeEnum.Color:
                    {
                        throw new NotImplementedException("颜色输入框控件->>>请提醒英杰加入拓展，详见Demo页");
                    }
                        
                    default:
                        temp=htmlHelper.InputFor(expression, tipString);
                        break;
                }
                 dest.Append(temp);
            });
            return new MvcHtmlString(dest.ToString());
        }


        public static bool UpdateTable(this HttpRequestBase request, string tableId, string relationKeyId)
        {
            var service = new ContentService();
            return service.UpdateTable(request, tableId, relationKeyId);
        }

        public static List<string> ToDataRowList(this TableValue tableValue)
        {
            return tableValue.Columns.Select(a => a.Value).ToList();
        }
        public static List<List<string>> ToDataRowList(this List<TableValue> tableValues)
        {
            return tableValues.Select(a=>a.ToDataRowList()).ToList();
        }
        public static List<string> FilterRow(this List<string> dataRowList,List<int>indexToShow )
        {
            return dataRowList.Where((t, i) => indexToShow.Contains(i)).ToList();
        }

        public static List<int> ToIntList(this List<string> intList)
        {
            return intList.Select(int.Parse).ToList();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using Microsoft.AspNetCore.Http;
using Qx.Contents.Models;
using Qx.Tools.CommonExtendMethods;


namespace Qx.Contents.Services
{
    public static class ContentsExtension
    {
        public const string SAVE_DIR = "/UserFiles/Contents";

        //public static MvcHtmlString ContentsFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
        //    Expression<Func<TModel, TProperty>> expression, string tipString)
        //{
        //    var tableId = htmlHelper.DisplayFor(expression).ToString();

        //    if (!tableId.HasValue())
        //    {
        //        throw new Exception("请检查ViewModel中是否给" + htmlHelper.IdFor(expression) + "赋值");
        //    }
        //    //获取Table信息
        //    var service = new ContentService();
        //    var table = service.GetTableDesign(tableId);

        //    var dest = new StringBuilder();
        //    //判断控件类型
        //    table.Columns.ToList().ForEach(t =>
        //    {
        //        switch (t.DateTypeID)
        //        {
        //            case "file":
        //            {
        //                var a = htmlHelper.File(t.ColumnName, t.ColumnID, t.ColumnID, SAVE_DIR, "请上传" + t.ColumnName);
        //                dest.Append(htmlHelper.File(t.ColumnName, t.ColumnID, t.ColumnID, SAVE_DIR, "请上传" + t.ColumnName));
        //                break;
        //            }
                        
        //            case "DateTime":
        //            {
        //                throw new NotImplementedException("日期时间控件->>>请提醒英杰加入拓展，详见Demo页");
        //            }
        //            case "string":
        //            {
        //                var a = htmlHelper.TimeFor(expression, tipString);
        //                dest.Append(htmlHelper.InputFor(expression, tipString));
        //                break;
        //            }
        //            case "html":
        //            {
        //                throw new NotImplementedException("富文本控件->>>请提醒英杰加入拓展，详见Demo页");
        //            }
        //            case "decemal":
        //            {
        //                throw new NotImplementedException("数值控件->>>请提醒英杰加入拓展，详见Demo页");
        //            }
        //            case "url":
        //            {
        //                throw new NotImplementedException("URL输入框控件->>>请提醒英杰加入拓展，详见Demo页");
        //            }
        //            case "color":
        //            {
        //                throw new NotImplementedException("颜色输入框控件->>>请提醒英杰加入拓展，详见Demo页");
        //            }
                        
        //            default:
        //                dest.Append(htmlHelper.InputFor(expression, tipString));
        //                break;
        //        }
        //    });

        //    return new MvcHtmlString(dest.ToString());
        //}


        public static bool UpdateTable(this HttpContext request, string tableId, string relationKeyId)
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
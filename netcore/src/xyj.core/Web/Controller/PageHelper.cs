using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Qx.Tools.Web.Controller
{
    public static class PageHelper
    {
        #region 获取下拉框数据源

        /// <summary>
        ///     获取下拉框数据源
        /// </summary>
        /// <param name="db">数据集</param>
        /// <param name="tableName">表名</param>
        /// <param name="nameSpace">命名空间</param>
        /// <param name="textIndex">text属性列索引</param>
        /// <param name="valueIndex">value属性列索引</param>
        /// <param name="contitions">筛选条件[SQL语句]</param>
        /// <returns>下拉框数据源</returns>
        private static List<SelectListItem> GetCodeTable(DbContext db, string tableName, string nameSpace, int textIndex,
            int valueIndex, string contitions)
        {
            var fullName = nameSpace + "." + tableName;
            var obj = Assembly.GetExecutingAssembly().CreateInstance(fullName);

            var items = new List<SelectListItem>();

            var datas = db.Database.SqlQuery(obj.GetType(), "select * from " + tableName + " " + contitions);

            foreach (var data in datas)
            {
                var item = ReflectionUtility.GetObjInfo(data)[1];
                items.Add(new SelectListItem {Value = item[valueIndex], Text = item[textIndex]});
            }

            return items;
        }

        #endregion

        #region 生成下拉框html代码[private]

        /// <summary>
        ///     生成下拉框html代码
        /// </summary>
        /// <param name="items">下拉框数据源</param>
        /// <param name="name">下拉框name属性</param>
        /// <param name="className">下拉框class属性</param>
        /// <returns>下拉框html代码</returns>
        private static string GetSelectHtml(List<SelectListItem> items, string name, string className)
        {
            var html = string.Format("<select name='{0}' class='{1}'>", name, className);

            if (items.Count == 0)
            {
                html += "<option value='-1'> 没有数据！</option>";
            }

            foreach (var item in items)
            {
                if (item.Text.Contains("全部") || item.Text.Contains("请选择"))
                    continue;
                html += "<option value=\"" + item.Value + "\">" + item.Text + "</option>";
            }

            html += " </select>";
            return html;
        }

        #endregion

        #region 生成下拉框html代码

        /// <summary>
        ///     生成下拉框html代码
        /// </summary>
        /// <param name="name">下拉框name属性</param>
        /// <param name="db">数据集</param>
        /// <param name="tableName">表名</param>
        /// <param name="nameSpace">命名空间</param>
        /// <param name="textIndex">text属性列索引</param>
        /// <param name="valueIndex">value属性列索引</param>
        /// <param name="contitions">筛选条件[SQL语句]</param>
        /// <returns>下拉框html代码</returns>
        public static HtmlString GetSelectHtml(string name, DbContext db, string tableName, string nameSpace,
            int textIndex = 1, int valueIndex = 0, string contitions = "", string className = "form-control")
        {
            return
                new HtmlString(GetSelectHtml(GetCodeTable(db, tableName, nameSpace, textIndex, valueIndex, contitions),
                    name, className));
        }

        #endregion

        #region 生成注释模型【已过时】

        /// <summary>
        ///     生成注释模型【已过时】
        /// </summary>
        /// <typeparam name="T">模型类型</typeparam>
        /// <param name="model">实例化的模型</param>
        /// <param name="notes">模型的描述字段</param>
        /// <returns></returns>
        public static List<string> GetModelNote<T>(T model, string[] notes)
        {
            var result = new List<string>();


            var temp = ReflectionUtility.GetObjInfo(model);
            temp[1] = notes;

            if (temp[0].Length == temp[1].Length)
            {
                result.Add(" public  class " + model.GetType().Name + "_Note");
                result.Add("{");


                //声明成员
                for (var i = 0; i < temp[0].Length; i++)
                {
                    result.Add("  public string " + temp[0][i] + " { get; set; }");
                }
                //构造函数
                result.Add("public " + model.GetType().Name + "_Note()");
                result.Add("   {");
                for (var i = 0; i < temp[0].Length; i++)
                {
                    result.Add(" " + temp[0][i] + " = \"" + temp[1][i] + "\";");
                }
                result.Add("   }");
                //注释
                var noteStr = "{";
                for (var i = 0; i < notes.Length; i++)
                {
                    noteStr += "\"" + notes[i] + "\",";
                }

                result.Add("//PageHelper.GetModelNote<" + model.GetType().Name + ">(new " + model.GetType().Name +
                           "(),new string[]" + noteStr.Substring(0, noteStr.Length - 1) + "});");
                result.Add("}");
            }
            else
            {
                result.Add("参数个数不匹配！");
            }


            return result;
        }

        #endregion

        #region 获取分页

        /// <summary>
        ///     获取分页
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="datas">数据源</param>
        /// <param name="perCount">每页数量</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <returns></returns>
        private static IEnumerable<T> GetPage<T>(IEnumerable<T> list, int perCount, int pageIndex)
        {
            var datas = list.ToList();
            var startIndex = perCount*(pageIndex - 1);
            //是否越界
            if (startIndex + perCount - 1 < datas.Count)
            {
                return datas.GetRange(startIndex, perCount);
            }
            //是否因为是最后一页而越界               
            if (startIndex < datas.Count)
            {
                return datas.GetRange(startIndex, datas.Count - startIndex);
            }
            return new List<T>();
        }

        #endregion

        #region 将对象数组转化为二维数组

        /// <summary>
        ///     将对象数组转化为二维数组
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="list">对象数组</param>
        /// <returns>二维数组</returns>
        public static List<List<string>> DbSetToArray<T>(List<T> list)
        {
            var array = new List<List<string>>();
            //遍历数据集
            for (var i = 0; i < list.Count; i++)
            {
                array.Add(new List<string>());
                //反射取出一行[只要数据列]
                var cols = ReflectionUtility.GetObjInfo(list[i])[1];
                foreach (var col  in cols)
                {
                    array[i].Add(col);
                }
            }
            return array;
        }

        #endregion

        #region 生成对话框

        public static string Tip(string tip, int returnIndex)
        {
            return "<script language=javascript>alert('" + tip + "');history.go(" + returnIndex + ");</script>";
        }

        public static string Tip(string tip)
        {
            return "<script>alert('" + tip + "'); window.location.href=document.referrer</script>";
        }

        public static string Tip(string tip, string returnUrl)
        {
            tip = " <script language=javascript>alert('" + tip + "');window.location.href='" + returnUrl + "';</script>";

            return tip;
        }

        #endregion

        #region 富文本和html互换

        /// <summary>
        ///     富文本转换为html
        /// </summary>
        /// <param name="paramStr">富文本字符串</param>
        /// <returns>html字符串</returns>
        public static string ToHtml(string paramStr)
        {
            var t =
                paramStr.Replace("\r\n", "</br>")
                    .Replace("\r", "</br>")
                    .Replace("\n", "</br>")
                    .Replace("“", "")
                    .Replace("'", "&quot;")
                    .Replace("‘", "&quot;")
                    .Replace("\"", "&quot;");

            return t;
        }

        /// <summary>
        ///     html转义
        /// </summary>
        /// <param name="paramStr">待转义html字符串</param>
        /// <returns>转义后的字符串</returns>
        public static string ToString(string paramStr)
        {
            var t = paramStr.Replace("</br>", "\n").Replace("\"", "‘").Replace("'", "’");

            return t;
        }

        #endregion

        #region 接口辅助函数

        /// <summary>
        ///     过滤列
        /// </summary>
        /// <param name="list">列集合</param>
        /// <param name="indexToShow">要显示的列索引集合</param>
        /// <returns>过滤后的列集合</returns>
        public static List<string> FilterColums(List<string> list, int[] indexToShow)
        {
            var array = new List<string>();
            var filterCount = 0;
            //根据规则过滤列
            for (var i = 0; i < list.Count && filterCount < indexToShow.Length; i++)
            {
                if (indexToShow[filterCount] == i)
                {
                    array.Add(list[i]);
                    filterCount++;
                }
            }
            return array;
        }

        /// <summary>
        ///     过滤列
        /// </summary>
        /// <param name="list">列集合[数据表]</param>
        /// <param name="indexToShow">要显示的列索引集合</param>
        /// <returns>过滤后的列集合</returns>
        public static List<List<string>> FilterColums(List<List<string>> list, int[] indexToShow)
        {
            var array = new List<List<string>>();

            //遍历行
            for (var i = 0; i < list.Count; i++)
            {
                array.Add(new List<string>());
                array[i].AddRange(FilterColums(list[i], indexToShow));
            }
            return array;
        }


        // 构造参数串
        public static List<string> GetLinkParms<T>(List<T> list, int perCount, int pageIndex)
        {
            var array = new List<string>();
            //遍历数据集

            for (var i = 0; i < list.Count; i++)
            {
                var parsmStr = "";
                //反射取出一行
                var row = ReflectionUtility.GetObjInfo(list[i]);
                //构造参数串
                for (var j = 0; j < row.Length; j++)
                {
                    parsmStr += row[0][j] + "=" + row[1][j] + "&"; //属性名=属性值&
                }
                array.Add(parsmStr);
            }
            return array;
        }

        //获取表头【已过时】
        public static List<string> GetHeadTitle<T>(int[] indexToShow) where T : new()
        {
            var array = new List<string>();
            //反射出所有标题
            var headTitle = ReflectionUtility.GetObjInfo(new T())[1];
            var countColumn = 0;
            for (var i = 0; i < headTitle.Length; i++)
            {
                if (indexToShow[countColumn] == i) //根据规则过滤列
                {
                    array.Add(headTitle[i]);
                    countColumn++;
                }
            }
            return array;
        }

        #endregion
    }
}
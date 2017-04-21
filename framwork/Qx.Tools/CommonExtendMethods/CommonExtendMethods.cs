using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;
using Qx.Tools.Models.Report;
using Qx.Tools.QxClass;
namespace Qx.Tools.CommonExtendMethods
{
    #region 报表扩展

    #endregion
    public static class CommonExtendMethods
    {
        //public static UnityIoc Controllers<T>(this UnityIoc ioc)
        //{
        //    UnityIoc.Register(UnityIoc.GetSubClasses<T>());
        //}

      
        public static List<List<string>> ToTableList(this SqlDataReader reader)
        {
            //所有行
            var rows = new List<List<string>>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //逐行添加内容
                    var cols = new List<string>();
                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        var value = "";

                        #region 根据格式取值

                        var type = reader.GetDataTypeName(i).ToLower();
                        if (reader.IsDBNull(i))
                        {
                            value = "";
                        }
                        else if (type==("smallint"))
                        {
                            value = reader.GetInt16(i) + "";
                        }
                        else if (type.Contains("int"))
                        {
                            value = reader.GetInt32(i) + "";
                            //
                            //var v = reader.GetInt32(i);
                            //if (v > 1000000000)
                            //{
                            //    value = reader.GetInt32(i).ToDateTime().ToStr();
                            //}
                            //else
                            //{
                            //    value = reader.GetInt32(i) + "";
                            //}
                        }
                        else if (type.Contains("float"))
                        {
                            value = reader.GetDouble(i) + "";
                        }
                        else if (type.Contains("datetime"))
                        {
                            value = reader.GetDateTime(i).ToString("yyyy-MM-dd HH:mm") + "";
                        }
                        else
                        {
                            value = reader.GetString(i) + "";
                            // Replace("%", "");//2016-09-05 配合报表转义规则 2016-09-10 更新规则
                            //if (value.Contains("%"))
                            //    throw new Exception("替换不完全！");
                        }

                        #endregion

                        cols.Add(value);
                    }
                    rows.Add(cols);
                }
            }
            reader.Close();
            reader.Dispose();
            return rows;
        }

        #region 通用

        public static bool IsSame<T, K>(this object obj)
        {
            return typeof (T).Name == typeof (K).Name;
        }

        #endregion

        #region List<SelectListItem> 相关
        public static List<DropDownListItem> ToDropDownListItem(this List<SelectListItem> items)
        {
            return items.Select(i => new DropDownListItem()
            {
                selected = i.Selected,
                text = i.Text,
                value = i.Value
            }).ToList();
        }
        public static List<SelectListItem> ToSelectListItem(this List<DropDownListItem> items)
        {
            return items.Select(i => new SelectListItem()
            {
                Selected = i.selected,
                Text = i.text,
                Value = i.value
            }).ToList().Format();
        }
      
        //从db层获取数据源
        public static List<SelectListItem> ToItems<TModel>(this IQueryable<TModel> source,
            Expression<Func<TModel, string>> valueExpression, Expression<Func<TModel, string>> textExpression)
        {
            return source.ToList().Select(m => new SelectListItem()
            {
                Text = textExpression.Compile().Invoke(m),
                Value = valueExpression.Compile().Invoke(m)
            }).ToList();
        }

        public static List<DropDownListItem> Format(this List<DropDownListItem> items, string selectedValue = ";")
        {
            return items.Format("全部",";", selectedValue);
        }
        public static List<DropDownListItem> Format(this List<DropDownListItem> items, string defaultText, string defaultValue, string selectedValue = "")
        {
            selectedValue = selectedValue.HasValue() ? selectedValue : defaultValue;
            items = items.Distinct(Equality<DropDownListItem>.CreateComparer(p => p.value)).ToList();
            if (!items.Any(a => a.text == defaultText && a.value == defaultValue))
            {
                items.Insert(0, new DropDownListItem { text = defaultText, value = defaultValue, selected = true });
            }
            items.ForEach(a =>
            {
                if (a.value == selectedValue || a.text == selectedValue)
                {
                    a.selected = true;
                }
            });
            return items;
        }


        public static List<SelectListItem> Format(this List<SelectListItem> items, string selectedValue = ";")
        {
            return items.Format( "全部", ";", selectedValue);
        }
        public static List<SelectListItem> Format(this List<SelectListItem> items,  string defaultText,string defaultValue, string selectedValue)
        {
            selectedValue = selectedValue.HasValue() ? selectedValue : defaultValue;
             items = items.Distinct(Equality<SelectListItem>.CreateComparer(p => p.Value)).ToList();
            if (!items.Any(a => a.Text == defaultText && a.Value == defaultValue))
            {
                items.Insert(0, new SelectListItem { Text = defaultText, Value = defaultValue, Selected = true });
            }
            items.ForEach(a =>
            {
                if (a.Value == selectedValue || a.Text == selectedValue)
                {
                    a.Selected = true;
                }
            });
            return items;
        }
        #endregion

        #region double 相关

        public static int EncodeingPrice(this double d_num)
        {
            return (int)(d_num * 100);
        }
        public static double DeEncodeingPrice(this int i_num)
        {
            return (i_num / 100.0);
        }
        #endregion


        #region int 相关

        public static DateTime ToDateTime(this int time)
        {
            var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return startTime.AddSeconds(time);
        }

        #endregion

        #region 快速创建 IEqualityComparer<T> 的实例

        //var equalityComparer1 = Equality<Person>.CreateComparer(p => p.ID);
        public static class Equality<T>
        {
            public static IEqualityComparer<T> CreateComparer<V>(Func<T, V> keySelector)
            {
                return new CommonEqualityComparer<V>(keySelector);
            }

            public static IEqualityComparer<T> CreateComparer<V>(Func<T, V> keySelector, IEqualityComparer<V> comparer)
            {
                return new CommonEqualityComparer<V>(keySelector, comparer);
            }

            private class CommonEqualityComparer<V> : IEqualityComparer<T>
            {
                private readonly IEqualityComparer<V> comparer;
                private readonly Func<T, V> keySelector;

                public CommonEqualityComparer(Func<T, V> keySelector, IEqualityComparer<V> comparer)
                {
                    this.keySelector = keySelector;
                    this.comparer = comparer;
                }

                public CommonEqualityComparer(Func<T, V> keySelector)
                    : this(keySelector, EqualityComparer<V>.Default)
                {
                }

                public bool Equals(T x, T y)
                {
                    return comparer.Equals(keySelector(x), keySelector(y));
                }

                public int GetHashCode(T obj)
                {
                    return comparer.GetHashCode(keySelector(obj));
                }
            }
        }

        #endregion

        #region 快速创建 IComparer<T> 的实例

        //var comparer1 = Comparison<Person>.CreateComparer(p => p.ID);
        public static class Comparison<T>
        {
            public static IComparer<T> CreateComparer<V>(Func<T, V> keySelector)
            {
                return new CommonComparer<V>(keySelector);
            }

            public static IComparer<T> CreateComparer<V>(Func<T, V> keySelector, IComparer<V> comparer)
            {
                return new CommonComparer<V>(keySelector, comparer);
            }

            private class CommonComparer<V> : IComparer<T>
            {
                private readonly IComparer<V> comparer;
                private readonly Func<T, V> keySelector;

                public CommonComparer(Func<T, V> keySelector, IComparer<V> comparer)
                {
                    this.keySelector = keySelector;
                    this.comparer = comparer;
                }

                public CommonComparer(Func<T, V> keySelector)
                    : this(keySelector, Comparer<V>.Default)
                {
                }

                public int Compare(T x, T y)
                {
                    return comparer.Compare(keySelector(x), keySelector(y));
                }
            }
        }

        #endregion

        #region List<List<string>>相关
        public static List<List<string>> RemoveCol(this List<List<string>> rows, int colIndex)
        {
            var dest = new List<List<string>>();
            for (var i = 0; i < rows.Count; i++)
            {
                var newRow = new List<string>();
                for (var j = 0; j < rows[i].Count; j++)
                {
                    if (j != colIndex)
                    {
                        newRow.Add(rows[i][j]);
                    }
                }
                dest.Add(newRow);
            }
            return dest;
        }

        public static List<List<string>> AddCol(this List<List<string>> rows, List<string> col)
        {
            if (rows.Count != col.Count)
                throw new Exception("待插入的列的个数与原有行数不匹配");
            var dest = new List<List<string>>();
            for (var i = 0; i < rows.Count; i++)
            {
                var newRow = new List<string>();
                newRow.AddRange(rows[i]);
                newRow.Add(col[i]);
                dest.Add(newRow);
            }
            return dest;
        }

        public static List<List<string>> AddRow(this List<List<string>> rows, List<string> row)
        {
            if (rows.Count > 0 && rows[0].Count != row.Count)
                throw new Exception("待插入的行的列数与原有列数不匹配");
            rows.Add(row);
            return rows;
        }

        public static List<List<string>> AddRowToFirst(this List<List<string>> rows, List<string> row)
        {
            if (rows.Count > 0 && rows[0].Count != row.Count)
                throw new Exception("待插入的行的列数与原有列数不匹配");
            rows.Insert(0, row);
            return rows;
        }

        public static List<List<string>> FilterRows(this List<List<string>> rows, List<string> indexToShow)
        {
            return rows.Select(row => FilterRow(row, indexToShow)).ToList();
        }

        #endregion

        #region List<string> 相关

        public static string PackString(this List<string> srcList, char flag = ';')
        {
            var tempString = "";

            if (srcList.Count > 0) //是否为空,只处理非空
            {
                for (var l = 0; l < srcList.Count; l++)
                {
                    tempString += srcList[l]; //构造认证字符串
                    if (l < srcList.Count - 1)
                    {
                        tempString += flag;
                    }
                }
            }

            return tempString;
        }

        public static string[] FormatString(this List<string> srcString, char flag = '%')
        {
            return srcString.Select(o => flag + o + flag).ToArray();
        }

        #endregion

        #region List<T> 相关

        public static List<T> Grap<T>(this List<T> data, int start, int end)
        {
            var dest = new List<T>();
            for (var i = start; i <= end && i < data.Count; i++)
            {
                dest.Add(data[i]);
            }
            return dest;
        }


        public static List<T> GetPage<T>(this List<T> list, int pageIndex, int perCount, out int maxIndex)
        {
            maxIndex = (int) Math.Ceiling(double.Parse(list.Count.ToString())/perCount);

            var datas = list.ToList();
            var startIndex = perCount*(pageIndex - 1);
            //是否越界
            if (pageIndex <= 0)
                return new List<T>();

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

        public static IEnumerable<T> GetPage<T>(this IEnumerable<T> list, int pageIndex, int perCount, out int maxIndex)
        {
            var datas = list.ToList();
            return datas.GetPage(pageIndex, perCount, out maxIndex);
        }

        #endregion

        #region List<string> 相关

        public static string ToString(this List<string> list, string splitFlag = " ")
        {
            var dest = "";
            list.ForEach(item => { dest += item + splitFlag; });
            return dest;
        }

        public static List<string> FilterRow(this List<string> row, List<string> indexToShow)
        {
            var dest = new List<string>();

            for (var i = 0; i < row.Count; i++)
            {
                if (indexToShow.Contains(i.ToString()))
                {
                    dest.Add(row[i]);
                }
            }

            return dest;
        }

        #endregion

        #region DateTime 相关

        public static string Random(this DateTime time)
        {
            return UUID.NewUUID();
        }

        public static string TimeToNow(this DateTime time)
        {
            return (int) (DateTime.Now - time).TotalDays + "天前";
        }

        public static string ToStr(this DateTime time, bool showToNow = false)
        {
            var temp = time.ToLongDateString() + " " + time.ToLongTimeString();
            return showToNow ? temp + "(" + TimeToNow(time) + ")" : temp;
        }

        public static int ToInt(this DateTime time)
        {
            var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return (int) (time - startTime).TotalSeconds;
        }
        public static int EncodeingTime(this DateTime time)
        {
            return ToInt(time);
        }
        public static DateTime DeEncodeingTime(this int seconds)
        {
            return TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1).AddSeconds(seconds));
        }
        public static string ToTimeStr(this DateTime time)
        {
            return time.ToLongDateString() + " " + time.ToLongTimeString();
        }

        #endregion

        #region Type 相关

        //获取Controller下的public action =>通过反射获取Controller的子方法
        public static List<MethodInfo> GetSubActions(this Type t)
        {
            return t.GetMethods().Where(m => m.ReturnType == typeof (ActionResult) && m.IsPublic).ToList();
        }

        //获取所有的Controllers =>通过反射获取Controller的子类
        public static List<Type> GetSubClasses(this Type type)
        {
            return Assembly.GetCallingAssembly().GetTypes().Where(
                t => t.IsSubclassOf(type)).ToList();
        }

        public static List<Type> GetAllTypes(this object obj, List<string> AssemblieFilter, List<string> NamespaceFilter)
        {
            var allAssemlys = AppDomain.CurrentDomain.GetAssemblies().ToList();
            var filteredAssemlys = new List<Assembly>();

            var allTypes = new List<Type>();
            var filteredTypes = new List<Type>();

            AssemblieFilter.ForEach(a => { filteredAssemlys.AddRange(allAssemlys.Where(b => b.FullName.Contains(a))); });
            for (var i = 0; i < filteredAssemlys.Count; i++)
            {
                try
                {
                    allTypes.AddRange(allAssemlys[i].GetTypes());
                }
                catch (Exception)
                {
                    i++;
                    //越过异常 throw;
                }
            }

            NamespaceFilter.ForEach(a => { filteredTypes.AddRange(allTypes.Where(b => b.FullName.Contains(a))); });
            return filteredTypes;
        }

        public static Dictionary<Type, Type> GetClassInterfaceDic(this List<Type> Types)
        {
            var dest = new Dictionary<Type, Type>();

            var interfaces = Types.Where(a => a.IsInterface);
            var classes = Types.Where(a => !a.IsInterface);

            foreach (var _interface in interfaces)
            {
                foreach (var _class in classes.Where(a => a.GetInterfaces().Contains(_interface))) //实现该接口的所有类
                {
                    //如果出现一个接口被多个类实现，这里会执行多次，对于ioc是非常不利的！！
                    //采用dictionary 可以避免避免插入重复匹配记录
                    try
                    {
                        dest.Add(_interface, _class);
                    }
                    catch (Exception ex)
                    {
                        break; //检测到重复 做中断处理
                    }
                }
            }

            return dest;
        }

        #endregion

        #region string 相关
        [Obsolete("请使用ExecuteReader2代替")]
        public static SqlDataReader ExecuteReader(this string sql, string connStr)
        {
            throw new Exception("方法已废弃,请使用ExecuteReader2代替!");
            SqlDataReader reader;
            var Con = new SqlConnection(connStr);

            var Com = new SqlCommand(sql, Con);
            try
            {
                Con.Open();
                reader = Com.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return reader;
        }
        public static List<List<string>> ExecuteReader2(this string sql, string connStr)
        {
            using (var Con = new SqlConnection(connStr))
            {
                using (var Com = new SqlCommand(sql, Con))
                {
                    try
                    {
                        //打开连接
                        if (Con.State != ConnectionState.Open)
                        {
                            Con.Open();
                        }
                        using (var reader = Com.ExecuteReader())
                        {
                            var result = reader.ToTableList();
                            //关闭reader
                            reader.Close();
                            reader.Dispose();
                            return result;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("执行数据库查询出错，错误信息:"+ex.Message);
                    }
                    finally
                    {
                        Com.Dispose();
                        // 关闭连接
                        if (Con.State != ConnectionState.Closed)
                        { Con.Close(); }
                    }
                }
            } 
         
        }

        public static string AddSpace(this string src, char splitFlag = ' ')
        {
            return src+"&nbsp;" + splitFlag ;
        }
        public static int ExecuteNonQuery(this string sql, string connStr)
        {
            var count = 0;
            using (var Con = new SqlConnection(connStr))
            {
                using (var Com = new SqlCommand(sql, Con))
                    try
                    {
                        //打开连接
                        if (Con.State != ConnectionState.Open)
                        { Con.Open(); }
                        count = Com.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("执行数据库查询失败，错误信息:" + ex.Message);
                    }
                    finally
                    {
                        if (Con.State == ConnectionState.Open)
                        {
                            Com.Dispose(); ;
                            Con.Close();
                            Con.Dispose();
                        }
                    }

            }
            return count;
        }

        public static List<string> UnPackString(this string srcString, char flag, bool removeEmpty = false)
        {
            //关于控制检测
            //若数据库 存在该行，但是该列为空，此时读出的字符串 ""
            //若数据库 不存在该行 此时读出的字符串 null

            if (!string.IsNullOrEmpty(srcString)) //是否为空 既然能传入肯定不是null
            {
                srcString.Trim(); //清除空格
                var temp = srcString.Split(flag).ToList(); //拆分成数组  
                if (removeEmpty)
                {
                    if (temp[temp.Count - 1] == "")
                    {
                        temp.RemoveAt(temp.Count - 1);
                    }
                }

                return temp;
            }
            return new List<string>(0);
        }

        public static bool HasValue(this string srcString)
        {
            if (string.IsNullOrWhiteSpace(srcString))
            {
                return false;
            }
            return true;
        }
        public static string ReplaceFirst(this string src, string oldValue, string newValue,string autoAddFlag="")
        {
            oldValue = autoAddFlag+ oldValue;
            var dest = src;
            var oldStringLenth = oldValue.Length;
            var index = src.IndexOf(oldValue, StringComparison.Ordinal);
            if (index > -1)
            {
                var startIndex = index + oldStringLenth;
                var front = src.Substring(0, index);
                var behind = src.Substring(startIndex, src.Length - startIndex);
                dest = front + newValue + behind;
            }
            return dest;
        }

        public static int ToInt(this string srcString)
        {
            if (srcString.HasValue())
            {
                return int.Parse(srcString);
            }
            return -1;
        }

        #endregion

        #region Entity 相关

        public static bool Saved(this DbContext db)
        {
            db.SaveChanges();
            return true;
        }

        public static bool SaveAdd(this DbContext db, object entity)
        {
            db.Entry(entity).State = EntityState.Added;
            db.SaveChanges();
            return true;
        }

        public static bool SaveDelete(this DbContext db, object entity)
        {
            db.Entry(entity).State = EntityState.Deleted;
            db.SaveChanges();
            return true;
        }

        public static bool SaveModified(this DbContext db, object entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        public static bool Save<T>(this T table, DbContext db) where T : class
        {
            return db.Saved();
        }

        #endregion

        #region Http
        public static string Post(this HttpClient client, string url, Dictionary<string, string> param)
        {
            var request = new HttpRequest(url, RestSharp.Method.POST);
            foreach (var key in param.Keys)
            {
                request.AddParameter(key, param[key]);
            }
            var response = client.Execute(request);
            var content = response.Content;
            return content;
        }
        public static string Post(this HttpClient client, string url, Dictionary<string, string> param, Dictionary<string, string> header)
        {
            var request = new HttpRequest(url, RestSharp.Method.POST);
            foreach (var key in param.Keys)
            {
                request.AddParameter(key, param[key]);
            }
            foreach (var key in header.Keys)
            {
                request.AddParameter(key, header[key]);
            }
            var response = client.Execute(request);
            var content = response.Content;
            return content;
        }
        public static string Get(this HttpClient client, string url)
        {
            var request = new HttpRequest(url, RestSharp.Method.GET);
            var response = client.Execute(request);
            var content = response.Content;
            return content;
        }
        #endregion
    }
}
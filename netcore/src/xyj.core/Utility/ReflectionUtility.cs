using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace xyj.core.Utility
{
    public static class ReflectionUtility
    {
        #region 获取对象的属性键值对

        /// <summary>
        ///     获取对象的属性键值对
        /// </summary>
        /// <param name="obj">赋值后的对象</param>
        /// <returns>属性键值对 string[0]+string[1]</returns>
        public static string[][] GetObjInfo(object obj)
        {
            var t = obj.GetType();
            var p = t.GetProperties();
            var properties = new string[p.Length];
            var values = new string[p.Length];
            for (var i = 0; i < p.Length; i++)
            {
                properties[i] = p[i].Name;
                var temp = t.GetProperty(p[i].Name).GetValue(obj);
                values[i] = temp == null ? "未填写" : temp.ToString();
            }
            var result = new[] {properties, values};
            return result;
        }
        public static Dictionary<string,object> GetObjDic(object obj)
        {
            
            var dic = new Dictionary<string, object>();
            var t = obj.GetType();

            if (t==typeof(JObject))
            {
                var jObj = (Newtonsoft.Json.Linq.JObject) obj;
                var properties = jObj.Properties();
                foreach (var p in properties)
                {
                    dic.Add(p.Name, p.Value+"");
                }
            }  
            else
            {
                var p = t.GetProperties();
                for (var i = 0; i < p.Length; i++)
                {
                    var propertie = p[i].Name;
                    var temp = t.GetProperty(p[i].Name).GetValue(obj);
                    var value = temp == null ? "" : temp.ToString();
                    dic.Add(propertie, value);
                }
            }
           
            return dic;
        }
        #endregion

        #region 取到对象的属性集合

        /// <summary>
        ///     取到对象的属性集合
        /// </summary>
        /// <param name="fullObjName">对象的类全名</param>
        /// <returns>属性集合</returns>
        public static string[] GetProperties(string fullObjName,Type type=null)
        {
            return GetProperties((type == null ? Assembly.GetExecutingAssembly() 
                : Assembly.GetAssembly(type)), fullObjName);
           
        }

        private static string[] GetProperties(Assembly assembly, string fullObjName)
        {
            var instance = assembly.CreateInstance(fullObjName);
            if (instance != null)
            {
                var p = instance.GetType().GetProperties();
                var result = new string[p.Length];
                for (var i = 0; i < p.Length; i++)
                {
                    result[i] = p[i].Name;
                }
                return result;
            }
            else
            {
                return new string[0];
            }
        }
        public static string[] GetProperties(Type type)
        {
            return GetProperties(Assembly.GetAssembly(type), type.FullName);
        }
        /// <summary>
        ///     取到对象的属性集合
        /// </summary>
        /// <param name="objName">对象的类名</param>
        /// <param name="nameSpace">对象的命名空间</param>
        /// <returns>属性集合</returns>
        public static string[] GetProperties(string objName, string nameSpace,Type type=null)
        {
            return GetProperties(nameSpace + "." + objName, type);
        }

        #endregion

        #region 获取对象的指定属性值

        /// <summary>
        ///     获取对象的属性值
        /// </summary>
        /// <param name="obj">赋值后的对象</param>
        /// <param name="PropertieName">属性值</param>
        /// <returns>属性名+属性值 object[0]+object[1]</returns>
        public static object GetObjPropertieValue(object obj, string PropertieName)
        {
            object value="";
            try
            {
                return obj.GetType().GetProperty(PropertieName).GetValue(obj);
            }
            catch (Exception)
            {
                return value;
            }
           
        }

        /// <summary>
        ///     获取对象的属性值
        /// </summary>
        /// <param name="obj">赋值后的对象</param>
        /// <param name="PropertieIndex">属性索引</param>
        /// <returns>属性名+属性值 object[0]+object[1]</returns>
        public static object GetObjPropertieValue(object obj, int PropertieIndex)
        {
            object[] result = null;
            if (obj != null)
            {
                result = new string[2];
                var t = obj.GetType();
                var p = t.GetProperties();
                result[0] = p[PropertieIndex].Name;
                result[1] = obj.GetType().GetProperty(p[PropertieIndex].Name).GetValue(obj);
                return result;
            }
            return result;
        }

        #endregion

        #region 根据对象的‘属性键值对’或‘已赋值对象’生成Sql语句  [规定表名和类名必须相同]

        /// <summary>
        ///     根据对象的‘属性键值对’生成Sql插入语句 [规定表名和类名必须相同]
        /// </summary>
        /// <param name="objName">类名</param>
        /// <param name="nameSpace">类命名空间</param>
        /// <param name="Data">对象的属性键值对</param>
        /// <returns>SQl插入语句</returns>
        public static string InsertSql(string objName, string nameSpace, string[][] Data)
        {
            //表名，默认等于类名
            var tableName = objName;
            var colNames = ""; //列名字符串
            var colValues = ""; //列名字符串
            for (var i = 0; i < Data[0].Length; i++)
            {
                colNames += Data[0][i];
                colValues += "'" + Data[1][i] + "'";
                colNames += ",";
                colValues += ",";
            }
            var tttt = colNames[colNames.Length - 1];
            if (colNames[colNames.Length - 1] == ',')
            {
                colNames = colNames.Substring(0, colNames.Length - 1);
                colValues = colValues.Substring(0, colValues.Length - 1);
            }

            var sql = "insert into " + tableName + "(" + colNames + ")values(" + colValues + ")";
            return sql;
        }

        /// <summary>
        ///     根据‘已赋值对象’生成Sql插入语句 [规定表名和类名必须相同]
        /// </summary>
        /// <param name="Data">已赋值对象</param>
        /// <returns>SQl插入语句</returns>
        public static string InsertSql(object Data)
        {
            var type = Data.GetType();
            var tableName = type.Name; //表名
            var Properties = type.GetProperties();
            var colNames = ""; //列名字符串
            var colValues = ""; //列名字符串
            for (var i = 0; i < Properties.Length; i++)
            {
                //过滤外键
                if (Properties[i].PropertyType.Name.Contains("String") ||
                    Properties[i].PropertyType.Name.Contains("Int") || Properties[i].PropertyType.Name.Contains("Float"))
                {
                    colNames += Properties[i].Name;
                    colValues += "'" + Properties[i].GetValue(Data) + "'";
                    colNames += ",";
                    colValues += ",";
                }
            }
            var tttt = colNames[colNames.Length - 1];
            if (colNames[colNames.Length - 1] == ',')
            {
                colNames = colNames.Substring(0, colNames.Length - 1);
                colValues = colValues.Substring(0, colValues.Length - 1);
            }

            var sql = "insert into " + tableName + "(" + colNames + ")values(" + colValues + ")";
            return sql;
        }


        /// <summary>
        ///     根据‘已赋值对象’生成Sql查询语句 [规定表名和类名必须相同]
        /// </summary>
        /// <param name="Data">已赋值对象</param>
        /// <param name="conditions">条件字符串集</param>
        /// <param name="slectColNames">投影字符串集</param>
        /// <returns></returns>
        public static string SelectSql(object Data, string[] conditions, string[] slectColNames = null)
        {
            var type = Data.GetType();
            var tableName = type.Name; //表名

            var slectColNameStr = ""; //选择列字符串
            if (slectColNames == null || slectColNames.Length == 0)
            {
                slectColNameStr = "*";
            }
            else
            {
                for (var a = 0; a < slectColNames.Length; a++)
                {
                    slectColNameStr += slectColNames[a] + ",";
                }
                if (slectColNameStr[slectColNameStr.Length - 1] == ',')
                {
                    slectColNameStr = slectColNameStr.Substring(0, slectColNameStr.Length - 1);
                }
            }


            var conditionStr = ""; //条件字符串
            for (var i = 0; i < conditions.Length; i++)
            {
                conditionStr += conditions[i] + " = " + "'" + type.GetProperty(conditions[i]).GetValue(Data) + "' And";
            }

            if (conditionStr[conditionStr.Length - 1] == 'd')
            {
                conditionStr = conditionStr.Substring(0, conditionStr.Length - 3);
            }

            var sql = "select " + slectColNameStr + " from " + tableName + " where " + conditionStr;
            return sql;
        }

        /// <summary>
        ///     根据‘已赋值对象’生成Sql查询语句 [规定表名和类名必须相同]
        /// </summary>
        /// <param name="Data">已赋值对象</param>
        /// <param name="conditionIndexs">条件索引集</param>
        /// <param name="slectColNameIndexs">投影索引集</param>
        /// <returns></returns>
        public static string SelectSql(object Data, int[] conditionIndexs, int[] slectColNameIndexs = null)
        {
            var type = Data.GetType();
            var tableName = type.Name; //表名
            var Properties = type.GetProperties();

            var slectColNameStr = ""; //选择列字符串
            //选择列是否为空
            if (slectColNameIndexs == null || slectColNameIndexs.Length == 0)
            {
                slectColNameStr = "*";
            }
            else
            {
                for (var a = 0; a < slectColNameIndexs.Length; a++)
                {
                    slectColNameStr += Properties[slectColNameIndexs[a]].Name + ",";
                }
                if (slectColNameStr[slectColNameStr.Length - 1] == ',')
                {
                    slectColNameStr = slectColNameStr.Substring(0, slectColNameStr.Length - 1);
                }
            }


            var conditionStr = ""; //条件字符串
            for (var i = 0; i < conditionIndexs.Length; i++)
            {
                //过滤外键
                if (Properties[conditionIndexs[i]].PropertyType.Name.Contains("String") ||
                    Properties[conditionIndexs[i]].PropertyType.Name.Contains("Int") ||
                    Properties[conditionIndexs[i]].PropertyType.Name.Contains("Float"))
                {
                    conditionStr += Properties[conditionIndexs[i]].Name + " = " + "'" +
                                    Properties[conditionIndexs[i]].GetValue(Data) + "' And";
                }
            }

            if (conditionStr[conditionStr.Length - 1] == 'd')
            {
                conditionStr = conditionStr.Substring(0, conditionStr.Length - 3);
            }

            var sql = "select " + slectColNameStr + " from " + tableName + " where " + conditionStr;
            return sql;
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Qx.Tools.CommonExtendMethods
{
    public static class JsonExtension
    {
        public static string Serialize<T>(this T obj,bool isEntity=false)
        {
            return isEntity? SerializeEntity(obj):JsonUtility.Serialize(obj);
        }
        public static string SerializeEntity<T>(this T obj)
        {
            var type = obj.GetType();
            var list = obj.GetType().GetProperties().
                Where(pi => !pi.PropertyType.IsClass||QxConfigs.AllType.Contains(pi.PropertyType.ToString())).ToList();
            if (!list.Any())
                return "{}";
            var json = "{";
            for (var i=0;i< list.Count();i++ )
            {
                var current = list[i];
                var value = type.GetProperty(current.Name).GetValue(obj);
                var valueString = "";
                switch (current.PropertyType.ToString())
                {
                    case "System.DateTime"://时间特别处理
                    {
                        if (value != null)
                                valueString = (((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss:ms"));
                    } break;
                    default:
                    {
                            if (value != null)
                                valueString = value+"" ;
                     }
                        break;
                }
                json += ("\"" + current.Name + "\":\"" + valueString + 
                         (i== list.Count()-1? "\"}" : "\",")
                         );
            }
            return json;
        }
        public static T Deserialize<T>(this string jsonString)
        {
            return JsonUtility.Deserialize<T>(jsonString);
        }

        public static dynamic ToObject(this string jsonString)
        {
            return JsonUtility.Deserialize<dynamic>(jsonString);
        }
    }
}
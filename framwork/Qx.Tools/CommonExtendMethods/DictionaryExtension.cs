using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qx.Tools.CommonExtendMethods
{
  public static class DictionaryExtension
    {
        public static string ToJson(this Dictionary<string, string> dictionary)
        {
            var json = "{";
            var keys = dictionary.Keys.ToList();
            for (var i = 0; i < keys.Count; i++)
            {
                var key = keys[i];
                var value = dictionary[key];
                json += "\"" + key + "\":\"" + value + "\"" 
                    + (i == keys.Count - 1 ? "" : ",");
            }
            json += "}";
            return json;
        }
    }
}

using System;
using System.Text;
using Qx.Tools;

namespace qx.wechat.Interfaces
{
  public static class WechatExtension
    {
        public static string ToXml(this object obj)
        {
         var keys=  ReflectionUtility.GetObjInfo(obj)[0];
            var values = ReflectionUtility.GetObjInfo(obj)[1];
            var dest = new StringBuilder();
            dest.Append("<xml>");
            for (var i=0;i<  keys.Length;i++)
            {
                dest.Append(String.Equals(keys[0], "CreateTime", StringComparison.CurrentCultureIgnoreCase)
                    ? string.Format("<{0}>{1}</{0}>", keys[i], values[i])
                    : string.Format("<{0}><![CDATA[{1}]]></{0}>", keys[i], values[i]));
            }
            dest.Append("</xml>");
            return dest.ToString();
        }
    }
}

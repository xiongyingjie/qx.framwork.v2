using System;
using System.Collections.Generic;
using System.Linq;

namespace Qx.Tools.CommonExtendMethods
{
    public static class DateTimeExtension
    {

        public static string Random(this DateTime time)
        {
            return UUID.NewUUID();
        }

        public static string TimeToNow(this DateTime time)
        {
            return (int)(DateTime.Now - time).TotalDays + "天前";
        }

        public static string ToStr(this DateTime time, bool showToNow = false)
        {
            var temp = time.ToLongDateString() + " " + time.ToLongTimeString();
            return showToNow ? temp + "(" + TimeToNow(time) + ")" : temp;
        }

        public static int ToInt(this DateTime time)
        {
            var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
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
    }
}
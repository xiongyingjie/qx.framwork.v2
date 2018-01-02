using System;
using xyj.core.Utility;

namespace xyj.core.Extensions
{
    public static class DateTimeExtension
    {

        public static string Random(this DateTime time,int length=-1,string pre="R")
        {
            var dest = UUID.NewUUID();
            return pre + (length==-1? dest: dest.Substring(0, length));
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

        public static DateTime ToDateTime(this string timeString)
        {
            var time = DateTime.Now;
            try
            {
                var realTime = DateTime.Parse(timeString);
                if (realTime != DateTime.MinValue)
                {
                    time = realTime;
                }
            }
            catch (Exception ex) { }
            return time;
          
        }
        public static string FormatTime(this DateTime time,bool blankSpace=true,bool onlyHMS=false)
        {
            return time.ToString(onlyHMS ?
                (blankSpace ? "HH:mm" : "HHmmss"):              
                (blankSpace ? "yyyy-MM-dd HH:mm" : "yyyyMMddHHmmss"));
        }
        public static string FormatDate(this DateTime time, bool removeSplit = false)
        {
            return time.ToString(removeSplit? "yyyyMMdd" : "yyyy-MM-dd");
        }
    }
}
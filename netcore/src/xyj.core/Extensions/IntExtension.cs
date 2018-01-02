using System;

namespace xyj.core.Extensions
{
    public static class IntExtension
    {
        public static DateTime ToDateTime(this int time)
        {
            var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return startTime.AddSeconds(time);
        }

    }
}
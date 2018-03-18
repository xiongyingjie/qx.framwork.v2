using System;

namespace xyj.core.Extensions
{
    public static class IntExtension
    {
        public static DateTime ToDateTime(this int time)
        {


    
               return time.DeEncodeingTime();
        }

    }
}
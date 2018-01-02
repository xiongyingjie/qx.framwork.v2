using System;
using System.Collections.Generic;
using System.Linq;

namespace Qx.Tools.CommonExtendMethods
{
    public static class DoubleExtension
    {
        public static int EncodeingPrice(this double d_num)
        {
            return (int)(d_num * 100);
        }

        public static double DeEncodeingPrice(this int i_num)
        {
            return (i_num / 100.0);
        }
    }
}
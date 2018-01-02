using System;

namespace xyj.core.Models.Report
{
   public class CrossDbParam
   {
       public int ParamIndex;
       public int OutIndex;
       // public string OutTitle;
        public Func<string, string> Func;
   }
}

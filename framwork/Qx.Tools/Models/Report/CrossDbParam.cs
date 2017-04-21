using System;

namespace Qx.Tools.Models.Report
{
   public class CrossDbParam
   {
       public int ParamIndex;
       public int OutIndex;
       // public string OutTitle;
        public Func<string, string> Func;
   }
}

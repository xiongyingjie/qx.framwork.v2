using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qx.Report.Models
{
   public class CrossDbParam
   {
       public int ParamIndex;
       public int OutIndex;
       // public string OutTitle;
        public Func<string, string> Func;
   }
}

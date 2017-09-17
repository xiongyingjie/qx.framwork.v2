using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qx.Tools.Annotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ReportAttrabute : Attribute
    {
        public string note;

        public ReportAttrabute(string note)
        {
            this.note = note;
        }
    }
}

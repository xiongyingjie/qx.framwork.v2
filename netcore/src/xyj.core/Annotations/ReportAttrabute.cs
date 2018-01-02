using System;

namespace xyj.core.Annotations
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

using System;

namespace Qx.Tools.Exceptions.Report
{
    public class ReportConfigErrorException : Exception
    {
        public ReportConfigErrorException(string message) : base(message)
        {
        }
    }
}

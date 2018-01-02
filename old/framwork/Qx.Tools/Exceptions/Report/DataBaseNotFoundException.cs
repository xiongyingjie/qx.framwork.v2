using System;

namespace Qx.Tools.Exceptions.Report
{
    public class DataBaseNotFoundException : Exception
    {
        public DataBaseNotFoundException(string message):base(message)
        {
        }
    }
}

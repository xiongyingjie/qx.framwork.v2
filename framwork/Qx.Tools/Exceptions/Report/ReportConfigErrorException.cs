namespace Qx.Tools.Exceptions.Report
{
    public class ReportConfigErrorException : System.Exception
    {
        private string v;

        public ReportConfigErrorException(string v)
        {
            this.v = v;
        }
    }
}

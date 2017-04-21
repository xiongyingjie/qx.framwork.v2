namespace Qx.Tools.Exceptions.Report
{
    public class ReportNotFoundException : System.Exception
    {
        private string v;

        public ReportNotFoundException(string v)
        {
            this.v = v;
        }
    }
}

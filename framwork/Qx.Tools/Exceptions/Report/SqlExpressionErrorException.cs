namespace Qx.Tools.Exceptions.Report
{
    public class SqlExpressionErrorException : System.Exception
    {
        private string v;

        public SqlExpressionErrorException(string v)
        {
            this.v = v;
        }
    }
}

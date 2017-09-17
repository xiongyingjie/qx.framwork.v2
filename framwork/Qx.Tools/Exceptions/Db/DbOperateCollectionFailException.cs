using System.Collections.Generic;
using System.Linq;
using Qx.Tools.Models.Db;

namespace Qx.Tools.Exceptions.Db
{
    public class DbOperateCollectionFailException : System.Exception
    {
        public List<string> Messages { get; }
        public List<DbOperate> Operates { get; }

        public List<DbOperate> SuccessfulOperates
        {
            get { return Operates.GetRange(0, _successfulCount).ToList(); }
        }

        private int _successfulCount;
        public DbOperateCollectionFailException(string message, List<DbOperate> operates, List<string> messages, int successfulCount) : base(message)
        {
            Operates = operates;
            Messages = messages;
            _successfulCount = successfulCount;
        }
    }
}

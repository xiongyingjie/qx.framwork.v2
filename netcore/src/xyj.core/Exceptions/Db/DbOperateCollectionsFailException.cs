using System.Collections.Generic;
using System.Linq;
using xyj.core.Models.Db;

namespace xyj.core.Exceptions.Db
{
    public class DbOperateCollectionsFailException : System.Exception
    {
        public List<string> Messages { get; }
        public List<DbOperateCollection> Operates { get; }

        public List<DbOperateCollection> SuccessfulOperates
        {
            get { return Operates.GetRange(0, _successfulCount).ToList(); }
        }

        private int _successfulCount;
        public DbOperateCollectionsFailException(string message, List<DbOperateCollection> operates, List<string> messages, int successfulCount) : base(message)
        {
            Operates = operates;
            Messages = messages;
            _successfulCount = successfulCount;
        }
    }
}

using System;
using Qx.Account.Entity;
using Qx.Tools.CommonExtendMethods;

namespace Qx.Account.Services
{
    public class BaseRepository
    {
        private MyDbContext db;

        protected MyDbContext Db
        {
            get
            {
                if (db == null)
                {
                    db = new MyDbContext();
                }
                return db;
            }
        }

        protected string Pk { get { return DateTime.Now.Random().ToString(); } }
    }
}

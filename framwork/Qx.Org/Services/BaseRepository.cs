using System;
using Qx.Org.Entity;
using Qx.Tools.CommonExtendMethods;

namespace Qx.Org.Services
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

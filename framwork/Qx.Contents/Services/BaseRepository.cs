using System;
using Qx.Contents.Entity;
using Qx.Tools.CommonExtendMethods;

namespace Qx.Contents.Services
{
    public class BaseRepository
    {
        private ContentsContext db;
      
        protected ContentsContext Db
        {
            get
            {
                if (db == null)
                {
                    db = new ContentsContext();
                }
                return db;
            }
        }


        protected string Pk
        {
            get { return DateTime.Now.Random().ToString(); }
        }
    }
}
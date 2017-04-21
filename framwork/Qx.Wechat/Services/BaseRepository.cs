using System;
using System.IO;
using System.Text;
using Qx.Tools.CommonExtendMethods;
using Qx.Wechat.Entity;

namespace Qx.Wechat.Services
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
       
        protected void WriteFile( string content, bool isBinaryWriter = true)
        {
            var filePath = @"E:\svn\djk.web\Web\UserFiles\Test\service-log.json";
            var fs = System.IO.File.Exists(filePath) ?
                new FileStream(filePath, FileMode.Append) :
                System.IO.File.Create(filePath);
            using (fs)
            {
                if (isBinaryWriter)
                {
                    var br = new BinaryWriter(fs, Encoding.UTF8);
                    br.Write(true);
                    br.Flush();
                    br.Close();
                }
                else
                {
                    var sw = new StreamWriter(fs);
                    sw.Write(content);
                    sw.Flush();
                    sw.Close();
                }
                fs.Close();
            }
        }
        protected string Pk { get { return DateTime.Now.Random().ToString(); } }
    }
}

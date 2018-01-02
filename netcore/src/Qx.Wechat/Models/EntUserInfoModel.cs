using System.Collections.Generic;

namespace qx.wechat.Models
{
    public class Extattr
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> attrs { get; set; }
    }

    public class EntUserInfoModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int errcode { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string errmsg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string userid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<int> department { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string position { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string gender { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string avatar { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Extattr extattr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> order { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int wxplugin_status { get; set; }
    }
}
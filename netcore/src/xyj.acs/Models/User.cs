using System;
using xyj.core.Extensions;

namespace xyj.acs.Models
{
    public  class User
    {
        public string units { get; set; }
        public string uid
        {
            get
            {
                return user_id.Encrypt();
            }
        } //加密版
        public string user_id { get; set; }
        
        public string nick_name { get; set; }

        public string user_pwd { get; set; }

        public string email { get; set; }

        public string phone { get; set; }
        
        public string user_type_id { get; set; }

        public string note { get; set; }
        public string sub_system_reg_id { get; set; }

        public DateTime register_date { get; set; }

        public DateTime last_login_date { get; set; }
        
    }
}

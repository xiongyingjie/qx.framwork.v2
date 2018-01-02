using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qx.wechat.Models
{
    public class WxCfg
    {
        public string appId { get; set; }
        public string jsapi_ticket { get; set; }
        public string param { get; set; }
        
        public string timestamp { get; set; }
        public string noncestr { get; set; }
        public string signature { get; set; }
        public string url { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qx.Wechat.Interfaces
{
   public interface IWechatProvider
    {
        string MsgHandle(string xmlBody);
    }
}

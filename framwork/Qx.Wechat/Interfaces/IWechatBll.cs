using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qx.Wechat.Models;

namespace Qx.Wechat.Interfaces
{
 public   interface IWeChatBll
    {
        bool Binding(string openId);
        bool HasBinding(string openId);

        bool UnBinding(string openId);
        Msg Main(Msg msg);
    }


}

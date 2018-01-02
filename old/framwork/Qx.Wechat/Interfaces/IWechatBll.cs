using qx.wechat.Models;
using Qx.Tools.Interfaces;

namespace qx.wechat.Interfaces
{
 public   interface IWeChatBll : IAutoInject
    {
        bool Binding(string openId);
        bool HasBinding(string openId);

        bool UnBinding(string openId);
        Msg Main(Msg msg);
    }


}

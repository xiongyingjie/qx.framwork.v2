using Qx.Tools.Interfaces;

namespace qx.wechat.Interfaces
{
   public interface IWechatProvider : IAutoInject
    {
        string MsgHandle(string xmlBody);
    }
}

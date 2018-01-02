using qx.wechat.Models;
using Qx.Tools.Interfaces;

namespace qx.wechat.Interfaces
{
    public interface IWxConfigHelper:IAutoInject
    {
        WxCfg GetCfg(string url, string key);
    }
}
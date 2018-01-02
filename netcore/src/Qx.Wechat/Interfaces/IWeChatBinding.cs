using System.Collections.Generic;
using Qx.Tools.Interfaces;

namespace qx.wechat.Interfaces
{
  public  interface IWeChatBinding : IAutoInject
    {
        bool Binding(string openId);
        bool HasBinding(string openId);
        T Find<T>(string openId);

        IEnumerable<T> All<T>();

        bool UnBinding(string openId);
    }
}

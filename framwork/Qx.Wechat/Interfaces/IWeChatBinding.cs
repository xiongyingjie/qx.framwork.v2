using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qx.Wechat.Interfaces
{
  public  interface IWeChatBinding
  {
        bool Binding(string openId);
        bool HasBinding(string openId);
        T Find<T>(string openId);

        IEnumerable<T> All<T>();

        bool UnBinding(string openId);
    }
}

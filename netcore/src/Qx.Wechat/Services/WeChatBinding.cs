using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using qx.wechat.Interfaces;

namespace Qx.Wechat.Services
{
   public class WeChatBinding: IWeChatBinding
    {
        public bool Binding(string openId)
        {
            throw new NotImplementedException();
        }

        public bool HasBinding(string openId)
        {
            throw new NotImplementedException();
        }

        public T Find<T>(string openId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> All<T>()
        {
            throw new NotImplementedException();
        }

        public bool UnBinding(string openId)
        {
            throw new NotImplementedException();
        }
    }
}

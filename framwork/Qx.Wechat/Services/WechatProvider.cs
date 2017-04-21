using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qx.Wechat.Interfaces;

namespace Qx.Wechat.Services
{
  public  class WechatProvider: IWechatProvider
  {
      private IWechatServices _wechatServices;

      public WechatProvider(IWechatServices wechatServices)
      {
          _wechatServices = wechatServices;
      }

      public string MsgHandle(string xmlBody)
      {
        return  _wechatServices.MsgHandle(xmlBody);
      }
    }
}

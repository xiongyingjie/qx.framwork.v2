using qx.wechat.Interfaces;

namespace qx.wechat.Services
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

using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Qx.Tools.CommonExtendMethods;
using Qx.Wechat.Interfaces;

namespace Web.Areas.WeChat.Controllers
{
    public class HomeController : BaseWeChatController
    {

        private IWechatServices _wechatServices;

        public HomeController(IWechatServices wechatServices)
        {
            _wechatServices = wechatServices;
        }

    
        // GET: /WeChat/Home/Index
//        public ActionResult Index()
//        {

          
//            var content = "success";

//            #region 记录日志

//            /*yyyy.MMMM.dd.hh.mm.ss*/
//            try
//            {
//                var test1 = @"<xml><ToUserName><![CDATA[gh_fc4c31ef2ade]]></ToUserName>
//<FromUserName><![CDATA[oe4J2uAJoapkwmf039OcFy_YwVMw]]></FromUserName>
//<CreateTime>1478029372</CreateTime>
//<MsgType><![CDATA[text]]></MsgType>
//<Content><![CDATA[哦哦]]></Content>
//<MsgId>6348087815716601133</MsgId>
//</xml>";

//                var test2 = @"<xml><ToUserName><![CDATA[gh_fc4c31ef2ade]]></ToUserName>
//<FromUserName><![CDATA[oe4J2uAJoapkwmf039OcFy_YwVMw]]></FromUserName>
//<CreateTime>1478029372</CreateTime>
//<MsgType><![CDATA[text]]></MsgType>
//<Content><![CDATA[哦哦]]></Content>
//<MsgId>6348087815716601133</MsgId>
//</xml>";
//                  //content = _wechatServices.MsgHandle(test1);
//                   //content = _wechatServices.MsgHandle(test2);
//                content = _wechatServices.MsgHandle(XmlRequstBody);
//            }
//            catch (Exception ex)
//            {
//                //小熊正在给公众号升级，晚些再来吧，么么哒~
//                content = string.Format(@"<xml>
//                                                    <ToUserName><![CDATA[{0}]]></ToUserName>
//                                                    <FromUserName><![CDATA[{1}]]></FromUserName>
//                                                    <CreateTime>{2}</CreateTime>
//                                                    <MsgType><![CDATA[text]]></MsgType>
//                                                    <Content><![CDATA[{3}]]></Content>
//                                                  </xml>", Message.FromUserName,
//                    Message.ToUserName, Message.CreateTime,
//                    "小熊正在给公众号升级，晚些再来吧，么么哒~");

//                WriteFile(string.Format("UserFiles\\Test\\Error-{0}.txt", DateTime.Now.ToString("yyyy.MM.dd.dd.hh")),
//                    ParseException(ex), false);
//            }
//            #endregion

//            WriteFile(string.Format("UserFiles\\Test\\log-{0}.txt", DateTime.Now.ToString("yyyy.MM.dd.dd.hh")),
//                RequstLog, false);

//            return Content(content.HasValue() ? content : "success");
//        }


        // GET: /WeChat/Home/Token
        //url         https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=APPID&secret=APPSECRET
        public ActionResult Token()
        {
            var action = "Token";

            Param.Add("grant_type", "client_credential");
            Param.Add("appid", APP_ID);
            Param.Add("secret", APP_SECRET);
            var content = _wechatServices.ApiHttpGet(URL_WECHAT_HOST,action, Param, action);
            WriteFile(
                string.Format("UserFiles\\Test\\log-GetCallBackIp-{0}.txt", DateTime.Now.ToString("yyyy.MM.dd.dd.hh")),
                content, false);

            return Content(content);
        }

        // GET: /WeChat/Home/GetCallBackIp
        //url   https://api.weixin.qq.com/cgi-bin/getcallbackip?access_token=ACCESS_TOKEN
        public ActionResult GetCallBackIp()
        {
            var action = "GetCallBackIp";

            Param.Add("access_token", _Token);
            var content = _wechatServices.ApiHttpGet(URL_WECHAT_HOST, action, Param, action);
            WriteFile(
                string.Format("UserFiles\\Test\\log-GetCallBackIp-{0}.txt", DateTime.Now.ToString("yyyy.MM.dd.dd.hh")),
                content, false);
            return Content(content);
        }


        // GET: /WeChat/Home/ShortUrl
        //url   https://api.weixin.qq.com/cgi-bin/shorturl?access_token=ACCESS_TOKEN
        public ActionResult ShortUrl()
        {
            var action = "shorturl";

            var obj = new
            {
                access_token = _Token,
                action = "long2short",
                long_url = "http://www.jikexueyuan.com/course/1946_2.html?ss=2"
            };
            var content = _wechatServices.ApiJsonHttpPost(URL_WECHAT_HOST, action, obj, "ShortUrl", "access_token=" + _Token);
            WriteFile(
                string.Format("UserFiles\\Test\\log-ShortUrl-{0}.txt", DateTime.Now.ToString("yyyy.MM.dd.dd.hh")),
                content, false);
            return Content(content);
        }

        // GET: /WeChat/Home/CreateMenu
        // https://api.weixin.qq.com/cgi-bin/menu/create?access_token=ACCESS_TOKEN
        public ActionResult CreateMenu()
        {
            var action = "menu/create";

            var obj = new
            {
                button = new List<object>
                {
                    new
                    {
                        name = "功能测试1",
                        key = "TEST_BUTTON1",
                        sub_button = new List<object>
                        {
                            new {type = "view", name = "打开网页", url = "http://v.soso.com/"},
                            new {type = "click", name = "发送key", key = "V1001_GOOD"},
                            new {type = "scancode_waitmsg", name = "扫码带提示", key = "rselfmenu_0_0"},
                            new {type = "scancode_push", name = "扫码推事件", key = "rselfmenu_0_1"},
                            new {type = "pic_sysphoto", name = "系统拍照发图", key = "rselfmenu_1_0"}
                        }
                    },
                    new
                    {
                        name = "功能测试2",
                        key = "TEST_BUTTON2",
                        sub_button = new List<object>
                        {
                            new {type = "pic_photo_or_album", name = "拍照或者相册发图", key = "rselfmenu_1_1"},
                            new {type = "pic_weixin", name = "微信相册发图", key = "rselfmenu_1_2"},
                            new {type = "location_select", name = "发送位置", key = "rselfmenu_2_0"}
                        }
                    },
                    new
                    {
                        name = "关于",
                        key = "http://v.qq.com/",
                        sub_button = new List<object>
                        {
                            new {type = "view", name = "关于我", url = "http://52xyj.cn/me"},
                            new {type = "view", name = "作者主页", url = "http://52xyj.cn/"}
                        }
                    }
                }
            };
            var content = _wechatServices.ApiJsonHttpPost(URL_WECHAT_HOST, action, obj, "ShortUrl", "access_token=" + _Token);
            WriteFile(
                string.Format("UserFiles\\Test\\log-CreateMenu-{0}.txt", DateTime.Now.ToString("yyyy.MM.dd.dd.hh")),
                content, false);
            return Content(content);
        }


        // GET: /WeChat/Home/template_send
        //url   https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=ACCESS_TOKEN
        public ActionResult template_send()
        {
            var action = "message/template/send";

            var obj = new
            {
                access_token = _Token,
                touser = "oksMlwPF5Y1KQvoi8AklF-lUwnYQ",
                template_id = "aP5WSx_hkcCEbDJSu1Takrch4tTB1-3YkpRI6ESjeeE",
                url = "http://wx.52xyj.cn/WeChat/BookTiketWeb/MyWallet",
                data = new
                {
                    first = new
                    {
                        value= "尊敬的用户，您已成功充值！",
                        color= "#173177",
                    },
                    keyword1 = new
                    {
                        value = "巧克力",
                        color = "#173177",
                    },
                    keyword2 = new
                    {
                        value = "39.8元",
                        color = "#173177",
                    },
                    keyword3 = new
                    {
                        value = "2017年1月26日",
                        color = "#173177",
                    },
                    remark = new
                    {
                        value = "欢迎再次充值！",
                        color = "#173177",
                    },
                }
            };
            var content =_wechatServices.ApiJsonHttpPost(URL_WECHAT_HOST, action, obj, "template_send", "access_token=" + _Token);
            WriteFile(
                string.Format("UserFiles\\Test\\log-template_send-{0}.txt", DateTime.Now.ToString("yyyy.MM.dd.dd.hh")),
                content, false);
            return Content(content);
        }
        public ActionResult NewToken()
        {
           
            return Content(_wechatServices.GetToken());
        }
        public ActionResult Send_Charge_Ok_Msg()
        {
            var touser = "oksMlwPF5Y1KQvoi8AklF-lUwnYQ";
            var url = "http://wx.52xyj.cn/WeChat/BookTiketWeb/MyWallet";
            return Content(_wechatServices.Send_Charge_Ok_Msg(touser, url,DateTime.Now.ToStr(),"100","50").ToString());
        }
    }
}
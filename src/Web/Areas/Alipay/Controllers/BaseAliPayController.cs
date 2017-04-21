using Web.Controllers.Base;

namespace Web.Areas.Alipay.Controllers
{
    public class BaseAliPayController : BaseController
    {
        protected const string PLATE_ALIPAY_ACCOUNT = "plate-alipay";
        protected const string DEMO_CHARGE_ACCOUNT = "test-panda";
        //private IAopClient _aopClient;
        //private  const  string SEVER_URL = "https://openapi.alipaydev.com/gateway.do";
        //private const string APP_ID = "2016092800613633";// "2016092800613633";
        //private const string APP_PRIVATE_KEY = "MIICXwIBAAKBgQDJPonqnYdPcf0n9pyGgNe5ZcLBBM0eFs51muu68NPryfVgo79zlMFsA2kI8jXhYLa6rwXK5vXCThaoklsXF+pHrrD+usyOtdWa+KNxfAHm1nv7I5TXFjJv0ovBrRpAr4JSLFdG2Sw1rhAtmnD8DUosKHvkW1KXoOEOPfKoEswAwwIDAQABAoGBAIursPK5hEjaNzZ+TWJ4l8Bf5QwrteS1NXOgIw1qydpzH6+D1oN0cc3yi/qeiFC02/2zLZUGOPkzUzyJ31imy3zbLX/+GpOl4ixvITVdLxRPcIUknc/ZDO6mLvGZtQ/ejzAOmOvk2vjy8mkwBG9ewIHAXmJ2B5byCabjeuam1Q7ZAkEA8Aw/ujkw203DNYO354DSQp19FKP0ICEW8V6wqXYlZrG0s/jN1YHWwf+XdkyzZ8QVo7iigAcmhDHIKk01OCmTdwJBANaeJ4yAYNy1syj9wuu2DO0JwNp5kMRvA4yi/vdprTtvsBtBd7oJq0fgReQ36yHram+q18vCr/ErYdnvg/FeWBUCQQCF4N799n2YIgOYahD8TW1296zWASbbcHkCPyRaLulnH/8/TKlHxbVH10vbD6YTXloPSJ9gthw2KCmR5iOjYhS7AkEAhN+P/sXwslTwYj2R85tXr13tf5XqEiPlH6o+jvFnZjgE4SsMNCsOV0a8HsqcEfkNgatVRXr4sSi5wVMv7j0J7QJBALg2lZ32BhO5izFDsqZaqgtytQmkL5Jdh8zIeS7HXAu78O5SJEt1uHixen4IS3Je/CZVOhhxMahl73MBPcYXkQU=";
        //private const string ALIPAY_PUBLIC_KEY = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDJPonqnYdPcf0n9pyGgNe5ZcLBBM0eFs51muu68NPryfVgo79zlMFsA2kI8jXhYLa6rwXK5vXCThaoklsXF+pHrrD+usyOtdWa+KNxfAHm1nv7I5TXFjJv0ovBrRpAr4JSLFdG2Sw1rhAtmnD8DUosKHvkW1KXoOEOPfKoEswAwwIDAQAB";
        //private const string VERSION = "1.0";
        //private const string SIGN_TYPE = "RSA";
        //private const string FORMATE = "json";//json
        //private const string CHARSET = "GBK";//GBK和UTF-8

        //protected const string SELLER_ID = "2088102177608952";
        //protected const string BUYER_ID = "kfmuwa5900@sandbox.com";
        //// private const string SEVER_URL = "https://openapi.alipay.com/gateway.do";
        //// private const string APP_ID = "";// "2016092800613633";
        ////private const string APP_PRIVATE_KEY = "";
        ////private const string ALIPAY_PUBLIC_KEY = "";                                                                                                                                                                                                                                                       // private const string ALIPAY_PUBLIC_KEY = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQC9nMisLvho1gbp2Y4fA/6rmdaZdsZBd1Md0KfYrtcNpPH9OZeEwhjUlnYqnGSA6Qws6jycN8NJn8QJOaH1qXhZLsl8wSKr2ruz2B0IBi9bwvlRv6QH3mnCOmRtjTv/JNcztTHHsHaT3FXyaINRzOpGdiBkMpqR9kqc++ja6McMKwIDAQAB";
        ////private const string CHARSET = "UTF-8";//GBK和UTF-8
        //// private const string FORMATE = "json";//json

        //protected AlipayOpenPublicTemplateMessageIndustryModifyRequest AlipayRequst
        //{
        //    //SDK已经封装掉了公共参数，这里只需要传入业务参数
        //    //此次只是参数展示，未进行字符串转义，实际情况下请转义
        //    //  request.BizContent = "";


        //    //实例化具体API对应的request类,类名称和接口名称对应,当前调用接口名称如：alipay.open.public.template.message.industry.modify 

        //    get { return new AlipayOpenPublicTemplateMessageIndustryModifyRequest(); }
        //}
        //protected IAopClient AlipayClient
        //{
        //    get
        //    {
        //        if (_aopClient == null)
        //        {
        //            _aopClient = new DefaultAopClient(SEVER_URL,
        //        APP_ID,
        //        APP_PRIVATE_KEY,
        //        FORMATE,
        //        VERSION,
        //        SIGN_TYPE,
        //        ALIPAY_PUBLIC_KEY,
        //        CHARSET);

        //        //    new DefaultAopClient(SEVER_URL,
        //        //APP_ID,
        //        //APP_PRIVATE_KEY,
        //        //FORMATE,
        //        //CHARSET,
        //        //ALIPAY_PUBLIC_KEY);
        //        }
        //        return _aopClient;
        //    }

        //}
    }
    
}
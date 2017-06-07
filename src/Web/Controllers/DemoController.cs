using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Qx.Account.Interfaces;
using Qx.Account.Models;
using Qx.Contents.Interfaces;
using Qx.Contents.Services;
using Qx.Msg.Interfaces;
using Qx.Order.Interfaces;
using Qx.Order.Models;
using qx.permmision.v2.Interfaces;
using Qx.Tools.CommonExtendMethods;
using Web.Controllers.Base;
using Web.ViewModels.Demo;
using Qx.Tools.Models.Report;
using Qx.WorkFlow.Interfaces;
using Qx.Tools;
using Qx.Tools.Interfaces;

namespace Web.Controllers
{
    public class DemoController : BaseController
    {
        //
        // GET: /Demo/
        private IAccountPayService _accountPayService;
        private IContents _contents;
        private IOrderService _orderService;
        private IWorkFlowService _workFlowService;
        private IMsgProvider _msgProvider;
        private IPermissionProvider _permissionProvider;

        public DemoController(IContents contents,  IOrderService orderService, IAccountPayService accountPayService, IWorkFlowService workFlowService, IMsgProvider msgProvider, IPermissionProvider permissionProvider)
        {
            _contents = contents;
            _orderService = orderService;
            _accountPayService = accountPayService;
            _workFlowService = workFlowService;
            _msgProvider = msgProvider;
            _permissionProvider = permissionProvider;
        }

        // /Demo/TestRegist
        public ActionResult TestRegist()
        {
           return Content( _permissionProvider.Regist("123+UID", "123+PSW", "12+nickname").ToString());
        }
        
        // /Demo/TestSendSms?mobile=手机号码
       
        public ActionResult TestSendSms(string mobile)
        {
            const string DEMO_Mobile = "15505927595";
            const string DEMO_Receiver = "大健康用户:Test";
            if (!mobile.HasValue())
            {
                mobile = DEMO_Mobile;
            }
            var result = _msgProvider.SendSms(mobile, DEMO_Receiver);
            //注意:请勿随意发送，本接口每调用一次会被收费!
            return Json(result);
        }
        // /Demo/TestCheckSms?requestId=F0A78E1C-4BED-452D-9032-385398E9BBE5&code=157839
        public ActionResult TestCheckSms(string requestId,string code)
        {
            var codeIsTrue = _msgProvider.CheckSms(requestId, code);
            return Content(codeIsTrue.ToString());
            
        }
        // /Demo/TestWorkFlow
        public ActionResult TestWorkFlow()
        {
            const string DEMO_WORKFLOWID = "test-dayoff";
            const string DEMO_OPERATOR = "panda";
            //----------创建实例
            var instance=  _workFlowService.CreateInstance(DEMO_WORKFLOWID); var instanceId = instance.Instance.WorkFlowInstanceID;
            //检测完成状态
            var isFinished=  _workFlowService.IsFinished(instance);
            //查看下一步的任务
            var nextStepInfo = instance.NextStepInfo();
            //移动到下一状态（B）
            var resultB=  _workFlowService.MoveNext(instance, new {WriteFormOK = 1}, DEMO_OPERATOR);
            //---------查找实例
            instance = _workFlowService.FindInstance(instanceId);
            isFinished = _workFlowService.IsFinished(instance);
            var nextStepInfoB = instance.NextStepInfo();
            //移动到下一状态（C）
            var resultC = _workFlowService.MoveNext(instance, new { Day = 4, TeacherChecked=1 }, DEMO_OPERATOR);
            //---------查找实例
            instance = _workFlowService.FindInstance(instanceId);
            isFinished = _workFlowService.IsFinished(instance);
            var nextStepInfoC = instance.NextStepInfo();
            //--强制移动，忽略条件
            var forceNodeId = nextStepInfoC.FirstOrDefault().ToNodeId;
            //移动到下一状态（D）    
            var resultD = _workFlowService.MoveNext(instance, forceNodeId, DEMO_OPERATOR);
            //var resultD = _workFlowService.MoveNext(instance, new { DepartmentChecked = 1 }, DEMO_OPERATOR);
            //---------查找实例
            instance = _workFlowService.FindInstance(instanceId);
            isFinished = _workFlowService.IsFinished(instance);
            var nextStepInfoD = instance.NextStepInfo();
            return Alert("测试成功！");
        }
        // /Demo/TestOrder
        public ActionResult TestOrder()
        {
            IProductProvider provider = null;

            const string DEMO_SELLER = "panda";
            const string DEMO_PRODUCT_ONE = "test-p1";
            const string DEMO_PRODUCT_TWO = "test-p2";
            const string DEMO_ORDERID = "panda-10385-14093-2016.10.04.17.03.18.下午.+08";

            //1.创建购物车
            var myCart = _orderService.CreateCart(DataContext);
            //2.为购物车添加商品
            myCart.AddItem(DEMO_SELLER, DEMO_PRODUCT_ONE, provider);
            //3.再次为购物车添加商品
            myCart.AddItem(DEMO_SELLER, DEMO_PRODUCT_TWO, provider);
            //4.从购物车删除商品
            myCart.RemoveItem(DEMO_SELLER, DEMO_PRODUCT_TWO);
            //5.同步购物车
            _orderService.SyncCart(myCart);

            //1.创建订单
            var myOrder = _orderService.CreateOrder(DataContext, DEMO_SELLER,"", OrderTypeEnum.Normal);
            //2.购买购物车中的物品
            myOrder.BuyCart(myCart, provider);
            //3.同步订单
            _orderService.SyncOrder(myOrder);

            //1.查找购物车
            var findCart = _orderService.FindCart(DataContext, provider);
            //1.查找所有订单
            var findOrders = _orderService.FindOrders(DataContext);

            //1.查找订单
            var findOrder = _orderService.FindOrder(DataContext, DEMO_ORDERID);
            //2.操作订单状态
            findOrder.Check();
            findOrder.Pay();
            findOrder.Deliver();
            findOrder.Done();
            findOrder.Evaluat(); 
            //3.更改订单类型
            findOrder.ChageType(OrderTypeEnum.Normal);
            //4.删除订单
            var deleteOrder = _orderService.DeleteOrder(DataContext, DEMO_ORDERID);
            //5.(不要忘记调用SyncOrder()同步更改！)
            return Alert("测试成功！");
        }

        // /Demo/TestWx
        public ActionResult TestWx()
        {
            InitWxLayout("测试微信布局");
           
            return View();

        }


        // /Demo/TestQR?content=baidu.com
        public ActionResult TestQR(string content )
        {
            if (!content.HasValue())
            {
                content = "baidu.com";
            }
           
            var path = "/UserFiles/QrCode.jpg";
            QRCoderUtility.CreateQrCode(content,PathUtility.ToPhysicalPath(path));
            return File(path, "image/jpeg");
        }
        // /Demo/TestPay
        public ActionResult TestPay()
        {   
            const string DEMO_ACCOUNT_ONE = "plate-alipay";
            const string DEMO_ACCOUNT_TWO = "test-panda";
            const string DEMO_ORDER = "10385-14093-8587258378306281019-10385-14093-8587258377194947454-8587258371564275398";
            const string DEMO_ALIPAY_ID = "123456415645121346313548454";

            ////1.创建账户
            //var account = _accountPayService.CreateAccount(DataContext, AccountTypeEnum.Personal);
            ////2.改变账户类型
            //account.ChangeType(AccountTypeEnum.Orgnization);
            ////3.为账户充值
            //account.Charge(1000);
            ////4.账户消费
            //account.Expense(200);
            ////5.同步账户
            //_accountPayService.SyncAccount(account);
            //6.查找账户
            var payer = _accountPayService.FindAccount(DEMO_ACCOUNT_ONE);
            var recever = _accountPayService.FindAccount(DEMO_ACCOUNT_TWO);
            ////7.删除账户
            //_accountPayService.DeleteAccount(DEMO_ACCOUNT_TWO);
            //8.账户支付记录
            var payerRecords = payer.Account.account_record;
            //1.创建支付订单
            var payOrder = _accountPayService.CreatePayOrder(payer, recever, 100, PayOrderTypeEnum.Nomal, PaymentTypeEnum.Jkb);
            //2.订单支付
            payOrder.Successful();
            //3.同步支付订单
            _accountPayService.SyncPayOrder(payOrder);
            //4.查找支付订单
            var findPayOrder = _accountPayService.FindPayOrder(DEMO_ORDER);
            
            ////5.删除支付订单
            //_accountPayService.DeletePayOrder(DEMO_ORDER);


            const string DEMO_CHARGE_ACCOUNT = "test-panda";
            const string PLATE_ALIPAY_ACCOUNT = "plate-alipay";
             //1.创建支付订单
             var chargePayOrder = _accountPayService.CreatePayOrder(PLATE_ALIPAY_ACCOUNT, DEMO_CHARGE_ACCOUNT, 1000, PayOrderTypeEnum.AliPay, PaymentTypeEnum.Rmb);
            _accountPayService.SyncPayOrder(chargePayOrder);
            //2.订单支付激活
            chargePayOrder.Pending(DEMO_ALIPAY_ID);
            _accountPayService.SyncPayOrder(chargePayOrder);
            //3.订单验证并付款
            if (chargePayOrder.IsValid(DEMO_ALIPAY_ID))
            {
                chargePayOrder.Successful();
            }
            else
            {
                //忽略
            }
            _accountPayService.SyncPayOrder(chargePayOrder);
            //4.订单验证并结束
            if (chargePayOrder.IsValid(DEMO_ALIPAY_ID))
            {
                chargePayOrder.Finished();
            }
            else
            {
                //忽略
            }
            _accountPayService.SyncPayOrder(chargePayOrder);
            //5.同步支付订单
           // _accountPayService.SyncPayOrder(chargePayOrder);
          
            return Alert("测试成功！");
        }
        public ActionResult Index()
        {
            InitForm("表单控件模版");
            return View();
        }
        // /Demo/TestMap?keyword=福建省厦门市集美区华侨大学
        public ActionResult TestMap(string keyword)
        {
            InitLayout("测试地图");
            return View();
        }
        public ActionResult TestMap2(string Longitude,string Latitude)
        {
            InitLayout("测试地图");
            return View();
        }
        // /Demo/Form

        //-----表单验证配置参考手册
        //必填字段                               [Required]
        //必填字段带错误消息                     [Required(ErrorMessage ="**是必填字段")]
        //必填字段带占位符错误消息               [Required(ErrorMessage ="Your {0} is required.")]
        //字符串至多n位：                        [StringLength(160)]
        //字符串至少n位：                        [StringLength(160, MinimumLength = 3)]
        //数值范围                               [Range(35, 44)][Range(typeof(decimal), "0.00", "49.99")]
        //正则验证                               [RegularExpression(@"正则表达式")]
        //正则验证带错误消息                     [RegularExpression(@"[A - Za - z0 - 9._ % +-] +@[A - Za - z0 - 9.-]+\.[A-Za-z]{2,4}", ErrorMessage="邮件地址不规范")]


        //-----常用正则表达式
        //数字：                                          "^[0-9]*$"。
        //n位的数字：                                     "^\d{n}$"。
        //至少n位的数字：                                 "^\d{n,}$"。
        //m ~n位的数字：                                  "^\d{m,n}$"
        //零和非零开头的数字：                            "^(0|[1-9][0-9]*)$"。
        //有两位小数的正实数：                            "^[0-9]+(.[0-9]{2})?$"。
        //有1 ~3位小数的正实数：                          "^[0-9]+(.[0-9]{1,3})?$"。
        //非零的正整数：                                  "^\+?[1-9][0-9]*$"。
        //非零的负整数：                                  "^\-[1-9][]0-9"*$。
        //长度为3的字符：                                 "^.{3}$"。
        //由26个英文字母组成的字符串：                    "^[A-Za-z]+$"。
        //由26个大写英文字母组成的字符串：                "^[A-Z]+$"。
        //由26个小写英文字母组成的字符串：                "^[a-z]+$"。
        //由数字和26个英文字母组成的字符串：              "^[A-Za-z0-9]+$"。
        //由数字、26个英文字母或者下划线组成的字符串：    "^\w+$"。
        //验证用户密码：                                  "^[a-zA-Z]\w{5,17}$"正确格式为：以字母开头，长度在6 ~18之间，只能包含字符、数字和下划线。
        //验证是否含有^%&’,;=?$\"等字符：                "[^%&’,;=?$\x22]+"。
        //只能输入汉字：                                  "^[\u4e00-\u9fa5]{0,}$"
        //验证Email地址：                                 "^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"。
        //验证InternetURL：                               "^http://([\w-]+\.)+[\w-]+(/[\w-./?%&=]*)?$"。
        //验证电话号码：                                  "^(\(\d{3,4}-)|\d{3.4}-)?\d{7,8}$"       正确格式为："XXX-XXXXXXX"、"XXXX- XXXXXXXX"、"XXX-XXXXXXX"、"XXX-XXXXXXXX"、"XXXXXXX"和"XXXXXXXX"。
        //验证身份证号(15位或18位数字)：                  "^\d{15}|\d{18}$"。
        //验证一年的12个月：                              "^(0?[1-9]|1[0-2])$"正确格式为："01"～"09"和"1"～"12"。
        //验证一个月的31天：                              "^((0?[1-9])|((1|2)[0-9])|30|31)$"正确格式为;"01"～"09"和"1"～"31"。



        public ActionResult Form()
        {
            var temp = _contents.GetTableValue("10001", "123");
            InitForm("FormDemo");
            return View(Form_M.ToViewModel(1, "我是string", DateTime.Now, 1.23f, 2.42343243432434d, 'a'));
        }
        [HttpPost]
        [ValidateInput(true)]//当表单中存在富文本输入的时候需要加上这句
        public ActionResult Form(Form_M model)
        {
            if (ModelState.IsValid)
            {
                Request.UpdateTable("10001", "123");
                return Alert("提交成功");
            }
            else
            {
                InitForm("FormDemo");
                return View(model);
            }

        }
        // /Demo/Table
        public ActionResult Table(string ReportID, string Params)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("Table", new { ReportID = "Demo.Service", Params = ";" });
            }
            //获取用户参数
            var param=Params.UnPackString(';');
            #region 从不同库获取数据
            var  datas = new List<List<string>>()
            {
                new List<string>() {"姓名1", "性别", "年龄"},
                new List<string>() {"姓名2", "性别", "年龄"},
                new List<string>() {"姓名3", "性别", "年龄"}
            };
            #endregion
            //根据用户参数过滤数据
            datas= datas.Where(a => a[0].Contains(param[0])).ToList();
            //初始化报表
            InitReport(datas, "ReportDemo(不同数据库)", "#");
            return View();
        }

        public ActionResult CrossDbReport()
        {

            InitForm("表单控件模版");
            return View();
        }
      

        // /Demo/Report?ReportID=Demo&Params=;
        public ActionResult Report(string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("Report", new { ReportID = "Demo", Params = ";", pageIndex = 1, perCount = 10 });
            }
            InitReport("ReportDemo(后端分页)", "#", "", true, "Qx.System");
            return View();
        }
        // /Demo/CrossServiceReport
        public ActionResult CrossServiceReport(string ReportID, string Paramsint, int pageIndex = 1, int perCount = 10)
        {

            if (!ReportID.HasValue())
            {
                return RedirectToAction("CrossServiceReport", new { ReportID = "Demo", Params = ";", pageIndex = 1, perCount = 10 });
            }

            var paramList = new List<CrossDbParam>();
            paramList.Add(new CrossDbParam()
            {
                ParamIndex = 5,
                OutIndex = 6,//应当与多配置的标题所在列索引相同
                Func = (a) =>
                {
                    return a == "10" ? "每页10条" : "每页不是10条";
                }
            });
            InitReport(paramList, "CrossServiceReport", "#", "", true, "Qx.System");
            return View("Report");
        }
        // /Demo/Report2?ReportID=System&Params=;
        public ActionResult Report2(string ReportID, string Params)
        {
            //InitReport("ReportDemo(前端分页)", "#", "", true, "Qx.System");
            return View();
        }

      
    }
}

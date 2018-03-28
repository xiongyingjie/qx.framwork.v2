using System;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using Qiniu.Storage;
//using Qiniu.Util;
using Web.Controllers.Base;
using xyj.acs.Interfaces;
using xyj.acs.Models;
using xyj.core;
using xyj.core.Exceptions.Upgrate;
using xyj.core.Extensions;
using xyj.core.Models.Http;
using xyj.core.Utility;


namespace Web.Controllers
{
    public partial class OpenController : BaseController
    {
     
        private readonly IAcsService _acsService;

        public OpenController(IAcsService acsService)
        {
            _acsService = acsService;
        }


        // GET: Open
        public IActionResult Index()
        {
            return View();
        }
        // GET: /Open/Grap
        public IActionResult Grap(string url= "http://w7.52xyj.cn")
        {
            var client = new HttpHelper();
            var res = client.GetHtml(new HttpItem()
            { URL = url, //Method = "post",// 默认为Get
            });
            while (res.RedirectUrl.HasValue())
            {
                res = client.GetHtml(new HttpItem()
                {
                    URL = res.RedirectUrl, //Method = "post",// 默认为Get
                });
            }
         
            return Content(res.Html);
        }
        // GET: Open/balance
        //public IActionResult Balance()
        //{
        //    return Json(State.Success,_accountPayService.FindAccount(DataContext.UserId).Account);
        //}
        // GET: Open/Regist?userId=panda&userPwd=123&nickName=panda
        public IActionResult Regist(string userId, string userPwd, string nickName, string email = "", string phone = "", string userTypeId = "0")
        {
            userId = userId.ToLower().Replace("http://", "").Replace("https://", "").Replace("/", "");
            return Json(State.Success,"用户" + userId+"注册结果:" +_acsService.Regist(userId, userPwd, nickName, email, phone, userTypeId));
        }

        // GET: Open/Login
        public IActionResult Login(string userId, string psw)
        {
            userId = userId.ToLower().Replace("http://", "").Replace("https://", "").Replace("/", "");
            var u =new User();
            try
            {
                var user = _acsService.Login(userId, psw);
                u.user_id = userId;
            }
            catch (Exception)
            {
                return Json(State.Fail, u, false);
            }
            return Json(State.Success, u,true);
        }

        public IActionResult SetSubSystemData(string sid, string key, string value)
        {
            return Json(_acsService.SetSubSystemData(sid, key, value)
                ?State.Success
                :State.Fail, "");
            
        }
        public IActionResult GetSubSystemData(string id)
        {
            return Json(State.Success, _acsService.GetSubSystemData(id));
        }
        //public IActionResult GetQiNiuUpToken(string id)
        //{
        //    var data = _acsService.GetSubSystemData(id).data_value.Deserialize<dynamic>();
        //    var mac = new Mac(data.ak, data.sk);
        //    var putPolicy = new PutPolicy();
        //    putPolicy.Scope = "test";
        //    var token = Auth.CreateUploadToken(mac, putPolicy.ToJsonString());
        //    return Json(State.Success,new{ data.ak, data.sk });
        //}
        public IActionResult AutoLogin(string userId, string userName, string roleString,string subSys,string site)
        {
            var site2 = site.ToLower().Replace("http://", "").Replace("https://", "").Replace("/", "");

            //兼容订阅号
            userId = (""+userId).CheckValue(subSys + "-visitor").ToLower();
            userId = subSys + "-"+site2 + "-" + userId;//同个用户打开不同站点处理为不同用户
            var u = new User();
            try
            {
                var user = _acsService.UserInfo(userId);
                u.user_id = userId;
                u.sub_system_reg_id = user.sub_system_reg_id;
            }
            catch (Exception)
            {
                //执行注册
                try
                {
                    _acsService.Regist(userId, userId, userName, "", "", "", site, roleString.UnPackString(';'), subSys);
                    var user = _acsService.UserInfo(userId);
                    u.user_id = userId;
                    u.sub_system_reg_id = user.sub_system_reg_id;
                }
                catch (Exception ex) {
                    //盗版检测
                    if(ex is DbUpdateException && ex.InnerException.Message.Contains("sub_system_id"))
                    {
                        var msg = "请勿使用盗版程序，正版程序请到官网购买。客服QQ:603748637";
                        return Json(State.Fail, msg);
                    }
                    else
                    {
                        var msg = "页面初始化失败,请关闭后重新打开";
                        return Json(State.Fail, msg);
                    }
             
                }
            }
            return Json(State.Success, u, true);
        }
        // GET: Open/UserInfo
        public IActionResult UserInfo()
        {
            var userid = DataContext.UserId;
            var u = new User();
            var user = _acsService.UserInfo(userid);
            u.nick_name = user.nick_name;
            u.user_id = user.user_id;
            u.sub_system_reg_id = user.sub_system_reg_id;
            var units = _acsService.GetOrgIdByUserId(userid, false).ToList();
            u.units = new
            {
                id = units.Select(a => a.orgnization_id.Encrypt()),
                name = units.Select(a => a.name)
            }.Serialize();
            var ok =u.user_id.HasValue() && u.units.Any();
            return Json(ok ? State.Success : State.Fail, u, false);

        }
        // GET: Open/GetMenu
        public IActionResult GetMenu(bool isWin10=true)
        {
            return Json(isWin10? 
                NavbarIndex.Init( _acsService.GetMenuByUserId(DataContext.UserId), _acsService.GetForbidenButtonByUserId(DataContext.UserId))
                :NavbarIndex.Init( _acsService.GetNavbarByUserId(DataContext.UserId), _acsService.GetMenuByUserId(DataContext.UserId),_acsService.GetForbidenButtonByUserId(DataContext.UserId)));
        }
        // GET: Open/GetTable
        public IActionResult GetTable(string id="demo")
        {
            throw new NotSupportedExceptionInCoreException();
          //  return Json(_contentService.GetTableDesign(id), JsonRequestBehavior.AllowGet);
        }
        // GET: Open/UpdateTable
        public IActionResult UpdateTable(string json)
        {
            throw new NotSupportedExceptionInCoreException();
            ///  return Json(_contentService.UpdateTable(json.Deserialize<ContentBag>()), JsonRequestBehavior.AllowGet);
        }
         // GET: Open/Upload

        public IActionResult Upload([FromServices]IHostingEnvironment env, string controlName, string folder)
        {
            folder= folder.Replace("/", "\\");
            var  saveDir = folder.HasValue() ? folder:"userfiles\\uploads\\files\\";
            //每个用户单独存储
            saveDir += "\\"+ DataContext.UserId+"\\";
            var physicSaveDir = GetProjectDir(env,saveDir);
            if (!Directory.Exists(physicSaveDir))//创建目录
            { Directory.CreateDirectory(physicSaveDir); }

            var reslut = new UploadResult();
            if (Request.Method.ToLower() == "post")
            {
                foreach (var upload in Request.Form.Files)
                {

                    if (!upload.HasFile()) continue;

                    var filename = upload.FileName.Replace(";", "_").TrimString();//替换特殊字符
                    var savedFileName = DateTime.Now.Random().Substring(0, 5) + "-split-" + filename;//实际存储文件名
                    var relativeSavedPath = (saveDir + savedFileName);//实际存储的相对路径
                    var showSavedPath = GetHost(true) + relativeSavedPath;//实际存储的相对路径
                  
                    using (var stream = new FileStream(physicSaveDir+savedFileName, FileMode.CreateNew))
                    {  //写入
                        upload.CopyTo(stream);  
                    }
                    reslut.Add(new FileItem()
                    {
                        id = DateTime.Now.Random(),
                        name = filename,
                        size = (int)upload.Length,
                        url = showSavedPath.Replace("\\", "/"),
                        thumbnailUrl = (filename.Contains(".jpg") || filename.Contains(".png") || filename.Contains(".gif")) ? showSavedPath.Replace("\\", "/") : "",
                        deleteUrl = "/open/Delete?savedPath=" + relativeSavedPath.Replace("\\", "/"),
                        deleteType = "Post",
                        controlName = controlName,
                        savedPath = relativeSavedPath.Replace("\\", "/"),
                    });
                }
            }
         

            return Json(reslut);
        }



        public IActionResult Delete([FromServices]IHostingEnvironment env, string controlName, string savedPath)
        {
  
            try
            {
                System.IO.File.Delete(GetProjectDir(env,savedPath.Replace("/", "\\")));
                return Json(State.Success, new { controlName = controlName, savedPath = savedPath });
            }
            catch (Exception ex)
            {
                return Json(State.Fail, "删除失败："+ex.Message);
            }
        }


        // /open/IpInfo?ip=192.168.31.2
        public IActionResult IpInfo([FromServices]IHostingEnvironment env, string ip="")
        {      
            if (!ip.HasValue())
            {
                return Json(State.Success, env.IpSearch(HttpContext));
            }
            else
            {
                return Json(State.Success, env.IpSearch(ip));
            }
        }



        // /open/Qr?content=baidu.com
        public IActionResult Qr(string content)
        {
            if (!content.HasValue())
            {
                content = "baidu.com";
            }
            return File(QRCoderUtility.CreateQrCode(content).BitmapToBytes(), "image/jpeg");
        }

        // GET: /open/ScanWxQr
        public IActionResult ScanWxQr(string info)
        {
            return View();
        }
        // GET: /open/WxCfg
        //public IActionResult WxCfg(string key,string url)
        //{
        //    return Json( _configHelper.GetCfg(url,key),JsonRequestBehavior.AllowGet);
        //}
    }

    public static class Extensions

{
        public static bool HasFile(this IFormFile file)
        {
            return (file != null && file.Length > 0) ? true : false;
        }
    }

}
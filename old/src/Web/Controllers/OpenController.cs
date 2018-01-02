using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using qx.permmision.v2.Entity;
using qx.permmision.v2.Interfaces;
using qx.permmision.v2.Models;
using Qx.Account.Interfaces;
using Qx.Tools;
using Qx.Tools.CommonExtendMethods;
using Web.Controllers.Base;
using Web.Models;

namespace Web.Controllers
{
    public class OpenController : BaseController
    {
     
        private readonly IPermissionProvider _permissionProvider;
        private readonly IAccountPayService _accountPayService;
        public OpenController(IPermissionProvider permissionProvider, IAccountPayService accountPayService)
        {
            _permissionProvider = permissionProvider;
            _accountPayService = accountPayService;
        }

        // GET: Open
        public ActionResult Index()
        {
            return View();
        }
       
        // GET: Open/balance
        public ActionResult Balance()
        {
            return Json(State.Success,_accountPayService.FindAccount(DataContext.UserId).Account);
        }
        // GET: Open/Login
        public ActionResult Login(string userid, string psw)
        {
            var u =new User();
            try
            {
                var user = _permissionProvider.UserInfo(userid);
                u.user_id = userid;
            }
            catch (Exception)
            {
                return Json(State.Fail, u, false);
            }
            return Json(State.Success, u,false);
        }
        // GET: Open/UserInfo
        public ActionResult UserInfo()
        {
            var userid = DataContext.UserId;
            var u = new User();
            try
            {
                var user = _permissionProvider.UserInfo(userid);
                u.nick_name = user.nick_name;
                u.user_id = user.user_id;
                var units = _permissionProvider.Services().GetOrgIdByUserId(userid, false).ToList();
                u.units = new
                {
                    id = units.Select(a => a.orgnization_id.Encrypt()),
                    name = units.Select(a => a.name)
                }.Serialize();
            }
            catch (Exception){ }
            var ok =u.user_id.HasValue() && u.units.Any();
            return Json(ok ? State.Success : State.Fail, u, false);

        }

        // GET: Open/GetMenu
        public ActionResult GetMenu()
        {
            return Json(NavbarIndex.Init(_permissionProvider.Services().GetNavbarByUserId(DataContext.UserId),
                 _permissionProvider.Services().GetForbidenButtonByUserId(DataContext.UserId)),JsonRequestBehavior.AllowGet);
        }

      
        // GET: Open/Upload
 
        public ActionResult Upload(string controlName, string folder)
        { 
            
            var  saveDir = folder.HasValue() ? folder:"userfiles\\uploads\\files\\";
            var physicSaveDir = GetProjectDir(saveDir);
            if (!Directory.Exists(physicSaveDir))//创建目录
            { Directory.CreateDirectory(physicSaveDir); }

            var reslut = new UploadResult();
            foreach (string upload in Request.Files)
            {
                if (!Request.Files[upload].HasFile()) continue;

                var filename = Path.GetFileName(Request.Files[upload].FileName).Replace(";", "_").TrimString();//替换特殊字符
                var savedFileName =DataContext.UserId+ DateTime.Now.Random().Substring(0,2) + "-split-" + filename;//实际存储文件名
                var relativeSavedPath = (saveDir + savedFileName);//实际存储的相对路径
                var showSavedPath = GetHost(true) + relativeSavedPath;//实际存储的相对路径
                //写入
                Request.Files[upload].SaveAs(Path.Combine(physicSaveDir, savedFileName));
                reslut.Add(new FileItem()
                {
                    id=DateTime.Now.Random(),
                    name = filename,
                    size = Request.Files[upload].ContentLength,
                    url = showSavedPath,
                    thumbnailUrl = (filename.Contains(".jpg")|| filename.Contains(".png")|| filename.Contains(".gif"))? showSavedPath : "",
                    deleteUrl = "/open/Delete?savedPath=" + relativeSavedPath,
                    deleteType = "Post",
                    controlName= controlName,
                    savedPath = relativeSavedPath,
                });
            }

            return Json(reslut, JsonRequestBehavior.AllowGet);
        }



        public ActionResult Delete(string controlName, string savedPath)
        {
            try
            {
                System.IO.File.Delete(GetProjectDir(savedPath));
                return Json(State.Success, new { controlName = controlName, savedPath = savedPath });
            }
            catch (Exception ex)
            {
                return Json(State.Fail, "删除失败："+ex.Message);
            }
        }
    }

  
        public class UploadResult
        {
            public UploadResult()
            {
                this.files = new List<FileItem>();
            }

            public UploadResult Add(FileItem item)
            {
                files.Add(item);
                return this;
            }
            public List<FileItem> files { get; set; }
        }
        public class FileItem
        {
            public string name { get; set; }
            public int size { get; set; }
            public string url { get; set; }
            public string thumbnailUrl { get; set; }
            public string deleteUrl { get; set; }
            public string deleteType { get; set; }
            public string id { get; set; }
    
            public string controlName { get; set; }
            public string savedPath { get; set; }
        }


        public class FilesItemError
        {
            /// <summary>
            /// 
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int size { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string error { get; set; }
        }

    public static class ttt

{
        public static bool HasFile(this HttpPostedFileBase file)
        {
            return (file != null && file.ContentLength > 0) ? true : false;
        }
    }

}
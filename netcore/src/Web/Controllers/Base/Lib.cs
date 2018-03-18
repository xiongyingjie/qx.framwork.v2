using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Mvc;
using xyj.core;
using xyj.core.Exceptions.Upgrate;
using xyj.core.Utility;

namespace Web.Controllers.Base
{
    public class Lib  : BaseController
    {
        protected string ToPhysicPath(string FilePath)
        {
            return new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).FullName + FilePath;//Qx.Tools.Web.HttpContext.Current.Server.MapPath(SavePath) + fileBase.FileName;
        }
        protected string ReadFile(string FilePath)
        {
            var filePath = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).FullName + FilePath;
            var temp = new List<char>();
            if (System.IO.File.Exists(filePath))
            {
                using (var fs = new FileStream(filePath, FileMode.Open))
                {
                    var br = new BinaryReader(fs, Encoding.UTF8);
                    //判断是否已经读到文件末尾
                    while (br.PeekChar() != -1)//使用while(temp=br.ReadString())!=null 会报异常System.IO.EndOfStreamExceptionl 
                    {
                        temp.Add(br.ReadChar());
                    }
                    br.Close();
                    fs.Close();
                }
            }
            return new string(temp.ToArray());
        }


      
      
      
     
       
      

        #region 文件上传 public
        static string TempPath = null;
        [HttpPost]
        public JsonResult UploadHandle(string saveDirectory)
        {
            throw new NotSupportedExceptionInCoreException();
           // var fileBase = Request.Form.Files[0];
           // var SavePath = saveDirectory;// "/UserFiles/Test/";
           // var TargetPath = "";
           ////   Qx.Tools.Web.HttpContext.Current.Server.MapPath(SavePath) + fileBase.FileName;
           // var ContentRange = Request.Headers["Content-Range"];
           // TempPath = TargetPath;
           // FileUploadUtility.UploadBigFile(fileBase, TargetPath, ContentRange);
           // var result = new { name = "提示:上传成功！", filePath = saveDirectory + fileBase.FileName };
           // return Json(result);
        }

        public IActionResult RedoHandle()
        {
            //处理Redo按钮的请求
            int command = Convert.ToInt32(F("DeleteCommand"));
            if (command == 1 && TempPath != null)
            {
                if (System.IO.File.Exists(TempPath))//判断文件是否存在
                {
                    System.IO.File.Delete(TempPath);//执行IO文件删除,需引入命名空间System.IO;    
                } //删除物理文件
                TempPath = null;
                return Content("删除成功!");
            }
            else
            {
                return Content("删除异常!");
            }
        }

        public IActionResult ContinueHandle()
        {
            //用于处理续传功能
            //var FileByte = System.IO.File.ReadAllBytes(TempPath);
            //var resp = new HttpResponseMessage(HttpStatusCode.OK)
            //{
            //    Content = new ByteArrayContent(FileByte)
            //};
            //var fileStream = new FileStream(TempPath, FileMode.Open);
            string CurrentFileName = Request.Query["file"];
            FileInfo info = new FileInfo(TempPath);
            long InfoSize = info.Length;
            var result = new { FileSize = InfoSize };
            return Json(result);
        }

        protected IActionResult FreshHandle()
        {
            TempPath = null;
            return View();
        }
        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

using Qx.Tools.CommonExtendMethods;

namespace Web.Controllers.Base
{
    public static  class FileOperate
    {
        //删除kindeditor富文本中的图片或文件，
        public static void DeleteContentFlie(string Content,string fileurlhead)
        {
            Regex reg = new Regex(fileurlhead);

            string[] match = reg.Split(Content);
            for (int i = 0; i < match.Length; i++)
            {
                string now = match[i];
                if (now.Length<32)
                {
                    continue;
                }
                else
                {
                    fileurlhead = fileurlhead.Replace("@", "");
                    string try1 = fileurlhead + now.Substring(0, 32);//jpg等三字格式
                    string try2 = fileurlhead + now.Substring(0, 33);//jpeg等四字格式
                    try
                    {
                        DeleteFlie(try1);
                        DeleteFlie(try2);
                    }
                    catch { }
                }
            }
        }
        public static bool DeleteFlie(string FilePath)
        {
            string AbsoluteFilePath = System.Web.HttpContext.Current.Server.MapPath(FilePath);//转换物理路径 
            if (System.IO.File.Exists(AbsoluteFilePath))//判断文件是否存在
            {
                System.IO.File.Delete(AbsoluteFilePath);//执行IO文件删除,需引入命名空间System.IO; 
                return true;
            }
            else
            {
                return false ;
            }
           
        }
        public static void DeleteFlie(List<string> FilePaths)
        {
            foreach (var FilePath in FilePaths)
            {
                DeleteFlie(FilePath);
            }

        }

        public static string UploadFile(HttpPostedFileBase file, string SaveDirectory = "/UserFiles/Test/")
        {
            if (file != null)
            {
                //构造文件上传路径(文件名为用户ID)
                string strFileTypeLimit = "image";

                int IsPicType = file.ContentType.IndexOf(strFileTypeLimit);
                //if (Photo.FileName.ToString() != "" && IsPicType != -1 && Photo.ContentLength < 20971520)
                string Ora_FileName = System.IO.Path.GetFileName(file.FileName);
                string Cur_FileName = DateTime.Now.ToBinary().ToString() + "." + Ora_FileName.Substring(Ora_FileName.LastIndexOf(".") + 1);
                string filePath = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath(SaveDirectory), Cur_FileName);
                //保存文件
                file.SaveAs(filePath);
                string End_filePath = SaveDirectory + Cur_FileName;
                return End_filePath;
            }
            else
            {
                return "";
            }
        }

        public static string UploadFile_OriName(HttpPostedFileBase file, string SaveDirectory = "/Content/files/Shop/",string ExStr="")
        {
            if (file != null)
            {
                //构造文件上传路径(文件名为用户ID)
                string strFileTypeLimit = "image";

                int IsPicType = file.ContentType.IndexOf(strFileTypeLimit);
                //if (Photo.FileName.ToString() != "" && IsPicType != -1 && Photo.ContentLength < 20971520)
                string Ora_FileName = string.Empty;
                if(ExStr=="")
                {
                    Ora_FileName = System.IO.Path.GetFileName(file.FileName);
                }
                else
                {
                    Ora_FileName = System.IO.Path.GetFileName(ExStr+"-"+file.FileName);
                }
                //string Cur_FileName = DateTime.Now.ToBinary().ToString() + "." + Ora_FileName.Substring(Ora_FileName.LastIndexOf(".") + 1);
                string filePath = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath(SaveDirectory), Ora_FileName);
                //保存文件
                file.SaveAs(filePath);
                string End_filePath = SaveDirectory + Ora_FileName;
                return End_filePath;
            }
            else
            {
                return "";
            }
        }
        public static string UploadFile(HttpPostedFileBase[] files, string SaveDirectory = "/Content/files/Shop/")
        {
            string filePath = "";
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        filePath += UploadFile(file, SaveDirectory) + ";";
                    }
                    if (filePath.Length > 0 && filePath[filePath.Length - 1] == ';')
                    {
                        filePath = filePath.Substring(0, filePath.Length - 1);
                    }
                }     
               
                return filePath;    
        }

        public static string UploadMultiFile(HttpPostedFileBase[] files, string SaveDirectory = "/Content/files/Shop/", string WithExStr = "")
        {
            string filePath = "";
            if (files != null)
            {
                foreach (var file in files)
                {
                    filePath += UploadFile_OriName(file, SaveDirectory, WithExStr) + ";";
                }
                if (filePath.Length > 0 && filePath[filePath.Length - 1] == ';')
                {
                    filePath = filePath.Substring(0, filePath.Length - 1);
                }
            }
            return filePath;
        }
       
        public static string UpdateOldFile(string OldFilePath,HttpPostedFileBase NewFile, string SaveDirectory = "/Content/files/Shop/")
        {
                //删除旧文件
                DeleteFlie(OldFilePath);
                //添加新文件
                return UploadFile(NewFile, SaveDirectory);
        }
        public static string UpdateOldFile(string OldFilePaths, HttpPostedFileBase[] NewFiles, string SaveDirectory = "/Content/files/Shop/")
        {
            //删除旧文件
            DeleteFlie( OldFilePaths.UnPackString(';'));
            //添加新文件
            return UploadFile(NewFiles, SaveDirectory);
        }
        public static string UpdateOldFile(List<string> OldFilePaths, HttpPostedFileBase[] NewFiles, string SaveDirectory = "/Content/files/Shop/")
        {
            //删除旧文件
            DeleteFlie(OldFilePaths);
            //添加新文件
            return UploadFile(NewFiles, SaveDirectory);
        }

        #region 文件目录
        public static int CreateDirectorys( List<string> pathList)
        {
            //创建成功的目录数量
            int SuccessCount=0;
            for (int i= 0;i< pathList.Count;i++)
            {
                pathList[i] = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath(pathList[i]));
                try
                {
                   
                    if (Directory.Exists(pathList[i]))
                    {
                        Console.WriteLine("That pathList[i] exists already.");
                        continue;
                    }
                    
                    DirectoryInfo di = Directory.CreateDirectory(pathList[i]);
                    Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(pathList[i]));
                    SuccessCount++;             
                }
                catch (Exception e)
                {
                    Console.WriteLine("The process failed: {0}", e.ToString());
                }
                finally
                {
                   
                }
               
            }

            return SuccessCount;

        }

        public static int DeleteDirectorys(List<string> pathList)
        {
            
            //删除失败的目录数量
            int ErrorCount = 0;
                for (int i = 0; i < pathList.Count; i++)
                {
                    pathList[i] = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath(pathList[i]));
                    try
                {
                    if (Directory.Exists(pathList[i]))
                    {
                        Directory.Delete(pathList[i],true);
                        continue;
                    }
                    else
                    {
                        ErrorCount++;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("The process failed: {0}", e.ToString());
                }
                finally
                {

                }

            }

            return ErrorCount;

        }
        #endregion
    }
}
using System.IO;
using Microsoft.AspNetCore.Http;

namespace xyj.core.Utility
{
    public class FileUploadUtility
    {
        public static void UploadBigFile(IFormFile fileBase, string SavePath, string ContentRange)
        {
            //disk存储过程
            var disk = new SaveDisk();
            disk.SaveChunk(fileBase, SavePath, ContentRange);
        }


        private class SaveDisk
        {
            //将上传的文件块保存
            public void SaveChunk(IFormFile targetFile, string FilePath, string ContentRange)
                // var ContentRange = HttpContext.Current.Request.Headers["Content-Range"];
            {
                /*----------基本属性---------------*/
                var startPosition = 0;
                var endPosition = 0;
                long BeginPosition = 0; //开始存储位置
                var OnceSaveNum = 512;

                //确定该文件的起始位置和终止位置
                if (!string.IsNullOrEmpty(ContentRange))
                {
                    ContentRange = ContentRange.Replace("bytes", "").Trim();
                    ContentRange = ContentRange.Substring(0, ContentRange.IndexOf("/"));
                    var ranges = ContentRange.Split('-');
                    startPosition = int.Parse(ranges[0]);
                    endPosition = int.Parse(ranges[1]);
                }

                //确定开始存储位置
                FileStream fs;
                if (File.Exists(FilePath))
                {
                    //如果该文件已经存在，则接着上一次存储的位置继续存储
                    //fs = System.IO.File.OpenWrite(FilePath);
                    fs = File.Open(FilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                    BeginPosition = fs.Length;
                }
                else
                {
                    //如果该文件不存在，则创建该文件，从起始位置0开始读
                    fs = new FileStream(FilePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                    BeginPosition = 0;
                }
                if (BeginPosition > endPosition)
                {
                    fs.Close();
                    return;
                }
                if (BeginPosition < startPosition)
                {
                    BeginPosition = startPosition;
                }
                else if (BeginPosition > startPosition && BeginPosition < endPosition)
                {
                    BeginPosition = startPosition;
                }
                fs.Seek(BeginPosition, SeekOrigin.Current); //寻找到当前存储起始位置

                //存储
                var nbytes = new byte[OnceSaveNum];
                var nReadSize = 0;
                nReadSize = targetFile.OpenReadStream().Read(nbytes, 0, 512);
                while (nReadSize > 0)
                {
                    fs.Write(nbytes, 0, nReadSize);
                    nReadSize = targetFile.OpenReadStream().Read(nbytes, 0, 512);
                }
                fs.Close();
                fs.Dispose();
            }
        }
    }
}
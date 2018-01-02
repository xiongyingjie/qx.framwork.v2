using System.IO;
using System.Text;

namespace xyj.core.Utility
{
    public class FileUtility
    {
        #region 调用
        //FileHelper.ReNameFile("C:/", "test.txt", "test.reNamed.txt");
        //FileHelper.ReNameDirectory("C:/", "tt", "ttReNamed");
        //FileHelper.MoveFile("C:/test.reNamed.txt", "C:/tt/");
        //FileHelper.MoveDirectory("C:/tt/", "C:/ttReNamed/");
        //FileHelper.CopyDirectory("C:/ttReNamed/tt/", "C:/ttReNamed/tt2/");
        //FileHelper.CopyFile("C:/test01.txt", "C:/",true); 
        #endregion

        #region 写入文件
        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="content">待写入文件的字符串</param>
        /// <param name="Apend">是否扩充原文件</param>
        /// <returns>是否写入成功</returns>
        public static bool WriteFile(string filePath, string content, bool overWrite = false)
        {
           if (!overWrite&&File.Exists(filePath))
            {
                return false; ;
            }
          //创建目录
            var fileInfo =new FileInfo(filePath);
            if (!fileInfo.Directory.Exists)
            {
                fileInfo.Directory.Create();
            }
            //执行操作
            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                //指定编码方式
                var writer = new StreamWriter(fs, Encoding.UTF8);
                //写入文件
                writer.Write(content);
                //刷新缓冲区并关闭对象
                writer.Flush();
                writer.Close();
                fs.Close();
            }
            return true;
        }
        #endregion

        #region 读取文件
        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>文件内容</returns>
        public static string ReadFile(string filePath)
        {
            string temp = "";
            if (File.Exists(filePath))
            {
                using (var fs = new FileStream(filePath, FileMode.Open))
                {
                    var reader = new StreamReader(fs, Encoding.UTF8);
                    temp = reader.ReadToEnd();
                    reader.Close();
                    fs.Close();
                }
            }
            return temp;
        }
        #endregion

        #region 文件重命名
        /// <summary>
        /// 文件重命名
        /// </summary>
        /// <param name="folderName">文件所在文件夹路径【末尾需要加上/】</param>
        /// <param name="oldName">旧名称</param>
        /// <param name="newName">新名称</param>
        /// <returns>是否操作成功</returns>
        public static bool ReNameFile(string folderName, string oldName, string newName)
        {
            string oldPath = folderName + oldName;
            string newPath = folderName + newName;
            //源文件存在且目标文件不存在
            if (File.Exists(oldPath) && !File.Exists(newPath))
            {
                FileInfo fi = new FileInfo(oldPath);
                fi.MoveTo(newPath);
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 文件夹重命名
        /// <summary>
        /// 文件夹重命名
        /// </summary>
        /// <param name="folderName">文件所在文件夹路径【末尾需要加上/】</param>
        /// <param name="oldName">旧名称</param>
        /// <param name="newName">新名称</param>
        /// <returns>是否操作成功</returns>
        public static bool ReNameDirectory(string folderName, string oldName, string newName)
        {
            string oldPath = folderName + oldName;
            string newPath = folderName + newName;
            //源目录存在且目标目录不存在
            if (Directory.Exists(oldPath) && !Directory.Exists(newPath))
            {
                DirectoryInfo di = new DirectoryInfo(oldPath);
                di.MoveTo(newPath);
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 移动文件夹
        /// <summary>
        /// 移动文件夹
        /// </summary>
        /// <param name="srcPath">源目录</param>
        /// <param name="destPath">目标目录</param>
        /// <param name="overWrite">是否覆盖</param>
        /// <returns>是否操作成功</returns>
        public static bool MoveDirectory(string srcPath, string destPath, bool overWrite = false)
        {
            //源目录存在
            if (Directory.Exists(srcPath))
            {
                //获取目录名并构造目标路径
                destPath += new DirectoryInfo(srcPath).Name;
                //存在目标目录 且 标志覆盖目标目录
                if (Directory.Exists(destPath) && overWrite)
                {
                    //将目标目录重命名
                    DirectoryInfo di = new DirectoryInfo(destPath);
                    di.MoveTo(destPath + "_BAK");
                }
                //目标目录 不存在
                else if (!Directory.Exists(destPath))
                {
                    //执行操作
                    DirectoryInfo di = new DirectoryInfo(srcPath);
                    di.MoveTo(destPath);
                    return true;
                }
                else
                {
                    return false;//存在目标目录且标志不覆盖
                }

            }
            return false;//源目录不存在

        }
        #endregion

        #region 复制文件夹[递归]
        /// <summary>
        /// 复制文件夹
        /// </summary>
        /// <param name="srcPath">源目录</param>
        /// <param name="destPath">目标目录</param>
        /// <param name="overWrite">是否覆盖</param>
        /// <returns>是否操作成功</returns>
        public static bool CopyDirectory(string srcPath, string destPath, bool overWrite = false)
        {
            ////源目录存在
            //if (Directory.Exists(srcPath))
            //{
            //    //获取目录名并构造目标路径
            //    destPath += new DirectoryInfo(srcPath).Name;
            //    //存在目标目录 且 标志覆盖目标目录
            //    if (Directory.Exists(destPath) && overWrite)
            //    {
            //        //将目标目录重命名
            //        DirectoryInfo di = new DirectoryInfo(destPath);
            //        di.MoveTo(destPath + "_BAK");
            //    }
            //    //目标目录 不存在
            //    else if (!Directory.Exists(destPath))
            //    {
            //        //执行操作
            //        DirectoryInfo di = new DirectoryInfo(srcPath);
            //        di.(destPath);
            //        return true;
            //    }
            //    else
            //    {
            //        return false;//存在目标目录且标志不覆盖
            //    }

            //}
            return false;//源目录不存在

        }
        #endregion

        #region 移动文件
        /// <summary>
        /// 移动文件
        /// </summary>
        /// <param name="srcFilePath">源文件路径</param>
        /// <param name="destFolderPath">目标目录</param>
        /// <param name="overWrite">是否覆盖</param>
        /// <returns>是否操作成功</returns>
        public static bool MoveFile(string srcFilePath, string destFolderPath, bool overWrite = false)
        {
            //源文件存在
            if (File.Exists(srcFilePath))
            {
                //获取文件名并构造目标路径
                string fileName = new FileInfo(srcFilePath).Name;
                destFolderPath += fileName;
                //存在目标文件 且 标志覆盖目标文件
                if (File.Exists(destFolderPath) && overWrite)
                {
                    //将目标文件重命名
                    FileInfo fi = new FileInfo(destFolderPath);
                    fi.MoveTo(destFolderPath + ".BAK");
                }
                //目标文件 不存在
                else if (!File.Exists(destFolderPath))
                {
                    //执行操作
                    FileInfo fi = new FileInfo(srcFilePath);
                    fi.MoveTo(destFolderPath);
                }
                else
                {
                    return false;//存在目标文件且标志不覆盖
                }
            }

            return false;//源目录不存在

        }
        #endregion

        #region 复制文件
        /// <summary>
        /// 复制文件
        /// </summary>
        /// <param name="srcFilePath">源文件路径</param>
        /// <param name="destFolderPath">目标目录</param>
        /// <param name="overWrite">是否覆盖</param>
        /// <returns>是否操作成功</returns>
        public static bool CopyFile(string srcFilePath, string destFolderPath, bool overWrite = false)
        {
            //源文件存在
            if (File.Exists(srcFilePath))
            {
                //获取文件名并构造目标路径
                string fileName = new FileInfo(srcFilePath).Name;
                destFolderPath += fileName;
                //源目录和目标目录相同
                if (File.Exists(destFolderPath) && new FileInfo(srcFilePath).DirectoryName == new FileInfo(destFolderPath).DirectoryName)
                {
                    //执行操作
                    FileInfo fi = new FileInfo(srcFilePath);
                    fi.CopyTo(destFolderPath + ".Copy");
                    return true;
                }
                //存在目标文件 且 标志覆盖目标文件
                else if (File.Exists(destFolderPath) && overWrite)
                {
                    //将目标文件重命名
                    FileInfo fi = new FileInfo(destFolderPath);
                    fi.MoveTo(destFolderPath + ".Bak");
                }
                //目标文件 不存在
                else if (!File.Exists(destFolderPath))
                {
                    //执行操作
                    FileInfo fi = new FileInfo(srcFilePath);
                    fi.CopyTo(destFolderPath);
                    return true;
                }
                else
                {
                    return false;//存在目标文件且标志不覆盖
                }
            }

            return false;//源目录不存在

        }
        #endregion

        #region 获取指定目录下的文件信息
        /// <summary>
        /// 获取指定目录下的文件信息
        /// </summary>
        /// <param name="folderPath">目录路径</param>
        /// <param name="searchPattern">搜索字符串（如“*.txt”）</param>
        /// <returns>是否操作成功</returns>
        public static FileInfo[] GetDirectoryFiles(string folderPath, string searchPattern = "")
        {
            //目录存在
            if (Directory.Exists(folderPath))
            {
                DirectoryInfo di = new DirectoryInfo(folderPath);
                return searchPattern == "" ? di.GetFiles() : di.GetFiles(searchPattern);
            }
            else
            {
                return null;//源目录不存在
            }
        }
        #endregion
    }
}

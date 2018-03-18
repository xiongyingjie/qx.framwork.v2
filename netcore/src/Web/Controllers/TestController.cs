using System;
using System.Collections.Generic;
using System.DrawingCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using xyj.core;
using xyj.core.Extensions;
using xyj.core.Utility;
using xyj.study.Interfaces;

namespace Web.Controllers
{
    public class TestController : Controller
    {
        private IYlService _ylService;
        #region 测试脚本
        private string sqlDropTable =
@"delete from Test_Persons";

        private string sqlCreateTable=
@"CREATE TABLE Test_Persons
(
Id_P int,
Name varchar(255),
Age varchar(255)
)";
        private string sqlInsertTable =@"insert into Test_Persons (Id_P,Name,Age) values( '1001', '小熊', '18')";
        private string sqlSelectTable = @"select * from Test_Persons";

        public TestController(IYlService ylService)
        {
            _ylService = ylService;
        }

        string  _Show(string tip,string connString, ClientType type)
        {
           var result = tip +"\n";
            var list = sqlSelectTable.ExecuteReader(connString, type);
            foreach (var item in list)
            {
                result += ($"Id_P：{item[0]} Name：{item[1]} Age：{item[2]} \n");
            }
            return result;
        }
        string Show(string connString, ClientType type)
        {
            string result = "";
            sqlDropTable.ExecuteNonQuery(connString, type);
            sqlCreateTable.ExecuteNonQuery(connString, type);
            result += _Show("写入前", connString, type);
            sqlInsertTable.ExecuteNonQuery(connString, type);
            result += _Show("写入后", connString, type);
            return result;
        }
        #endregion

        public IActionResult Db()
        {
            string result = "";
            var mySqlConnString = DbUtility.MySqlConnString("47.92.109.79", "test", "admin", "admin");
            var sqlSeverConnString = DbUtility.SqlSeverConnString();
            //var oracleConnString = DbUtility.OracleConnString("47.92.109.79", "orcl", "panda", "QxamoySQL666");

            result += Show(mySqlConnString, ClientType.MySql);
            result += "\n\n";
            result += Show(sqlSeverConnString, ClientType.SqlSever);
            result += "\n\n";
            //result += Show(oracleConnString, ClientType.Oracle);
            return Content(result);
        }
        //Test/Grap120Ask
        public IActionResult Grap120Ask(int start=3000,int count=20)
        {
            var startTime = DateTime.Now;
           // _ylService.Grap120Ask(start, count);
            return Content(DateTime.Now+"采集完成,耗时:"+ (DateTime.Now- startTime).Seconds+"(s)");
        }
        public IActionResult Grap01()
        {
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = "http://www.sufeinet.com",//URL     必需项
                Encoding = null,//编码格式（utf-8,gb2312,gbk）     可选项 默认类会自动识别
                //Encoding = Encoding.Default,
                Method = "get",//URL     可选项 默认为Get
                Timeout = 100000,//连接超时时间     可选项默认为100000
                ReadWriteTimeout = 30000,//写入Post数据超时时间     可选项默认为30000
                IsToLower = false,//得到的HTML代码是否转成小写     可选项默认转小写
                Cookie = "",//字符串Cookie     可选项
                UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)",//用户的浏览器类型，版本，操作系统     可选项有默认值
                Accept = "text/html, application/xhtml+xml, */*",//    可选项有默认值
                ContentType = "text/html",//返回类型    可选项有默认值
                Referer = "http://www.sufeinet.com",//来源URL     可选项
                Allowautoredirect = true,//是否根据３０１跳转     可选项
                CerPath = "d:\\123.cer",//证书绝对路径     可选项不需要证书时可以不写这个参数
                Connectionlimit = 1024,//最大连接数     可选项 默认为1024
                Postdata = "C:\\PERKYSU_20121129150608_ScrubLog.txt",//Post数据     可选项GET时不需要写
                PostDataType = PostDataType.FilePath,//默认为传入String类型，也可以设置PostDataType.Byte传入Byte类型数据
                ProxyIp = "192.168.1.105：8015",//代理服务器ID 端口可以直接加到后面以：分开就行了    可选项 不需要代理 时可以不设置这三个参数
                ProxyPwd = "123456",//代理服务器密码     可选项
                ProxyUserName = "administrator",//代理服务器账户名     可选项
                ResultType = ResultType.Byte,//返回数据类型，是Byte还是String
                PostdataByte = System.Text.Encoding.Default.GetBytes("测试一下"),//如果PostDataType为Byte时要设置本属性的值
                CookieCollection = new System.Net.CookieCollection(),//可以直接传一个Cookie集合进来
            };
            item.Header.Add("测试Key1", "测试Value1");
            item.Header.Add("测试Key2", "测试Value2");
            //得到HTML代码
            HttpResult result = http.GetHtml(item);
            //取出返回的Cookie
            string cookie = result.Cookie;
            //返回的Html内容
            string html = result.Html;
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //表示访问成功，具体的大家就参考HttpStatusCode类
            }
            //表示StatusCode的文字说明与描述
            string statusCodeDescription = result.StatusDescription;
            //把得到的Byte转成图片
            var img = byteArrayToImage(result.ResultByte);
            return Content("ok");
        }



        /// <summary>
        /// 字节数组生成图片
        /// </summary>
        /// <param name="Bytes">字节数组</param>
        /// <returns>图片</returns>
        private Image byteArrayToImage(byte[] Bytes)
        {
            MemoryStream ms = new MemoryStream(Bytes);
            Image outputImg = Image.FromStream(ms);
            return outputImg;
        }


    }
}
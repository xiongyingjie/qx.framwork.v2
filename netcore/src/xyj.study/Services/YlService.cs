using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using xyj.core;
using xyj.core.Extensions;
using xyj.study.Entity;
using xyj.study.Interfaces;

namespace xyj.study.Services
{
    public class YlService : BaseRepository, IYlService
    {
        //private string ThirdGet(string url)
        //{
        //    try
        //    {
        //        // 要访问的目标页面
        //        string targetUrl = url; //"http://test.abuyun.com/proxy.php";

        //        // 代理服务器
        //        string proxyHost = "http://http-dyn.abuyun.com";
        //        string proxyPort = "9020";

        //        // 代理隧道验证信息
        //        string proxyUser = "H583KQMM9183886D";
        //        string proxyPass = "E7854563A85B0376";

        //        // 设置代理服务器
        //        var proxy = new WebProxy();
        //        proxy.Address = new Uri(string.Format("{0}:{1}", proxyHost, proxyPort));
        //        proxy.Credentials = new NetworkCredential(proxyUser, proxyPass);

        //        ServicePointManager.Expect100Continue = false;

        //        var request = WebRequest.Create(targetUrl) as HttpWebRequest;

        //        request.AllowAutoRedirect = true;
        //        request.KeepAlive = true;
        //        request.Method = "GET";
        //        request.Proxy = proxy;

        //        //request.Timeout = 20000;
        //        //request.ServicePoint.ConnectionLimit = 512;
        //        //request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.82 Safari/537.36";
        //        //request.Headers.Add("Cache-Control", "max-age=0");
        //        //request.Headers.Add("DNT", "1");

        //        using (var response = request.GetResponse() as HttpWebResponse)
        //        using (var sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
        //        {
        //            return sr.ReadToEnd();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex is System.Net.WebException&& ((WebException)ex).Status == WebExceptionStatus.ProtocolError&& ex.Message.Contains("404"))
        //        {//处理404
                   
        //            return "";
        //        }
        //        else
        //        {
        //            return ThirdGet(url);
        //        }
                
        //    }
           
          
        //}
        //public void Grap120Ask(int startIndex,int count)
        //{
        //    var siteId = "120ask";
        //    var currentIndex = startIndex;
        //    var url = "http://www.120ask.com/question/" + currentIndex + ".htm";
        //    var writeCount = 0;
        //    var writeDiv = 20;//分片大小
        //    while (count>0)
        //    {
        //        url= "http://www.120ask.com/question/" + currentIndex + ".htm";
        //        var html = ThirdGet(url);
               
        //        if (html.HasValue()&&!html.Contains("找不到相关页面"))
        //        {
        //            Db.site_page.Add(new site_page()
        //            {
        //                site_page_id = siteId+"-"+ currentIndex,
        //                site_id = siteId,
        //                html = html,
        //                seq = currentIndex,
        //                url = url,
        //                create_time = DateTime.Now
        //            });
        //            writeCount++;//增加计数
        //            //每writeDiv条写入一次数据库（最后一批不足writeDiv也可以写入）
        //            if (writeCount == writeDiv || count ==1)
        //            {
        //                try
        //                {
        //                    Db.SaveChanges();
        //                }
        //                catch (Exception)
        //                {//提交出现异常时写入日志
        //                    Db.site_log.Add(new site_log()
        //                    {
        //                        site_log_id = siteId+DateTime.Now.FormatTime(false)+DateTime.Now.Random(),
        //                        site_id = siteId,
        //                        contents = "第"+ (currentIndex - writeDiv)  + "-"+ currentIndex + "写入失败",
        //                        log_time = DateTime.Now
        //                    });
                            
        //                    Db.SaveChanges();
        //                }
        //                writeCount = 0;
        //            }
        //        }
        //        count--;
        //        currentIndex++;//移动到下一条
        //    }  
        //}

        //public void Grap120Ask(int startIndex, int count)
        //{
        //    var currentIndex = startIndex;
        //    var taskDiv = 20;//单个线程处理的分片大小
        //    while (count>0)
        //    {
        //        var index = currentIndex;
        //        var subCount = count;
        //        #region 开启新线程
        //        try
        //        {   
        //            Task.Factory.StartNew(() =>
        //            {
        //                SubGrap120Ask(index, subCount <= taskDiv? subCount : taskDiv);
        //            });
        //        }
        //        catch (Exception ex)
        //        {//线程异常时写入日志
        //            Db.site_log.Add(new site_log()
        //            {
        //                site_log_id =  DateTime.Now.FormatTime(false) + DateTime.Now.Random(),
        //                site_id = "test",
        //                contents = "第" + (index ) + "-" + (index+ taskDiv) + "写入失败,原因:"+ ex.Message,
        //                log_time = DateTime.Now
        //            });
        //            Db.SaveChanges();
        //        }
        //        #endregion
        //        currentIndex += taskDiv;
        //        count -= taskDiv;
        //    }
          
        //}
        public void Test()
        {
            var myOrg = Db.user_orgnization.Where(a => a.user_id == "1325112033");
            var t= myOrg.Select(b => b.orgnization.orgnization_id).ToList();
            Db.user_position.Where(a => a.user_id == "1325112033").Select(b => b.orgnization_position.orgnization.orgnization_id).ToList();
        }
    }
}

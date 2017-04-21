using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qx.Tools.CommonExtendMethods;
using Web.Controllers.Base;
using HtmlAgilityPack;
using Qx.Tools.QxClass;


namespace Web.Controllers
{
    public class SbController : BaseController
    {
        // GET: Sb
        // GET: /<controller>/
        //  /Sb/Grap?dist_url=/emap/sys/panda/*default/index.do#/jgb
        public ActionResult Grap(string dist_url)
        {
            
            var html = "Failed To Connect To" + dist_url;
            //抓取页面
            if (dist_url.HasValue())
            {
                var author_host = "http://148u548o08.imwork.net:31796";
                var author_url = "/emap/sys/emapAuth/debug/login.do?back=%2Femap%2Fsys%2Fpanda%2F*default%2Findex.do";
                dist_url = "/emap/sys/panda/*default/index.do#/jgb";
                var client= new HttpClient(new Uri(author_host));
                client.CookieContainer = new System.Net.CookieContainer();
                //身份认证
                html = client.Post(author_url, new Dictionary<string, string>()
                {
                    {"userId","admin" },
                    {"role","" }
                });
                html = client.Get(dist_url);
                //ar doc = new HtmlDocument();
                //oc.LoadHtml(html);
                //ar nodes = doc.DocumentNode.ChildNodes.ToList();
            }
            V("html", html);
            return View();
        }
        public ActionResult blank()
        {
            return View();
        }
        public ActionResult buttons()
        {
            return View();
        }
        public ActionResult flot()
        {
            return View();
        }
        public ActionResult forms()
        {
            return View();
        }
        public ActionResult grid()
        {
            return View();
        }
        public ActionResult icons()
        {
            return View();
        }
        public ActionResult index()
        {
            return View();
        }
        public ActionResult welcome()
        {
            return View();
        }
        public ActionResult login()
        {
            return View();
        }
        public ActionResult morris()
        {
            return View();
        }
        public ActionResult notifications()
        {
            return View();
        }
        public ActionResult panelsWells()
        {
            return View();
        }
        public ActionResult tables()
        {
            return View();
        }
        public ActionResult typography()
        {
            return View();
        }
        public ActionResult layer()
        {
            return View();
        }
        
    }
}
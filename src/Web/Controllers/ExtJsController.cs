using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using Web.Controllers.Base;

namespace Web.Controllers
{
    public class ExtJsController : BaseController
    {
        public void ProcessRequest()
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            string act = Request["act"];
            if (act != null)
            {
                if (act == "getmoive")
                {
                    string r = "{rows:[{\"id\":\"1\",\"genre\":\"Comedy\",\"sort_order\":\"0\"},{\"id\":\"2\",\"genre\":\"Drama\",\"sort_order\":\"1\"},{\"id\":\"3\",\"genre\":\"Action\",\"sort_order\":\"2\"}]}";
                    Response.Write(r);
                    return;
                }
                else if (act == "getdata")
                {
                    {
                        string r = "{success: true,data:{\"id\":\"1\",\"title\":\"Office Space\",\"director\":\"Mike Judge\",\"released\":\"1999-02-14\",\"genre\":\"Drama\",\"tagline\":\"Work Sucks\",\"coverthumb\":\"84m.jpg\",\"price\":\"19.95\",\"available\":\"1\"}} ";
                        Response.Write(r);
                        return;
                    }
                }
            }
            else
            {
                //string r = "{ success: false,errors: {title: \"Sounds like a Chick Flick\"},errormsg: \"That movie title sounds like a chick flick.\"}";
                string r = "{ success: true}";
                Response.Write(r);
            }

            // context.Response.Write ("From Server: " +context.Request.Form["name"]+"\n");
            //  context. Response.End();


        }
        // GET: ExtJs
        public ActionResult Index()
        {
            InitMenu(new Dictionary<string, string>() {
                {"ext1","/ExtJs/ext1"},
                {"ext2","/ExtJs/ext2"},
                {"ext3","/ExtJs/ext3"},
                {"ext4","/ExtJs/ext4"},
                {"extajax","/ExtJs/extajax"},
                {"extgrid","/ExtJs/extgrid"},
                {"ExtMsg","/ExtJs/ExtMsg"},
                {"ExtStart","/ExtJs/ExtStart"},
                {"form1","/ExtJs/form1"},
                {"form2","/ExtJs/form2"},
                {"form3","/ExtJs/form3"},
                {"form4","/ExtJs/form4"},
                {"form5","/ExtJs/form5"},
                {"form6","/ExtJs/form6"},
                {"form7","/ExtJs/form7"},
                {"form8","/ExtJs/form8"},
                {"form9","/ExtJs/form9"},
                {"form10","/ExtJs/form10"},
                {"form11","/ExtJs/form11"},
                {"form12","/ExtJs/form12"},
                {"form13","/ExtJs/form13"},
                {"form14","/ExtJs/form14"},
                {"form15","/ExtJs/form15"},
                {"form16","/ExtJs/form16"},
                {"form17","/ExtJs/form17"},
                {"form18","/ExtJs/form18"},
                {"form19","/ExtJs/form19"},
                {"form20","/ExtJs/form20"},
                {"form21","/ExtJs/form21"},
                {"form22","/ExtJs/form22"},
                {"setup","/ExtJs/setup"},
                {"test1","/ExtJs/test1"},
            });
            return View();
        }
        public ActionResult Demo()
         {
            InitEJLayout("Demo");
            return View();
        }
        public ActionResult P1()
        {
            
            InitEJLayout("P1");
            return View();
        }
        public ActionResult ext1()
        {
            InitEJLayout("ext1");
            return View();
        }
        public ActionResult ext2()
        {
            InitEJLayout("ext2");
            return View();
        }
        public ActionResult ext3()
        {
            InitEJLayout("ext3");
            return View();
        }
        public ActionResult ext4()
        {
            InitEJLayout("ext4");
            return View();
        }   
        public ActionResult extajax()
        {
            InitEJLayout("extajax");
            return View();
        }
        public ActionResult extgrid()
        {
            InitEJLayout("extgrid");
            return View();
        }
        public ActionResult extjs1()
        {
            InitEJLayout("extjs1");
            return View();
        }
        public ActionResult ExtMsg()
        {
            InitEJLayout("ExtMsg");
            return View();
        }
        public ActionResult ExtStart()
        {
            InitEJLayout("ExtStart");
            return View();
        }
        public ActionResult form1()
        {
            InitEJLayout("form1");
            return View();
        }
        public ActionResult form10()
        {
            InitEJLayout("form10");
            return View();
        }
        public ActionResult form11()
        {
            InitEJLayout("form11");
            return View();
        }
        public ActionResult form12()
        {
            InitEJLayout("form12");
            return View();
        }
        public ActionResult form13()
        {
            InitEJLayout("form13");
            return View();
        }
        public ActionResult form14()
        {
            InitEJLayout("form14");
            return View();
        }
        public ActionResult form15()
        {
            InitEJLayout("form15");
            return View();
        }
        public ActionResult form16()
        {
            InitEJLayout("form16");
            return View();
        }
        public ActionResult form17()
        {
            InitEJLayout("form17");
            return View();
        }

        public ActionResult form18()
        {
            InitEJLayout("form18");
            return View();
        }
        public ActionResult form19()
        {
            InitEJLayout("form19");
            return View();
        }
        public ActionResult form2()
        {
            InitEJLayout("form2");
            return View();
        }
        public ActionResult form20()
        {
            InitEJLayout("form20");
            return View();
        }
        public ActionResult form21()
        {
            InitEJLayout("form21");
            return View();
        }
        public ActionResult form22()
        {
            InitEJLayout("form22");
            return View();
        }
        public ActionResult form3()
        {
            InitEJLayout("form3");
            return View();
        }
        public ActionResult form4()
        {
            InitEJLayout("form4");
            return View();
        }
        public ActionResult form5()
        {
            InitEJLayout("form5");
            return View();
        }
        public ActionResult form6()
        {
            InitEJLayout("form6");
            return View();
        }
        public ActionResult form7()
        {
            InitEJLayout("form7");
            return View();
        }
        public ActionResult form8()
        {
            InitEJLayout("form8");
            return View();
        }
        public ActionResult form9()
        {
            InitEJLayout("form9");
            return View();
        }
        public ActionResult setup()
        {
            InitEJLayout("setup");
            return View();
        }
        public ActionResult test1()
        {
            InitEJLayout("test1");
            return View();
        }
    }
}
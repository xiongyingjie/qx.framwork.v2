using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;

namespace Web.Areas.Json.Models
{
    public class Answer
    {
        public Answer()
        {
            Content = "我是内容" + DateTime.Now;
            IsBest = false;
            Author=new Person();
            CreaTime = DateTime.Now;
        }
        public string Content;
        public bool IsBest;
        public Person Author;
        public DateTime CreaTime;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Areas.Json.Models
{
    public class Question
    {
        public Question()
        {
            Title = "你觉得最丢脸的事情是什么";
            Author=new Person();
            Price = 10;
            HearedCount = 2348;
            PraiseCount = 2333;
            CollectCount = 4999;
            Answers=new List<Answer>()
            {
                new Answer(),
                new Answer()
            };
            CreaTime=DateTime.Now;
        }
        public string Title;
        public Person Author;
        public double Price;
        public int HearedCount;
        public int PraiseCount;
        public int CollectCount;
       
        public List<Answer> Answers;
        public DateTime CreaTime;
       
    }
}
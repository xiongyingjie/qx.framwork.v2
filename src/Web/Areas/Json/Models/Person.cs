using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Areas.Json.Models
{
    public class Person
    {
        public  Person()
        {
            Icon = "#";
            Name = "英杰";
            Descrip = "华侨大学学生";
        }
        public string Icon;
        public string Name;
        public string Descrip;
    }
}
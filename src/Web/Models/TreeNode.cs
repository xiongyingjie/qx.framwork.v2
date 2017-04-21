using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class TreeNode
    {
        public string memberid { get; set; }
        public double TotalPrice { get; set; }
        public int PurchaseTimes { get; set; }
        public string HeadPicture { get; set; }
    }
}
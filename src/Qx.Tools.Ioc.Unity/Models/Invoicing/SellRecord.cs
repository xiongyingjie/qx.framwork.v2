using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qx.Tools.Ioc.Unity.Models.Invoicing
{
    public class SellRecord
    {
        public string SellRecordID { get; set; }

        public string OrgShelveProductID { get; set; }

        public int SellNum { get; set; }

        public DateTime Time { get; set; }

        public string OperatorUserID { get; set; }

        public string ProductName { get; set; }

        public string OrgShelveName { get; set; }

        public double Price { get; set; }
    }
}

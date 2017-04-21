using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qx.Tools.Ioc.Unity.Models
{
    public class DailyReport
    {
        public string time { get; set; }
        public double PhysicalProducts { get; set; }//实物产品销售额
        public double ServicesProducts { get; set; }//服务产品销售额   
        public double Profit { get; set; }//利润
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qx.Tools.Annotations;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Models;

namespace Test
{

    public class Custom
    {
        [Form("deptName",Show.Add,FormControlType.Checkbox)]
        public string Name { get; set; }

        [Form(Lable = "deptAddress")]
        public string Address { get; set; }
    }
}

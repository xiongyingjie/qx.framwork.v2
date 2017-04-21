using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class ProfitTree
    {
        public int MyPosition { get; set; }
        public int ChidNum { get; set; }
        public int TreeNodeNum { get; set; }
        public List<TreeNode> TreeNode { get; set; }
    }
}
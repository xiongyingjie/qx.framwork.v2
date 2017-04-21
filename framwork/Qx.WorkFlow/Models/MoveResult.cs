using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qx.WorkFlow.Models
{
   public class MoveResult
    {
       public MoveResult()
       {
            SucessMsgs = new List<string>();
            ErrorMsgs =new List<string>();
       }

       public bool Successful
       {
           get { return ErrorMsgs.Count <= 0&& SucessMsgs.Count>=1; }
       }
        public string FromNodeId { get; set; }
        public string ToNodeId { get; set; }
        public List<string> ErrorMsgs { get; set; }
        public List<string> SucessMsgs { get; set; }
    }
}

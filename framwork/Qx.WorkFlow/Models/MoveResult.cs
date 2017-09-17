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
            SubMoveResults = new List<MoveResult>();
            _allResults=new List<MoveResult>();
       }

       private void GetChildren(MoveResult father)
       {
            _allResults.AddRange(father.SubMoveResults);
            foreach (var item in father.SubMoveResults)
            {
                GetChildren(item);
            }
        }
       public bool Successful
       {
           get
           {
                return  ErrorMsgs.Count <= 0&& SucessMsgs.Count>=1; }
       }
        public bool SuccessfulAll
        {
            get
            {
                GetChildren(this);
                return _allResults.All(a => a.Successful);
            }
        }
      
        public MoveResult AddRelationMoveResult(MoveResult relationMoveResult)
        {
            SubMoveResults.Add(relationMoveResult);
            return this;
        }
        public string FromNodeId { get; set; }
        public string ToNodeId { get; set; }
        public List<string> ErrorMsgs { get; set; }
        public List<string> SucessMsgs { get; set; }
        public List<MoveResult>  SubMoveResults { get; }
       private List<MoveResult> _allResults;
    }
}

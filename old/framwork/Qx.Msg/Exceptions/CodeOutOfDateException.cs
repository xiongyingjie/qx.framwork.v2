using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qx.Msg.Exceptions
{
    public class CodeOutOfDateException: Exception
    {
        public CodeOutOfDateException()
        {
        }

        public CodeOutOfDateException(string message) : base(message)
        {
        }
    }
   
}

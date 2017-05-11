using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qx.Contents.Exceptions
{
    public class ParamNumberInccorectException :Exception
    {
        public ParamNumberInccorectException(string message)
            : base(message)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qx.Contents.Exceptions
{
    public class ParmFlagInccorectException :Exception
    {
        public ParmFlagInccorectException(string message)
            : base(message)
        {
        }
    }
}

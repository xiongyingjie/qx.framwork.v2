using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qx.Msg.Exceptions
{
    public class ErrorTimeMoreThan3Exception: Exception
    {
        public ErrorTimeMoreThan3Exception()
        {
        }

        public ErrorTimeMoreThan3Exception(string message) : base(message)
        {
        }
    }
}

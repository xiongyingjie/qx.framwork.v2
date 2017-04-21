using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qx.Permission.Exceptions
{
    public class ParamNotEnoughException : Exception
    {
        public ParamNotEnoughException(string message) : base(message)
        {
        }
    }
}

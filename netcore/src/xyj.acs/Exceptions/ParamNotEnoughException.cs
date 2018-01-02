using System;

namespace xyj.acs.Exceptions
{
    public class ParamNotEnoughException : Exception
    {
        public ParamNotEnoughException(string message) : base(message)
        {
        }
    }
}

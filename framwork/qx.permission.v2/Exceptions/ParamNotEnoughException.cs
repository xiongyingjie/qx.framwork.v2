using System;

namespace qx.permmision.v2.Exceptions
{
    public class ParamNotEnoughException : Exception
    {
        public ParamNotEnoughException(string message) : base(message)
        {
        }
    }
}

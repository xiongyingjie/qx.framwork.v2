using System;

namespace qx.permmision.v2.Exceptions
{
    public class MultipleOrganizationException : Exception
    {
        public MultipleOrganizationException(string message) : base(message)
        {
        }
    }
}

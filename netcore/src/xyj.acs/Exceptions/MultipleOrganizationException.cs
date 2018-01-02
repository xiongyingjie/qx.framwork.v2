using System;

namespace xyj.acs.Exceptions
{
    public class MultipleOrganizationException : Exception
    {
        public MultipleOrganizationException(string message) : base(message)
        {
        }
    }
}

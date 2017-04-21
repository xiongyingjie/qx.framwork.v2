using System;

namespace Qx.Contents.Exceptions
{
    public class GetLibraryFailException : Exception
    {
        public GetLibraryFailException(string message)
            : base(message)
        {
        }
    }
}

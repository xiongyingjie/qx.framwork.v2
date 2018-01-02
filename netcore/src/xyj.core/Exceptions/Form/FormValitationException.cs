using System.Collections.Generic;
using xyj.core.Extensions;

namespace xyj.core.Exceptions.Form
{
    public class FormValitationException : System.Exception
    {
        public List<DbValidationError> ValidationErrors;

        public FormValitationException() : this(null)
        {
        }

      

        public FormValitationException(List<DbValidationError> validationErrors)
        {
            throw new System.NotImplementedException();
        }
    }
}

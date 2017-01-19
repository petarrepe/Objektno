using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objektno.Framework
{
    class ValidationException : ApplicationException
    {
        public string PropertyName { get; set; }

        public ValidationException(string propertyName, string message) 
            : base(message)
        {
            PropertyName = propertyName;
        }

        public ValidationException(string propertyName, string message, Exception innerException)
            : base(message, innerException)
        {
            PropertyName = propertyName;
        }
    }
}

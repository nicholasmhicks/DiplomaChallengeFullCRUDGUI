using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudGUI
{
    public class ValidationFailureException : Exception
    {
        public ValidationFailureException()
        {
        }

        public ValidationFailureException(string message) : base (message)
        {
        }

        public ValidationFailureException(string message, Exception inner) :base (message, inner)
        {

        }
    }
}

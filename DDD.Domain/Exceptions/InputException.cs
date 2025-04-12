using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Exceptions
{
    public sealed class InputException : ExceptionBase
    {
        public InputException(string message) : base(message)
        {
            
        }

        public override ExceptionKind Kind => ExceptionKind.Info;
    }
}

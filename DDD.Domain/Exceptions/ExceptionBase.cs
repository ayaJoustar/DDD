using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Exceptions
{
    public abstract class ExceptionBase : Exception
    {
        public ExceptionBase(string message) : base(message)
        {
        }

        protected ExceptionBase(string message,Exception exception) : base(message, exception)
        {
                
        }

        public abstract ExceptionKind Kind { get; }
        public enum ExceptionKind 
        {
            Info,
            Warning,
            Error,
        }

    }
}

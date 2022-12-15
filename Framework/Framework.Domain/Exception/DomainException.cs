using System;

namespace Framework.Domain.Exception
{
    public class DomainException : ApplicationException
    {
        public DomainException()
        {
        }


        public DomainException(string message) : base(message)
        {
        }
    }
}
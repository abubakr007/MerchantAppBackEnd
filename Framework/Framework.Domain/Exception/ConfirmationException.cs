using System;

namespace Framework.Domain.Exception
{
    public class ConfirmationException : ApplicationException
    {
        public ConfirmationException()
        {
        }


        public ConfirmationException(string message) : base(message)
        {
        }
    }
}
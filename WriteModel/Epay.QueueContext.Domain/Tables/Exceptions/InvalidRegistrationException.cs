using Epay.QueueContext.Resources;
using Framework.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epay.QueueContext.Domain.Tables.Exceptions
{
    public class InvalidRegistrationException : DomainException
    {
        override public string Message => ExceptionResource.InvalidOpenPrice;
    }
}

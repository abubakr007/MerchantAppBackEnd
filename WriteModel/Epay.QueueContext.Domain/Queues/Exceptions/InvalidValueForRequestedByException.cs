using Epay.QueueContext.Resources;
using Framework.Domain.Exception;

namespace Epay.QueueContext.Domain.Queues.Exceptions
{
    public class InvalidValueForRequestedByException : DomainException
    {
        override public string Message => ExceptionResource.InvalidValueForRequestedBy;
    }
}

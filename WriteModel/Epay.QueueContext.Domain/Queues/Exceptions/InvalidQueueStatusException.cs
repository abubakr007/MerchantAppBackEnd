using Epay.QueueContext.Resources;
using Framework.Domain.Exception;

namespace Epay.QueueContext.Domain.Queues.Exceptions
{
    internal class InvalidQueueStatusException : DomainException
    {
        override public string Message => ExceptionResource.InvalidQueueStatus;
    }
}

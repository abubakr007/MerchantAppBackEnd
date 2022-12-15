using Epay.QueueContext.Resources;
using Framework.Domain.Exception;

namespace Epay.QueueContext.Domain.Queues.Exceptions
{
    internal class ApproveNoneCreatedQueueStatusException : DomainException
    {
        override public string Message => ExceptionResource.ApproveNoneCreatedQueueStatus;
    }
}

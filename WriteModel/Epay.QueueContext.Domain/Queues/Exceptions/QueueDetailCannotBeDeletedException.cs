using Epay.QueueContext.Resources;
using Framework.Domain.Exception;

namespace Epay.QueueContext.Domain.Queues.Exceptions
{
    public class QueueDetailCannotBeDeletedException : DomainException
    {
        override public string Message => ExceptionResource.QueueDetailCannotBeDeleted;
    }
}

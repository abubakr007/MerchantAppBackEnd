using Epay.QueueContext.Resources;
using Framework.Domain.Exception;

namespace Epay.QueueContext.Domain.Queues.Exceptions
{
    public class QueueDetailEmptyException: DomainException
    {
        override public string Message => ExceptionResource.QueueDetailEmpty;
    }
}

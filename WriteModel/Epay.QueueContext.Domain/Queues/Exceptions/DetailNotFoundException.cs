using Epay.QueueContext.Resources;
using Framework.Domain.Exception;

namespace Epay.QueueContext.Domain.Queues.Exceptions
{
    public class DetailNotFoundException : DomainException
    {
        override public string Message => ExceptionResource.DetailNotFound;
    }
}

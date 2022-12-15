using Epay.QueueContext.Resources;
using Framework.Domain.Exception;

namespace Epay.QueueContext.Domain.Queues.Exceptions
{
    public class QueueDetailsIsNullException : DomainException
    {
        override public string Message => ExceptionResource.QueueDetailsIsNull;
    }
}

using Epay.QueueContext.Resources;
using Framework.Domain.Exception;

namespace Epay.QueueContext.Domain.Queues.Exceptions
{
    public class InvalidQuantityException : DomainException
    {
        override public string Message => ExceptionResource.InvalidQuantity;
    }
}

using Epay.QueueContext.Resources;
using Framework.Domain.Exception;

namespace Epay.QueueContext.Domain.Queues.Exceptions
{
    public class InvalidOpenPriceException : DomainException
    {
        override public string Message => ExceptionResource.InvalidOpenPrice;
    }
}

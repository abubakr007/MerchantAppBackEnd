using Epay.QueueContext.Resources;
using Framework.Domain.Exception;

namespace Epay.QueueContext.Domain.Queues.Exceptions
{
    public class BothDiscountUsageException : DomainException
    {
        override public string Message => ExceptionResource.BothDiscountUsage;
    }
}

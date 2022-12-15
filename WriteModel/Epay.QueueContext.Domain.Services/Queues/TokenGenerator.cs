using Epay.QueueContext.Domain.Queues.Services;

namespace Epay.QueueContext.Domain.Services.Queues
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly IQueueRepository queueRepository;

        public TokenGenerator(IQueueRepository queueRepository)
        {
            this.queueRepository = queueRepository;
        }
        public long GetNewToken(int merchantId)
        {
            long latest = queueRepository.GetLatestToken(merchantId);
            return latest + 1;
        }
    }
}

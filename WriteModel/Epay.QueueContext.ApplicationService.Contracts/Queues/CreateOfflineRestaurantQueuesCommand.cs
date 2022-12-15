namespace Epay.QueueContext.ApplicationService.Contracts.Queues
{
    public class CreateOfflineRestaurantQueuesCommand : CreateOfflineGeneralQueuesCommand
    {
        public int TableId { get; set; }
        public string RequestedBy { get; set; }
    }
}

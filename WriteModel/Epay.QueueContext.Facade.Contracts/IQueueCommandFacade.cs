using Epay.QueueContext.ApplicationService.Contracts.Queues;
using Epay.QueueContext.Domain.Contracts.Events;

namespace Epay.QueueContext.Facade.Contracts
{
    public interface IQueueCommandFacade
    {

        QueueCreatedEvent CreateGeneralQueue(CreateGeneralQueueCommand command);
        QueueCreatedEvent CreateLaundaryQueue(CreateLaundaryQueueCommand command);
        QueueCreatedEvent CreateRestaurantQueue(CreateRestaurantQueueCommand command);
        QueueCreatedEvent CreateRestaurantQueueByCustomer(CreateRestaurantQueueByCustomerCommand command);
        QueueDetailDeletedEvent RemoveQueueDetail(DeleteDetailFromQueueMasterCommand command);
        QueueDetailAddedEvent AddDetailsToQueue(AddDetailToQueueMasterCommand command);

        QueueDetailDiscountAppliedEvent ApplyDiscount(QueueDetailSetDiscountCommand command);

        void CreateOfflineGeneralQueue(CreateOfflineGeneralQueuesCommand command);
        void CreateOfflineLaundaryQueue(CreateOfflineLaundaryQueuesCommand command);
        QueueCreatedEvent CreateOfflineRestaurantQueue(CreateOfflineRestaurantQueuesCommand command);
        QueueDeletedEvent DeleteQueue(DeleteQueueCommand command);
        QueueDetailEditedQuantityEvent EditQuantity(EditQueueDetailQuantityCommand command);

        

    }
}

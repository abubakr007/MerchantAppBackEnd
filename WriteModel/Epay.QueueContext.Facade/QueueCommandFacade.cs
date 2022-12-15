using Epay.QueueContext.ApplicationService.Contracts.Queues;
using Epay.QueueContext.Domain.Contracts.Events;
using Epay.QueueContext.Facade.Contracts;
using Framework.Core.Application;
using Framework.Core.Domain;
using Framework.Core.PushNotification;
using Framework.Facade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Epay.QueueContext.Facade
{
    [Route("/api/Queue/[action]")]
    [ApiController]
    [Authorize]
    public class QueueCommandFacade : FacadeCommandBase, IQueueCommandFacade
    {
        private readonly INotificationFactory notificationFactory;

        public QueueCommandFacade(ICommandBus commandBus, IEventBus eventBus, INotificationFactory notificationFactory) : base(commandBus, eventBus)
        {
            this.notificationFactory = notificationFactory;
        }
        [HttpPost]
        public QueueCreatedEvent CreateGeneralQueue(CreateGeneralQueueCommand command)
        {
            QueueCreatedEvent queueEvent = null;
            EventBus.Subscribe<QueueCreatedEvent>(a => queueEvent = a);
            EventBus.Subscribe<QueueCreatedByCatalogakEvent>(a => {
                var smartEmpaySender = notificationFactory.CreateNotificationSender(ApplicationName.SmartEpay);
                smartEmpaySender.SendToSubject(
                    a.MerchantCode + "_new_queue_cashier",
                    "Queue Created",
                    "New order has been received.", a);
            });
            CommandBus.Dispatch(command);
            return queueEvent;
        }

        [HttpPost]
        [AllowAnonymous]
        public QueueCreatedEvent CreateGeneralQueueByCustomer(CreateGeneralQueueByCustomerCommand command)
        {
            QueueCreatedEvent queueEvent = null;
            EventBus.Subscribe<QueueCreatedEvent>(a => queueEvent = a);
            EventBus.Subscribe<QueueCreatedByCatalogakEvent>(a => {
                var smartEmpaySender = notificationFactory.CreateNotificationSender(ApplicationName.SmartEpay);
                smartEmpaySender.SendToSubject(
                    a.MerchantCode + "_new_queue_cashier",
                    "Queue Created",
                    "New order has been received.", a);
            });
            CommandBus.Dispatch(command);
            return queueEvent;
        }

        [HttpPost]
        public QueueCreatedEvent CreateLaundaryQueue(CreateLaundaryQueueCommand command)
        {
            QueueCreatedEvent queueEvent = null;
            EventBus.Subscribe<QueueCreatedEvent>(a => queueEvent = a);
            CommandBus.Dispatch(command);
            return queueEvent;
        }
        [HttpPost]
        public QueueCreatedEvent CreateRestaurantQueue(CreateRestaurantQueueCommand command)
        {
            
            QueueCreatedEvent queueEvent = null;
            EventBus.Subscribe<QueueCreatedEvent>(a => queueEvent = a);
            EventBus.Subscribe<QueueCreatedByCashierEvent>(a => {
                var smartEmpaySender = notificationFactory.CreateNotificationSender(ApplicationName.SmartEpayQueue);
                smartEmpaySender.SendToSubject(
                    a.MerchantId + "_kitchen",
                    "Queue Created",
                    "New order has been received.", a);
            });
            EventBus.Subscribe<QueueCreatedByCatalogakEvent>(a => {
                var smartEmpaySender = notificationFactory.CreateNotificationSender(ApplicationName.SmartEpay);
                smartEmpaySender.SendToSubject(
                    a.MerchantCode + "_new_queue_cashier",
                    "Queue Created",
                    "New order has been received.", a);
            });
            CommandBus.Dispatch(command);
            return queueEvent;
        }

        [HttpPost]
        [AllowAnonymous]
        public QueueCreatedEvent CreateRestaurantQueueByCustomer(CreateRestaurantQueueByCustomerCommand command)
        {
            QueueCreatedEvent queueEvent = null;
            EventBus.Subscribe<QueueCreatedEvent>(a => queueEvent = a);
            EventBus.Subscribe<QueueCreatedByCashierEvent>(a => {
                var queueSender = notificationFactory.CreateNotificationSender(ApplicationName.SmartEpayQueue);
                queueSender.SendToSubject(a.MerchantId + "_kitchen",
                    "Queue Created",
                    "New order has been received.",
                    a);
            });
            EventBus.Subscribe<QueueCreatedByCatalogakEvent>(a => {
                var smartEmpaySender = notificationFactory.CreateNotificationSender(ApplicationName.SmartEpay);
                smartEmpaySender.SendToSubject(
                    a.MerchantCode + "_new_queue_cashier",
                    "Queue Created",
                    "New order has been received.", a);
            });

            CommandBus.Dispatch(command);
            return queueEvent;
        }


        [HttpPost]
        public QueueDetailDeletedEvent RemoveQueueDetail(DeleteDetailFromQueueMasterCommand command)
        {

            QueueDetailDeletedEvent queueDetailDeletedEvent = null;
 
            EventBus.Subscribe<QueueDetailDeletedEvent>(a => queueDetailDeletedEvent = a);
            CommandBus.Dispatch(command);

            var queueSender = notificationFactory.CreateNotificationSender(ApplicationName.SmartEpayQueue);
            queueSender.SendToSubject(queueDetailDeletedEvent.MerchantId + "_kitchen",
                "Queue Detail Removed",
                "Queue Detail has been Removed.",
                queueDetailDeletedEvent);
            return queueDetailDeletedEvent;


        }
        [HttpPost]
        public QueueDetailAddedEvent AddDetailsToQueue(AddDetailToQueueMasterCommand command)
        {

            QueueDetailAddedEvent queueDetailAddedEvent = null;

            EventBus.Subscribe<QueueDetailAddedEvent>(a => queueDetailAddedEvent = a);
            CommandBus.Dispatch(command);

            var queueSender = notificationFactory.CreateNotificationSender(ApplicationName.SmartEpayQueue);
            queueSender.SendToSubject(queueDetailAddedEvent.MerchantId + "_kitchen",
               "New Detail Added",
               "The new detail has been added",
               queueDetailAddedEvent);

            return queueDetailAddedEvent;

        }

        [HttpPost]
        public void CreateOfflineGeneralQueue(CreateOfflineGeneralQueuesCommand command)
        {
            CommandBus.Dispatch(command);
        }

        [HttpPost]
        public void CreateOfflineLaundaryQueue(CreateOfflineLaundaryQueuesCommand command)
        {
            CommandBus.Dispatch(command);
        }

        [HttpPost]
        public QueueCreatedEvent CreateOfflineRestaurantQueue(CreateOfflineRestaurantQueuesCommand command)
        {
            QueueCreatedEvent queueEvent = null;
            EventBus.Subscribe<QueueCreatedEvent>(a => queueEvent = a);
            EventBus.Subscribe<QueueCreatedByCashierEvent>(a =>
            {
                var queueSender = notificationFactory.CreateNotificationSender(ApplicationName.SmartEpayQueue);
                queueSender.SendToSubject(a.MerchantId + "_kitchen",
                    "Queue Created",
                    "New order has been received.",
                    a);
            });
            EventBus.Subscribe<QueueCreatedByCatalogakEvent>(a => {
                var smartEmpaySender = notificationFactory.CreateNotificationSender(ApplicationName.SmartEpay);
                smartEmpaySender.SendToSubject(
                    a.MerchantCode + "_new_queue_cashier",
                    "Queue Created",
                    "New order has been received.", a);
            });
            CommandBus.Dispatch(command);
            return queueEvent;
        }

        [HttpPost]
        public QueueDeletedEvent DeleteQueue(DeleteQueueCommand command)
        {
            QueueDeletedEvent queueDeletedEvent = null;
           
            EventBus.Subscribe<QueueDeletedEvent>(a => queueDeletedEvent = a);


            CommandBus.Dispatch(command);


            var queueSender = notificationFactory.CreateNotificationSender(ApplicationName.SmartEpayQueue);

            queueSender.SendToSubject(queueDeletedEvent.MerchantId + "_kitchen",

                "Queue Deleted",
                "The order has been removed",
                queueDeletedEvent) ;
            return queueDeletedEvent;





        }
        [HttpPost]
        public QueueDetailEditedQuantityEvent EditQuantity(EditQueueDetailQuantityCommand command)
        {
            QueueDetailEditedQuantityEvent queueDetailEditedQuantityEvent = null;

            EventBus.Subscribe<QueueDetailEditedQuantityEvent>(a => queueDetailEditedQuantityEvent = a);

            CommandBus.Dispatch(command);
            var queueSender = notificationFactory.CreateNotificationSender(ApplicationName.SmartEpayQueue);

            queueSender.SendToSubject(queueDetailEditedQuantityEvent.MerchantId + "_kitchen",
                "Quantity Edited",
                "The Quantity has been Changed",
                queueDetailEditedQuantityEvent);

            return queueDetailEditedQuantityEvent;
        }
        [HttpPost]
        public QueueDetailDiscountAppliedEvent ApplyDiscount(QueueDetailSetDiscountCommand command)
        {
            QueueDetailDiscountAppliedEvent queueDetailDiscountAppliedEvent = null;
            EventBus.Subscribe<QueueDetailDiscountAppliedEvent>(a => queueDetailDiscountAppliedEvent = a);

            CommandBus.Dispatch(command);
            return queueDetailDiscountAppliedEvent!;
        }

        [HttpPost]
        public void SetNextQueueStatus(SetQueueNextStatusCommand command)
        {
            CommandBus.Dispatch(command);
        }

        [HttpPost]
        public void ChangeQueueStatus(ChangeQueueStatusCommand command)
        {
            CommandBus.Dispatch(command);
        }
        [HttpPost]
        public ApproveRestaurntQueueEvent ApproveRestaurntQueue(ApproveRestaurntQueueCommand command)
        {
            ApproveRestaurntQueueEvent approveQueueEvent = null;
            EventBus.Subscribe<ApproveRestaurntQueueEvent>(a => approveQueueEvent = a);


           
            CommandBus.Dispatch(command);
            var queueSender = notificationFactory.CreateNotificationSender(ApplicationName.SmartEpayQueue);

                queueSender.SendToSubject(approveQueueEvent.MerchantId + "_kitchen",
                    "Queue Approved",
                    "Queue has been Approved.",
                    approveQueueEvent);
        

            return approveQueueEvent;
        }
    }
}

using Epay.Constants;
using Epay.QueueContext.Domain.Acl;
using Epay.QueueContext.Domain.Contracts.Events;
using Epay.QueueContext.Domain.Queues;
using Epay.QueueContext.Domain.Queues.Services;
using Framework.Core.Application;
using Framework.Core.Domain;
using Framework.Core.Mapper;
using Framework.Core.Persistence;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace Epay.QueueContext.ApplicationService.Contracts.Queues
{
    public class CreateRestaurantQueueByCustomerCommandHandler : ICommandHandler<CreateRestaurantQueueByCustomerCommand>
    {
        private readonly IQueueRepository queueRepository;
        private readonly IEntityIdGenerator<QueueMaster> entityIdGenerator;
        private readonly IEntityIdGenerator<QueueDetail> detailIdGenerator;
        private readonly IMerchantSettingAccessor merchantSettingAccessor;
        private readonly ISmartCardDiscountGetter smartCardDiscountGetter;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ITokenGenerator tokenGenerator;
        private readonly IProductAcl productAcl;
        private readonly IMerchantAcl merchantAcl;
        private readonly IDbContext dbContext;
        private readonly IEventBus eventBus;
        private readonly IMapper mapper;
        public CreateRestaurantQueueByCustomerCommandHandler(
            IQueueRepository queueRepository,
            IEntityIdGenerator<QueueMaster> entityIdGenerator,
            IEntityIdGenerator<QueueDetail> detailIdGenerator,
            IMerchantSettingAccessor merchantSettingAccessor,
            ISmartCardDiscountGetter smartCardDiscountGetter,
            IHttpContextAccessor httpContextAccessor,
            ITokenGenerator tokenGenerator,
            IProductAcl productAcl,
            IMerchantAcl merchantAcl,
            IDbContext dbContext,
            IEventBus eventBus,
            IMapper mapper)
        {
            this.queueRepository = queueRepository;
            this.entityIdGenerator = entityIdGenerator;
            this.detailIdGenerator = detailIdGenerator;
            this.merchantSettingAccessor = merchantSettingAccessor;
            this.smartCardDiscountGetter = smartCardDiscountGetter;
            this.httpContextAccessor = httpContextAccessor;
            this.tokenGenerator = tokenGenerator;
            this.productAcl = productAcl;
            this.merchantAcl = merchantAcl;
            this.dbContext = dbContext;
            this.eventBus = eventBus;
            this.mapper = mapper;
        }
        public void Execute(CreateRestaurantQueueByCustomerCommand command)
        {
            var productsPrice = productAcl.GetProductsPriceAndTaxForMerchant(command.Details.Select(x => x.ProductId).ToList(), command.MerchantId);
            var merchantCode = merchantAcl.GetMerchantCodeById(command.MerchantId);

            var details = new List<QueueDetail>();
            var cardDiscount = smartCardDiscountGetter.GetDiscount(command.NfcCardNumber, merchantCode);
            foreach (var item in command.Details)
            {
                var product = productsPrice.SingleOrDefault(x => x.Id == item.ProductId);
                var detail = new QueueDetail(detailIdGenerator, merchantSettingAccessor, item.ProductId, product?.Tax, item.Quantity, item.Discount, cardDiscount, item.OpenPrice, command.MerchantId, null, null, item.WorkerId, product?.Price);
                details.Add(detail);
            }
            var queue = QueueMaster.CreateRestaurantQueue(
                entityIdGenerator,
                tokenGenerator,
                merchantSettingAccessor,
                command.MerchantId,
                null,
                null,
                command.IsPaid,
                details,
                command.PhoneNumber,
                command.Param1,
                command.Param2,
                command.Param3,
                command.CouponCode,
                command.NfcCardNumber,
                command.CustomerId,
                command.TableId,
                command.RequestedBy);
            queueRepository.Create(queue);

            dbContext.SaveChanges();

            var eventNotificationToKitchen = GetRestaurantQueueCreateEvent(queue);
            eventBus.Publish(new QueueCreatedEvent() { TokenNumber = queue.TokenNumber, Id = queue.Id, Detail = eventNotificationToKitchen.QueueDetails });

            if (queue.RequestedBy != RestaurantRequestedBy.Cashier)
                eventBus.Publish(mapper.Map<QueueCreatedByCatalogakEvent, QueueCreatedByCashierEvent>(eventNotificationToKitchen));

            if (queue.QueueStatusId == (int)RestaurantQueuesStatuses.Approved)
                eventBus.Publish(eventNotificationToKitchen);

        }

        private QueueCreatedByCashierEvent GetRestaurantQueueCreateEvent(QueueMaster queue)
        {
            var restaurantQueue = mapper.Map<QueueCreatedByCashierEvent, QueueMaster>(queue);
            restaurantQueue.MerchantCode = merchantAcl.GetMerchantCodeById(queue.MerchantId);
            restaurantQueue.TableId = queue.QueueRestaurant.TableId;
            var productIds = restaurantQueue.QueueDetails.Select(x => x.ProductId).ToList();
            var names = productAcl.GetProductName(productIds);

            foreach (var item in restaurantQueue.QueueDetails)
            {
                item.ProductName = names.Single(x => x.Id == item.ProductId).Name;
            }
            return restaurantQueue;
        }
    }
}

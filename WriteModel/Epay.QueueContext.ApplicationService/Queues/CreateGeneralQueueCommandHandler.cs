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
    public class CreateGeneralQueueCommandHandler : ICommandHandler<CreateGeneralQueueCommand>
    {
        private readonly IQueueRepository queueRepository;
        private readonly IEntityIdGenerator<QueueMaster> entityIdGenerator;
        private readonly IEntityIdGenerator<QueueDetail> detailIdGenerator;
        IMerchantSettingAccessor merchantSettingAccessor;
        private readonly ISmartCardDiscountGetter smartCardDiscountGetter;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IProductAcl productAcl;
        private readonly ITokenGenerator tokenGenerator;
        private readonly IDbContext db;
        private readonly IMapper mapper;
        private readonly IEventBus eventBus;

        public CreateGeneralQueueCommandHandler(
            IQueueRepository queueRepository,
            IEntityIdGenerator<QueueMaster> entityIdGenerator,
            IEntityIdGenerator<QueueDetail> detailIdGenerator,
            IMerchantSettingAccessor merchantSettingAccessor,
            ISmartCardDiscountGetter smartCardDiscountGetter,
            IHttpContextAccessor httpContextAccessor,
            IProductAcl productAcl,
            ITokenGenerator tokenGenerator,
            IDbContext db,
            IMapper mapper,
            IEventBus eventBus)
        {
            this.queueRepository = queueRepository;
            this.entityIdGenerator = entityIdGenerator;
            this.detailIdGenerator = detailIdGenerator;
            this.merchantSettingAccessor = merchantSettingAccessor;
            this.smartCardDiscountGetter = smartCardDiscountGetter;
            this.httpContextAccessor = httpContextAccessor;
            this.productAcl = productAcl;
            this.tokenGenerator = tokenGenerator;
            this.db = db;
            this.mapper = mapper;
            this.eventBus = eventBus;
        }
        public void Execute(CreateGeneralQueueCommand command)
        {
            var userId = int.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ApplicationClaims.Cashier)?.Value ?? "0");
            var merchantId = int.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ApplicationClaims.MerchantId)?.Value ?? "0");
            var merchantCode = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ApplicationClaims.MerchantCode)?.Value;


            var productsPriceWitTax = productAcl.GetProductsPriceAndTaxForMerchant(command.Details.Select(x => x.ProductId).ToList(), merchantId);

            var details = new List<QueueDetail>();
            var cardDiscount = smartCardDiscountGetter.GetDiscount(command.NfcCardNumber, merchantCode!);
            foreach (var item in command.Details)
            {
                var product = productsPriceWitTax.SingleOrDefault(x => x.Id == item.ProductId);
                var detail = new QueueDetail(detailIdGenerator, merchantSettingAccessor, item.ProductId, product?.Tax, item.Quantity, item.Discount, cardDiscount, item.OpenPrice, merchantId, item.IsHang, userId, item.WorkerId, product?.Price);
                details.Add(detail);
            }
            var queue = QueueMaster.CreateGeneralQueue(
                entityIdGenerator,
                tokenGenerator,
                merchantId,
                userId,
                userId,
                details,
                command.PhoneNumber,
                command.Param1,
                command.Param2,
                command.Param3,
                command.CouponCode,
                command.NfcCardNumber,
                command.CustomerId,
                command.RequestedBy);
            queueRepository.Create(queue);
            db.SaveChanges();

            var eventNotificationToCashier = GetGeneralQueueCreateEvent(queue, merchantCode!);
            eventBus.Publish(new QueueCreatedEvent() { TokenNumber = queue.TokenNumber, Id = queue.Id, Detail = eventNotificationToCashier.QueueDetails });

            if (queue.RequestedBy != GeneralRequestedBy.Cashier)
                eventBus.Publish(eventNotificationToCashier);

            eventBus.Publish(new QueueCreatedEvent() { TokenNumber = queue.TokenNumber, Id = queue.Id });
        }


        private QueueCreatedByCatalogakEvent GetGeneralQueueCreateEvent(QueueMaster queue, string merchantCode)
        {
            var restaurantQueue = mapper.Map<QueueCreatedByCatalogakEvent, QueueMaster>(queue);
            restaurantQueue.MerchantCode = merchantCode;
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

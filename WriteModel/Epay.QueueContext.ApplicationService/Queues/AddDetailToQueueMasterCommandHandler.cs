using Epay.Constants;
using Epay.QueueContext.ApplicationService.Contracts.Queues;
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

namespace Epay.QueueContext.ApplicationService.Queues
{
    public class AddDetailToQueueMasterCommandHandler : ICommandHandler<AddDetailToQueueMasterCommand>
    {
        private readonly IQueueRepository queueRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMerchantSettingAccessor merchantSettingAccessor;
        private readonly IProductAcl productAcl;
        private readonly IEntityIdGenerator<QueueDetail> idGenerator;
        private readonly ISmartCardDiscountGetter smartCardDiscountGetter;
        private readonly IEventBus eventBus;
        private readonly IMapper mapper;

        public AddDetailToQueueMasterCommandHandler(
            IQueueRepository queueRepository,
            IHttpContextAccessor httpContextAccessor,
            IMerchantSettingAccessor merchantSettingAccessor,
            IProductAcl productAcl,
            IEntityIdGenerator<QueueDetail> idGenerator,
            ISmartCardDiscountGetter smartCardDiscountGetter,
            IEventBus eventBus,
            IMapper mapper)
        {
            this.queueRepository = queueRepository;
            this.httpContextAccessor = httpContextAccessor;
            this.merchantSettingAccessor = merchantSettingAccessor;
            this.productAcl = productAcl;
            this.idGenerator = idGenerator;
            this.smartCardDiscountGetter = smartCardDiscountGetter;
            this.eventBus = eventBus;
            this.mapper = mapper;
        }
        public void Execute(AddDetailToQueueMasterCommand command)
        {
            var userId = int.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ApplicationClaims.Cashier)?.Value ?? "0");
            var merchantId = int.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ApplicationClaims.MerchantId)?.Value ?? "0");

            var merchantCode = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ApplicationClaims.MerchantCode)?.Value;

            var productsPrice = productAcl.GetProductsPriceAndTaxForMerchant(command.DetailsForQueueMaster.Select(x => x.ProductId).ToList(), merchantId);


            var queue = queueRepository.GetQueueMasterById(command.QueueMasterId);

            var details = new List<QueueDetail>();
            var cardDiscount = smartCardDiscountGetter.GetDiscount(queue.NfccardNumber, merchantCode!);
            foreach (var item in command.DetailsForQueueMaster)
            {
                var product = productsPrice.SingleOrDefault(x => x.Id == item.ProductId);
                details.Add(new QueueDetail(idGenerator, merchantSettingAccessor, item.ProductId, product?.Tax, item.Quantity, item.Discount, cardDiscount, item.OpenPrice, merchantId, item.IsHang, userId, item.WorkerId, product?.Price));
            }
            queue.AddDetails(details);
            queueRepository.UpdateQueue(queue);
            details.ForEach(x => x.QueueMasterId = command.QueueMasterId);
            queueRepository.InsertDetails(details);

            eventBus.Publish(new QueueDetailAddedEvent
            {
                MerchantId = queue.MerchantId,
                QueueMasterId = command.QueueMasterId,
                TotalAmount = command.TotalAmount,
                QueueDetails = mapper.Map<QueueDetailEvent, QueueDetail>(details)

            });

        }


    }
}

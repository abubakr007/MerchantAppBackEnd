using Epay.Constants;
using Epay.QueueContext.ApplicationService.Contracts.Queues;
using Epay.QueueContext.Domain.Acl;
using Epay.QueueContext.Domain.Contracts.Events;
using Epay.QueueContext.Domain.Queues;
using Epay.QueueContext.Domain.Queues.Services;
using Framework.Core.Application;
using Framework.Core.Domain;
using Framework.Core.Mapper;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace Epay.QueueContext.ApplicationService.Queues
{
    public class QueueDetailSetDiscountCommandHandler : ICommandHandler<QueueDetailSetDiscountCommand>
    {
        private readonly IQueueRepository queueRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMerchantSettingAccessor merchantSetting;
        private readonly IProductAcl productAcl;
        private readonly IMapper mapper;
        private readonly IEventBus eventBus;

        
        public QueueDetailSetDiscountCommandHandler(
            IQueueRepository queueRepository,
            IHttpContextAccessor httpContextAccessor,
            IMerchantSettingAccessor merchantSetting,
            IProductAcl productAcl,
            IMapper mapper,
            IEventBus eventBus)
        {
            this.queueRepository = queueRepository;
            this.httpContextAccessor = httpContextAccessor;
            this.merchantSetting = merchantSetting;
            this.productAcl = productAcl;
            this.mapper = mapper;
            this.eventBus = eventBus;
        }
        public void Execute(QueueDetailSetDiscountCommand command)
        {
            var userId = int.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ApplicationClaims.Cashier)?.Value ?? "0");
            var queue = queueRepository.GetQueueMasterById(command.QueueMasterId);
            var productId = queue.QueueDetails.Single(x => x.Id == command.DetailId).ProductId;

            var productsPrice = productAcl.GetProductsPriceAndTaxForMerchant(new List<int> {productId }, queue.MerchantId);


            queue.ApplyDiscountToDetail(command.DetailId, command.DiscountAmount, productsPrice.Single().Tax, merchantSetting);
            queueRepository.UpdateQueue(queue);
            queueRepository.UpdateQueueDetail(queue.QueueDetails.Single(x => x.Id == command.DetailId));
            eventBus.Publish(mapper.Map<QueueDetailDiscountAppliedEvent,QueueDetail>(queue.QueueDetails.Single(x => x.Id == command.DetailId)));

        }
    }
}

using Epay.Constants;
using Epay.QueueContext.ApplicationService.Contracts.Queues;
using Epay.QueueContext.Domain.Acl;
using Epay.QueueContext.Domain.Queues;
using Epay.QueueContext.Domain.Queues.Services;
using Framework.Core.Application;
using Framework.Core.Persistence;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace Epay.QueueContext.ApplicationService.Queues
{
    public class CreateOfflineLaundaryQueuesCommandHandler : ICommandHandler<CreateOfflineLaundaryQueuesCommand>
    {
        private readonly IQueueRepository queueRepository;
        private readonly IEntityIdGenerator<QueueMaster> entityIdGenerator;
        private readonly IEntityIdGenerator<QueueDetail> detailIdGenerator;
        private readonly IMerchantSettingAccessor merchantSettingAccessor;
        private readonly IProductAcl productAcl;
        private readonly IHttpContextAccessor httpContextAccessor;

        public CreateOfflineLaundaryQueuesCommandHandler(
            IQueueRepository queueRepository,
            IEntityIdGenerator<QueueMaster> entityIdGenerator,
            IEntityIdGenerator<QueueDetail> detailIdGenerator,
            IMerchantSettingAccessor merchantSettingAccessor,
            IProductAcl productAcl,
            IHttpContextAccessor httpContextAccessor)
        {
            this.queueRepository = queueRepository;
            this.entityIdGenerator = entityIdGenerator;
            this.detailIdGenerator = detailIdGenerator;
            this.merchantSettingAccessor = merchantSettingAccessor;
            this.productAcl = productAcl;
            this.httpContextAccessor = httpContextAccessor;
        }
        public void Execute(CreateOfflineLaundaryQueuesCommand command)
        {
            var userId = int.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ApplicationClaims.Cashier)?.Value ?? "0");

            var merchantId = int.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ApplicationClaims.MerchantId)?.Value ?? "0");

            var productsPriceWitTax = productAcl.GetProductsPriceAndTaxForMerchant(command.Details.Select(x => x.ProductId).ToList(), merchantId);

            var details = new List<QueueDetail>();
            foreach (var item in command.Details)
            {
                var product = productsPriceWitTax.SingleOrDefault(x => x.Id == item.ProductId);
                var detail = new QueueDetail(detailIdGenerator, merchantSettingAccessor, item.ProductId, product?.Tax, item.Quantity, item.Discount, null, item.OpenPrice, merchantId, item.IsHang, userId, item.WorkerId, product?.Price);
                details.Add(detail);
            }
            QueueMaster queue = QueueMaster.CreateLaundaryQueue(
                entityIdGenerator,
                command.OfflineTokenNumber,
                command.MerchantId,
                userId,
                userId,
                command.TotalAmount,
                details,
                command.PhoneNumber,
                command.Param1,
                command.Param2,
                command.Param3,
                command.CouponCode,
                command.NfcCardNumber,
                command.CustomerId,
                command.FromAddress,
                command.ToAddress,
                command.IsOnlinePayment);
            queueRepository.Create(queue);
        }
    }
}

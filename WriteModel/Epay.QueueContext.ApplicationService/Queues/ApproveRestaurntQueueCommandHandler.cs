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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epay.QueueContext.ApplicationService.Queues
{
    public class ApproveRestaurntQueueCommandHandler :ICommandHandler<ApproveRestaurntQueueCommand>
    {
        private readonly IQueueRepository queueRepository;
        private readonly IDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IEventBus eventBus;
        private readonly IProductAcl productAcl;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ApproveRestaurntQueueCommandHandler(IQueueRepository queueRepository , IDbContext dbContext,IMapper mapper,  IEventBus eventBus,
            IProductAcl productAcl, IHttpContextAccessor httpContextAccessor)
        {
            this.queueRepository = queueRepository;
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.eventBus = eventBus;
            this.productAcl = productAcl;
            this.httpContextAccessor = httpContextAccessor;
        }

        public void Execute(ApproveRestaurntQueueCommand command)
        {
            var queue = queueRepository.GetQueueMasterById(command.QueueId);
            
            var curentStatusId = queue.QueueStatusId;
            queue.ApproveRestaurntQueue(curentStatusId);
            queue.MobileNumber = command.MobileNumber??queue.MobileNumber;
            queue.Param1 = command.Param1 ?? queue.Param1;
            queue.Param2 = command.Param2 ?? queue.Param2;
            queue.Param3 = command.Param3 ?? queue.Param3;
            queueRepository.UpdateQueue(queue);
            dbContext.SaveChanges();

            var merchantCode = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ApplicationClaims.MerchantCode)?.Value;

            var approvedQueue = mapper.Map<ApproveRestaurntQueueEvent, QueueMaster>(queue);
            approvedQueue.MerchantCode = merchantCode;
            approvedQueue.TableId = queue.QueueRestaurant.TableId;
            var productIds = approvedQueue.QueueDetails.Select(x => x.ProductId).ToList();

            var names = productAcl.GetProductName(productIds);

            foreach (var item in approvedQueue.QueueDetails)
            {
                item.ProductName = names.Single(x => x.Id == item.ProductId).Name;
            }
            

            eventBus.Publish(approvedQueue);
        }
    }
}

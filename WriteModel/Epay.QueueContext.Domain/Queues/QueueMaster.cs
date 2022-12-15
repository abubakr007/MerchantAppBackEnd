using Epay.Constants;
using Epay.QueueContext.Domain.Queues.Exceptions;
using Epay.QueueContext.Domain.Queues.Services;
using Framework.Core.Persistence;
using Framework.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;

namespace Epay.QueueContext.Domain.Queues
{
    public class QueueMaster : EntityBase<QueueMaster>
    {

        public QueueMaster() { }
        private QueueMaster(IEntityIdGenerator<QueueMaster> idGenerator, ITokenGenerator tokenGenerator, int merchantId, int? createdBy, int? cashierId, IList<QueueDetail> details, string phoneNumber, string? param1, string? param2, string? param3, string? couponCode, string? nfcCardNumber, int? customerId) : base(idGenerator)
        {
            TokenNumber = tokenGenerator.GetNewToken(merchantId);
            MerchantId = merchantId;
            CreatedBy = createdBy;
            CashierId = cashierId;
            CustomerId = customerId;
            CouponCode = couponCode;
            NfccardNumber = nfcCardNumber;
            MobileNumber = phoneNumber;
            OpeningTime = DateTime.Now;
            ApprovedDateTime = DateTime.Now;
            CreatedOn = DateTime.Now;
            SetParams(param1, param2, param3);
            AddDetails(details);
            SetId();

        }

        private QueueMaster(IEntityIdGenerator<QueueMaster> entityIdGenerator, int offlineTokenNumber, int merchantId, int createdBy, int cashierId, IList<QueueDetail> details, double totalAmount, string phoneNumber, string? param1, string? param2, string? param3, string? couponCode, string? nfcCardNumber, int? customerId) : base(entityIdGenerator)
        {
            TokenNumber = offlineTokenNumber;
            MerchantId = merchantId;
            CreatedBy = createdBy;
            CashierId = cashierId;
            CustomerId = customerId;
            CouponCode = couponCode;
            NfccardNumber = nfcCardNumber;
            MobileNumber = phoneNumber;
            OpeningTime = DateTime.Now;
            CreatedOn = DateTime.Now;
            SetParams(param1, param2, param3);
            AddDetails(details);
            SetId();
        }


        public static QueueMaster CreateRestaurantQueue(IEntityIdGenerator<QueueMaster> idGenerator, ITokenGenerator tokenGenerator, IMerchantSettingAccessor setting, int merchantId, int? createdBy, int? cashierId, bool isPaid, IList<QueueDetail> details, string phoneNumber, string? param1, string? param2, string? param3, string? couponCode, string? nfcCardNumber, int? customerId, int? tableId, string requestedBy)
        {
            var queue = new QueueMaster(idGenerator, tokenGenerator, merchantId, createdBy, cashierId, details, phoneNumber,
             param1, param2, param3, couponCode, nfcCardNumber, customerId);
            queue.SetRestaurant(tableId);
            queue.IsPaid = isPaid;
            queue.SetRestaurantRequestedBy(requestedBy);
            queue.SetRestaurantStatusOnCreate(requestedBy, setting, merchantId, tableId == null);

            return queue;
        }

        public static QueueMaster CreateRestaurantQueue(IEntityIdGenerator<QueueMaster> idGenerator, IMerchantSettingAccessor setting, int offlineTokenNumber, int merchantId, int createdBy, int cashierId, double totalAmount, IList<QueueDetail> details, string phoneNumber, string? param1, string? param2, string? param3, string? couponCode, string? nfcCardNumber, int? customerId, int? tableId, string requestedBy)
        {
            var queue = new QueueMaster(idGenerator, offlineTokenNumber, merchantId, createdBy, cashierId, details, totalAmount, phoneNumber,
             param1, param2, param3, couponCode, nfcCardNumber, customerId);
            queue.SetRestaurant(tableId);
            queue.SetRestaurantRequestedBy(requestedBy);
            queue.SetRestaurantStatusOnCreate(requestedBy, setting, merchantId, tableId == null);

            return queue;
        }


        public static QueueMaster CreateGeneralQueue(IEntityIdGenerator<QueueMaster> idGenerator, ITokenGenerator tokenGenerator, int merchantId, int? createdBy, int? cashierId, IList<QueueDetail> details, string phoneNumber, string? param1, string? param2, string? param3, string? couponCode, string? nfcCardNumber, int? customerId, string requestedBy)
        {
            var queue = new QueueMaster(idGenerator, tokenGenerator, merchantId, createdBy, cashierId, details, phoneNumber,
             param1, param2, param3, couponCode, nfcCardNumber, customerId);
            queue.SetGeneralStatusOnCreate();
            queue.SetGeneralRequestedBy(requestedBy);
            return queue;
        }

        public static QueueMaster CreateGeneralQueue(IEntityIdGenerator<QueueMaster> idGenerator, int offlineTokenNumber, int merchantId, int createdBy, int cashierId, double totalAmount, List<QueueDetail> details, string phoneNumber, string? param1, string? param2, string? param3, string? couponCode, string? nfcCardNumber, int? customerId, string requestedBy)
        {
            var queue = new QueueMaster(idGenerator, offlineTokenNumber, merchantId, createdBy, cashierId, details, totalAmount, phoneNumber,
             param1, param2, param3, couponCode, nfcCardNumber, customerId);
            queue.SetGeneralStatusOnCreate();
            queue.SetGeneralRequestedBy(requestedBy);
            return queue;
        }


        public static QueueMaster CreateLaundaryQueue(IEntityIdGenerator<QueueMaster> idGenerator, ITokenGenerator tokenGenerator, int merchantId, int createdBy, int cashierId, double totalAmount, IList<QueueDetail> details, string phoneNumber,
            string? param1, string? param2, string? param3, string? couponCode, string? nfcCardNumber, int? customerId, string? fromAddress, string? toAddress, bool isOnlinePayment)
        {
            var queue = new QueueMaster(idGenerator, tokenGenerator, merchantId, createdBy, cashierId, details, phoneNumber,
             param1, param2, param3, couponCode, nfcCardNumber, customerId);
            queue.SetLaundary(fromAddress, toAddress, isOnlinePayment);
            queue.SetLaundaryStatusOnCreate();
            return queue;
        }

        public static QueueMaster CreateLaundaryQueue(IEntityIdGenerator<QueueMaster> idGenerator, int offlineTokenNumber, int merchantId, int createdBy, int cashierId, double totalAmount, List<QueueDetail> details, string phoneNumber, string? param1, string? param2, string? param3, string? couponCode, string? nfcCardNumber, int? customerId, string? fromAddress, string? toAddress, bool isOnlinePayment)
        {
            var queue = new QueueMaster(idGenerator, offlineTokenNumber, merchantId, createdBy, cashierId, details, totalAmount, phoneNumber,
             param1, param2, param3, couponCode, nfcCardNumber, customerId);
            queue.SetLaundary(fromAddress, toAddress, isOnlinePayment);
            queue.SetLaundaryStatusOnCreate();
            return queue;
        }

        public void SetStatus(int statusId)
        {
            if (statusId == 0)
                throw new InvalidQueueStatusException();
            QueueStatusId = statusId;
        }
        private void SetRestaurantStatusOnCreate(string requestedBy, IMerchantSettingAccessor setting, int merchantId, bool isOutsideCustomer)
        {
            QueueStatusId = (int)RestaurantQueuesStatuses.Created;

            if (requestedBy == RestaurantRequestedBy.Cashier)
                QueueStatusId = (int)RestaurantQueuesStatuses.Approved;

            else if (requestedBy == RestaurantRequestedBy.Customer && !isOutsideCustomer && !setting.IsApprovalNeededForInsideCustomerQueue(merchantId))
                QueueStatusId = (int)RestaurantQueuesStatuses.Approved;

            else if (requestedBy == RestaurantRequestedBy.Customer && isOutsideCustomer && !setting.IsApprovalNeededForOutsideCustomerQueue(merchantId))
                QueueStatusId = (int)RestaurantQueuesStatuses.Approved;

            else if (requestedBy == RestaurantRequestedBy.Waiter && !setting.IsApprovalNeededForWaiterQueue(merchantId))
                QueueStatusId = (int)RestaurantQueuesStatuses.Approved;

        }
        public void SetLaundaryStatusOnCreate()
        {
            QueueStatusId = (int)LaundryQueuesStatuses.Created;
        }
        private void SetGeneralStatusOnCreate()
        {
            QueueStatusId = (int)CarWashQueuesStatuses.Created;
        }
        public void ApproveRestaurntQueue(int currentstatusId)
        {
            if (currentstatusId != (int)RestaurantQueuesStatuses.Created)
                throw new ApproveNoneCreatedQueueStatusException();
            QueueStatusId = (int)RestaurantQueuesStatuses.Approved;
            ApprovedDateTime = DateTime.Now;

        }
        
        private void SetGeneralRequestedBy(string requestedBy)
        {
            var value = requestedBy.ToLower();

            if (value != GeneralRequestedBy.Cashier &&
                value != GeneralRequestedBy.Catalogak &&
                value != GeneralRequestedBy.Customer)
                    throw new InvalidValueForRequestedByException();
            RequestedBy = value;

        }

        private void SetRestaurantRequestedBy(string requestedBy)
        {
            var value = requestedBy.ToLower();

            if (value == RestaurantRequestedBy.Cashier ||
                value == RestaurantRequestedBy.Catalogak ||
                value == RestaurantRequestedBy.Customer ||
                value == RestaurantRequestedBy.Waiter)
                RequestedBy = value;
            else
                throw new InvalidValueForRequestedByException();
        }

        
        public void AddDetails(IList<QueueDetail> details)
        {

            if (details == null || details.Count == 0)
                throw new QueueDetailsIsNullException();
            if (QueueDetails.Count > 0)
                ValidateForEdit();
            details.ToList().ForEach(x => QueueDetails.Add(x));
            CalCulateTotalAmountAndTax();
        }
        public void RemoveDetail(long detailId)
        {
            ValidateForEdit();
            var detail = QueueDetails.SingleOrDefault(x => x.Id == detailId);
            if (detail == null)
            {
                throw new DetailNotFoundException();
            }
            detail.IsDeleted = true;

            if (IsQueueDetailEmpty())
            {
                throw new QueueDetailCannotBeDeletedException();
            }
            CalCulateTotalAmountAndTax();
        }
        public void UpdateDetailCount(long detailId, double quantity)
        {
            ValidateForEdit();
            var detail = QueueDetails.Single(x => x.Id == detailId);
            detail.UpdateQuantity(quantity);
            
            CalCulateTotalAmountAndTax();
        }

        public void ApplyDiscountToDetail(long detailId, double discountAmount, double productTax, IMerchantSettingAccessor setting)
        {
            ValidateForEdit();
            var detail = QueueDetails.Single(x => x.Id == detailId);
            detail.SetDiscount(discountAmount, productTax, MerchantId, setting);
            CalCulateTotalAmountAndTax();
        }

        private void ValidateForEdit()
        {
            if (IsPaid)
                throw new PaidQueueEditingException();
        }

        private void CalCulateTotalAmountAndTax()
        {
            TotalAmount = QueueDetails.Where(x => !x.IsDeleted).Sum(x => x.OpenPrice - x.Discount);
            TotalTax = QueueDetails.Where(x => !x.IsDeleted).Sum(x => x.Tax);
        }

        private bool IsQueueDetailEmpty() => QueueDetails.Count(x => !x.IsDeleted) == 0;
        private void SetLaundary(string? fromAddress, string? toAddress, bool isOnlinePayment)
        {
            QueueLaundary = new QueueLaundary(fromAddress, toAddress, isOnlinePayment);
        }

        private void SetRestaurant(int? tableId)
        {
            QueueRestaurant = new QueueRestaurant(tableId);
        }

        

        private void SetParams(string? param1, string? param2, string? param3)
        {
            Param1 = param1;
            Param2 = param2;
            Param3 = param3;
        }

        public int MerchantId { get; set; }
        public int? CreatedBy { get; set; }
        public int? CashierId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public int PaymentMode { get; set; }
        public long? CustomerId { get; set; }
        public string? NfccardNumber { get; set; }
        public bool IsPaid { get; set; }
        public double TotalAmount { get; set; }
        public string? CouponCode { get; set; }
        public string? Param1 { get; set; }
        public string? Param2 { get; set; }
        public string? Param3 { get; set; }
        public long TokenNumber { get; set; }
        public int OfflineTokenNumber { get; set; }
        public DateTime OpeningTime { get; set; }
        public DateTime? CompletionTime { get; set; }
        public long? TransactionMasterId { get; set; }
        public int QueueStatusId { get; set; }
        public string? MobileNumber { get; set; }
        public string RequestedBy { get; set; }
        public DateTime ApprovedDateTime { get; set; }
        public double TotalTax { get; set; }
        public virtual QueueStatus QueueStatus { get; set; } = null!;
        public virtual QueueLaundary QueueLaundary { get; set; } = null!;
        public virtual QueueRestaurant QueueRestaurant { get; set; } = null!;
        public virtual ICollection<QueueDetail> QueueDetails { get; set; } = new HashSet<QueueDetail>();
    }
}

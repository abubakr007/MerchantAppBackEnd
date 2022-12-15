using Epay.QueueContext.Domain.Queues.Exceptions;
using Epay.QueueContext.Domain.Queues.Services;
using Framework.Core.Persistence;
using Framework.Domain;
using System;

namespace Epay.QueueContext.Domain.Queues
{
    public class QueueDetail : EntityBase<QueueDetail>
    {
        public QueueDetail(){}
        public QueueDetail(
            IEntityIdGenerator<QueueDetail> idGenerator,
            IMerchantSettingAccessor settings,
            int productId,
            double? productTax,
            double quantity,
            double discount,
            double? cardDiscount,
            double openPrice,
            int merchantId,
            bool? isHang,
            int? createdBy,
            int? workerId,
            double? productPrice): base(idGenerator)
        {
            ProductId = productId;
            SetQuantity(quantity);
            SetPriceAndTaxAndDiscount(openPrice, productPrice, quantity, productTax!.Value, discount, cardDiscount, merchantId, settings);
            IsHang = isHang;
            CreatedBy = createdBy;
            CreatedOn = DateTime.Now;
            IsDeleted = false;
            WorkerId = workerId;
            SetId();

        }

        private void SetPriceAndTaxAndDiscount(double openPrice, double? productPrice, double quantity, double tax, double discount, double? cardDiscount, int merchantId, IMerchantSettingAccessor settings)
        {

            if (cardDiscount.HasValue && cardDiscount < 0)
                throw new InvalidDiscountException();

            if (UsingBothTypeOfDiscount(discount, cardDiscount))
            {
                throw new BothDiscountUsageException();
            }


            OrginalPrice = quantity * openPrice;
            if (openPrice < 0)
                throw new InvalidOpenPriceException();
            if (openPrice == 0 && !productPrice.HasValue)
                throw new ProductPriceNotFoundException();
            if (openPrice == 0)
                OrginalPrice = quantity * productPrice!.Value;

            discount = cardDiscount.HasValue ? (OrginalPrice * cardDiscount.Value / 100) : discount;

            SetDiscount(discount, tax, merchantId, settings);
        }

        private static bool UsingBothTypeOfDiscount(double discount, double? cardDiscount)
        {
            return cardDiscount.HasValue && cardDiscount > 0 && discount > 0;
        }

        private void SetQuantity(double quantity)
        {
            if (quantity <= 0)
                throw new InvalidQuantityException();
            Quantity = quantity;
        }

        internal void UpdateQuantity(double quantity)
        {
            var price = (OpenPrice / Quantity);
            var tax = (Tax / Quantity);
            var orginalPrice = (OrginalPrice / Quantity);

            Quantity = quantity;
            OpenPrice = price * quantity;
            OrginalPrice = orginalPrice * quantity;
            Discount = 0;
            Tax = tax * quantity;
        }

        internal void SetDiscount(double discountAmount, double productTax, int merchantId, IMerchantSettingAccessor settings)
        {
            if (discountAmount < 0)
                throw new InvalidDiscountException();
            OpenPrice = OrginalPrice;
            Discount = discountAmount;
            var taxSetting = settings.GetTaxSettingForMerchant(merchantId);
            if (taxSetting.IsTaxAllowded)
            {
                if (taxSetting.IsTaxExcluded)
                {
                    Tax = (OpenPrice - Discount) * productTax / 100;
                }
                else
                {
                    Tax = OpenPrice - Discount - ((OpenPrice - Discount) * 100 / (100 + productTax));
                    OpenPrice -= Tax;
                }
            }
        }

        public long QueueMasterId { get; set; }
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public double Discount { get; set; }
        public double OpenPrice { get; set; }
        public bool? IsHang { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public int? WorkerId { get; set; }
        public double Tax { get; set; }
        public double OrginalPrice { get; set; }
        public QueueMaster QueueMaster { get; set; } = null!;

        
    }
}

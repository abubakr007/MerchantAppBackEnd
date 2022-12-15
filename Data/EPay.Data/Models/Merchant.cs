using System;
using System.Collections.Generic;

namespace EPay.Data.Models
{
    public partial class Merchant
    {
        public Merchant()
        {
            Tables = new HashSet<Table>();
        }

        public int Recid { get; set; }
        public int AccountType { get; set; }
        public string? SalesmanId { get; set; }
        public string? SalesmanName { get; set; }
        public string MerchantId { get; set; } = null!;
        public string MerchantName { get; set; } = null!;
        public int TerminalType { get; set; }
        public string? AccountManager { get; set; }
        public bool? Status { get; set; }
        public string? Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public string? OperationAddress1 { get; set; }
        public string? OperationAddress2 { get; set; }
        public string? City { get; set; }
        public int? Country { get; set; }
        public string? Currency { get; set; }
        public string? Region { get; set; }
        public string? Language { get; set; }
        public byte[]? LogoImage { get; set; }
        public int? CashierTimeOut { get; set; }
        public bool? PrintPollingTicket { get; set; }
        public bool? PrintMerchantTicket { get; set; }
        public bool? ShowBalance { get; set; }
        public bool? LoyaltyCard { get; set; }
        public bool? PrintMultisales { get; set; }
        public int? CatalogId { get; set; }
        public int? PricingGroupId { get; set; }
        public int? QuantityGroupId { get; set; }
        public long? TicketLayoutId { get; set; }
        public bool? ClaimMode { get; set; }
        public int? ConnectionProfile { get; set; }
        public int? TimeZone { get; set; }
        public bool? TicketReprint { get; set; }
        public string? CrtUserid { get; set; }
        public DateTime? CrtDt { get; set; }
        public string? UpdUserid { get; set; }
        public DateTime? UpdDt { get; set; }
        public bool? IsAllowedReprint { get; set; }
        public bool? IsGroupPrint { get; set; }
        public bool? IsAllowedMerchantCopy { get; set; }
        public double? AccountBalance { get; set; }
        public bool? IsAllowedCashCard { get; set; }
        public bool? IsAllowedDiscountCard { get; set; }
        public bool? IsAllowedLoyaltyCard { get; set; }
        public int? BusinessTypeId { get; set; }
        public bool? IsMultiSales { get; set; }
        public bool? IsQallowed { get; set; }
        public bool? IsDiscountAllowed { get; set; }
        public bool? QueuePrintAllowed { get; set; }
        public bool? BarcodeAllowed { get; set; }
        public string? FooterMessage { get; set; }
        public int? SessionTimeOut { get; set; }
        public bool? VisaCardAllowed { get; set; }
        public bool? CarNumberAllowed { get; set; }
        public int? CountryCode { get; set; }
        public bool? HeaderAllowed { get; set; }
        public bool? PincodeAllowed { get; set; }
        public bool? AutoClaimAllowed { get; set; }
        public bool? MultiCarAllowed { get; set; }
        public string? Trn { get; set; }
        public string? PrefixCode { get; set; }
        public bool? SubscriptionAllowed { get; set; }
        public bool? TaxAllowed { get; set; }
        public string? SmsText { get; set; }
        public bool? ConfirmationPrintAllowed { get; set; }
        public int? SmsLimit { get; set; }
        public bool? AutoLoginAllowed { get; set; }
        public bool? CardSearchAllowed { get; set; }
        public bool? ConfirmationAllowed { get; set; }
        public string? TrxText { get; set; }
        public bool? TrxTextAllowed { get; set; }
        public bool? SearchAllowed { get; set; }
        public string? TimeZone1 { get; set; }
        public bool? MobileNumberAllowed { get; set; }
        public int? NoOfDecimalPoint { get; set; }
        public bool? CustomerAllowed { get; set; }
        public bool? InventoryAllowed { get; set; }
        public bool? CouponAllowed { get; set; }
        public bool? IsCustomerReportAllowed { get; set; }
        public bool? IsTodayTaxAllowed { get; set; }
        public bool? IsCreditCardAllowed { get; set; }
        public bool? IsTotalApiallowed { get; set; }
        public bool? IsStockReportAllowed { get; set; }
        public string? PointsParam { get; set; }
        public bool? IsDiscountPercentage { get; set; }
        public bool? IsCategoryAllowed { get; set; }
        public bool? IsMobileLoyalty { get; set; }
        public bool? IsDealAllowed { get; set; }
        public bool? IsCashDebitAllowed { get; set; }
        public bool? IsCouponsAllowed { get; set; }
        public bool? IsCustomParam { get; set; }
        public long? TokenLayoutId { get; set; }
        public string? Param1Value { get; set; }
        public bool? IsBusinessDayAllowed { get; set; }
        public bool? IsBusinessShiftAllowed { get; set; }
        public bool? IsShortcutKeyAllowed { get; set; }
        public int? NumberOfIconsInRow { get; set; }
        public bool? IsShiftLoginAllowed { get; set; }
        public bool? IsPrintingAllowed { get; set; }
        public bool? IsSmscustomerAllowed { get; set; }
        public string? SmscustomerText { get; set; }
        public bool? IsCarLoyalty { get; set; }
        public bool? IsDisByTotalAllowed { get; set; }
        public int? Cartlimit { get; set; }
        public bool? IsNotificationsAllowed { get; set; }
        public bool? IsCusMobNumMandatory { get; set; }
        public bool? IsMerchantTokenCopy { get; set; }
        public bool? PayWithPassword { get; set; }
        public bool? SingleQtyCart { get; set; }
        public bool? PrintCardReport { get; set; }
        public bool? IsDirectCheckoutAllowed { get; set; }
        public bool? IsTaxExcluded { get; set; }
        public bool? LogoReplacement { get; set; }
        public bool? IsDealsSmsallowed { get; set; }
        public string? DealsSmstext { get; set; }
        public bool? IsHangFoldAllowed { get; set; }
        public bool? IsDeliveryDateAllowed { get; set; }
        public bool? IsOperatorAllowed { get; set; }
        public bool? IsArabicPrintAllowed { get; set; }
        public bool? IsEmiratesAllowed { get; set; }
        public long? TaxValue { get; set; }
        public bool? IsCarBrandAllowed { get; set; }
        public bool? IsTokenPrintNecessary { get; set; }
        public bool? IsNfcsearchallowed { get; set; }
        public bool? IsParam2Allowed { get; set; }
        public bool? IsParam3Allowed { get; set; }
        public string? Param2Value { get; set; }
        public string? Param3Value { get; set; }
        public bool? IsSmsloyaltyAllowed { get; set; }
        public string? SmsloyaltyText { get; set; }
        public bool? ISproductReplacementAllowed { get; set; }
        public bool? IsLocationTrackingAllowed { get; set; }
        public string? ProductParam1Value { get; set; }
        public bool? IsMinimumMaximumPriceAllowed { get; set; }
        public DateTime? RenewalDate { get; set; }
        public bool? IsRechargeable { get; set; }
        public bool? IsWorkerPerProduct { get; set; }
        public bool? IsSendPdfbySmsenabled { get; set; }
        public bool? IsAllMerchantDailyReport { get; set; }
        public string? YoutubePage { get; set; }
        public string? FacebookPage { get; set; }
        public string? InstagramPage { get; set; }
        public string? SnapchatPage { get; set; }
        public string? TwitterPage { get; set; }
        public bool? IsAppoimentAllowed { get; set; }
        public bool? IsLoundryAllowed { get; set; }
        public bool? IsBackToQueue { get; set; }
        public string? YallaWashPos { get; set; }
        public string? PrintPos { get; set; }
        public bool? IsPrintingEnabled { get; set; }
        public string? WhatsappNumber { get; set; }
        public bool? IsOfflineAllowed { get; set; }
        public long? ItemListId { get; set; }
        public string? DomainName { get; set; }
        public bool IsApproveNeedToInsideCustomer { get; set; }
        public bool IsApproveNeedToOutsideCustomer { get; set; }
        public bool IsApproveNeedToWaiter { get; set; }

        public virtual ItemList? ItemList { get; set; }
        public virtual ICollection<Table> Tables { get; set; }
    }
}

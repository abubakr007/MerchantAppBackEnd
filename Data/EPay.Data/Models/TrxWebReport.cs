using System;
using System.Collections.Generic;

namespace EPay.Data.Models
{
    public partial class TrxWebReport
    {
        public string? TransactionType { get; set; }
        public string? ReferenceNo { get; set; }
        public DateTime? Date { get; set; }
        public double? TotalQty { get; set; }
        public double? TotalAmount { get; set; }
        public double? TotalTaxAmount { get; set; }
        public string Eancode { get; set; } = null!;
        public string PosSn { get; set; } = null!;
        public long? TransactionNo { get; set; }
        public string MerchantId { get; set; } = null!;
        public string MerchantName { get; set; } = null!;
        public string? SalesmanName { get; set; }
        public string? SalesmanId { get; set; }
        public string ClientType { get; set; } = null!;
        public double? Point { get; set; }
        public double? OpeningBalance { get; set; }
        public double? Trxvalue { get; set; }
        public double? ClosingBalance { get; set; }
        public DateTime? RequestedOn { get; set; }
        public string? TerminalId { get; set; }
        public long? Id { get; set; }
        public double? MerchantNetPrice { get; set; }
        public string ProviderId { get; set; } = null!;
        public string ProviderNameAr { get; set; } = null!;
        public string? Product { get; set; }
        public string? ProductNameAr { get; set; }
        public int ProviderId1 { get; set; }
        public double? TaxAmount { get; set; }
        public string UserId { get; set; } = null!;
        public int CashierId { get; set; }
        public string ShiftId { get; set; } = null!;
        public string TransType { get; set; } = null!;
        public int ProviderCategoryId { get; set; }
        public double FaceValue { get; set; }
        public string? PaymentMode { get; set; }
        public long? CustomerId { get; set; }
        public string? City { get; set; }
        public string? DutyType { get; set; }
        public double? SafityLimit { get; set; }
        public int? TotalDutyDays { get; set; }
        public double? BasicSalary { get; set; }
        public string? VoucherNo { get; set; }
        public string? CardNo { get; set; }
        public long TrxNo { get; set; }
        public double? Qty { get; set; }
        public string? ContactNo { get; set; }
        public int? FaceValueReal { get; set; }
        public double? DiscountAmount { get; set; }
        public string? WorkerName { get; set; }
        public string? Param2 { get; set; }
        public string? Param3 { get; set; }
        public string? MerchantParentName { get; set; }
        public string? InternalRef { get; set; }
        public double? TotalQuantity { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string PaidBy { get; set; } = null!;
        public string? Midsid { get; set; }
        public string ServiceProvider { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string? Comments { get; set; }
        public string? CreatedBy { get; set; }
        public bool? Status { get; set; }
        public string? PaymentModeP { get; set; }
        public string ApprovedBy { get; set; } = null!;
        public DateTime? ApprovalTime { get; set; }
        public string ApprovalComment { get; set; } = null!;
        public string PaymentRef { get; set; } = null!;
        public string? PayeeId { get; set; }
        public string? CarNumber { get; set; }
        public string? MerchantIdTrx { get; set; }
        public string ProductEancode { get; set; } = null!;
        public string? AtmcardNo { get; set; }
        public string? BankAccount { get; set; }
        public DateTime? BankDate { get; set; }
        public string? CreditCardTrxNo { get; set; }
        public long? PaymentId { get; set; }
        public bool? IsApproved { get; set; }
        public bool? IsCustomerPayment { get; set; }
        public string? PaymentNo { get; set; }
        public string? BankName { get; set; }
        public string? PaidById { get; set; }
        public double? TotalPoint { get; set; }
        public double? Visa { get; set; }
        public double? Cash { get; set; }
        public double? Credit { get; set; }
        public string? VisaTransactionId { get; set; }
        public string? CheckInfo { get; set; }
        public string? MerchantParam1 { get; set; }
        public string? CategoryName { get; set; }
        public string? CustomerPoBox { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerAddress { get; set; }
        public DateTime? CustomerCreatedDate { get; set; }
        public string? ProductParam1 { get; set; }
        public string? ProductParam1Value { get; set; }
        public int ProductId { get; set; }
        public double? ItemDiscount { get; set; }
        public int? WorkerId { get; set; }
        public bool? Deduction { get; set; }
        public DateTime? ActualTrxTime { get; set; }
        public string? OfflineRefId { get; set; }
        public bool? IsOffline { get; set; }
        public string Cashiertype { get; set; } = null!;
        public bool? IsClaimed { get; set; }
        public long? IdClaimRef { get; set; }
        public string? Expr1 { get; set; }
        public string? ShiftName { get; set; }
        public string? BusinessDayId { get; set; }
        public string? ContactNumber { get; set; }
        public string? CouponCode { get; set; }
        public DateTime? Expirydate { get; set; }
        public double? Percentage { get; set; }
        public bool? Redeemed { get; set; }
        public int? TransactionTypeId { get; set; }
        public string CashierName { get; set; } = null!;
        public string? CommissionPercentage { get; set; }
    }
}

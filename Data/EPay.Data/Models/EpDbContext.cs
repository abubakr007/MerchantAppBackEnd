using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EPay.Data.Models
{
    public partial class EpDbContext : DbContext
    {
        public EpDbContext()
        {
        }

        public EpDbContext(DbContextOptions<EpDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<Batch> Batches { get; set; } = null!;
        public virtual DbSet<Cashier> Cashiers { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<GetTransaction> GetTransactions { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<ItemList> ItemLists { get; set; } = null!;
        public virtual DbSet<ItemLoyalty> ItemLoyalties { get; set; } = null!;
        public virtual DbSet<ItemPrice> ItemPrices { get; set; } = null!;
        public virtual DbSet<Logo> Logos { get; set; } = null!;
        public virtual DbSet<Merchant> Merchants { get; set; } = null!;
        public virtual DbSet<PriceGroupDetail> PriceGroupDetails { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Provider> Providers { get; set; } = null!;
        public virtual DbSet<ProviderCategory> ProviderCategories { get; set; } = null!;
        public virtual DbSet<QueueDetail> QueueDetails { get; set; } = null!;
        public virtual DbSet<QueueLaundary> QueueLaundaries { get; set; } = null!;
        public virtual DbSet<QueueList> QueueLists { get; set; } = null!;
        public virtual DbSet<QueueMaster> QueueMasters { get; set; } = null!;
        public virtual DbSet<QueueRestaurant> QueueRestaurants { get; set; } = null!;
        public virtual DbSet<QueueStatus> QueueStatuses { get; set; } = null!;
        public virtual DbSet<SmartCard> SmartCards { get; set; } = null!;
        public virtual DbSet<SubCategory> SubCategories { get; set; } = null!;
        public virtual DbSet<Table> Tables { get; set; } = null!;
        public virtual DbSet<Tax> Taxes { get; set; } = null!;
        public virtual DbSet<TransactionDetail> TransactionDetails { get; set; } = null!;
        public virtual DbSet<TransactionMaster> TransactionMasters { get; set; } = null!;
        public virtual DbSet<TrxWebReport> TrxWebReports { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server =213.159.5.155; initial catalog = SmartepayJafar;Persist Security Info=True;TrustServerCertificate=True;User ID=sa;Password=8HX2y9rtWYWV25Gb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserLevel).HasMaxLength(2);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Batch>(entity =>
            {
                entity.ToTable("Batch");

                entity.Property(e => e.Barcode).HasColumnName("barcode");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ManufacturingDate).HasColumnType("datetime");

                entity.Property(e => e.PartNo).HasColumnName("partNo");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.Property(e => e.Wac).HasColumnName("WAC");
            });

            modelBuilder.Entity<Cashier>(entity =>
            {
                entity.ToTable("Cashier");

                entity.Property(e => e.CashierKind)
                    .HasMaxLength(50)
                    .HasColumnName("cashierKind");

                entity.Property(e => e.Cashiertype)
                    .HasMaxLength(1)
                    .HasColumnName("cashiertype")
                    .IsFixedLength();

                entity.Property(e => e.Forcetomodifypassword).HasColumnName("forcetomodifypassword");

                entity.Property(e => e.MerchantId)
                    .HasMaxLength(50)
                    .HasColumnName("MerchantID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UserShiftId).HasColumnName("UserShiftID");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category", "AO");

                entity.Property(e => e.Id).HasDefaultValueSql("(NEXT VALUE FOR [Shared].[Category])");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CategoryType).HasMaxLength(10);

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(256);

                entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.MerchantGroupId).HasMaxLength(50);

                entity.Property(e => e.MerchantId).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(16);

                entity.Property(e => e.Pobox).HasColumnName("POBox");

                entity.Property(e => e.Vfcode)
                    .HasMaxLength(4)
                    .HasColumnName("VFCode");
            });

            modelBuilder.Entity<GetTransaction>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GetTransactions");

                entity.Property(e => e.CashierName)
                    .HasMaxLength(50)
                    .HasColumnName("cashierName");

                entity.Property(e => e.CategoryName).HasMaxLength(50);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.MerchantId).HasMaxLength(50);

                entity.Property(e => e.PaymentMode).HasMaxLength(20);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductNameEng).HasMaxLength(100);

                entity.Property(e => e.SubCategoryName).HasMaxLength(100);

                entity.Property(e => e.TransactionTime).HasColumnType("datetime");

                entity.Property(e => e.VoucherNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Items", "AO");

                entity.HasIndex(e => e.ItemListId, "IX_ItemListId");

                entity.HasIndex(e => e.SubCategoryId, "IX_SubCategoryId");

                entity.Property(e => e.Id).HasDefaultValueSql("(NEXT VALUE FOR [Shared].[Items])");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.ItemList)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.ItemListId)
                    .HasConstraintName("FK_AO.Items_AO.ItemList_ItemListId");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.SubCategoryId)
                    .HasConstraintName("FK_AO.Items_AO.SubCategory_SubCategoryId");
            });

            modelBuilder.Entity<ItemList>(entity =>
            {
                entity.ToTable("ItemList", "AO");

                entity.Property(e => e.Id).HasDefaultValueSql("(NEXT VALUE FOR [Shared].[ItemList])");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<ItemLoyalty>(entity =>
            {
                entity.ToTable("ItemLoyalty", "AO");

                entity.HasIndex(e => e.Id, "IX_Id");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ExpirePeriod).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.ItemLoyalty)
                    .HasForeignKey<ItemLoyalty>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AO.ItemLoyalty_AO.Items_Id");
            });

            modelBuilder.Entity<ItemPrice>(entity =>
            {
                entity.ToTable("ItemPrice", "AO");

                entity.HasIndex(e => e.Id, "IX_Id");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.ItemPrice)
                    .HasForeignKey<ItemPrice>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AO.ItemPrice_AO.Items_Id");
            });

            modelBuilder.Entity<Logo>(entity =>
            {
                entity.ToTable("Logo");
            });

            modelBuilder.Entity<Merchant>(entity =>
            {
                entity.HasKey(e => e.Recid);

                entity.ToTable("Merchant");

                entity.HasIndex(e => e.ItemListId, "IX_ItemListId");

                entity.Property(e => e.Recid).HasColumnName("recid");

                entity.Property(e => e.AccountManager)
                    .HasMaxLength(50)
                    .HasColumnName("account_manager");

                entity.Property(e => e.AccountType).HasColumnName("account_type");

                entity.Property(e => e.Cartlimit).HasColumnName("CARTLIMIT");

                entity.Property(e => e.CashierTimeOut).HasColumnName("Cashier_Time_Out");

                entity.Property(e => e.CatalogId).HasColumnName("Catalog_id");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.ClaimMode).HasColumnName("Claim_Mode");

                entity.Property(e => e.ConnectionProfile).HasColumnName("Connection_Profile");

                entity.Property(e => e.CrtDt)
                    .HasColumnType("datetime")
                    .HasColumnName("CRT_DT");

                entity.Property(e => e.CrtUserid)
                    .HasMaxLength(50)
                    .HasColumnName("CRT_USERID");

                entity.Property(e => e.Currency).HasMaxLength(50);

                entity.Property(e => e.DealsSmstext).HasColumnName("DealsSMSText");

                entity.Property(e => e.FacebookPage).HasColumnName("facebookPage");

                entity.Property(e => e.ISproductReplacementAllowed).HasColumnName("iSProductReplacementAllowed");

                entity.Property(e => e.InstagramPage).HasColumnName("instagramPage");

                entity.Property(e => e.IsAllMerchantDailyReport).HasColumnName("isAllMerchantDailyReport");

                entity.Property(e => e.IsAllowedCashCard).HasColumnName("isAllowedCashCard");

                entity.Property(e => e.IsAllowedDiscountCard).HasColumnName("isAllowedDiscountCard");

                entity.Property(e => e.IsAllowedLoyaltyCard).HasColumnName("isAllowedLoyaltyCard");

                entity.Property(e => e.IsAllowedMerchantCopy).HasColumnName("isAllowedMerchantCopy");

                entity.Property(e => e.IsAllowedReprint).HasColumnName("isAllowedReprint");

                entity.Property(e => e.IsAppoimentAllowed).HasColumnName("isAppoimentAllowed");

                entity.Property(e => e.IsArabicPrintAllowed).HasColumnName("isArabicPrintAllowed");

                entity.Property(e => e.IsBackToQueue).HasColumnName("isBackToQueue");

                entity.Property(e => e.IsBusinessDayAllowed).HasColumnName("isBusinessDayAllowed");

                entity.Property(e => e.IsBusinessShiftAllowed).HasColumnName("isBusinessShiftAllowed");

                entity.Property(e => e.IsCarLoyalty).HasColumnName("isCarLoyalty");

                entity.Property(e => e.IsCashDebitAllowed).HasColumnName("isCashDebitAllowed");

                entity.Property(e => e.IsCategoryAllowed).HasColumnName("isCategoryAllowed");

                entity.Property(e => e.IsCouponsAllowed).HasColumnName("isCouponsAllowed");

                entity.Property(e => e.IsCreditCardAllowed).HasColumnName("isCreditCardAllowed");

                entity.Property(e => e.IsCusMobNumMandatory).HasColumnName("isCusMobNumMandatory");

                entity.Property(e => e.IsCustomParam).HasColumnName("isCustomParam");

                entity.Property(e => e.IsCustomerReportAllowed).HasColumnName("isCustomerReportAllowed");

                entity.Property(e => e.IsDealAllowed).HasColumnName("isDealAllowed");

                entity.Property(e => e.IsDealsSmsallowed).HasColumnName("IsDealsSMSAllowed");

                entity.Property(e => e.IsDeliveryDateAllowed).HasColumnName("isDeliveryDateAllowed");

                entity.Property(e => e.IsDirectCheckoutAllowed).HasColumnName("isDirectCheckoutAllowed");

                entity.Property(e => e.IsDisByTotalAllowed).HasColumnName("isDisByTotalAllowed");

                entity.Property(e => e.IsDiscountAllowed).HasColumnName("isDiscountAllowed");

                entity.Property(e => e.IsDiscountPercentage).HasColumnName("isDiscountPercentage");

                entity.Property(e => e.IsGroupPrint).HasColumnName("isGroupPrint");

                entity.Property(e => e.IsHangFoldAllowed).HasColumnName("isHangFoldAllowed");

                entity.Property(e => e.IsLocationTrackingAllowed).HasColumnName("isLocationTrackingAllowed");

                entity.Property(e => e.IsLoundryAllowed).HasColumnName("isLoundryAllowed");

                entity.Property(e => e.IsMerchantTokenCopy).HasColumnName("isMerchantTokenCopy");

                entity.Property(e => e.IsMinimumMaximumPriceAllowed).HasColumnName("isMinimumMaximumPriceAllowed");

                entity.Property(e => e.IsMobileLoyalty).HasColumnName("isMobileLoyalty");

                entity.Property(e => e.IsMultiSales).HasColumnName("isMultiSales");

                entity.Property(e => e.IsNfcsearchallowed).HasColumnName("isNFCsearchallowed");

                entity.Property(e => e.IsOfflineAllowed).HasColumnName("isOfflineAllowed");

                entity.Property(e => e.IsOperatorAllowed).HasColumnName("isOperatorAllowed");

                entity.Property(e => e.IsParam2Allowed).HasColumnName("isParam2Allowed");

                entity.Property(e => e.IsParam3Allowed).HasColumnName("isParam3Allowed");

                entity.Property(e => e.IsPrintingAllowed).HasColumnName("isPrintingAllowed");

                entity.Property(e => e.IsPrintingEnabled).HasColumnName("isPrintingEnabled");

                entity.Property(e => e.IsQallowed).HasColumnName("isQAllowed");

                entity.Property(e => e.IsRechargeable).HasColumnName("isRechargeable");

                entity.Property(e => e.IsSendPdfbySmsenabled).HasColumnName("isSendPDFBySMSEnabled");

                entity.Property(e => e.IsShiftLoginAllowed).HasColumnName("isShiftLoginAllowed");

                entity.Property(e => e.IsShortcutKeyAllowed).HasColumnName("isShortcutKeyAllowed");

                entity.Property(e => e.IsSmscustomerAllowed).HasColumnName("isSMSCustomerAllowed");

                entity.Property(e => e.IsSmsloyaltyAllowed).HasColumnName("isSMSLoyaltyAllowed");

                entity.Property(e => e.IsStockReportAllowed).HasColumnName("isStockReportAllowed");

                entity.Property(e => e.IsTaxExcluded).HasColumnName("isTaxExcluded");

                entity.Property(e => e.IsTodayTaxAllowed).HasColumnName("isTodayTaxAllowed");

                entity.Property(e => e.IsTokenPrintNecessary).HasColumnName("isTokenPrintNecessary");

                entity.Property(e => e.IsTotalApiallowed).HasColumnName("isTotalAPIAllowed");

                entity.Property(e => e.IsWorkerPerProduct).HasColumnName("isWorkerPerProduct");

                entity.Property(e => e.Language).HasMaxLength(50);

                entity.Property(e => e.LogoImage)
                    .HasMaxLength(50)
                    .HasColumnName("Logo_Image")
                    .IsFixedLength();

                entity.Property(e => e.MerchantId)
                    .HasMaxLength(50)
                    .HasColumnName("merchant_id");

                entity.Property(e => e.MerchantName)
                    .HasMaxLength(255)
                    .HasColumnName("merchant_name");

                entity.Property(e => e.OperationAddress1)
                    .HasMaxLength(500)
                    .HasColumnName("Operation_Address1");

                entity.Property(e => e.OperationAddress2)
                    .HasMaxLength(500)
                    .HasColumnName("Operation_Address2");

                entity.Property(e => e.Phone1).HasMaxLength(50);

                entity.Property(e => e.Phone2).HasMaxLength(50);

                entity.Property(e => e.PointsParam).HasMaxLength(50);

                entity.Property(e => e.PrefixCode).HasMaxLength(10);

                entity.Property(e => e.PricingGroupId).HasColumnName("Pricing_Group_id");

                entity.Property(e => e.PrintCardReport).HasColumnName("printCardReport");

                entity.Property(e => e.PrintMerchantTicket).HasColumnName("Print_Merchant_Ticket");

                entity.Property(e => e.PrintMultisales).HasColumnName("Print_multisales");

                entity.Property(e => e.PrintPollingTicket).HasColumnName("Print_Polling_Ticket");

                entity.Property(e => e.PrintPos).HasColumnName("PrintPOS");

                entity.Property(e => e.QuantityGroupId).HasColumnName("Quantity_Group_id");

                entity.Property(e => e.Region).HasMaxLength(50);

                entity.Property(e => e.RenewalDate).HasColumnType("datetime");

                entity.Property(e => e.SalesmanId)
                    .HasMaxLength(50)
                    .HasColumnName("salesman_id");

                entity.Property(e => e.SalesmanName)
                    .HasMaxLength(255)
                    .HasColumnName("salesman_name");

                entity.Property(e => e.ShowBalance).HasColumnName("Show_balance");

                entity.Property(e => e.SingleQtyCart).HasColumnName("singleQtyCart");

                entity.Property(e => e.SmscustomerText).HasColumnName("SMSCustomerText");

                entity.Property(e => e.SmsloyaltyText).HasColumnName("SMSLoyaltyText");

                entity.Property(e => e.SnapchatPage).HasColumnName("snapchatPage");

                entity.Property(e => e.TerminalType).HasColumnName("terminal_type");

                entity.Property(e => e.TimeZone).HasColumnName("Time_Zone");

                entity.Property(e => e.TimeZone1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TimeZone");

                entity.Property(e => e.Trn)
                    .HasMaxLength(50)
                    .HasColumnName("TRN");

                entity.Property(e => e.TwitterPage).HasColumnName("twitterPage");

                entity.Property(e => e.UpdDt)
                    .HasColumnType("datetime")
                    .HasColumnName("UPD_DT");

                entity.Property(e => e.UpdUserid)
                    .HasMaxLength(50)
                    .HasColumnName("UPD_USERID");

                entity.Property(e => e.YallaWashPos).HasColumnName("YallaWashPOS");

                entity.Property(e => e.YoutubePage).HasColumnName("youtubePage");

                entity.HasOne(d => d.ItemList)
                    .WithMany(p => p.Merchants)
                    .HasForeignKey(d => d.ItemListId)
                    .HasConstraintName("FK_dbo.Merchant_AO.ItemList_ItemListId");
            });

            modelBuilder.Entity<PriceGroupDetail>(entity =>
            {
                entity.HasIndex(e => e.LogoId, "IX_LogoId");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(50);

                entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.RechargeNfc).HasColumnName("RechargeNFC");

                entity.HasOne(d => d.Logo)
                    .WithMany(p => p.PriceGroupDetails)
                    .HasForeignKey(d => d.LogoId)
                    .HasConstraintName("FK_dbo.PriceGroupDetails_dbo.Logo_LogoId");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("PRODUCT");

                entity.Property(e => e.BuyingPrice)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Currency)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Eancode)
                    .HasMaxLength(50)
                    .HasColumnName("EANCode")
                    .IsFixedLength();

                entity.Property(e => e.Eantype)
                    .HasMaxLength(10)
                    .HasColumnName("EANType")
                    .IsFixedLength();

                entity.Property(e => e.FaceValue)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.InternalReference)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(50);

                entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Points).HasMaxLength(10);

                entity.Property(e => e.PosprintProductName)
                    .HasMaxLength(100)
                    .HasColumnName("POSPrintProductName");

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.ProductNameAr).HasMaxLength(100);

                entity.Property(e => e.ProductNameEng).HasMaxLength(100);

                entity.Property(e => e.ProductNameTurki).HasMaxLength(100);

                entity.Property(e => e.ProductType).HasMaxLength(50);

                entity.Property(e => e.QgroupId).HasColumnName("QGroupId");

                entity.Property(e => e.TicketLayoutId).HasColumnName("TicketLayoutID");

                entity.Property(e => e.ValiditydateEnd).HasColumnType("datetime");

                entity.Property(e => e.ValiditydateStart).HasColumnType("datetime");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.ToTable("Provider");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.IsAllowedReprint).HasColumnName("isAllowedReprint");

                entity.Property(e => e.IsTotalApiallowed).HasColumnName("isTotalAPIAllowed");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(50);

                entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.PosPrintProviderName).HasMaxLength(100);

                entity.Property(e => e.Poslogo)
                    .HasMaxLength(50)
                    .HasColumnName("POSLogo")
                    .IsFixedLength();

                entity.Property(e => e.ProviderNameAr)
                    .HasMaxLength(100)
                    .HasColumnName("ProviderNameAR");

                entity.Property(e => e.ProviderNameEn)
                    .HasMaxLength(100)
                    .HasColumnName("ProviderNameEN");

                entity.Property(e => e.ProviderNameTürki).HasMaxLength(100);
            });

            modelBuilder.Entity<ProviderCategory>(entity =>
            {
                entity.ToTable("ProviderCategory");

                entity.Property(e => e.Name).HasMaxLength(50);
            });


            modelBuilder.Entity<QueueDetail>(entity =>
            {
                entity.ToTable("QueueDetail", "AO");

                entity.HasIndex(e => e.ProductId, "IX_ProductId");

                entity.HasIndex(e => e.QueueMasterId, "IX_QueueMasterId");

                entity.Property(e => e.Id).HasDefaultValueSql("(NEXT VALUE FOR [Shared].[QueueDetail])");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.QueueDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_AO.QueueDetail_dbo.Product_ProductId");

                entity.HasOne(d => d.QueueMaster)
                    .WithMany(p => p.QueueDetails)
                    .HasForeignKey(d => d.QueueMasterId)
                    .HasConstraintName("FK_AO.QueueDetail_AO.QueueMaster_QueueMasterId");
            });

            modelBuilder.Entity<QueueLaundary>(entity =>
            {
                entity.ToTable("QueueLaundary", "AO");

                entity.HasIndex(e => e.Id, "IX_Id");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.QueueLaundary)
                    .HasForeignKey<QueueLaundary>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AO.QueueLaundary_AO.QueueMaster_Id");
            });

            modelBuilder.Entity<QueueList>(entity =>
            {
                entity.ToTable("QueueList");

                entity.HasIndex(e => e.CashierId, "IX_CashierId");

                entity.Property(e => e.CouponCode).HasMaxLength(100);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Discount).HasMaxLength(50);

                entity.Property(e => e.IsHang).HasColumnName("isHang");

                entity.Property(e => e.IsPaid).HasColumnName("isPaid");

                entity.Property(e => e.Itemopenprice).HasColumnName("ITEMOPENPRICE");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(50);

                entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.MerchantId)
                    .HasMaxLength(10)
                    .HasColumnName("MerchantID");

                entity.Property(e => e.QgroupId).HasColumnName("QGroupId");

                entity.Property(e => e.QueueListMasterId).HasColumnName("QueueListMasterID");

                entity.Property(e => e.QueueStatus).HasMaxLength(20);

                entity.Property(e => e.ToAddress).HasColumnName("toAddress");

                entity.Property(e => e.WorderId).HasColumnName("WorderID");

                entity.HasOne(d => d.Cashier)
                    .WithMany(p => p.QueueLists)
                    .HasForeignKey(d => d.CashierId)
                    .HasConstraintName("FK_dbo.QueueList_dbo.Cashier_CashierId");
            });

            modelBuilder.Entity<QueueMaster>(entity =>
            {
                entity.ToTable("QueueMaster", "AO");

                entity.HasIndex(e => e.CashierId, "IX_CashierId");

                entity.HasIndex(e => e.CustomerId, "IX_CustomerId");

                entity.HasIndex(e => e.QueueStatusId, "IX_QueueStatusId");

                entity.HasIndex(e => e.TransactionMasterId, "IX_TransactionMasterId");

                entity.Property(e => e.Id).HasDefaultValueSql("(NEXT VALUE FOR [Shared].[QueueMaster])");

                entity.Property(e => e.ApprovedDateTime).HasColumnType("datetime");

                entity.Property(e => e.CompletionTime).HasColumnType("datetime");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.NfccardNumber).HasColumnName("NFCCardNumber");

                entity.Property(e => e.OpeningTime).HasColumnType("datetime");

                entity.HasOne(d => d.Cashier)
                    .WithMany(p => p.QueueMasters)
                    .HasForeignKey(d => d.CashierId)
                    .HasConstraintName("FK_AO.QueueMaster_dbo.Cashier_CashierId");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.QueueMasters)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_AO.QueueMaster_dbo.Customer_CustomerId");

                entity.HasOne(d => d.QueueStatus)
                    .WithMany(p => p.QueueMasters)
                    .HasForeignKey(d => d.QueueStatusId)
                    .HasConstraintName("FK_AO.QueueMaster_AO.QueueStatus_QueueStatusId");

                entity.HasOne(d => d.TransactionMaster)
                    .WithMany(p => p.QueueMasters)
                    .HasForeignKey(d => d.TransactionMasterId)
                    .HasConstraintName("FK_AO.QueueMaster_dbo.TransactionMaster_TransactionMasterId");
            });

            modelBuilder.Entity<QueueRestaurant>(entity =>
            {
                entity.ToTable("QueueRestaurant", "AO");

                entity.HasIndex(e => e.Id, "IX_Id");

                entity.HasIndex(e => e.TableId, "IX_TableId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.QueueRestaurant)
                    .HasForeignKey<QueueRestaurant>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AO.QueueRestaurant_AO.QueueMaster_Id");

                entity.HasOne(d => d.Table)
                    .WithMany(p => p.QueueRestaurants)
                    .HasForeignKey(d => d.TableId)
                    .HasConstraintName("FK_AO.QueueRestaurant_AO.Table_TableId");
            });

            modelBuilder.Entity<QueueStatus>(entity =>
            {
                entity.ToTable("QueueStatus", "AO");

                entity.HasIndex(e => e.BusinessTypeId, "IX_BusinessTypeId");

                entity.Property(e => e.Id).HasDefaultValueSql("(NEXT VALUE FOR [Shared].[QueueStatus])");
            });

            modelBuilder.Entity<SmartCard>(entity =>
            {
                entity.HasKey(e => e.CardId);

                entity.HasIndex(e => e.CustomerId, "IX_CustomerId");

                entity.Property(e => e.ActivationDate).HasColumnType("datetime");

                entity.Property(e => e.CardNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CardStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CardType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ExpairyDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.MerchantGroupId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MerchantId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TagUid).HasColumnName("TagUID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.SmartCards)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_dbo.SmartCards_dbo.Customer_CustomerId");
            });

            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.ToTable("SubCategory", "AO");

                entity.HasIndex(e => e.CategoryId, "IX_CategoryId");

                entity.Property(e => e.Id).HasDefaultValueSql("(NEXT VALUE FOR [Shared].[SubCategory])");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SubCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_AO.SubCategory_AO.Category_CategoryId");
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.ToTable("Table", "AO");

                entity.HasIndex(e => e.MerchantId, "IX_MerchantId");

                entity.Property(e => e.Id).HasDefaultValueSql("(NEXT VALUE FOR [Shared].[Table])");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Merchant)
                    .WithMany(p => p.Tables)
                    .HasForeignKey(d => d.MerchantId)
                    .HasConstraintName("FK_AO.Table_dbo.Merchant_MerchantId");
            });

            modelBuilder.Entity<Tax>(entity =>
            {
                entity.ToTable("Tax");
            });

            modelBuilder.Entity<TransactionDetail>(entity =>
            {
                entity.HasKey(e => e.TrxNo);

                entity.Property(e => e.Currency)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EanCode)
                    .HasMaxLength(50)
                    .HasColumnName("EAN_Code");

                entity.Property(e => e.InternalRef).HasMaxLength(50);

                entity.Property(e => e.IsClaimed).HasColumnName("isClaimed");

                entity.Property(e => e.IsClaimedTrxId).HasColumnName("isClaimedTrxID");

                entity.Property(e => e.IsHang).HasColumnName("isHang");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductParam1).HasColumnName("productParam1");

                entity.Property(e => e.ProviderId).HasColumnName("ProviderID");

                entity.Property(e => e.ReconcilationTime).HasColumnType("datetime");

                entity.Property(e => e.WorkerId).HasColumnName("WorkerID");
            });

            modelBuilder.Entity<TransactionMaster>(entity =>
            {
                entity.ToTable("TransactionMaster");

                entity.Property(e => e.ActualTrxTime)
                    .HasColumnType("datetime")
                    .HasColumnName("actualTrxTime");

                entity.Property(e => e.BusinessDayId).HasColumnName("BusinessDayID");

                entity.Property(e => e.CardNo).HasMaxLength(20);

                entity.Property(e => e.CashierId).HasColumnName("CashierID");

                entity.Property(e => e.ContactNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsOffline).HasColumnName("isOffline");

                entity.Property(e => e.IsTaxExcluded).HasColumnName("isTaxExcluded");

                entity.Property(e => e.MerchantId)
                    .HasMaxLength(50)
                    .HasColumnName("MerchantID");

                entity.Property(e => e.OfflineRefId).HasColumnName("offlineRefID");

                entity.Property(e => e.PaymentMode).HasMaxLength(20);

                entity.Property(e => e.ReconcilationTime).HasColumnType("datetime");

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.Property(e => e.TerminalId).HasMaxLength(50);

                entity.Property(e => e.TrxTime).HasColumnType("datetime");

                entity.Property(e => e.VoucherNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WorkerId).HasColumnName("WorkerID");
            });

            modelBuilder.Entity<TrxWebReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TrxWebReport");

                entity.Property(e => e.ActualTrxTime)
                    .HasColumnType("datetime")
                    .HasColumnName("actualTrxTime");

                entity.Property(e => e.ApprovalComment)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalTime).HasColumnType("datetime");

                entity.Property(e => e.ApprovedBy)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.AtmcardNo)
                    .HasMaxLength(50)
                    .HasColumnName("ATMCardNo");

                entity.Property(e => e.BankAccount).HasMaxLength(50);

                entity.Property(e => e.BankDate).HasColumnType("datetime");

                entity.Property(e => e.BankName).HasMaxLength(50);

                entity.Property(e => e.BusinessDayId).HasColumnName("BusinessDayID");

                entity.Property(e => e.CardNo).HasMaxLength(20);

                entity.Property(e => e.CashierId).HasColumnName("cashierId");

                entity.Property(e => e.CashierName).HasMaxLength(50);

                entity.Property(e => e.Cashiertype)
                    .HasMaxLength(1)
                    .HasColumnName("cashiertype")
                    .IsFixedLength();

                entity.Property(e => e.CategoryName).HasMaxLength(50);

                entity.Property(e => e.ClientType).HasMaxLength(50);

                entity.Property(e => e.ContactNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreditCardTrxNo).HasMaxLength(50);

                entity.Property(e => e.CustomerAddress).HasColumnName("customerAddress");

                entity.Property(e => e.CustomerCreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("customerCreatedDate");

                entity.Property(e => e.CustomerEmail).HasColumnName("customerEmail");

                entity.Property(e => e.CustomerName).HasColumnName("customerName");

                entity.Property(e => e.CustomerPoBox).HasColumnName("customerPoBox");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Eancode)
                    .HasMaxLength(50)
                    .HasColumnName("EANCode");

                entity.Property(e => e.Expirydate)
                    .HasColumnType("datetime")
                    .HasColumnName("expirydate");

                entity.Property(e => e.InternalRef).HasMaxLength(50);

                entity.Property(e => e.IsApproved).HasColumnName("isApproved");

                entity.Property(e => e.IsClaimed).HasColumnName("isClaimed");

                entity.Property(e => e.IsOffline).HasColumnName("isOffline");

                entity.Property(e => e.MerchantId)
                    .HasMaxLength(50)
                    .HasColumnName("MerchantID");

                entity.Property(e => e.MerchantIdTrx).HasMaxLength(50);

                entity.Property(e => e.MerchantName).HasMaxLength(255);

                entity.Property(e => e.MerchantParentName).HasMaxLength(255);

                entity.Property(e => e.Midsid)
                    .HasMaxLength(50)
                    .HasColumnName("MIDSID");

                entity.Property(e => e.OfflineRefId).HasColumnName("offlineRefID");

                entity.Property(e => e.PaidBy)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.PaidById)
                    .HasMaxLength(50)
                    .HasColumnName("paidById");

                entity.Property(e => e.PayeeId).HasMaxLength(50);

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentId).HasColumnName("paymentId");

                entity.Property(e => e.PaymentMode).HasMaxLength(20);

                entity.Property(e => e.PaymentModeP).HasMaxLength(50);

                entity.Property(e => e.PaymentNo).HasMaxLength(50);

                entity.Property(e => e.PaymentRef)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.PosSn)
                    .HasMaxLength(255)
                    .HasColumnName("POS_SN")
                    .IsFixedLength();

                entity.Property(e => e.Product).HasMaxLength(100);

                entity.Property(e => e.ProductEancode)
                    .HasMaxLength(50)
                    .HasColumnName("productEANCode")
                    .IsFixedLength();

                entity.Property(e => e.ProductNameAr).HasMaxLength(100);

                entity.Property(e => e.ProductParam1).HasColumnName("productParam1");

                entity.Property(e => e.ProviderId)
                    .HasMaxLength(100)
                    .HasColumnName("ProviderID");

                entity.Property(e => e.ProviderId1).HasColumnName("Provider_Id");

                entity.Property(e => e.ProviderNameAr)
                    .HasMaxLength(100)
                    .HasColumnName("ProviderNameAR");

                entity.Property(e => e.RequestedOn).HasColumnType("datetime");

                entity.Property(e => e.SalesmanId)
                    .HasMaxLength(50)
                    .HasColumnName("SalesmanID");

                entity.Property(e => e.SalesmanName).HasMaxLength(255);

                entity.Property(e => e.ServiceProvider)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ShiftId)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ShiftID");

                entity.Property(e => e.TerminalId).HasMaxLength(50);

                entity.Property(e => e.TransType)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionType).HasMaxLength(256);

                entity.Property(e => e.Trxvalue).HasColumnName("TRXValue");

                entity.Property(e => e.Type)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("UserID");

                entity.Property(e => e.VoucherNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WorkerId).HasColumnName("WorkerID");

                entity.Property(e => e.WorkerName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

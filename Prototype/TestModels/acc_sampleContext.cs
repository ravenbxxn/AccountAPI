using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APIPrototype.TestModels;

public partial class acc_sampleContext : DbContext
{
    public acc_sampleContext()
    {
    }

    public acc_sampleContext(DbContextOptions<acc_sampleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acc_AdditionDatum> Acc_AdditionData { get; set; }

    public virtual DbSet<Acc_JournalDT> Acc_JournalDTs { get; set; }

    public virtual DbSet<Acc_JournalHD> Acc_JournalHDs { get; set; }

    public virtual DbSet<Acc_StockTransaction> Acc_StockTransactions { get; set; }

    public virtual DbSet<Acc_TempGL> Acc_TempGLs { get; set; }

    public virtual DbSet<Acc_TransactionDT> Acc_TransactionDTs { get; set; }

    public virtual DbSet<Acc_TransactionHD> Acc_TransactionHDs { get; set; }

    public virtual DbSet<Mas_AccCode> Mas_AccCodes { get; set; }

    public virtual DbSet<Mas_AccCodeConfig> Mas_AccCodeConfigs { get; set; }

    public virtual DbSet<Mas_AccConfig> Mas_AccConfigs { get; set; }

    public virtual DbSet<Mas_AccType> Mas_AccTypes { get; set; }

    public virtual DbSet<Mas_Company> Mas_Companies { get; set; }

    public virtual DbSet<Mas_Customer> Mas_Customers { get; set; }

    public virtual DbSet<Mas_Department> Mas_Departments { get; set; }

    public virtual DbSet<Mas_DocConfig> Mas_DocConfigs { get; set; }

    public virtual DbSet<Mas_DocConfigSchema> Mas_DocConfigSchemas { get; set; }

    public virtual DbSet<Mas_HRDepartment> Mas_HRDepartments { get; set; }

    public virtual DbSet<Mas_HRDivision> Mas_HRDivisions { get; set; }

    public virtual DbSet<Mas_HREmployment> Mas_HREmployments { get; set; }

    public virtual DbSet<Mas_HRLevel> Mas_HRLevels { get; set; }

    public virtual DbSet<Mas_HRPosition> Mas_HRPositions { get; set; }

    public virtual DbSet<Mas_HRStaff> Mas_HRStaffs { get; set; }

    public virtual DbSet<Mas_Module> Mas_Modules { get; set; }

    public virtual DbSet<Mas_ModuleMenu> Mas_ModuleMenus { get; set; }

    public virtual DbSet<Mas_Product> Mas_Products { get; set; }

    public virtual DbSet<Mas_ProductSetDT> Mas_ProductSetDTs { get; set; }

    public virtual DbSet<Mas_ProductSetHD> Mas_ProductSetHDs { get; set; }

    public virtual DbSet<Mas_ProductType> Mas_ProductTypes { get; set; }

    public virtual DbSet<Mas_Promotion> Mas_Promotions { get; set; }

    public virtual DbSet<Mas_SalesProductDT> Mas_SalesProductDTs { get; set; }

    public virtual DbSet<Mas_SalesProductHD> Mas_SalesProductHDs { get; set; }

    public virtual DbSet<Mas_Supplier> Mas_Suppliers { get; set; }

    public virtual DbSet<Mas_User> Mas_Users { get; set; }

    public virtual DbSet<Mas_UserRole> Mas_UserRoles { get; set; }

    public virtual DbSet<Mas_UserRoleAssign> Mas_UserRoleAssigns { get; set; }

    public virtual DbSet<Mas_UserRoleAuthor> Mas_UserRoleAuthors { get; set; }

    public virtual DbSet<Mas_Warehouse> Mas_Warehouses { get; set; }

    public virtual DbSet<vAP_D> vAP_Ds { get; set; }

    public virtual DbSet<vAP_H> vAP_Hs { get; set; }

    public virtual DbSet<vAR_D> vAR_Ds { get; set; }

    public virtual DbSet<vAR_H> vAR_Hs { get; set; }

    public virtual DbSet<vJournal_All> vJournal_Alls { get; set; }

    public virtual DbSet<vJournal_D> vJournal_Ds { get; set; }

    public virtual DbSet<vJournal_H> vJournal_Hs { get; set; }

    public virtual DbSet<vMas_AccCode> vMas_AccCodes { get; set; }

    public virtual DbSet<vMas_Product> vMas_Products { get; set; }

    public virtual DbSet<vMas_ProductType> vMas_ProductTypes { get; set; }

    public virtual DbSet<vMas_Warehouse> vMas_Warehouses { get; set; }

    public virtual DbSet<vPO_All> vPO_Alls { get; set; }

    public virtual DbSet<vPO_Balance> vPO_Balances { get; set; }

    public virtual DbSet<vPO_Delivery> vPO_Deliveries { get; set; }

    public virtual DbSet<vPR_All> vPR_Alls { get; set; }

    public virtual DbSet<vPV_All> vPV_Alls { get; set; }

    public virtual DbSet<vRV_All> vRV_Alls { get; set; }

    public virtual DbSet<vSO_All> vSO_Alls { get; set; }

    public virtual DbSet<vSO_Balance> vSO_Balances { get; set; }

    public virtual DbSet<vSO_Delivery> vSO_Deliveries { get; set; }

    public virtual DbSet<vSR_All> vSR_Alls { get; set; }

    public virtual DbSet<vStock_Card> vStock_Cards { get; set; }

    public virtual DbSet<vStock_Onhand> vStock_Onhands { get; set; }

    public virtual DbSet<vSum_AllType> vSum_AllTypes { get; set; }

    public virtual DbSet<vSum_Balance> vSum_Balances { get; set; }

    public virtual DbSet<vSum_JournalByPrefix> vSum_JournalByPrefixes { get; set; }

    public virtual DbSet<vSum_JournalByType> vSum_JournalByTypes { get; set; }

    public virtual DbSet<vSum_Stock> vSum_Stocks { get; set; }

    public virtual DbSet<vSum_StockByType> vSum_StockByTypes { get; set; }

    public virtual DbSet<vSum_TransactionByType> vSum_TransactionByTypes { get; set; }

    public virtual DbSet<vTransaction_All> vTransaction_Alls { get; set; }

    public virtual DbSet<vTransaction_D> vTransaction_Ds { get; set; }

    public virtual DbSet<vTransaction_H> vTransaction_Hs { get; set; }

    public virtual DbSet<vTrial_Balance> vTrial_Balances { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=203.154.140.51;Initial Catalog=acc_sample;Persist Security Info=True;User ID=sa;Password='9t;yogm8';TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acc_AdditionDatum>(entity =>
        {
            entity.HasKey(e => new { e.DocNo, e.Seq });

            entity.Property(e => e.DocNo).HasMaxLength(50);
            entity.Property(e => e.Date1).HasColumnType("datetime");
            entity.Property(e => e.Date10).HasColumnType("datetime");
            entity.Property(e => e.Date2).HasColumnType("datetime");
            entity.Property(e => e.Date3).HasColumnType("datetime");
            entity.Property(e => e.Date4).HasColumnType("datetime");
            entity.Property(e => e.Date5).HasColumnType("datetime");
            entity.Property(e => e.Date6).HasColumnType("datetime");
            entity.Property(e => e.Date7).HasColumnType("datetime");
            entity.Property(e => e.Date8).HasColumnType("datetime");
            entity.Property(e => e.Date9).HasColumnType("datetime");
            entity.Property(e => e.Text1)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text10)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text2)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text3)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text4)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text5)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text6)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text7)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text8)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text9)
                .HasMaxLength(1000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Acc_JournalDT>(entity =>
        {
            entity.HasKey(e => new { e.EntryId, e.Seq });

            entity.ToTable("Acc_JournalDT");

            entity.Property(e => e.AccCode).HasMaxLength(50);
            entity.Property(e => e.AccName).HasMaxLength(255);
            entity.Property(e => e.Credit).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.Debit).HasColumnType("decimal(18, 10)");
        });

        modelBuilder.Entity<Acc_JournalHD>(entity =>
        {
            entity.HasKey(e => e.EntryId);

            entity.ToTable("Acc_JournalHD");

            entity.Property(e => e.EntryId).ValueGeneratedNever();
            entity.Property(e => e.EffectiveDate).HasColumnType("datetime");
            entity.Property(e => e.EntryBy).HasMaxLength(50);
            entity.Property(e => e.EntryDate).HasColumnType("datetime");
            entity.Property(e => e.JournalNo).HasMaxLength(50);
            entity.Property(e => e.TotalCredit).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.TotalDebit).HasColumnType("decimal(18, 10)");
        });

        modelBuilder.Entity<Acc_StockTransaction>(entity =>
        {
            entity.HasKey(e => e.TransID).HasName("PK_Mas_StockTransaction");

            entity.ToTable("Acc_StockTransaction");

            entity.HasIndex(e => e.TransNum, "IX_Acc_StockTransaction").IsUnique();

            entity.Property(e => e.AssetAccCode).HasMaxLength(10);
            entity.Property(e => e.RefDocNo).HasMaxLength(50);
            entity.Property(e => e.StockProductCode).HasMaxLength(50);
            entity.Property(e => e.TransCurrency).HasMaxLength(10);
            entity.Property(e => e.TransNum).HasMaxLength(50);
            entity.Property(e => e.TransPrice).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.TransRate).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.TransType).HasMaxLength(50);
            entity.Property(e => e.WarehouseCode).HasMaxLength(50);

            entity.HasOne(d => d.WarehouseCodeNavigation).WithMany(p => p.Acc_StockTransactions)
                .HasPrincipalKey(p => p.WarehouseCode)
                .HasForeignKey(d => d.WarehouseCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Acc_StockTransaction_Mas_Warehouse");
        });

        modelBuilder.Entity<Acc_TempGL>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Acc_TempGL");

            entity.Property(e => e.AccCode).HasMaxLength(50);
            entity.Property(e => e.EffectiveDate).HasColumnType("datetime");
            entity.Property(e => e.JournalNo).HasMaxLength(50);
        });

        modelBuilder.Entity<Acc_TransactionDT>(entity =>
        {
            entity.HasKey(e => new { e.AccDocNo, e.AccItemNo });

            entity.ToTable("Acc_TransactionDT");

            entity.Property(e => e.AccDocNo).HasMaxLength(50);
            entity.Property(e => e.AccSourceDocNo).HasMaxLength(50);
            entity.Property(e => e.Currency).HasMaxLength(50);
            entity.Property(e => e.SaleProductCode).HasMaxLength(50);
            entity.Property(e => e.SalesDescription).HasMaxLength(255);
            entity.Property(e => e.UnitMea).HasMaxLength(50);
        });

        modelBuilder.Entity<Acc_TransactionHD>(entity =>
        {
            entity.HasKey(e => e.AccDocNo).HasName("PK_Mas_AccTransactionHD");

            entity.ToTable("Acc_TransactionHD");

            entity.Property(e => e.AccDocNo).HasMaxLength(50);
            entity.Property(e => e.AccBatchDate).HasColumnType("date");
            entity.Property(e => e.AccDocType).HasMaxLength(50);
            entity.Property(e => e.AccEffectiveDate).HasColumnType("date");
            entity.Property(e => e.AccPostDate).HasColumnType("date");
            entity.Property(e => e.DocRefNo).HasMaxLength(50);
            entity.Property(e => e.FiscalYear).HasColumnType("date");
            entity.Property(e => e.IssueBy).HasMaxLength(50);
            entity.Property(e => e.PartyAddress).HasMaxLength(255);
            entity.Property(e => e.PartyCode).HasMaxLength(50);
            entity.Property(e => e.PartyName).HasMaxLength(255);
            entity.Property(e => e.PartyTaxCode).HasMaxLength(50);
        });

        modelBuilder.Entity<Mas_AccCode>(entity =>
        {
            entity.HasKey(e => e.AccCode);

            entity.ToTable("Mas_AccCode");

            entity.Property(e => e.AccCode).HasMaxLength(50);
            entity.Property(e => e.AccMainCode).HasMaxLength(50);
            entity.Property(e => e.AccName).HasMaxLength(255);
            entity.Property(e => e.AccNameEN).HasMaxLength(255);
        });

        modelBuilder.Entity<Mas_AccCodeConfig>(entity =>
        {
            entity.HasKey(e => e.AccCode);

            entity.ToTable("Mas_AccCodeConfig");

            entity.Property(e => e.AccCode).HasMaxLength(50);
            entity.Property(e => e.CreditAccCode).HasMaxLength(50);
            entity.Property(e => e.DebitAccCode).HasMaxLength(50);
        });

        modelBuilder.Entity<Mas_AccConfig>(entity =>
        {
            entity.HasKey(e => new { e.ConfigCode, e.ConfigKey });

            entity.ToTable("Mas_AccConfig");

            entity.Property(e => e.ConfigCode).HasMaxLength(50);
            entity.Property(e => e.ConfigKey).HasMaxLength(50);
        });

        modelBuilder.Entity<Mas_AccType>(entity =>
        {
            entity.HasKey(e => e.AccTypeID);

            entity.ToTable("Mas_AccType");

            entity.Property(e => e.AccSide)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.AccType)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.AccTypeName).HasMaxLength(255);
            entity.Property(e => e.AccTypeNameEN).HasMaxLength(255);
        });

        modelBuilder.Entity<Mas_Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId);

            entity.ToTable("Mas_Company");

            entity.Property(e => e.CompanyName).HasMaxLength(255);
            entity.Property(e => e.CompanyNameEN).HasMaxLength(255);
            entity.Property(e => e.CompanyTaxBranch).HasMaxLength(5);
            entity.Property(e => e.CompanyTaxId).HasMaxLength(50);
            entity.Property(e => e.CountryCode)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Mas_Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerID);

            entity.ToTable("Mas_Customer");

            entity.Property(e => e.Contact).HasMaxLength(255);
            entity.Property(e => e.CountryCode).HasMaxLength(5);
            entity.Property(e => e.CustomerCode).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FaxNumber).HasMaxLength(30);
            entity.Property(e => e.GLAccountCode).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(30);
            entity.Property(e => e.TaxBranch).HasMaxLength(10);
            entity.Property(e => e.TaxNumber).HasMaxLength(13);
            entity.Property(e => e.WebLink).HasMaxLength(255);
            entity.Property(e => e.ZIPCode).HasMaxLength(50);
        });

        modelBuilder.Entity<Mas_Department>(entity =>
        {
            entity.HasKey(e => e.DPID);

            entity.ToTable("Mas_Department");

            entity.Property(e => e.DPCODE).HasMaxLength(50);
            entity.Property(e => e.Department).HasMaxLength(255);
            entity.Property(e => e.EFullName).HasMaxLength(255);
            entity.Property(e => e.EShortName).HasMaxLength(50);
            entity.Property(e => e.TFullName).HasMaxLength(255);
            entity.Property(e => e.TShortName).HasMaxLength(50);
        });

        modelBuilder.Entity<Mas_DocConfig>(entity =>
        {
            entity.HasKey(e => e.DocConfigID);

            entity.ToTable("Mas_DocConfig");

            entity.Property(e => e.Category).HasMaxLength(2);
            entity.Property(e => e.EName).HasMaxLength(255);
            entity.Property(e => e.Number).HasMaxLength(15);
            entity.Property(e => e.Prefix).HasMaxLength(2);
            entity.Property(e => e.TName).HasMaxLength(255);
        });

        modelBuilder.Entity<Mas_DocConfigSchema>(entity =>
        {
            entity.HasKey(e => new { e.DocConfigID, e.ConfigType }).HasName("PK_Acc_DocConfigSchema");

            entity.ToTable("Mas_DocConfigSchema");

            entity.Property(e => e.Field1).HasMaxLength(500);
            entity.Property(e => e.Field10).HasMaxLength(500);
            entity.Property(e => e.Field11).HasMaxLength(500);
            entity.Property(e => e.Field12).HasMaxLength(500);
            entity.Property(e => e.Field13).HasMaxLength(500);
            entity.Property(e => e.Field14).HasMaxLength(500);
            entity.Property(e => e.Field15).HasMaxLength(500);
            entity.Property(e => e.Field16).HasMaxLength(500);
            entity.Property(e => e.Field17).HasMaxLength(500);
            entity.Property(e => e.Field18).HasMaxLength(500);
            entity.Property(e => e.Field19).HasMaxLength(500);
            entity.Property(e => e.Field2).HasMaxLength(500);
            entity.Property(e => e.Field20).HasMaxLength(500);
            entity.Property(e => e.Field3).HasMaxLength(500);
            entity.Property(e => e.Field4).HasMaxLength(500);
            entity.Property(e => e.Field5).HasMaxLength(500);
            entity.Property(e => e.Field6).HasMaxLength(500);
            entity.Property(e => e.Field7).HasMaxLength(500);
            entity.Property(e => e.Field8).HasMaxLength(500);
            entity.Property(e => e.Field9).HasMaxLength(500);
        });

        modelBuilder.Entity<Mas_HRDepartment>(entity =>
        {
            entity.HasKey(e => e.DepartmentId);

            entity.ToTable("Mas_HRDepartment");

            entity.Property(e => e.DepartmentName).HasMaxLength(255);
            entity.Property(e => e.DepartmentNameEN).HasMaxLength(255);
        });

        modelBuilder.Entity<Mas_HRDivision>(entity =>
        {
            entity.HasKey(e => e.DivisionId);

            entity.ToTable("Mas_HRDivision");

            entity.Property(e => e.DivisionName).HasMaxLength(255);
            entity.Property(e => e.DivisionNameEN).HasMaxLength(255);
        });

        modelBuilder.Entity<Mas_HREmployment>(entity =>
        {
            entity.HasKey(e => new { e.CompanyId, e.PositionId, e.StaffId });

            entity.ToTable("Mas_HREmployment");

            entity.Property(e => e.AssignmentDate).HasColumnType("datetime");
            entity.Property(e => e.BeginDate).HasColumnType("datetime");
            entity.Property(e => e.ContractId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Mas_HRLevel>(entity =>
        {
            entity.HasKey(e => e.LevelId);

            entity.ToTable("Mas_HRLevel");

            entity.Property(e => e.LevelName).HasMaxLength(50);
            entity.Property(e => e.LevelNameEN).HasMaxLength(50);
        });

        modelBuilder.Entity<Mas_HRPosition>(entity =>
        {
            entity.HasKey(e => e.PositionId);

            entity.ToTable("Mas_HRPosition");

            entity.Property(e => e.PositionName).HasMaxLength(255);
            entity.Property(e => e.PositionNameEN).HasMaxLength(255);
        });

        modelBuilder.Entity<Mas_HRStaff>(entity =>
        {
            entity.HasKey(e => e.StaffId);

            entity.ToTable("Mas_HRStaff");

            entity.Property(e => e.Nationality)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.StaffAddrZipcode).HasMaxLength(50);
            entity.Property(e => e.StaffCitizenID).HasMaxLength(50);
            entity.Property(e => e.StaffCitizenIDExpireDate).HasColumnType("datetime");
            entity.Property(e => e.StaffCode).HasMaxLength(50);
            entity.Property(e => e.StaffLastName).HasMaxLength(50);
            entity.Property(e => e.StaffLastNameEN).HasMaxLength(50);
            entity.Property(e => e.StaffMiddleName).HasMaxLength(50);
            entity.Property(e => e.StaffName).HasMaxLength(50);
            entity.Property(e => e.StaffNameEN).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(50);
            entity.Property(e => e.TitleEN)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Mas_Module>(entity =>
        {
            entity.HasKey(e => e.ModuleID);

            entity.ToTable("Mas_Module");

            entity.Property(e => e.ModuleID)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModuleName).HasMaxLength(500);
            entity.Property(e => e.ModuleNameEN).HasMaxLength(500);
        });

        modelBuilder.Entity<Mas_ModuleMenu>(entity =>
        {
            entity.HasKey(e => new { e.ModuleID, e.MenuID });

            entity.ToTable("Mas_ModuleMenu");

            entity.Property(e => e.ModuleID).HasMaxLength(50);
            entity.Property(e => e.MenuID).HasMaxLength(50);
            entity.Property(e => e.HeadMenuID).HasMaxLength(50);
            entity.Property(e => e.MenuName).HasMaxLength(500);
            entity.Property(e => e.MenuNameEN).HasMaxLength(500);
            entity.Property(e => e.WebAddress).HasMaxLength(500);
        });

        modelBuilder.Entity<Mas_Product>(entity =>
        {
            entity.HasKey(e => e.ProductID);

            entity.Property(e => e.Brand).HasMaxLength(255);
            entity.Property(e => e.Color).HasMaxLength(30);
            entity.Property(e => e.ProductCode).HasMaxLength(50);
            entity.Property(e => e.ProductName).HasMaxLength(255);
            entity.Property(e => e.ProductTypeCode).HasMaxLength(50);
            entity.Property(e => e.SizeUnit).HasMaxLength(30);
            entity.Property(e => e.UnitStock).HasMaxLength(50);
            entity.Property(e => e.Volume).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.VolumeUnit).HasMaxLength(30);
        });

        modelBuilder.Entity<Mas_ProductSetDT>(entity =>
        {
            entity.HasKey(e => e.ProductSetDTID);

            entity.ToTable("Mas_ProductSetDT");

            entity.Property(e => e.ItemNo).HasDefaultValueSql("((1))");
            entity.Property(e => e.ProductCode).HasMaxLength(50);
            entity.Property(e => e.ProductSetCode).HasMaxLength(50);
            entity.Property(e => e.UnitStock).HasMaxLength(50);
        });

        modelBuilder.Entity<Mas_ProductSetHD>(entity =>
        {
            entity.HasKey(e => e.ProductSetHDID);

            entity.ToTable("Mas_ProductSetHD");

            entity.Property(e => e.ExpenseAccCode).HasMaxLength(10);
            entity.Property(e => e.IncomeAccCode).HasMaxLength(10);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.ProductSetCode).HasMaxLength(50);
            entity.Property(e => e.PromoCode).HasMaxLength(50);
            entity.Property(e => e.SalesCurrency).HasMaxLength(10);
            entity.Property(e => e.SalesPrice).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.SalesRate)
                .HasDefaultValueSql("((1))")
                .HasColumnType("decimal(18, 10)");
            entity.Property(e => e.UnitStock).HasMaxLength(50);
        });

        modelBuilder.Entity<Mas_ProductType>(entity =>
        {
            entity.HasKey(e => e.ProductTypeID);

            entity.ToTable("Mas_ProductType");

            entity.HasIndex(e => e.ProductTypeCode, "IX_Mas_ProductType").IsUnique();

            entity.Property(e => e.ProductTypeCode).HasMaxLength(50);
            entity.Property(e => e.ProductTypeName).HasMaxLength(100);
            entity.Property(e => e.RateVat).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.RateWht).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.VatType).HasMaxLength(1);
            entity.Property(e => e.WarehouseCode).HasMaxLength(50);

            entity.HasOne(d => d.WarehouseCodeNavigation).WithMany(p => p.Mas_ProductTypes)
                .HasPrincipalKey(p => p.WarehouseCode)
                .HasForeignKey(d => d.WarehouseCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mas_ProductType_Mas_Warehouse");
        });

        modelBuilder.Entity<Mas_Promotion>(entity =>
        {
            entity.HasKey(e => e.PromoCodeID);

            entity.HasIndex(e => e.PromoCode, "IX_Mas_Promotions").IsUnique();

            entity.Property(e => e.DiscountCash).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ExpenseAccCode).HasMaxLength(10);
            entity.Property(e => e.PercentDiscountRate).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.PromoCode).HasMaxLength(50);
            entity.Property(e => e.PromoName).HasMaxLength(255);
        });

        modelBuilder.Entity<Mas_SalesProductDT>(entity =>
        {
            entity.HasKey(e => e.SalesProductIDDT);

            entity.ToTable("Mas_SalesProductDT");

            entity.Property(e => e.ProductSetCode).HasMaxLength(50);
            entity.Property(e => e.SalesItemNo).HasDefaultValueSql("((1))");
            entity.Property(e => e.SalesProductCode).HasMaxLength(50);
        });

        modelBuilder.Entity<Mas_SalesProductHD>(entity =>
        {
            entity.HasKey(e => e.SalesProductIDHD).HasName("PK_Mas_SalesProduct");

            entity.ToTable("Mas_SalesProductHD");

            entity.HasIndex(e => e.SalesProductCode, "IX_Mas_SalesProductHD").IsUnique();

            entity.Property(e => e.BeginSalesDate).HasColumnType("date");
            entity.Property(e => e.EndSalesDate).HasColumnType("date");
            entity.Property(e => e.SalesProductCode).HasMaxLength(50);
            entity.Property(e => e.SalesProductName).HasMaxLength(255);
        });

        modelBuilder.Entity<Mas_Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierID);

            entity.ToTable("Mas_Supplier");

            entity.Property(e => e.Contact).HasMaxLength(255);
            entity.Property(e => e.CountryCode).HasMaxLength(5);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FaxNumber).HasMaxLength(30);
            entity.Property(e => e.GLAccountCode).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(30);
            entity.Property(e => e.SupplierCode).HasMaxLength(50);
            entity.Property(e => e.TaxBranch).HasMaxLength(10);
            entity.Property(e => e.TaxNumber).HasMaxLength(13);
            entity.Property(e => e.WebLink).HasMaxLength(255);
            entity.Property(e => e.ZIPCode).HasMaxLength(50);
        });

        modelBuilder.Entity<Mas_User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Mas_User__3214EC07870F3698");

            entity.ToTable("Mas_User");

            entity.HasIndex(e => e.Username, "UQ__Mas_User__536C85E48E815843").IsUnique();

            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<Mas_UserRole>(entity =>
        {
            entity.HasKey(e => e.RoleID);

            entity.ToTable("Mas_UserRole");

            entity.Property(e => e.RoleID).HasMaxLength(50);
        });

        modelBuilder.Entity<Mas_UserRoleAssign>(entity =>
        {
            entity.HasKey(e => new { e.RoleID, e.UserID });

            entity.ToTable("Mas_UserRoleAssign");

            entity.Property(e => e.RoleID)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.UserID)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.LastUpdate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Mas_UserRoleAuthor>(entity =>
        {
            entity.HasKey(e => new { e.RoleID, e.ModuleID, e.MenuID });

            entity.ToTable("Mas_UserRoleAuthor");

            entity.Property(e => e.RoleID).HasMaxLength(50);
            entity.Property(e => e.ModuleID).HasMaxLength(50);
            entity.Property(e => e.MenuID).HasMaxLength(50);
            entity.Property(e => e.Author).HasMaxLength(50);
        });

        modelBuilder.Entity<Mas_Warehouse>(entity =>
        {
            entity.HasKey(e => e.WarehouseID).HasName("PK_Mas_Warehouses");

            entity.ToTable("Mas_Warehouse");

            entity.HasIndex(e => e.WarehouseCode, "IX_Mas_Warehouse").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.AssetAccCode).HasMaxLength(10);
            entity.Property(e => e.ExpenseAccCode).HasMaxLength(10);
            entity.Property(e => e.IncomeAccCode).HasMaxLength(10);
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.WarehouseCode).HasMaxLength(50);
        });

        modelBuilder.Entity<vAP_D>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vAP_D");

            entity.Property(e => e.AccBatchDate).HasColumnType("date");
            entity.Property(e => e.AccDocNo).HasMaxLength(50);
            entity.Property(e => e.AccDocType).HasMaxLength(50);
            entity.Property(e => e.AccEffectiveDate).HasColumnType("date");
            entity.Property(e => e.AccPostDate).HasColumnType("date");
            entity.Property(e => e.AccSourceDocNo).HasMaxLength(50);
            entity.Property(e => e.AssetAccCode).HasMaxLength(10);
            entity.Property(e => e.AssetAccMainCode).HasMaxLength(50);
            entity.Property(e => e.AssetAccMainName).HasMaxLength(255);
            entity.Property(e => e.AssetAccMainNameEN).HasMaxLength(255);
            entity.Property(e => e.AssetAccName).HasMaxLength(255);
            entity.Property(e => e.AssetAccNameEN).HasMaxLength(255);
            entity.Property(e => e.AssetAccSide)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.AssetAccType)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.AssetAccTypeName).HasMaxLength(255);
            entity.Property(e => e.AssetAccTypeNameEN).HasMaxLength(255);
            entity.Property(e => e.Currency).HasMaxLength(50);
            entity.Property(e => e.DocRefNo).HasMaxLength(50);
            entity.Property(e => e.ExpenseAccCode).HasMaxLength(10);
            entity.Property(e => e.ExpenseAccMainCode).HasMaxLength(50);
            entity.Property(e => e.ExpenseAccMainName).HasMaxLength(255);
            entity.Property(e => e.ExpenseAccMainNameEN).HasMaxLength(255);
            entity.Property(e => e.ExpenseAccName).HasMaxLength(255);
            entity.Property(e => e.ExpenseAccNameEN).HasMaxLength(255);
            entity.Property(e => e.ExpenseAccSide)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.ExpenseAccType)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ExpenseAccTypeName).HasMaxLength(255);
            entity.Property(e => e.ExpenseAccTypeNameEN).HasMaxLength(255);
            entity.Property(e => e.FiscalYear).HasColumnType("date");
            entity.Property(e => e.IncomeAccCode).HasMaxLength(10);
            entity.Property(e => e.IncomeAccMainCode).HasMaxLength(50);
            entity.Property(e => e.IncomeAccMainName).HasMaxLength(255);
            entity.Property(e => e.IncomeAccMainNameEN).HasMaxLength(255);
            entity.Property(e => e.IncomeAccName).HasMaxLength(255);
            entity.Property(e => e.IncomeAccNameEN).HasMaxLength(255);
            entity.Property(e => e.IncomeAccSide)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.IncomeAccType)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.IncomeAccTypeName).HasMaxLength(255);
            entity.Property(e => e.IncomeAccTypeNameEN).HasMaxLength(255);
            entity.Property(e => e.IssueBy).HasMaxLength(50);
            entity.Property(e => e.PartyAddress).HasMaxLength(255);
            entity.Property(e => e.PartyCode).HasMaxLength(50);
            entity.Property(e => e.PartyName).HasMaxLength(255);
            entity.Property(e => e.PartyTaxCode).HasMaxLength(50);
            entity.Property(e => e.ProductBrand).HasMaxLength(255);
            entity.Property(e => e.ProductCode).HasMaxLength(50);
            entity.Property(e => e.ProductColor).HasMaxLength(30);
            entity.Property(e => e.ProductName).HasMaxLength(255);
            entity.Property(e => e.ProductSizeUnit).HasMaxLength(30);
            entity.Property(e => e.ProductTypeCode).HasMaxLength(50);
            entity.Property(e => e.ProductTypeName).HasMaxLength(100);
            entity.Property(e => e.ProductVolume).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.ProductVolumeUnit).HasMaxLength(30);
            entity.Property(e => e.RateVat).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.RateWht).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.SaleProductCode).HasMaxLength(50);
            entity.Property(e => e.SalesDescription).HasMaxLength(255);
            entity.Property(e => e.UnitMea).HasMaxLength(50);
            entity.Property(e => e.UnitStock).HasMaxLength(50);
            entity.Property(e => e.VatType).HasMaxLength(1);
            entity.Property(e => e.WarehouseAddress).HasMaxLength(255);
            entity.Property(e => e.WarehouseCode).HasMaxLength(50);
            entity.Property(e => e.WarehouseLocation).HasMaxLength(255);
            entity.Property(e => e.WarehouseName).HasMaxLength(255);
        });

        modelBuilder.Entity<vAP_H>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vAP_H");

            entity.Property(e => e.AccBatchDate).HasColumnType("date");
            entity.Property(e => e.AccDocNo).HasMaxLength(50);
            entity.Property(e => e.AccDocType).HasMaxLength(50);
            entity.Property(e => e.AccEffectiveDate).HasColumnType("date");
            entity.Property(e => e.AccPostDate).HasColumnType("date");
            entity.Property(e => e.DocRefNo).HasMaxLength(50);
            entity.Property(e => e.FiscalYear).HasColumnType("date");
            entity.Property(e => e.IssueBy).HasMaxLength(50);
            entity.Property(e => e.PartyAddress).HasMaxLength(255);
            entity.Property(e => e.PartyCode).HasMaxLength(50);
            entity.Property(e => e.PartyName).HasMaxLength(255);
            entity.Property(e => e.PartyTaxCode).HasMaxLength(50);
        });

        modelBuilder.Entity<vAR_D>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vAR_D");

            entity.Property(e => e.AccBatchDate).HasColumnType("date");
            entity.Property(e => e.AccDocNo).HasMaxLength(50);
            entity.Property(e => e.AccDocType).HasMaxLength(50);
            entity.Property(e => e.AccEffectiveDate).HasColumnType("date");
            entity.Property(e => e.AccPostDate).HasColumnType("date");
            entity.Property(e => e.AccSourceDocNo).HasMaxLength(50);
            entity.Property(e => e.AssetAccCode).HasMaxLength(10);
            entity.Property(e => e.AssetAccMainCode).HasMaxLength(50);
            entity.Property(e => e.AssetAccMainName).HasMaxLength(255);
            entity.Property(e => e.AssetAccMainNameEN).HasMaxLength(255);
            entity.Property(e => e.AssetAccName).HasMaxLength(255);
            entity.Property(e => e.AssetAccNameEN).HasMaxLength(255);
            entity.Property(e => e.AssetAccSide)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.AssetAccType)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.AssetAccTypeName).HasMaxLength(255);
            entity.Property(e => e.AssetAccTypeNameEN).HasMaxLength(255);
            entity.Property(e => e.Currency).HasMaxLength(50);
            entity.Property(e => e.DocRefNo).HasMaxLength(50);
            entity.Property(e => e.ExpenseAccCode).HasMaxLength(10);
            entity.Property(e => e.ExpenseAccMainCode).HasMaxLength(50);
            entity.Property(e => e.ExpenseAccMainName).HasMaxLength(255);
            entity.Property(e => e.ExpenseAccMainNameEN).HasMaxLength(255);
            entity.Property(e => e.ExpenseAccName).HasMaxLength(255);
            entity.Property(e => e.ExpenseAccNameEN).HasMaxLength(255);
            entity.Property(e => e.ExpenseAccSide)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.ExpenseAccType)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ExpenseAccTypeName).HasMaxLength(255);
            entity.Property(e => e.ExpenseAccTypeNameEN).HasMaxLength(255);
            entity.Property(e => e.FiscalYear).HasColumnType("date");
            entity.Property(e => e.IncomeAccCode).HasMaxLength(10);
            entity.Property(e => e.IncomeAccMainCode).HasMaxLength(50);
            entity.Property(e => e.IncomeAccMainName).HasMaxLength(255);
            entity.Property(e => e.IncomeAccMainNameEN).HasMaxLength(255);
            entity.Property(e => e.IncomeAccName).HasMaxLength(255);
            entity.Property(e => e.IncomeAccNameEN).HasMaxLength(255);
            entity.Property(e => e.IncomeAccSide)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.IncomeAccType)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.IncomeAccTypeName).HasMaxLength(255);
            entity.Property(e => e.IncomeAccTypeNameEN).HasMaxLength(255);
            entity.Property(e => e.IssueBy).HasMaxLength(50);
            entity.Property(e => e.PartyAddress).HasMaxLength(255);
            entity.Property(e => e.PartyCode).HasMaxLength(50);
            entity.Property(e => e.PartyName).HasMaxLength(255);
            entity.Property(e => e.PartyTaxCode).HasMaxLength(50);
            entity.Property(e => e.ProductBrand).HasMaxLength(255);
            entity.Property(e => e.ProductCode).HasMaxLength(50);
            entity.Property(e => e.ProductColor).HasMaxLength(30);
            entity.Property(e => e.ProductName).HasMaxLength(255);
            entity.Property(e => e.ProductSizeUnit).HasMaxLength(30);
            entity.Property(e => e.ProductTypeCode).HasMaxLength(50);
            entity.Property(e => e.ProductTypeName).HasMaxLength(100);
            entity.Property(e => e.ProductVolume).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.ProductVolumeUnit).HasMaxLength(30);
            entity.Property(e => e.RateVat).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.RateWht).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.SaleProductCode).HasMaxLength(50);
            entity.Property(e => e.SalesDescription).HasMaxLength(255);
            entity.Property(e => e.UnitMea).HasMaxLength(50);
            entity.Property(e => e.UnitStock).HasMaxLength(50);
            entity.Property(e => e.VatType).HasMaxLength(1);
            entity.Property(e => e.WarehouseAddress).HasMaxLength(255);
            entity.Property(e => e.WarehouseCode).HasMaxLength(50);
            entity.Property(e => e.WarehouseLocation).HasMaxLength(255);
            entity.Property(e => e.WarehouseName).HasMaxLength(255);
        });

        modelBuilder.Entity<vAR_H>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vAR_H");

            entity.Property(e => e.AccBatchDate).HasColumnType("date");
            entity.Property(e => e.AccDocNo).HasMaxLength(50);
            entity.Property(e => e.AccDocType).HasMaxLength(50);
            entity.Property(e => e.AccEffectiveDate).HasColumnType("date");
            entity.Property(e => e.AccPostDate).HasColumnType("date");
            entity.Property(e => e.DocRefNo).HasMaxLength(50);
            entity.Property(e => e.FiscalYear).HasColumnType("date");
            entity.Property(e => e.IssueBy).HasMaxLength(50);
            entity.Property(e => e.PartyAddress).HasMaxLength(255);
            entity.Property(e => e.PartyCode).HasMaxLength(50);
            entity.Property(e => e.PartyName).HasMaxLength(255);
            entity.Property(e => e.PartyTaxCode).HasMaxLength(50);
        });

        modelBuilder.Entity<vJournal_All>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vJournal_All");

            entity.Property(e => e.AccCode).HasMaxLength(50);
            entity.Property(e => e.AccMainCode).HasMaxLength(50);
            entity.Property(e => e.AccMainCodeName).HasMaxLength(255);
            entity.Property(e => e.AccName).HasMaxLength(255);
            entity.Property(e => e.AccRemark).HasMaxLength(255);
            entity.Property(e => e.Credit).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.DDate1).HasColumnType("datetime");
            entity.Property(e => e.DDate10).HasColumnType("datetime");
            entity.Property(e => e.DDate2).HasColumnType("datetime");
            entity.Property(e => e.DDate3).HasColumnType("datetime");
            entity.Property(e => e.DDate4).HasColumnType("datetime");
            entity.Property(e => e.DDate5).HasColumnType("datetime");
            entity.Property(e => e.DDate6).HasColumnType("datetime");
            entity.Property(e => e.DDate7).HasColumnType("datetime");
            entity.Property(e => e.DDate8).HasColumnType("datetime");
            entity.Property(e => e.DDate9).HasColumnType("datetime");
            entity.Property(e => e.DText1)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText10)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText2)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText3)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText4)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText5)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText6)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText7)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText8)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText9)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Date1).HasColumnType("datetime");
            entity.Property(e => e.Date10).HasColumnType("datetime");
            entity.Property(e => e.Date2).HasColumnType("datetime");
            entity.Property(e => e.Date3).HasColumnType("datetime");
            entity.Property(e => e.Date4).HasColumnType("datetime");
            entity.Property(e => e.Date5).HasColumnType("datetime");
            entity.Property(e => e.Date6).HasColumnType("datetime");
            entity.Property(e => e.Date7).HasColumnType("datetime");
            entity.Property(e => e.Date8).HasColumnType("datetime");
            entity.Property(e => e.Date9).HasColumnType("datetime");
            entity.Property(e => e.Debit).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.DocNo).HasMaxLength(50);
            entity.Property(e => e.EffectiveDate).HasColumnType("datetime");
            entity.Property(e => e.EntryBy).HasMaxLength(50);
            entity.Property(e => e.EntryDate).HasColumnType("datetime");
            entity.Property(e => e.JournalNo).HasMaxLength(50);
            entity.Property(e => e.Text1)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text10)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text2)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text3)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text4)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text5)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text6)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text7)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text8)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text9)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.TotalCredit).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.TotalDebit).HasColumnType("decimal(18, 10)");
        });

        modelBuilder.Entity<vJournal_D>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vJournal_D");

            entity.Property(e => e.AccCode).HasMaxLength(50);
            entity.Property(e => e.AccName).HasMaxLength(255);
            entity.Property(e => e.Credit).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.DDate1).HasColumnType("datetime");
            entity.Property(e => e.DDate10).HasColumnType("datetime");
            entity.Property(e => e.DDate2).HasColumnType("datetime");
            entity.Property(e => e.DDate3).HasColumnType("datetime");
            entity.Property(e => e.DDate4).HasColumnType("datetime");
            entity.Property(e => e.DDate5).HasColumnType("datetime");
            entity.Property(e => e.DDate6).HasColumnType("datetime");
            entity.Property(e => e.DDate7).HasColumnType("datetime");
            entity.Property(e => e.DDate8).HasColumnType("datetime");
            entity.Property(e => e.DDate9).HasColumnType("datetime");
            entity.Property(e => e.DText1)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText10)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText2)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText3)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText4)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText5)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText6)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText7)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText8)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText9)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Debit).HasColumnType("decimal(18, 10)");
        });

        modelBuilder.Entity<vJournal_H>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vJournal_H");

            entity.Property(e => e.Date1).HasColumnType("datetime");
            entity.Property(e => e.Date10).HasColumnType("datetime");
            entity.Property(e => e.Date2).HasColumnType("datetime");
            entity.Property(e => e.Date3).HasColumnType("datetime");
            entity.Property(e => e.Date4).HasColumnType("datetime");
            entity.Property(e => e.Date5).HasColumnType("datetime");
            entity.Property(e => e.Date6).HasColumnType("datetime");
            entity.Property(e => e.Date7).HasColumnType("datetime");
            entity.Property(e => e.Date8).HasColumnType("datetime");
            entity.Property(e => e.Date9).HasColumnType("datetime");
            entity.Property(e => e.DocNo).HasMaxLength(50);
            entity.Property(e => e.EffectiveDate).HasColumnType("datetime");
            entity.Property(e => e.EntryBy).HasMaxLength(50);
            entity.Property(e => e.EntryDate).HasColumnType("datetime");
            entity.Property(e => e.JournalNo).HasMaxLength(50);
            entity.Property(e => e.Text1)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text10)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text2)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text3)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text4)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text5)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text6)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text7)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text8)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text9)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.TotalCredit).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.TotalDebit).HasColumnType("decimal(18, 10)");
        });

        modelBuilder.Entity<vMas_AccCode>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vMas_AccCode");

            entity.Property(e => e.AccCode).HasMaxLength(50);
            entity.Property(e => e.AccMainCode).HasMaxLength(50);
            entity.Property(e => e.AccMainName).HasMaxLength(255);
            entity.Property(e => e.AccMainNameEN).HasMaxLength(255);
            entity.Property(e => e.AccName).HasMaxLength(255);
            entity.Property(e => e.AccNameEN).HasMaxLength(255);
            entity.Property(e => e.AccSide)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.AccType)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.AccTypeName).HasMaxLength(255);
            entity.Property(e => e.AccTypeNameEN).HasMaxLength(255);
        });

        modelBuilder.Entity<vMas_Product>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vMas_Product");

            entity.Property(e => e.AssetAccCode).HasMaxLength(10);
            entity.Property(e => e.AssetAccMainCode).HasMaxLength(50);
            entity.Property(e => e.AssetAccMainName).HasMaxLength(255);
            entity.Property(e => e.AssetAccMainNameEN).HasMaxLength(255);
            entity.Property(e => e.AssetAccName).HasMaxLength(255);
            entity.Property(e => e.AssetAccNameEN).HasMaxLength(255);
            entity.Property(e => e.AssetAccSide)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.AssetAccType)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.AssetAccTypeName).HasMaxLength(255);
            entity.Property(e => e.AssetAccTypeNameEN).HasMaxLength(255);
            entity.Property(e => e.ExpenseAccCode).HasMaxLength(10);
            entity.Property(e => e.ExpenseAccMainCode).HasMaxLength(50);
            entity.Property(e => e.ExpenseAccMainName).HasMaxLength(255);
            entity.Property(e => e.ExpenseAccMainNameEN).HasMaxLength(255);
            entity.Property(e => e.ExpenseAccName).HasMaxLength(255);
            entity.Property(e => e.ExpenseAccNameEN).HasMaxLength(255);
            entity.Property(e => e.ExpenseAccSide)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.ExpenseAccType)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ExpenseAccTypeName).HasMaxLength(255);
            entity.Property(e => e.ExpenseAccTypeNameEN).HasMaxLength(255);
            entity.Property(e => e.IncomeAccCode).HasMaxLength(10);
            entity.Property(e => e.IncomeAccMainCode).HasMaxLength(50);
            entity.Property(e => e.IncomeAccMainName).HasMaxLength(255);
            entity.Property(e => e.IncomeAccMainNameEN).HasMaxLength(255);
            entity.Property(e => e.IncomeAccName).HasMaxLength(255);
            entity.Property(e => e.IncomeAccNameEN).HasMaxLength(255);
            entity.Property(e => e.IncomeAccSide)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.IncomeAccType)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.IncomeAccTypeName).HasMaxLength(255);
            entity.Property(e => e.IncomeAccTypeNameEN).HasMaxLength(255);
            entity.Property(e => e.ProductBrand).HasMaxLength(255);
            entity.Property(e => e.ProductCode).HasMaxLength(50);
            entity.Property(e => e.ProductColor).HasMaxLength(30);
            entity.Property(e => e.ProductName).HasMaxLength(255);
            entity.Property(e => e.ProductSizeUnit).HasMaxLength(30);
            entity.Property(e => e.ProductTypeCode).HasMaxLength(50);
            entity.Property(e => e.ProductTypeName).HasMaxLength(100);
            entity.Property(e => e.ProductVolume).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.ProductVolumeUnit).HasMaxLength(30);
            entity.Property(e => e.RateVat).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.RateWht).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.UnitStock).HasMaxLength(50);
            entity.Property(e => e.VatType).HasMaxLength(1);
            entity.Property(e => e.WarehouseAddress).HasMaxLength(255);
            entity.Property(e => e.WarehouseCode).HasMaxLength(50);
            entity.Property(e => e.WarehouseLocation).HasMaxLength(255);
            entity.Property(e => e.WarehouseName).HasMaxLength(255);
        });

        modelBuilder.Entity<vMas_ProductType>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vMas_ProductType");

            entity.Property(e => e.AssetAccCode).HasMaxLength(10);
            entity.Property(e => e.AssetAccMainCode).HasMaxLength(50);
            entity.Property(e => e.AssetAccMainName).HasMaxLength(255);
            entity.Property(e => e.AssetAccMainNameEN).HasMaxLength(255);
            entity.Property(e => e.AssetAccName).HasMaxLength(255);
            entity.Property(e => e.AssetAccNameEN).HasMaxLength(255);
            entity.Property(e => e.AssetAccSide)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.AssetAccType)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.AssetAccTypeName).HasMaxLength(255);
            entity.Property(e => e.AssetAccTypeNameEN).HasMaxLength(255);
            entity.Property(e => e.ExpenseAccCode).HasMaxLength(10);
            entity.Property(e => e.ExpenseAccMainCode).HasMaxLength(50);
            entity.Property(e => e.ExpenseAccMainName).HasMaxLength(255);
            entity.Property(e => e.ExpenseAccMainNameEN).HasMaxLength(255);
            entity.Property(e => e.ExpenseAccName).HasMaxLength(255);
            entity.Property(e => e.ExpenseAccNameEN).HasMaxLength(255);
            entity.Property(e => e.ExpenseAccSide)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.ExpenseAccType)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ExpenseAccTypeName).HasMaxLength(255);
            entity.Property(e => e.ExpenseAccTypeNameEN).HasMaxLength(255);
            entity.Property(e => e.IncomeAccCode).HasMaxLength(10);
            entity.Property(e => e.IncomeAccMainCode).HasMaxLength(50);
            entity.Property(e => e.IncomeAccMainName).HasMaxLength(255);
            entity.Property(e => e.IncomeAccMainNameEN).HasMaxLength(255);
            entity.Property(e => e.IncomeAccName).HasMaxLength(255);
            entity.Property(e => e.IncomeAccNameEN).HasMaxLength(255);
            entity.Property(e => e.IncomeAccSide)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.IncomeAccType)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.IncomeAccTypeName).HasMaxLength(255);
            entity.Property(e => e.IncomeAccTypeNameEN).HasMaxLength(255);
            entity.Property(e => e.ProductTypeCode).HasMaxLength(50);
            entity.Property(e => e.ProductTypeName).HasMaxLength(100);
            entity.Property(e => e.RateVat).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.RateWht).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.VatType).HasMaxLength(1);
            entity.Property(e => e.WarehouseAddress).HasMaxLength(255);
            entity.Property(e => e.WarehouseCode).HasMaxLength(50);
            entity.Property(e => e.WarehouseLocation).HasMaxLength(255);
            entity.Property(e => e.WarehouseName).HasMaxLength(255);
        });

        modelBuilder.Entity<vMas_Warehouse>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vMas_Warehouse");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.AssetAccCode).HasMaxLength(10);
            entity.Property(e => e.AssetAccMainCode).HasMaxLength(50);
            entity.Property(e => e.AssetAccMainName).HasMaxLength(255);
            entity.Property(e => e.AssetAccMainNameEN).HasMaxLength(255);
            entity.Property(e => e.AssetAccName).HasMaxLength(255);
            entity.Property(e => e.AssetAccNameEN).HasMaxLength(255);
            entity.Property(e => e.AssetAccSide)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.AssetAccType)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.AssetAccTypeName).HasMaxLength(255);
            entity.Property(e => e.AssetAccTypeNameEN).HasMaxLength(255);
            entity.Property(e => e.ExpenseAccCode).HasMaxLength(10);
            entity.Property(e => e.ExpenseAccMainCode).HasMaxLength(50);
            entity.Property(e => e.ExpenseAccMainName).HasMaxLength(255);
            entity.Property(e => e.ExpenseAccMainNameEN).HasMaxLength(255);
            entity.Property(e => e.ExpenseAccName).HasMaxLength(255);
            entity.Property(e => e.ExpenseAccNameEN).HasMaxLength(255);
            entity.Property(e => e.ExpenseAccSide)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.ExpenseAccType)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ExpenseAccTypeName).HasMaxLength(255);
            entity.Property(e => e.ExpenseAccTypeNameEN).HasMaxLength(255);
            entity.Property(e => e.IncomeAccCode).HasMaxLength(10);
            entity.Property(e => e.IncomeAccMainCode).HasMaxLength(50);
            entity.Property(e => e.IncomeAccMainName).HasMaxLength(255);
            entity.Property(e => e.IncomeAccMainNameEN).HasMaxLength(255);
            entity.Property(e => e.IncomeAccName).HasMaxLength(255);
            entity.Property(e => e.IncomeAccNameEN).HasMaxLength(255);
            entity.Property(e => e.IncomeAccSide)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.IncomeAccType)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.IncomeAccTypeName).HasMaxLength(255);
            entity.Property(e => e.IncomeAccTypeNameEN).HasMaxLength(255);
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.WarehouseCode).HasMaxLength(50);
        });

        modelBuilder.Entity<vPO_All>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vPO_All");

            entity.Property(e => e.AccBatchDate).HasColumnType("date");
            entity.Property(e => e.AccDocNo).HasMaxLength(50);
            entity.Property(e => e.AccDocType).HasMaxLength(50);
            entity.Property(e => e.AccEffectiveDate).HasColumnType("date");
            entity.Property(e => e.AccPostDate).HasColumnType("date");
            entity.Property(e => e.AccSourceDocNo).HasMaxLength(50);
            entity.Property(e => e.Currency).HasMaxLength(50);
            entity.Property(e => e.DocRefNo).HasMaxLength(50);
            entity.Property(e => e.FiscalYear).HasColumnType("date");
            entity.Property(e => e.IssueBy).HasMaxLength(50);
            entity.Property(e => e.PartyAddress).HasMaxLength(255);
            entity.Property(e => e.PartyCode).HasMaxLength(50);
            entity.Property(e => e.PartyName).HasMaxLength(255);
            entity.Property(e => e.PartyTaxCode).HasMaxLength(50);
            entity.Property(e => e.SaleProductCode).HasMaxLength(50);
            entity.Property(e => e.SalesDescription).HasMaxLength(255);
            entity.Property(e => e.UnitMea).HasMaxLength(50);
        });

        modelBuilder.Entity<vPO_Balance>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vPO_Balance");

            entity.Property(e => e.AccBatchDate).HasColumnType("date");
            entity.Property(e => e.AccDocNo).HasMaxLength(50);
            entity.Property(e => e.AccDocType).HasMaxLength(50);
            entity.Property(e => e.AccEffectiveDate).HasColumnType("date");
            entity.Property(e => e.AccPostDate).HasColumnType("date");
            entity.Property(e => e.AccSourceDocNo).HasMaxLength(50);
            entity.Property(e => e.Currency).HasMaxLength(50);
            entity.Property(e => e.DocRefNo).HasMaxLength(50);
            entity.Property(e => e.FiscalYear).HasColumnType("date");
            entity.Property(e => e.IssueBy).HasMaxLength(50);
            entity.Property(e => e.PartyAddress).HasMaxLength(255);
            entity.Property(e => e.PartyCode).HasMaxLength(50);
            entity.Property(e => e.PartyName).HasMaxLength(255);
            entity.Property(e => e.PartyTaxCode).HasMaxLength(50);
            entity.Property(e => e.SaleProductCode).HasMaxLength(50);
            entity.Property(e => e.SalesDescription).HasMaxLength(255);
            entity.Property(e => e.UnitMea).HasMaxLength(50);
        });

        modelBuilder.Entity<vPO_Delivery>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vPO_Delivery");

            entity.Property(e => e.AccBatchDate).HasColumnType("date");
            entity.Property(e => e.AccDocNo).HasMaxLength(50);
            entity.Property(e => e.AccDocType).HasMaxLength(50);
            entity.Property(e => e.AccEffectiveDate).HasColumnType("date");
            entity.Property(e => e.AccPostDate).HasColumnType("date");
            entity.Property(e => e.AccSourceDocNo).HasMaxLength(50);
            entity.Property(e => e.Currency).HasMaxLength(50);
            entity.Property(e => e.DocRefNo).HasMaxLength(50);
            entity.Property(e => e.FiscalYear).HasColumnType("date");
            entity.Property(e => e.IssueBy).HasMaxLength(50);
            entity.Property(e => e.PartyAddress).HasMaxLength(255);
            entity.Property(e => e.PartyCode).HasMaxLength(50);
            entity.Property(e => e.PartyName).HasMaxLength(255);
            entity.Property(e => e.PartyTaxCode).HasMaxLength(50);
            entity.Property(e => e.SaleProductCode).HasMaxLength(50);
            entity.Property(e => e.SalesDescription).HasMaxLength(255);
            entity.Property(e => e.UnitMea).HasMaxLength(50);
        });

        modelBuilder.Entity<vPR_All>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vPR_All");

            entity.Property(e => e.AccBatchDate).HasColumnType("date");
            entity.Property(e => e.AccDocNo).HasMaxLength(50);
            entity.Property(e => e.AccDocType).HasMaxLength(50);
            entity.Property(e => e.AccEffectiveDate).HasColumnType("date");
            entity.Property(e => e.AccPostDate).HasColumnType("date");
            entity.Property(e => e.AccSourceDocNo).HasMaxLength(50);
            entity.Property(e => e.Currency).HasMaxLength(50);
            entity.Property(e => e.DocRefNo).HasMaxLength(50);
            entity.Property(e => e.FiscalYear).HasColumnType("date");
            entity.Property(e => e.IssueBy).HasMaxLength(50);
            entity.Property(e => e.PartyAddress).HasMaxLength(255);
            entity.Property(e => e.PartyCode).HasMaxLength(50);
            entity.Property(e => e.PartyName).HasMaxLength(255);
            entity.Property(e => e.PartyTaxCode).HasMaxLength(50);
            entity.Property(e => e.SaleProductCode).HasMaxLength(50);
            entity.Property(e => e.SalesDescription).HasMaxLength(255);
            entity.Property(e => e.UnitMea).HasMaxLength(50);
        });

        modelBuilder.Entity<vPV_All>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vPV_All");

            entity.Property(e => e.AccCode).HasMaxLength(50);
            entity.Property(e => e.AccName).HasMaxLength(255);
            entity.Property(e => e.Credit).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.Debit).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.EffectiveDate).HasColumnType("datetime");
            entity.Property(e => e.EntryBy).HasMaxLength(50);
            entity.Property(e => e.EntryDate).HasColumnType("datetime");
            entity.Property(e => e.JournalNo).HasMaxLength(50);
            entity.Property(e => e.TotalCredit).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.TotalDebit).HasColumnType("decimal(18, 10)");
        });

        modelBuilder.Entity<vRV_All>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vRV_All");

            entity.Property(e => e.AccCode).HasMaxLength(50);
            entity.Property(e => e.AccName).HasMaxLength(255);
            entity.Property(e => e.Credit).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.Debit).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.EffectiveDate).HasColumnType("datetime");
            entity.Property(e => e.EntryBy).HasMaxLength(50);
            entity.Property(e => e.EntryDate).HasColumnType("datetime");
            entity.Property(e => e.JournalNo).HasMaxLength(50);
            entity.Property(e => e.TotalCredit).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.TotalDebit).HasColumnType("decimal(18, 10)");
        });

        modelBuilder.Entity<vSO_All>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vSO_All");

            entity.Property(e => e.AccBatchDate).HasColumnType("date");
            entity.Property(e => e.AccDocNo).HasMaxLength(50);
            entity.Property(e => e.AccDocType).HasMaxLength(50);
            entity.Property(e => e.AccEffectiveDate).HasColumnType("date");
            entity.Property(e => e.AccPostDate).HasColumnType("date");
            entity.Property(e => e.AccSourceDocNo).HasMaxLength(50);
            entity.Property(e => e.Currency).HasMaxLength(50);
            entity.Property(e => e.DocRefNo).HasMaxLength(50);
            entity.Property(e => e.FiscalYear).HasColumnType("date");
            entity.Property(e => e.IssueBy).HasMaxLength(50);
            entity.Property(e => e.PartyAddress).HasMaxLength(255);
            entity.Property(e => e.PartyCode).HasMaxLength(50);
            entity.Property(e => e.PartyName).HasMaxLength(255);
            entity.Property(e => e.PartyTaxCode).HasMaxLength(50);
            entity.Property(e => e.SaleProductCode).HasMaxLength(50);
            entity.Property(e => e.SalesDescription).HasMaxLength(255);
            entity.Property(e => e.UnitMea).HasMaxLength(50);
        });

        modelBuilder.Entity<vSO_Balance>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vSO_Balance");

            entity.Property(e => e.AccBatchDate).HasColumnType("date");
            entity.Property(e => e.AccDocNo).HasMaxLength(50);
            entity.Property(e => e.AccDocType).HasMaxLength(50);
            entity.Property(e => e.AccEffectiveDate).HasColumnType("date");
            entity.Property(e => e.AccPostDate).HasColumnType("date");
            entity.Property(e => e.AccSourceDocNo).HasMaxLength(50);
            entity.Property(e => e.Currency).HasMaxLength(50);
            entity.Property(e => e.DocRefNo).HasMaxLength(50);
            entity.Property(e => e.FiscalYear).HasColumnType("date");
            entity.Property(e => e.IssueBy).HasMaxLength(50);
            entity.Property(e => e.PartyAddress).HasMaxLength(255);
            entity.Property(e => e.PartyCode).HasMaxLength(50);
            entity.Property(e => e.PartyName).HasMaxLength(255);
            entity.Property(e => e.PartyTaxCode).HasMaxLength(50);
            entity.Property(e => e.SaleProductCode).HasMaxLength(50);
            entity.Property(e => e.SalesDescription).HasMaxLength(255);
            entity.Property(e => e.UnitMea).HasMaxLength(50);
        });

        modelBuilder.Entity<vSO_Delivery>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vSO_Delivery");

            entity.Property(e => e.AccBatchDate).HasColumnType("date");
            entity.Property(e => e.AccDocNo).HasMaxLength(50);
            entity.Property(e => e.AccDocType).HasMaxLength(50);
            entity.Property(e => e.AccEffectiveDate).HasColumnType("date");
            entity.Property(e => e.AccPostDate).HasColumnType("date");
            entity.Property(e => e.AccSourceDocNo).HasMaxLength(50);
            entity.Property(e => e.Currency).HasMaxLength(50);
            entity.Property(e => e.DocRefNo).HasMaxLength(50);
            entity.Property(e => e.FiscalYear).HasColumnType("date");
            entity.Property(e => e.IssueBy).HasMaxLength(50);
            entity.Property(e => e.PartyAddress).HasMaxLength(255);
            entity.Property(e => e.PartyCode).HasMaxLength(50);
            entity.Property(e => e.PartyName).HasMaxLength(255);
            entity.Property(e => e.PartyTaxCode).HasMaxLength(50);
            entity.Property(e => e.SaleProductCode).HasMaxLength(50);
            entity.Property(e => e.SalesDescription).HasMaxLength(255);
            entity.Property(e => e.UnitMea).HasMaxLength(50);
        });

        modelBuilder.Entity<vSR_All>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vSR_All");

            entity.Property(e => e.AccBatchDate).HasColumnType("date");
            entity.Property(e => e.AccDocNo).HasMaxLength(50);
            entity.Property(e => e.AccDocType).HasMaxLength(50);
            entity.Property(e => e.AccEffectiveDate).HasColumnType("date");
            entity.Property(e => e.AccPostDate).HasColumnType("date");
            entity.Property(e => e.AccSourceDocNo).HasMaxLength(50);
            entity.Property(e => e.Currency).HasMaxLength(50);
            entity.Property(e => e.DocRefNo).HasMaxLength(50);
            entity.Property(e => e.FiscalYear).HasColumnType("date");
            entity.Property(e => e.IssueBy).HasMaxLength(50);
            entity.Property(e => e.PartyAddress).HasMaxLength(255);
            entity.Property(e => e.PartyCode).HasMaxLength(50);
            entity.Property(e => e.PartyName).HasMaxLength(255);
            entity.Property(e => e.PartyTaxCode).HasMaxLength(50);
            entity.Property(e => e.SaleProductCode).HasMaxLength(50);
            entity.Property(e => e.SalesDescription).HasMaxLength(255);
            entity.Property(e => e.UnitMea).HasMaxLength(50);
        });

        modelBuilder.Entity<vStock_Card>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vStock_Card");

            entity.Property(e => e.AccBatchDate).HasColumnType("date");
            entity.Property(e => e.AccDocNo).HasMaxLength(50);
            entity.Property(e => e.AccDocType).HasMaxLength(50);
            entity.Property(e => e.AccEffectiveDate).HasColumnType("date");
            entity.Property(e => e.AccPostDate).HasColumnType("date");
            entity.Property(e => e.AccSourceDocNo).HasMaxLength(50);
            entity.Property(e => e.AssetAccCode).HasMaxLength(10);
            entity.Property(e => e.AssetAccMainCode).HasMaxLength(50);
            entity.Property(e => e.AssetAccMainName).HasMaxLength(255);
            entity.Property(e => e.AssetAccName).HasMaxLength(255);
            entity.Property(e => e.FiscalYear).HasColumnType("date");
            entity.Property(e => e.IssueBy).HasMaxLength(50);
            entity.Property(e => e.PartyAddress).HasMaxLength(255);
            entity.Property(e => e.PartyCode).HasMaxLength(50);
            entity.Property(e => e.PartyName).HasMaxLength(255);
            entity.Property(e => e.PartyTaxCode).HasMaxLength(50);
            entity.Property(e => e.ProductBrand).HasMaxLength(255);
            entity.Property(e => e.ProductColor).HasMaxLength(30);
            entity.Property(e => e.ProductName).HasMaxLength(255);
            entity.Property(e => e.SaleProductCode).HasMaxLength(50);
            entity.Property(e => e.SalesDescription).HasMaxLength(255);
            entity.Property(e => e.StockProductCode).HasMaxLength(50);
            entity.Property(e => e.TransAmount).HasColumnType("decimal(38, 10)");
            entity.Property(e => e.TransCurrency).HasMaxLength(10);
            entity.Property(e => e.TransPrice).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.TransRate).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.UnitStock).HasMaxLength(50);
            entity.Property(e => e.WarehouseCode).HasMaxLength(50);
        });

        modelBuilder.Entity<vStock_Onhand>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vStock_Onhand");

            entity.Property(e => e.AssetAccCode).HasMaxLength(10);
            entity.Property(e => e.AssetAccMainCode).HasMaxLength(50);
            entity.Property(e => e.AssetAccMainName).HasMaxLength(255);
            entity.Property(e => e.AssetAccName).HasMaxLength(255);
            entity.Property(e => e.AvgPrice).HasColumnType("decimal(38, 10)");
            entity.Property(e => e.ProductBrand).HasMaxLength(255);
            entity.Property(e => e.ProductColor).HasMaxLength(30);
            entity.Property(e => e.ProductName).HasMaxLength(255);
            entity.Property(e => e.StockProductCode).HasMaxLength(50);
            entity.Property(e => e.SumAmount).HasColumnType("decimal(38, 10)");
            entity.Property(e => e.UnitStock).HasMaxLength(50);
            entity.Property(e => e.WarehouseCode).HasMaxLength(50);
        });

        modelBuilder.Entity<vSum_AllType>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vSum_AllType");

            entity.Property(e => e.AccTypeName).HasMaxLength(255);
            entity.Property(e => e.Credit).HasColumnType("decimal(38, 10)");
            entity.Property(e => e.Debit).HasColumnType("decimal(38, 10)");
        });

        modelBuilder.Entity<vSum_Balance>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vSum_Balance");

            entity.Property(e => e.AccCode).HasMaxLength(50);
            entity.Property(e => e.AccName).HasMaxLength(255);
            entity.Property(e => e.AccType)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.AccTypeName).HasMaxLength(255);
            entity.Property(e => e.Credit).HasColumnType("decimal(38, 10)");
            entity.Property(e => e.Debit).HasColumnType("decimal(38, 10)");
        });

        modelBuilder.Entity<vSum_JournalByPrefix>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vSum_JournalByPrefix");

            entity.Property(e => e.AccCode).HasMaxLength(50);
            entity.Property(e => e.AccName).HasMaxLength(255);
            entity.Property(e => e.Cr).HasColumnType("decimal(38, 10)");
            entity.Property(e => e.Dr).HasColumnType("decimal(38, 10)");
            entity.Property(e => e.Header).HasMaxLength(6);
        });

        modelBuilder.Entity<vSum_JournalByType>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vSum_JournalByType");

            entity.Property(e => e.Header).HasMaxLength(6);
            entity.Property(e => e.NewDocNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TotalCredit).HasColumnType("decimal(38, 10)");
            entity.Property(e => e.TotalDebit).HasColumnType("decimal(38, 10)");
        });

        modelBuilder.Entity<vSum_Stock>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vSum_Stock");

            entity.Property(e => e.AssetAccCode).HasMaxLength(10);
            entity.Property(e => e.AssetAccName).HasMaxLength(255);
            entity.Property(e => e.AvgPrice).HasColumnType("decimal(38, 10)");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(38, 10)");
        });

        modelBuilder.Entity<vSum_StockByType>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vSum_StockByType");

            entity.Property(e => e.Header).HasMaxLength(6);
            entity.Property(e => e.TotalValue).HasColumnType("decimal(38, 10)");
        });

        modelBuilder.Entity<vSum_TransactionByType>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vSum_TransactionByType");

            entity.Property(e => e.Header).HasMaxLength(6);
            entity.Property(e => e.NewDocNo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<vTransaction_All>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vTransaction_All");

            entity.Property(e => e.AccBatchDate).HasColumnType("date");
            entity.Property(e => e.AccDocNo).HasMaxLength(50);
            entity.Property(e => e.AccDocType).HasMaxLength(50);
            entity.Property(e => e.AccEffectiveDate).HasColumnType("date");
            entity.Property(e => e.AccPostDate).HasColumnType("date");
            entity.Property(e => e.AccSourceDocNo).HasMaxLength(50);
            entity.Property(e => e.AssetAccCode).HasMaxLength(10);
            entity.Property(e => e.AssetAccMainCode).HasMaxLength(50);
            entity.Property(e => e.AssetAccMainName).HasMaxLength(255);
            entity.Property(e => e.AssetAccMainNameEN).HasMaxLength(255);
            entity.Property(e => e.AssetAccName).HasMaxLength(255);
            entity.Property(e => e.AssetAccNameEN).HasMaxLength(255);
            entity.Property(e => e.AssetAccSide)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.AssetAccType)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.AssetAccTypeName).HasMaxLength(255);
            entity.Property(e => e.AssetAccTypeNameEN).HasMaxLength(255);
            entity.Property(e => e.Currency).HasMaxLength(50);
            entity.Property(e => e.DDate1).HasColumnType("datetime");
            entity.Property(e => e.DDate10).HasColumnType("datetime");
            entity.Property(e => e.DDate2).HasColumnType("datetime");
            entity.Property(e => e.DDate3).HasColumnType("datetime");
            entity.Property(e => e.DDate4).HasColumnType("datetime");
            entity.Property(e => e.DDate5).HasColumnType("datetime");
            entity.Property(e => e.DDate6).HasColumnType("datetime");
            entity.Property(e => e.DDate7).HasColumnType("datetime");
            entity.Property(e => e.DDate8).HasColumnType("datetime");
            entity.Property(e => e.DDate9).HasColumnType("datetime");
            entity.Property(e => e.DText1)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText10)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText2)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText3)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText4)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText5)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText6)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText7)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText8)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText9)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Date1).HasColumnType("datetime");
            entity.Property(e => e.Date10).HasColumnType("datetime");
            entity.Property(e => e.Date2).HasColumnType("datetime");
            entity.Property(e => e.Date3).HasColumnType("datetime");
            entity.Property(e => e.Date4).HasColumnType("datetime");
            entity.Property(e => e.Date5).HasColumnType("datetime");
            entity.Property(e => e.Date6).HasColumnType("datetime");
            entity.Property(e => e.Date7).HasColumnType("datetime");
            entity.Property(e => e.Date8).HasColumnType("datetime");
            entity.Property(e => e.Date9).HasColumnType("datetime");
            entity.Property(e => e.DocNo).HasMaxLength(50);
            entity.Property(e => e.DocRefNo).HasMaxLength(50);
            entity.Property(e => e.ExpenseAccCode).HasMaxLength(10);
            entity.Property(e => e.ExpenseAccMainCode).HasMaxLength(50);
            entity.Property(e => e.ExpenseAccMainName).HasMaxLength(255);
            entity.Property(e => e.ExpenseAccMainNameEN).HasMaxLength(255);
            entity.Property(e => e.ExpenseAccName).HasMaxLength(255);
            entity.Property(e => e.ExpenseAccNameEN).HasMaxLength(255);
            entity.Property(e => e.ExpenseAccSide)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.ExpenseAccType)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ExpenseAccTypeName).HasMaxLength(255);
            entity.Property(e => e.ExpenseAccTypeNameEN).HasMaxLength(255);
            entity.Property(e => e.FiscalYear).HasColumnType("date");
            entity.Property(e => e.IncomeAccCode).HasMaxLength(10);
            entity.Property(e => e.IncomeAccMainCode).HasMaxLength(50);
            entity.Property(e => e.IncomeAccMainName).HasMaxLength(255);
            entity.Property(e => e.IncomeAccMainNameEN).HasMaxLength(255);
            entity.Property(e => e.IncomeAccName).HasMaxLength(255);
            entity.Property(e => e.IncomeAccNameEN).HasMaxLength(255);
            entity.Property(e => e.IncomeAccSide)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.IncomeAccType)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.IncomeAccTypeName).HasMaxLength(255);
            entity.Property(e => e.IncomeAccTypeNameEN).HasMaxLength(255);
            entity.Property(e => e.IssueBy).HasMaxLength(50);
            entity.Property(e => e.PartyAddress).HasMaxLength(255);
            entity.Property(e => e.PartyCode).HasMaxLength(50);
            entity.Property(e => e.PartyName).HasMaxLength(255);
            entity.Property(e => e.PartyTaxCode).HasMaxLength(50);
            entity.Property(e => e.ProductBrand).HasMaxLength(255);
            entity.Property(e => e.ProductCode).HasMaxLength(50);
            entity.Property(e => e.ProductColor).HasMaxLength(30);
            entity.Property(e => e.ProductName).HasMaxLength(255);
            entity.Property(e => e.ProductSizeUnit).HasMaxLength(30);
            entity.Property(e => e.ProductTypeCode).HasMaxLength(50);
            entity.Property(e => e.ProductTypeName).HasMaxLength(100);
            entity.Property(e => e.ProductVolume).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.ProductVolumeUnit).HasMaxLength(30);
            entity.Property(e => e.RateVat).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.RateWht).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.SaleProductCode).HasMaxLength(50);
            entity.Property(e => e.SalesDescription).HasMaxLength(255);
            entity.Property(e => e.Text1)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text10)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text2)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text3)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text4)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text5)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text6)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text7)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text8)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text9)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.UnitMea).HasMaxLength(50);
            entity.Property(e => e.UnitStock).HasMaxLength(50);
            entity.Property(e => e.VatType).HasMaxLength(1);
            entity.Property(e => e.WarehouseAddress).HasMaxLength(255);
            entity.Property(e => e.WarehouseCode).HasMaxLength(50);
            entity.Property(e => e.WarehouseLocation).HasMaxLength(255);
            entity.Property(e => e.WarehouseName).HasMaxLength(255);
        });

        modelBuilder.Entity<vTransaction_D>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vTransaction_D");

            entity.Property(e => e.AccSourceDocNo).HasMaxLength(50);
            entity.Property(e => e.Currency).HasMaxLength(50);
            entity.Property(e => e.DDate1).HasColumnType("datetime");
            entity.Property(e => e.DDate10).HasColumnType("datetime");
            entity.Property(e => e.DDate2).HasColumnType("datetime");
            entity.Property(e => e.DDate3).HasColumnType("datetime");
            entity.Property(e => e.DDate4).HasColumnType("datetime");
            entity.Property(e => e.DDate5).HasColumnType("datetime");
            entity.Property(e => e.DDate6).HasColumnType("datetime");
            entity.Property(e => e.DDate7).HasColumnType("datetime");
            entity.Property(e => e.DDate8).HasColumnType("datetime");
            entity.Property(e => e.DDate9).HasColumnType("datetime");
            entity.Property(e => e.DText1)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText10)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText2)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText3)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText4)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText5)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText6)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText7)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText8)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DText9)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.DocNo).HasMaxLength(50);
            entity.Property(e => e.SaleProductCode).HasMaxLength(50);
            entity.Property(e => e.SalesDescription).HasMaxLength(255);
            entity.Property(e => e.UnitMea).HasMaxLength(50);
        });

        modelBuilder.Entity<vTransaction_H>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vTransaction_H");

            entity.Property(e => e.AccBatchDate).HasColumnType("date");
            entity.Property(e => e.AccDocNo).HasMaxLength(50);
            entity.Property(e => e.AccDocType).HasMaxLength(50);
            entity.Property(e => e.AccEffectiveDate).HasColumnType("date");
            entity.Property(e => e.AccPostDate).HasColumnType("date");
            entity.Property(e => e.Date1).HasColumnType("datetime");
            entity.Property(e => e.Date10).HasColumnType("datetime");
            entity.Property(e => e.Date2).HasColumnType("datetime");
            entity.Property(e => e.Date3).HasColumnType("datetime");
            entity.Property(e => e.Date4).HasColumnType("datetime");
            entity.Property(e => e.Date5).HasColumnType("datetime");
            entity.Property(e => e.Date6).HasColumnType("datetime");
            entity.Property(e => e.Date7).HasColumnType("datetime");
            entity.Property(e => e.Date8).HasColumnType("datetime");
            entity.Property(e => e.Date9).HasColumnType("datetime");
            entity.Property(e => e.DocRefNo).HasMaxLength(50);
            entity.Property(e => e.FiscalYear).HasColumnType("date");
            entity.Property(e => e.IssueBy).HasMaxLength(50);
            entity.Property(e => e.PartyAddress).HasMaxLength(255);
            entity.Property(e => e.PartyCode).HasMaxLength(50);
            entity.Property(e => e.PartyName).HasMaxLength(255);
            entity.Property(e => e.PartyTaxCode).HasMaxLength(50);
            entity.Property(e => e.Text1)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text10)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text2)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text3)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text4)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text5)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text6)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text7)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text8)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Text9)
                .HasMaxLength(1000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<vTrial_Balance>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vTrial_Balance");

            entity.Property(e => e.AccCode).HasMaxLength(50);
            entity.Property(e => e.AccMainCode).HasMaxLength(50);
            entity.Property(e => e.AccMainName).HasMaxLength(255);
            entity.Property(e => e.AccName).HasMaxLength(255);
            entity.Property(e => e.Cr).HasColumnType("decimal(38, 10)");
            entity.Property(e => e.Dr).HasColumnType("decimal(38, 10)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

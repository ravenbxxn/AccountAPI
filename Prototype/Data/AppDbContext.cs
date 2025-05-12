using Microsoft.EntityFrameworkCore;
using APIPrototype.Models;
using static APIPrototype.Models.View_Model;

namespace APIPrototype.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Mas_SrvSingle> Mas_SrvSingle { get; set; }

        public DbSet<Acc_AdditionData> Acc_AdditionData { get; set; }
        public DbSet<Acc_Profile> Acc_Profile { get; set; }

        public DbSet<Mas_Department> Mas_Department { get; set; }

        public DbSet<Mas_AccPeriod> Mas_AccPeriod { get; set; }

        public DbSet<Mas_Warehouse> Mas_Warehouse { get; set; }

        public DbSet<Mas_ProductSetHD> Mas_ProductSetHD { get; set; }

        public DbSet<Mas_ProductSetDT> Mas_ProductSetDT { get; set; }

        public DbSet<Mas_Promotions> Mas_Promotions { get; set; }

        public DbSet<Mas_Products> Mas_Products { get; set; }

        public DbSet<Mas_ProductType> Mas_ProductType { get; set; }

        public DbSet<Acc_StockTransaction> Acc_StockTransaction { get; set;}

        public DbSet<Mas_DocConfig> Mas_DocConfig { get; set; }

        public DbSet<Mas_SalesProductHD> Mas_SalesProductHD { get;set; }

        public DbSet<Mas_SalesProductDT> Mas_SalesProductDT { get;set; }

        public DbSet<Acc_TransactionHD> Acc_TransactionHD { get; set; }

        public DbSet<Acc_TransactionDT> Acc_TransactionDT { get; set; }

        public DbSet<Mas_Customer> Mas_Customer { get; set; }

        public DbSet<Mas_Supplier> Mas_Supplier { get; set;}

        public DbSet<Mas_AccType> Mas_AccType { get; set; }

        public DbSet<Mas_AccCode> Mas_AccCode { get; set; }

        public DbSet<Acc_JournalHD> Acc_JournalHD { get; set; } 

        public DbSet<Acc_JournalDT> Acc_JournalDT { get; set;}

        public DbSet<Mas_HRStaff> Mas_HRStaff { get; set; }

        public DbSet<Mas_HRPosition> Mas_HRPosition { get; set; }

        public DbSet<Mas_HRLevel> Mas_HRLevel { get; set; }

        public DbSet<Mas_Company> Mas_Company { get; set; }

        public DbSet<Mas_HRDivision> Mas_HRDivision { get; set; }

        public DbSet<Mas_User> Mas_User { get; set; }

        public DbSet<Mas_UserRole> Mas_UserRole { get; set; }

        public DbSet<Mas_UserRoleAssign> Mas_UserRoleAssign { get; set; }

        public DbSet<Mas_UserRoleAuthor> Mas_UserRoleAuthor { get; set; }

        public DbSet<Mas_Module> Mas_Module { get; set; }

        public DbSet<Mas_ModuleMenu> Mas_ModuleMenu { get; set; }

        public DbSet<Mas_DocConfigSchema> Mas_DocConfigSchema { get; set; }

        public DbSet<Mas_HRDepartment> Mas_HRDepartment { get; set; }

        public DbSet<Mas_HREmployment> Mas_HREmployment { get; set; }

        public DbSet<Mas_AccConfig> Mas_AccConfig { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
            // กำหนดว่า View นี้มี Key มากกว่า 1
            modelBuilder.Entity<Acc_TransactionDT>()
                        .HasKey(e => new { e.AccDocNo, e.AccItemNo });

            modelBuilder.Entity<Acc_JournalDT>()
                        .HasKey(e => new { e.EntryId, e.Seq });

            modelBuilder.Entity<Mas_ModuleMenu>()
                        .HasKey(e => new { e.ModuleID, e.MenuID });

            modelBuilder.Entity<Mas_DocConfigSchema>()
                        .HasKey(e => new { e.DocConfigID, e.ConfigType });

            modelBuilder.Entity<Acc_AdditionData>()
                        .HasKey(e => new { e.DocNo, e.Seq });

            modelBuilder.Entity<Mas_UserRoleAssign>()
                        .HasKey(e => new { e.RoleID, e.UserID });

            modelBuilder.Entity<Mas_UserRoleAuthor>()
                        .HasKey(e => new { e.RoleID, e.ModuleID, e.MenuID });

            modelBuilder.Entity<Mas_HREmployment>()
                        .HasKey(e => new { e.CompanyId, e.PositionId, e.StaffId });

            modelBuilder.Entity<Mas_AccConfig>()
                        .HasKey(e => new { e.ConfigCode, e.ConfigKey });
        }
    }
}

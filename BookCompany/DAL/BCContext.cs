using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BookCompanyManagement.Models;

namespace BookCompanyManagement.DAL
{
    public class BcContext:DbContext
    {
        public DbSet<Book> Books { get; set; } 
        public DbSet<BookCompany> BookCompany { get; set; }
        public System.Data.Entity.DbSet<BookCompanyManagement.Models.PaperBrand> PaperBrands { get; set; }
        public DbSet<PaperInstock> PaperInstcok { get; set; }
        public DbSet<PaperMakingOrder> PapermakingOrder { get; set; }
        public DbSet<PaperMill> Papermills { get; set; }
        public System.Data.Entity.DbSet<BookCompanyManagement.Models.Paper> Papers { get; set; }
        public DbSet<PaperSpec> Paperspec { get; set; }
        public DbSet<PrintShop> Printshop { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<BookCompanyManagement.Models.BookPrintOrder> BookPrintOrders { get; set; }

        public System.Data.Entity.DbSet<BookCompanyManagement.Models.BookInstock> BookInstocks { get; set; }

        public System.Data.Entity.DbSet<BookCompanyManagement.Models.PaperNeed> PaperNeeds { get; set; }

        public System.Data.Entity.DbSet<BookCompanyManagement.Models.BookEditon> BookEditons { get; set; }

        public System.Data.Entity.DbSet<BookCompanyManagement.Models.Makeup> Makeups { get; set; }

        public System.Data.Entity.DbSet<BookCompanyManagement.Models.BookDelivery> BookDeliveries { get; set; }

        public DbSet<BookDeliveryOrder> BookDeliveryOrders { get; set; } 

    }
}
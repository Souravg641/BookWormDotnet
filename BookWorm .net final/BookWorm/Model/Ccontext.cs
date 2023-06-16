using Microsoft.EntityFrameworkCore;


namespace BookWorm.Models
{
    public class Ccontext:DbContext
    {
        public Ccontext(DbContextOptions<Ccontext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=BookWormDB;Integrated Security=True;");
            
        }
        public DbSet<CustomerMaster> CustomerMasters { get; set; }
        public DbSet<Authentication> Authentications { get; set; }
        public DbSet<ProductMaster> ProductMasters { get; set; }

        public DbSet<AttributeMaster> AttributesMasters { get; set; }
        public DbSet<BeneficiaryMaster> BeneficiaryMasters { get; set; }
        public DbSet<GenreMaster> GenreMasters { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<LanguageMaster> LanguageMasters { get; set; }
        public DbSet<MyShelf> MyShelfs { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<ProductBeneficiaryMaster> ProductBeneficiaryMasters { get; set; }
        public DbSet<ProductTypeMaster> ProductTypeMasters { get; set; }
        public DbSet<RoyaltyCalculation> RoyaltyCalculations { get; set; }

    }
}

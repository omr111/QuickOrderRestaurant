namespace QuickOrder.Entities.Entities.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuickOrderContext : DbContext
    {
        public QuickOrderContext()
            : base("name=QuickOrderContext")
        {
        }

        public virtual DbSet<banners> banners { get; set; }
        public virtual DbSet<Bills> Bills { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<CompanyInformations> CompanyInformations { get; set; }
        public virtual DbSet<Phones> Phones { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<reviews> reviews { get; set; }
        public virtual DbSet<rezervations> rezervations { get; set; }
        public virtual DbSet<roleOfUsers> roleOfUsers { get; set; }
        public virtual DbSet<roles> roles { get; set; }
        public virtual DbSet<SaleProducts> SaleProducts { get; set; }
        public virtual DbSet<SaleProductsDetails> SaleProductsDetails { get; set; }
        public virtual DbSet<services> services { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<users> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bills>()
                .HasMany(e => e.SaleProducts)
                .WithOptional(e => e.Bills)
                .HasForeignKey(e => e.billID);

            modelBuilder.Entity<Categories>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Categories)
                .HasForeignKey(e => e.categoryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyInformations>()
                .HasMany(e => e.Phones)
                .WithRequired(e => e.CompanyInformations)
                .HasForeignKey(e => e.CompanyID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Products>()
                .Property(e => e.price)
                .HasPrecision(6, 2);

            modelBuilder.Entity<Products>()
                .HasMany(e => e.SaleProductsDetails)
                .WithRequired(e => e.Products)
                .HasForeignKey(e => e.productID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<roles>()
                .HasMany(e => e.roleOfUsers)
                .WithRequired(e => e.roles)
                .HasForeignKey(e => e.roleID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SaleProducts>()
                .HasMany(e => e.SaleProductsDetails)
                .WithRequired(e => e.SaleProducts)
                .HasForeignKey(e => e.SaleID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<users>()
                .HasMany(e => e.reviews)
                .WithOptional(e => e.users)
                .HasForeignKey(e => e.userID);

            modelBuilder.Entity<users>()
                .HasMany(e => e.roleOfUsers)
                .WithRequired(e => e.users)
                .HasForeignKey(e => e.userID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<users>()
                .HasMany(e => e.SaleProducts)
                .WithRequired(e => e.users)
                .HasForeignKey(e => e.customerID)
                .WillCascadeOnDelete(false);
        }
    }
}

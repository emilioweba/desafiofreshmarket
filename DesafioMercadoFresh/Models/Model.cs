namespace DesafioMercadoFresh.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=NewConnection")
        {
        }

        public DbSet<Order> Orders { get; set; }
        
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ProductOrder> ProductOrder { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductOrder>().HasKey(u => new { u.OrderId, u.ProductId }).ToTable("ProductOrder");

            modelBuilder.Entity<ProductOrder>()
                .HasRequired(t => t.Order)
                .WithMany(t => t.Products)
                .HasForeignKey(t => t.OrderId);

            modelBuilder.Entity<ProductOrder>()
                .HasRequired(t => t.Product)
                .WithMany(t => t.Order)
                .HasForeignKey(t => t.ProductId);
        }
    }
}

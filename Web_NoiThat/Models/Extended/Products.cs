namespace Web_NoiThat.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Products : DbContext
    {
        public Products()
            : base("name=Products1")
        {
        }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Category> categories { get; set; }
        public virtual DbSet<Supplier> supplier { get; set; }
        public virtual DbSet<Promotion> promotion { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(e => e.product_name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.created_at)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.product_img)
                .IsUnicode(false);
        }
    }
}

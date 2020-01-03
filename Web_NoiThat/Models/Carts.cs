namespace Web_NoiThat.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Carts : DbContext
    {
        public Carts()
            : base("name=Carts")
        {
        }

        public virtual DbSet<Cart> cartss { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>()
               .Property(e => e.id_cart);

            modelBuilder.Entity<Cart>()
                .Property(e => e.created_at);
                
        }
    }
}

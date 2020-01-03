namespace Web_NoiThat.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Categories : DbContext
    {
        public Categories()
            : base("name=Categories")
        {
        }

        public virtual DbSet<Category> categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.cat_id);
                

            modelBuilder.Entity<Category>()
                .Property(e => e.cat_name)
                .IsUnicode(true);
        }
    }
}

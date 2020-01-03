namespace Web_NoiThat.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Orders : DbContext
    {
        public Orders()
            : base("name=Orders")
        {
        }

        public virtual DbSet<Order> orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

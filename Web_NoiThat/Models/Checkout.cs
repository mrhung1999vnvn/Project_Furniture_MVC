namespace Web_NoiThat.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Checkout
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int checkout_id { get; set; }

        public int id_user { get; set; }

        public double? checkout_total { get; set; }

        [Column(TypeName = "date")]
        public DateTime? created_at { get; set; }

        [StringLength(50)]
        public string checkout_address { get; set; }


        public Checkout()
        {

        }

        Data dbCheckout = new Data();
        public bool Add_Checkout(Checkout checkout)
        {
            try
            {
                dbCheckout.Checkouts.Add(checkout);
                dbCheckout.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

namespace Web_NoiThat.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;
    using System.Web.Mvc;

    [Table("Cart")]
    public partial class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_cart { get; set; }

        public double? quantity { get; set; }

        public int? user_id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public DateTime created_at { get; set; }

        public int? id_product { get; set; }

        public double? price { get; set; }

        public string address { get; set; }

        Carts dbCart = new Carts();
        Data db = new Data();
        Products prod = new Products();

        //Method
        public bool Insert_Cart(Cart item)
        {
            try
            {
                dbCart.cartss.Add(item);
                dbCart.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }


        //public bool Remove_Item_In_Cart()
        //{
            
        //}
        //public bool Checkout()
        //{

        //}

    }
}

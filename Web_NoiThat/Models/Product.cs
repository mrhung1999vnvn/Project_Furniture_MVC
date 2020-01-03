namespace Web_NoiThat.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Product ID:")]
        public int product_id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        [Display(Name = "Product Name:")]
        public string product_name { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Description about product:")]
        public string description { get; set; }

        [Display(Name = "Prices($):")]
        public double? price { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] created_at { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Status:")]
        public string status { get; set; }

        [Column(TypeName = "text")]
        public string product_img { get; set; }

        public int id_cat { get; set; }

        public int id_supplier { get; set; }

        [Display(Name ="Quantity:")]
        public int product_quantities { get; set; }

        //Xong model
    }
}

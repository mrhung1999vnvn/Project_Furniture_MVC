namespace Web_NoiThat.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int supplier_id { get; set; }

        [Required]
        [StringLength(50)]
        public string supplier_name { get; set; }

        [StringLength(30)]
        public string supplier_contact { get; set; }

        [StringLength(60)]
        public string supplier_address { get; set; }

        [StringLength(15)]
        public string supplier_province { get; set; }

        [StringLength(24)]
        public string supplier_phone { get; set; }
    }
}

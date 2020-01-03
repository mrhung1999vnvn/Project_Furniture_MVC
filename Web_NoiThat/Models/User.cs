namespace Web_NoiThat.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public int UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(254)]
        public string EmailID { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsEmailVerified { get; set; }

        public Guid ActivationCode { get; set; }
    }
}

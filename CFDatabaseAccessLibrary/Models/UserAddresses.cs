using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFDatabaseAccessLibrary.Models
{
    [Table("feedback_useraddresses")]
    public class UserAddresses
    {
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("userid")]
        public int UserId { get; set; }

        [Required]
        [Column("addresstype", TypeName = "varchar(20)")]
        public string AddressType { get; set; } // Home, Work, Billing

        [Required]
        [Column("address", TypeName = "varchar(500)")]
        public string Address { get; set; }

        [Required]
        [Column("city", TypeName = "varchar(100)")]
        public string City { get; set; }

        [Required]
        [Column("state", TypeName = "varchar(100)")]
        public string State { get; set; }

        [Required]
        [Column("postalcode", TypeName = "varchar(20)")]
        public string PostalCode { get; set; }

        [Required]
        [Column("country", TypeName = "varchar(100)")]
        public string Country { get; set; }

        [Column("isprimary")]
        public byte IsPrimary { get; set; } = 0;

        [Required]
        [Column("status")]
        public byte Status { get; set; } = 1;

        [Required]
        [Column("isdelete")]
        public byte Isdelete { get; set; } = 0;

        [Required]
        [Column("createdbyuserid")]
        public int Createdbyuserid { get; set; }

        [Required]
        [Column("createddate")]
        public DateTime Createddate { get; set; }

        [Required]
        [Column("modefiedbyuserid")]
        public int Modefiedbyuserid { get; set; }

        [Required]
        [Column("modefieddate")]
        public DateTime Modefieddate { get; set; }

        public virtual Users User { get; set; }
    }
}

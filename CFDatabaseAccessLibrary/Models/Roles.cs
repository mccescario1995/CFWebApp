using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFDatabaseAccessLibrary.Models
{
    [Table("feedback_roles")]
    public class Roles
    {
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("description")]
        public string Description { get; set; }

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
        public DateTime Createddate { get; set; } = DateTime.Now;

        [Required]
        [Column("modefiedbyuserid")]
        public int Modefiedbyuserid { get; set; }

        [Column("modefieddate")]
        public DateTime Modefieddate { get; set; } = DateTime.Now;

        public virtual ICollection<Users> Users { get; set; }
    }
}

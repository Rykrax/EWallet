using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EWalletMVC.Models
{
    [Table("tblUsers")] 
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("iUserID_PK")]
        public int UserID { get; set; }

        [Required, MaxLength(10)]
        [Column("sPhoneNumber")]
        public string PhoneNumber { get; set; }

        [Required, MaxLength(100)]
        [Column("sFullName")]
        public string FullName { get; set; }

        [Required, MaxLength(12)]
        [Column("sCCCD")]
        public string CCCD { get; set; }

        [Required]
        [Column("dBirthDate")]
        public DateTime BirthDate { get; set; }

        [Required, MaxLength(100)]
        [Column("sEmail")]
        public string Email { get; set; }

        [Column("fBalance", TypeName = "decimal(15,2)")]
        public decimal Balance { get; set; } = 0;

        [Required, MaxLength(255)]
        [Column("sPasswordHash")]
        public string PasswordHash { get; set; }

        [Required, MaxLength(6)]
        [Column("sPinCode")]
        public string PinCode { get; set; }

        [Column("dCreatedAt")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("dUpdatedAt")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [Required]
        [Column("iRoleID_FK")]
        [ForeignKey(nameof(Role))] // Trỏ chính xác đến `Role`
        public byte RoleID { get; set; }

        public Role Role { get; set; }  

        [Required, MaxLength(10)]
        [Column("sStatus")]
        public string Status { get; set; } = "active";
    }
}

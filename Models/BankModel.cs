using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EWalletMVC.Models
{
    [Table("tblBanks")] 
    public class Bank
    {
        [Key, MaxLength(10)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("sBankID_PK")]
        public string BankID { get; set; }

        [Required, MaxLength(100)]
        [Column("sBankName")]
        public string BankName { get; set; }

        [MaxLength(255)]
        [Column("sImage")]
        public string? Image { get; set; }
    }
}

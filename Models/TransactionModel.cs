using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EWalletMVC.Models
{
    [Table("tblTransactions")] // Ánh xạ đến bảng tblTransactions
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("iTransactionID_PK")]
        public int TransactionID { get; set; }

        [Required]
        [Column("iSenderUserID_FK")]
        public int SenderUserID { get; set; }

        [Column("iRecipientUserID_FK")]
        public int? RecipientUserID { get; set; } // Có thể null

        [Column("iBankAccountID_FK")]
        public int? BankAccountID { get; set; } // Có thể null

        [Required]
        [Column("sTransactionType")]
        public string TransactionType { get; set; } // deposit, withdraw, transfer

        [Required]
        [Column("fAmount", TypeName = "decimal(15,2)")]
        public decimal Amount { get; set; }

        [Column("dCreatedAt")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("sDescription")]
        public string Description { get; set; }

        [Column("sStatus")]
        public string Status { get; set; } = "pending"; // pending, completed, failed

        // Quan hệ với bảng User
        [ForeignKey("SenderUserID")]
        public User Sender { get; set; }

        [ForeignKey("RecipientUserID")]
        public User Recipient { get; set; }

        // Quan hệ với bảng BankAccount
        [ForeignKey("BankAccountID")]
        public BankAccount BankAccount { get; set; }
    }
}

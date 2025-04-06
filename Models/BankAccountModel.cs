using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EWalletMVC.Models
{
    [Table("tblBankAccounts")]
    public class BankAccount
    {
        [Key]
        [Column("iAccountID_PK")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountID { get; set; }  // Mã tài khoản ngân hàng (PK)

        [Required]
        [ForeignKey("User")]
        [Column("iUserID_FK")]
        public int UserID { get; set; }  // Mã người dùng (FK)

        [Required]
        [ForeignKey("Bank")]
        [Column("sBankID_FK")]
        [MaxLength(10)]
        public string BankID { get; set; }  // Mã ngân hàng (FK)

        [Required]
        [Column("sAccountNumber")]
        [MaxLength(20)]
        public string AccountNumber { get; set; }  // Số tài khoản ngân hàng

        [Required]
        [Column("sStatus")]
        [MaxLength(10)]
        public string Status { get; set; } = "active";  // Trạng thái (active/blocked)

        // Khai báo mối quan hệ với User và Bank
        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual Bank Bank { get; set; }
    }
}

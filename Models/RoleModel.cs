using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EWalletMVC.Models
{
    [Table("tblRoles")]
    public class Role
    {
        [Key]
        [Column("iRoleID_PK")]
        public byte RoleID { get; set; }

        [Required, MaxLength(50)]
        [Column("sRoleName")]
        public string RoleName { get; set; }

        [JsonIgnore] // Xử lý lỗi A possible object cycle was detected xảy ra do vòng lặp tuần hoàn khi serialize dữ liệu
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}

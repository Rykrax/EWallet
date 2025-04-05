using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class LoginDTO
{
    [Required]
    public string PhoneNumber { get; set; }

    [Required, MinLength(6)]
    public string Password { get; set; }
}

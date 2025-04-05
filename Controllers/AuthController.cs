using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EWalletMVC.Models;
using BCrypt.Net;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly EWalletContext _context;

    public AuthController(EWalletContext context)
    {
        _context = context;
    }

//     private string GenerateJwtToken(User user)
// {
//     var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_secret_key"));
//     var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

//     var claims = new[]
//     {
//         new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
//         new Claim(ClaimTypes.Email, user.Email),
//         new Claim(ClaimTypes.Role, user.RoleID.ToString())
//     };

//     var token = new JwtSecurityToken(
//         issuer: "yourdomain.com",
//         audience: "yourdomain.com",
//         claims: claims,
//         expires: DateTime.UtcNow.AddHours(2), // Token hết hạn sau 2 giờ
//         signingCredentials: credentials
//     );

//     return new JwtSecurityTokenHandler().WriteToken(token);
// }


    // [HttpPost("login")]
    // public async Task<IActionResult> Login([FromBody] LoginDTO model)
    // {
    //     var user = await _context.Users
    //         .FirstOrDefaultAsync(u => u.Email == model.Email);

    //     if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
    //     {
    //         return Unauthorized(new { status = 401, message = "Email hoặc mật khẩu không đúng!" });
    //     }

    //     return Ok(new { status = 200, message = "Đăng nhập thành công!" });
    // }

    [HttpPost("/login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO model)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.PhoneNumber == model.PhoneNumber);

        if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
        {
            return new JsonResult(new { status = 401, message = "Số điện thoại hoặc mật khẩu không đúng!" });
        }
        HttpContext.Session.SetInt32("UserID", user.UserID);
        HttpContext.Session.SetString("FullName", user.FullName);
        HttpContext.Session.SetString("PhoneNumber", user.PhoneNumber);
        return Ok(new { status = 200, message = "Đăng nhập thành công!" });
    }

    [HttpGet("/hash-passwords")]
    public IActionResult HashPasswords()
    {
        var users = _context.Users.ToList(); 
        
        foreach (var user in users)
        {
            if (!user.PasswordHash.StartsWith("$2a$")) // Check if password isn't already hashed
            {
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            }
        }

        _context.SaveChanges(); 

        return Content("Mật khẩu đã được hash thành công!");
    }

    [HttpPost("/register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO model)
    {
        if (await _context.Users.AnyAsync(u => u.Email == model.Email))
        {
            return BadRequest(new { status = 400, message = "Email đã tồn tại! Vui lòng thử lại" });
        }

        if (await _context.Users.AnyAsync(u => u.PhoneNumber == model.PhoneNumber))
        {
            return BadRequest(new { status = 400, message = "Số điện thoại đã tồn tại! Vui lòng thử lại" });
        }

        if (await _context.Users.AnyAsync(u => u.CCCD == model.CCCD))
        {
            return BadRequest(new { status = 400, message = "CCCD đã tồn tại! Vui lòng thử lại" });
        }
        
        var user = new User
        {
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            CCCD = model.CCCD,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password),
            FullName = "",
            BirthDate = new DateTime(2000, 1, 1),
            Balance = 0,
            PinCode = "000000",
            RoleID = 2
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return Ok(new { status = 200, message = "Đăng ký thành công!" });
    }

    [HttpPost("/change-password")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO model)
    {
        // var user = await _context.Users.FindAsync(model.PhoneNumber);
        // Nếu bạn tìm theo PhoneNumber:
        var user = _context.Users.FirstOrDefault(u => u.PhoneNumber == model.PhoneNumber);

        if (user == null)
        {
            return NotFound(new { status = 404, message = "Người dùng không tồn tại." });
        }

        if (!BCrypt.Net.BCrypt.Verify(model.OldPassword, user.PasswordHash))
        {
            return BadRequest(new { status = 400, message = "Mật khẩu cũ không đúng." });
        }

        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.NewPassword);
        await _context.SaveChangesAsync();

        return Ok(new { status = 200, message = "Đổi mật khẩu thành công." });
    }


    [HttpGet("/get-user-info")]
    public IActionResult GetUserSessionData()
    {
        var userID = HttpContext.Session.GetInt32("UserID");
        var fullName = HttpContext.Session.GetString("FullName");
        var phoneNumber = HttpContext.Session.GetString("PhoneNumber");

        // Trả về dữ liệu dưới dạng JSON
        return new JsonResult(new { userID, fullName, phoneNumber });
    }

}

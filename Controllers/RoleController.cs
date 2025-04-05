using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EWalletMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EWalletMVC.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly EWalletContext _context;

        public RoleController(EWalletContext context)
        {
            _context = context;
        }

        // API: Lấy danh sách tất cả Role
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        // API: Lấy Role theo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRoleById(byte id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound(new { message = "Role not found!" });
            }
            return role;
        }
    }
}

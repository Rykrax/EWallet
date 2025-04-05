using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EWalletMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EWalletMVC.Controllers
{
    [Route("api/banks")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly EWalletContext _context;

        public BankController(EWalletContext context)
        {
            _context = context;
        }

        // API: Lấy danh sách ngân hàng
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bank>>> GetBanks()
        {
            return await _context.Banks.ToListAsync();
        }

        // API: Lấy ngân hàng theo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Bank>> GetBank(int id)
        {
            var bank = await _context.Banks.FindAsync(id);
            if (bank == null)
            {
                return NotFound(new { message = "Bank not found!" });
            }
            return bank;
        }

        // API: Thêm ngân hàng mới
        [HttpPost]
        public async Task<ActionResult<Bank>> CreateBank(Bank bank)
        {
            _context.Banks.Add(bank);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBank), new { id = bank.BankID }, bank);
        }

        // API: Cập nhật ngân hàng
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBank(string id, Bank bank)
        {
            if (id != bank.BankID)
            {
                return BadRequest();
            }

            _context.Entry(bank).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Banks.Any(e => e.BankID == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // API: Xóa ngân hàng
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBank(int id)
        {
            var bank = await _context.Banks.FindAsync(id);
            if (bank == null)
            {
                return NotFound();
            }

            _context.Banks.Remove(bank);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

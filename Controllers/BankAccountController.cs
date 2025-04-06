using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EWalletMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EWalletMVC.Controllers
{
    [Route("api/bankaccounts")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        private readonly EWalletContext _context;

        public BankAccountController(EWalletContext context)
        {
            _context = context;
        }

        // API: Lấy danh sách tất cả tài khoản ngân hàng
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BankAccount>>> GetBankAccounts()
        {
            return await _context.BankAccounts.Include(ba => ba.User).Include(ba => ba.Bank).ToListAsync();
        }

        // API: Lấy tài khoản ngân hàng theo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<BankAccount>> GetBankAccount(int id)
        {
            var bankAccount = await _context.BankAccounts.Include(ba => ba.User).Include(ba => ba.Bank).FirstOrDefaultAsync(ba => ba.AccountID == id);

            if (bankAccount == null)
            {
                return NotFound(new { message = "Bank account not found!" });
            }
            return bankAccount;
        }

        // API: Thêm tài khoản ngân hàng mới
            [HttpPost]
            public async Task<ActionResult<BankAccount>> CreateBankAccount(BankAccount bankAccount)
            {
                _context.BankAccounts.Add(bankAccount);
                await _context.SaveChangesAsync();
                return Ok(new { status = 200, message = "Thêm tài khoản ngân hàng thành công!" });
                // return CreatedAtAction(nameof(GetBankAccount), new { id = bankAccount.AccountID }, bankAccount);
            }

        // API: Cập nhật tài khoản ngân hàng
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBankAccount(int id, BankAccount bankAccount)
        {
            if (id != bankAccount.AccountID)
            {
                return BadRequest();
            }

            _context.Entry(bankAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.BankAccounts.Any(e => e.AccountID == id))
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

        // API: Xóa tài khoản ngân hàng
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBankAccount(int id)
        {
            var bankAccount = await _context.BankAccounts.FindAsync(id);
            if (bankAccount == null)
            {
                return NotFound();
            }

            _context.BankAccounts.Remove(bankAccount);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

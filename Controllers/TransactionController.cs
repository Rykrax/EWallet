using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EWalletMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EWalletMVC.Controllers
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly EWalletContext _context;

        public TransactionController(EWalletContext context)
        {
            _context = context;
        }

        // API: Lấy danh sách tất cả giao dịch
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
        {
            var transactions = await _context.Transactions
                .Include(t => t.Sender)
                .Include(t => t.Recipient)
                .Include(t => t.BankAccount)
                .ToListAsync();
            return Ok(transactions);
        }

        // API: Lấy giao dịch theo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransaction(int id)
        {
            var transaction = await _context.Transactions
                .Include(t => t.Sender)
                .Include(t => t.Recipient)
                .Include(t => t.BankAccount)
                .FirstOrDefaultAsync(t => t.TransactionID == id);

            if (transaction == null)
            {
                return NotFound(new { message = "Transaction not found!" });
            }

            return transaction;
        }

        // API: Tạo giao dịch mới
        [HttpPost]
        public async Task<ActionResult<Transaction>> CreateTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTransaction), new { id = transaction.TransactionID }, transaction);
        }

        // API: Cập nhật giao dịch
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction(int id, Transaction transaction)
        {
            if (id != transaction.TransactionID)
            {
                return BadRequest();
            }

            _context.Entry(transaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Transactions.Any(e => e.TransactionID == id))
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

        // API: Xóa giao dịch
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

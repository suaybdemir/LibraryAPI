using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Identity;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace LibraryAPI.Controllers
{
    [Authorize(Policy = "AllUsers")]
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TransactionsController(ApplicationContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
           
        }

        // GET: api/Transactions
        [Authorize(Roles = "Admin,Employee")]
        [HttpGet("GetTransactions")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
        {
          if (_context.Transactions == null)
          {
              return NotFound();
          }
            return await _context.Transactions.ToListAsync();
        }

        // GET: api/Transactions/5
        [HttpGet("GetTransaction")]
        public async Task<ActionResult<Transaction>> GetTransaction(string id)
        {
          if (_context.Transactions == null)
          {
              return NotFound();
          }
            var transaction = await _context.Transactions.FindAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return transaction;
        }

        //PUT: api/Transactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutTransaction")]
        public async Task<IActionResult> PutTransaction(string id, Transaction transaction)
        {
            

            _context.Entry(transaction).State = EntityState.Modified;

            await _context.SaveChangesAsync();


            return NoContent();
        }

        // POST: api/Transactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Admin,Employee,Member")]
        [HttpPost("BorrowBook")]
        public async Task<ActionResult<Transaction>> BorrowBook(string id, int bookId)
        {

            if (await _context.Transactions.FindAsync(id) != null)
            {
                return BadRequest("There is an item which has given Id");
            }

            Transaction transaction = new Transaction();

            Member member = await _context.Members!
                .Include(e => e.LoanedBooks)
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();

            Book book = await _context.Books!
                .FirstOrDefaultAsync(b => b.Id == bookId);


            if (_context.Transactions == null)
            {
                return Problem("Entity set 'ApplicationContext.Borrows'  is null.");
            }

            if (member.LoanedBooks.Count >= 15)
            {
                ApplicationUser applicationUser = await _userManager.FindByIdAsync(id);
                applicationUser.isActive = false;
                return BadRequest("User has reached the maximum limit for borrowed books.");
            }

            //This is an user who borrowed book
            member.LoanedBooks!.Add(book);
            member.NumberOfBorrowings++;

            book.NumberOfBorrowings += 1;

            transaction.Id = CreateHashedId();
            transaction.BookId = bookId;
            transaction.BorrowedDate = DateTime.Now;
            transaction.Member = member;




            _context.Books!.Update(book);

            _context.Transactions.Add(transaction);

            await _context.SaveChangesAsync();

            return Ok("Book borrowed successfully.");
        }

        private string CreateHashedId()
        {
            // Generate a unique identifier (you can use GUID or any other method)
            string uniqueString = Guid.NewGuid().ToString();

            // Compute hash value using SHA256 algorithm
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(uniqueString));

                // Convert byte array to a hexadecimal string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        // POST: api/Transactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("ReturnBook")]
        [Authorize(Roles = "Admin,Employee,Member")]
        public async Task<ActionResult<Transaction>> ReturnBook(string id, int bookId)
        {
            ApplicationUser applicationUser = await _userManager.FindByIdAsync(id);

            Transaction transaction = await _context.Transactions
                .FirstOrDefaultAsync(t => t.BookId == bookId && t.UserId == id);


            Member member = await _context.Members!
                .Include(e => e.LoanedBooks)
                .FirstOrDefaultAsync(e => e.Id == id);

            Book book = await _context.Books!
                .FirstOrDefaultAsync(b => b.Id == bookId);

            if (_context.Transactions == null)
            {
                return Problem("Entity set 'ApplicationContext.Borrows'  is null.");
            }

            if (applicationUser.isActive == false && member.LoanedBooks.Count-1 <=15)
            {
                applicationUser.isActive = true;
            }

            member.LoanedBooks!.Remove(book);
            member.NumberOfBorrowings++;

            transaction.BookId = bookId;
            transaction.DeliveredDate = DateTime.Now;
            transaction.isDelivered = true;

            int totalFine = 0;


            if (member == null)
            {
                return NotFound();
            }



            foreach (var item in member!.LoanedBooks!)
            {

                int bookId2 = item.Id;

                Transaction transaction2 = await _context.Transactions
                    .Include(t => t.BookId == bookId2)
                    .FirstOrDefaultAsync(t => t.UserId == id);

                TimeSpan timeDifference = (TimeSpan)(transaction2.DeliveredDate - transaction2.BorrowedDate);
                int days = timeDifference.Days - 15;
                if (days > 15)
                {
                    totalFine += days * 1;
                }
            }

            member.TotalFine = totalFine;

            _context.Members!.Update(member);
            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();

            return Ok("Book borrowed successfully.");
        }

        // DELETE: api/Transactions/5
        [HttpDelete("DeleteTransaction")]
        [Authorize(Roles = "Admin,Employee,Member")]
        public async Task<IActionResult> DeleteTransaction(string id)
        {
            if (_context.Transactions == null)
            {
                return NotFound();
            }
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            transaction.isDeleted = true;

            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Transactions/5
        [Authorize(Roles = "Admin,Employee")]
        [HttpDelete("DeleteTransactionTotally/{id}")]
        public async Task<IActionResult> DeleteTransactionTotally(string id)
        {
            if (_context.Transactions == null)
            {
                return NotFound();
            }
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransactionExists(string id)
        {
            return (_context.Transactions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

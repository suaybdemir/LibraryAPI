using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Data;
using LibraryAPI.Models.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Identity;
using QRCoder;
using Microsoft.AspNetCore.WebUtilities;

namespace LibraryAPI.Controllers
{
    [Authorize(Policy ="AllUsers")]
    [Route("api/[controller]")]
    [ApiController]
    public class RepresentativeBooksController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IConfiguration _config;
        private readonly UserManager<ApplicationUser> _userManager;

        public RepresentativeBooksController(ApplicationContext context,IConfiguration config,UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _config = config;
            _userManager = userManager;
        }

        // GET: api/RepresentativeBooks
        [Authorize(Roles = "Admin,Employee")]
        [HttpGet("GetRepresentativeBooks")]
        public async Task<ActionResult<IEnumerable<RepresentativeBook>>> GetRepresentativeBooks()
        {
          if (_context.RepresentativeBooks == null)
          {
              return NotFound();
          }
            return await _context.RepresentativeBooks.ToListAsync();
        }

        // GET: api/RepresentativeBooks/5
        [HttpGet("GetRepresentativeBook")]
        public async Task<ActionResult<RepresentativeBook>> GetRepresentativeBook(int id)
        {
          if (_context.RepresentativeBooks == null)
          {
              return NotFound();
          }
            var representativeBook = await _context.RepresentativeBooks.FindAsync(id);

            if (representativeBook == null)
            {
                return NotFound();
            }

            return representativeBook;
        }

        // GET: api/RepresentativeBooks/5
        [HttpGet("GetWithQr")]
        public async Task<ActionResult<RepresentativeBook>> GetRepresentativeBookWqR(int id)
        {
            if (_context.RepresentativeBooks == null)
            {
                return NotFound();
            }
            var representativeBook = await _context.RepresentativeBooks.FindAsync(id);


            string qRCode = "Book Title : " + representativeBook.Title + "\nPageCount : "
                + representativeBook.PageCount + "\nBook Thickness : "
                + representativeBook.BookThickness + "\nRating : " + representativeBook.Rating + "\nDescription : "
                + representativeBook.Description + "\nPublishing Year : " + representativeBook.PublishingYear + "\nIs Banned ? "
                + representativeBook.Banned;


            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(qRCode, QRCodeGenerator.ECCLevel.Q))
            using (PngByteQRCode qrCode = new PngByteQRCode(qrCodeData))
            {
                byte[] qrCodeImage = qrCode.GetGraphic(5);
                return File(qrCodeImage, "image/bmp");
            }

        }

        // PUT: api/RepresentativeBooks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Admin,Employee")]
        [HttpPut("PutRepresentativeBook")]
        public async Task<IActionResult> PutRepresentativeBook(int id, RepresentativeBook representativeBook)
        {
            if (id != representativeBook.Id)
            {
                return BadRequest();
            }

            _context.Entry(representativeBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepresentativeBookExists(id))
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

        // POST: api/RepresentativeBooks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Admin,Employee")]
        [HttpPost("PostRepresentativeBook")]
        public async Task<ActionResult<RepresentativeBook>> PostRepresentativeBook(RepresentativeBook representativeBook)
        {
          if (_context.RepresentativeBooks == null)
          {
              return Problem("Entity set 'ApplicationContext.RepresentativeBooks'  is null.");
          }
            _context.RepresentativeBooks.Add(representativeBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRepresentativeBook", new { id = representativeBook.Id }, representativeBook);
        }


        [Authorize(Roles = "Admin,Employee")]
        [HttpPost("OnPostUploadAsync")]
        public async Task<IActionResult> OnPostUploadAsync(List<IFormFile> files, int id)
        {
            if (files == null || files.Count == 0)
            {
                return BadRequest("No files uploaded.");
            }

            // Retrieve the book record from the database
            var repBook = await _context.RepresentativeBooks.FindAsync(id);

            if (repBook == null)
            {
                return NotFound("Book not found.");
            }

            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    // Validate file type and size here if necessary
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(_config["FilePath:StoredFilesPath"]+"-"+id.ToString()+"-", fileName);

                    try
                    {
                        // Ensure directory exists
                        var directory = Path.GetDirectoryName(filePath);
                        if (!Directory.Exists(directory))
                        {
                            Directory.CreateDirectory(directory);
                        }

                        // Save the file
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        // Update the book record with the file path
                        repBook.Image = filePath;
                        _context.RepresentativeBooks.Update(repBook);
                        await _context.SaveChangesAsync();

                        // Read file and convert to Base64 string (Optional)
                        using (var memoryStream = new MemoryStream())
                        {
                            await file.CopyToAsync(memoryStream);
                            byte[] imageBytes = memoryStream.ToArray();
                            string base64Image = Convert.ToBase64String(imageBytes);

                            // Return the image as a FileContentResult (Optional)
                            // Adjust MIME type if necessary
                            // Return only the first image for demonstration
                            return File(imageBytes, "image/png");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log exception details
                        // Consider using ILogger to log exceptions to a file or monitoring system
                        Console.WriteLine($"Exception: {ex.Message}");
                        return StatusCode(500, $"Internal server error: {ex.Message}");
                    }
                }
            }

            return Ok("Files uploaded successfully.");
        }





        //[HttpGet("GetImage")]
        //public  string ImageBase64(string filepath)
        //{
        //    byte[] imageArry = System.IO.File.ReadAllBytes(filepath.Replace("//", "\\"));
        //    string base64ImageRepresantation = Convert.ToBase64String(imageArry);
        //    return "data:image/jpge;base64," + base64ImageRepresantation;
        //}




        // DELETE: api/RepresentativeBooks/5
        [Authorize(Roles = "Admin,Employee")]
        [HttpDelete("DeleteRepresentativeBook")]
        public async Task<IActionResult> DeleteRepresentativeBook(int id)
        {
            if (_context.RepresentativeBooks == null)
            {
                return NotFound();
            }
            var representativeBook = await _context.RepresentativeBooks.FindAsync(id);
            if (representativeBook == null)
            {
                return NotFound();
            }

            _context.RepresentativeBooks.Remove(representativeBook);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RepresentativeBookExists(int id)
        {
            return (_context.RepresentativeBooks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

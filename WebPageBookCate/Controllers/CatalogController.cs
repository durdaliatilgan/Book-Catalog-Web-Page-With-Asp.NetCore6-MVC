using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPageBookCate.Data;

namespace WebPageBookCate.Controllers
{
    public class CatalogController : Controller
    {
        private readonly WebPageBookCateContext _context;

        public CatalogController(WebPageBookCateContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString, string Author)
        {
            var books = _context.Books.Select(b => b);

            if (!string.IsNullOrEmpty(searchString))
            {
                books = books.Where(b => b.Title.Contains(searchString) || b.Author.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(Author))
            {
                books = books.Where(b => b.Author == Author);
            }

            return View(await books.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
    }
}

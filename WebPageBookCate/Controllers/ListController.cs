using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebPageBookCate.Data;
using WebPageBookCate.Models;

namespace WebPageBookCate.Controllers
{
    //[Authorize]
    public class ListController : Controller
    {
        private readonly WebPageBookCateContext _context;
        private readonly UserList _userList;

        public ListController(WebPageBookCateContext context, UserList userList)
        {
            _context = context;
            _userList = userList;
        }
        [Authorize]
        public IActionResult Index()
        {
            var items = _userList.GetAllListItems();
            _userList.ListItems = items;

            return View(_userList);
        }

        public IActionResult AddToList(int id)
        {
            var selectedBook = GetBookById(id);

            if (selectedBook != null)
            {
                _userList.AddToList(selectedBook, 1);
            }

            return RedirectToAction("Index", "List");
        }

        public IActionResult RemoveFromList(int id)
        {
            var selectedBook = GetBookById(id);

            if (selectedBook != null)
            {
                _userList.RemoveFromList(selectedBook);
            }

            return RedirectToAction("Index");
        }

        public IActionResult ReduceQuantity(int id)
        {
            var selectedBook = GetBookById(id);

            if (selectedBook != null)
            {
                _userList.ReduceQuantity(selectedBook);
            }

            return RedirectToAction("Index");
        }

        public IActionResult IncreaseQuantity(int id)
        {
            var selectedBook = GetBookById(id);

            if (selectedBook != null)
            {
                _userList.IncreaseQuantity(selectedBook);
            }

            return RedirectToAction("Index");
        }

        public IActionResult ClearList()
        {
            _userList.ClearList();

            return RedirectToAction("Index");
        }

        public Book GetBookById(int id)
        {
            return _context.Books.FirstOrDefault(b => b.Id == id);
        }
    }
}

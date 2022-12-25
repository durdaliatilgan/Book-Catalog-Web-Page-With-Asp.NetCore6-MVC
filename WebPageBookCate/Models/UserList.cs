using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebPageBookCate.Data;

namespace WebPageBookCate.Models
{
    public class UserList
    {


        private readonly WebPageBookCateContext _context;

        public UserList(WebPageBookCateContext context)
        {
            _context = context;
        }

        public string Id { get; set; }
        public List<ListItem> ListItems { get; set; }

        public static UserList GetList(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<WebPageBookCateContext>();
            string listId = session.GetString("Id") ?? Guid.NewGuid().ToString();

            session.SetString("Id", listId);

            return new UserList(context) { Id = listId };
        }

        public ListItem GetListItem(Book book)
        {
            return _context.ListItems.SingleOrDefault(ci =>
                ci.Book.Id == book.Id && ci.ListId == Id);
        }

        public void AddToList(Book book, int quantity)
        {
            var listItem = GetListItem(book);

            if (listItem == null)
            {
                listItem = new ListItem
                {
                    Book = book,
                    Quantity = quantity,
                    ListId = Id
                };

                _context.ListItems.Add(listItem);
            }
            else
            {
                listItem.Quantity += quantity;
            }
            _context.SaveChanges();
        }

        public int ReduceQuantity(Book book)
        {
            var listItem = GetListItem(book);
            var remainingQuantity = 0;

            if (listItem != null)
            {
                if (listItem.Quantity > 1)
                {
                    remainingQuantity = --listItem.Quantity;
                }
                else
                {
                    _context.ListItems.Remove(listItem);
                }
            }
            _context.SaveChanges();

            return remainingQuantity;
        }

        public int IncreaseQuantity(Book book)
        {
            var listItem = GetListItem(book);
            var remainingQuantity = 0;

            if (listItem != null)
            {
                if (listItem.Quantity > 0)
                {
                    remainingQuantity = ++listItem.Quantity;
                }
            }
            _context.SaveChanges();

            return remainingQuantity;
        }

        public void RemoveFromList(Book book)
        {
            var listItem = GetListItem(book);

            if (listItem != null)
            {
                _context.ListItems.Remove(listItem);
            }
            _context.SaveChanges();
        }

        public void ClearList()
        {
            var listItems = _context.ListItems.Where(ci => ci.ListId == Id);

            _context.ListItems.RemoveRange(listItems);

            _context.SaveChanges();
        }

        public List<ListItem> GetAllListItems()
        {
            return ListItems ??
                (ListItems = _context.ListItems.Where(ci => ci.ListId == Id)
                    .Include(ci => ci.Book)
                    .ToList());
        }

    }
}

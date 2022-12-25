using Microsoft.EntityFrameworkCore;
using WebPageBookCate.Data;

namespace WebPageBookCate.Models
{
    public class BookDatas
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new WebPageBookCateContext(serviceProvider.GetRequiredService<DbContextOptions<WebPageBookCateContext>>()))
            {

                if(context.Books.Any())
                {

                    return;
                }
                context.Books.AddRange(
                    new Book
                    {
                        Title = "Bröderna Lejonhjärta",
                        Description = "asad",
                        DatePublished = DateTime.Parse("2013-9-26"),
                        Author = "Astrid Lindgren",
                        ImageUrl = "/images/lejonhjärta.jpg"
                    },

                    new Book
                    {
                        Title = "The Fellowship of the Ring",
                        Description = "asaaad",
                        DatePublished = DateTime.Parse("1991-7-4"),
                        Author = "J. R. R. Tolkien",
                        ImageUrl = "/images/lotr.jpg"
                    }


                ) ;

                context.SaveChanges();
            }
        }
    }
}

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
                        Title = "Nutuk",
                        Description = "Ey Türk gençliği! Birinci görevin, Türk bağımsızlığını, Türk Cumhuriyeti’ni sonsuza kadar korumak ve savunmaktır. ",
                        DatePublished = DateTime.Parse("2016-9-26"),
                        Author = "Mustafa K. Atatürk",
                        ImageUrl = "/images/nutuk.png"
                    },

                    new Book
                    {
                        Title = "Bir Aşka Vuran Güneş",
                        Description = "Ölümsüz günler onlar, bir hiçle beslenen; Zaman dışı güvercinler, uçma bilmeyen;  " +
                                      "başka bir dal, başka yemiş.",
                        DatePublished = DateTime.Parse("2018-11-1"),
                        Author = "Oktay Rıfat",
                        ImageUrl = "/images/bagg.jpg"
                    },
                    new Book
                    {
                        Title = "Eski  Sokak",
                        Description = "Küçük ahşap bir dizi evlerdi On yıl önce o sokak. Sonra geniş caddelere çıktık Apartman",
                        DatePublished = DateTime.Parse("2008-11-4"),
                        Author = "Behçet Necatigil",
                        ImageUrl = "/images/es.jpg"
                    },
                    new Book
                    {
                        Title = "Mecburiyet",
                        Description = "Savaş karşıtı görüşleriyle tanınan Zweig I. Dünya Savaşı boyunca bu görüşlerini yaymayı kendine misyon edinmişti.",
                        DatePublished = DateTime.Parse("2017-9-4"),
                        Author = "Stefan Zweig",
                        ImageUrl = "/images/mecburiyet.jpg"
                    },
                    new Book
                    {
                        Title = "Ateş Yakmak",
                        Description = "Jack London, Kuzey topraklarını konu alan eserlerinde okurlarını buzla sarmalanmış bir diyarda adım adım gezdirir.",
                        DatePublished = DateTime.Parse("2019-4-14"),
                        Author = "Jack London",
                        ImageUrl = "/images/atesy.jpg"
                    },

                    new Book
                    {
                        Title = "İçimizdeki Şeytan",
                        Description = "Siir Kitabı",
                        DatePublished = DateTime.Parse("1998-2-24"),
                        Author = "Sabahattin Ali",
                        ImageUrl = "/images/icimizde.jpg"
                    },
                    new Book
                    {
                        Title = "Cesur Yeni Dünya",
                        Description = "Cesur yeni Dünya bizi 'Ford'dan sonra 632 yılına' götürür.  ",
                        DatePublished = DateTime.Parse("2021-08-20"),
                        Author = "Aldous Huxley",
                        ImageUrl = "/images/cyd.jpg"
                    },
                    new Book
                    {
                        Title = "1984",
                        Description = "Distopya olarak nitelendirilen George Orwell’ın bu şahane eseri. ",
                        DatePublished = DateTime.Parse("1991-7-4"),
                        Author = "George Orwell",
                        ImageUrl = "/images/1984.jpg"
                    }


                ) ;

                context.SaveChanges();
            }
        }
    }
}

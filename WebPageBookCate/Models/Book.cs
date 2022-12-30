using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebPageBookCate.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required,
        DataType(DataType.Date),
        Display(Name = "Date Published")]
        public DateTime DatePublished { get; set; }


        [Required]
        public string Author { get; set; }

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }
    }
}

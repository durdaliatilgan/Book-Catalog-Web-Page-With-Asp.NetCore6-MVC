namespace WebPageBookCate.Models
{
    public class ListItem
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }

        public string ListId { get; set; }

    }
}

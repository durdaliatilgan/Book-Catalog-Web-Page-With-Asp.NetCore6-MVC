using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebPageBookCate.Models;

namespace WebPageBookCate.Data
{
    public class WebPageBookCateContext : IdentityDbContext<DefaultUser>
    {
        public WebPageBookCateContext (DbContextOptions<WebPageBookCateContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; } 

        public DbSet<ListItem> ListItems { get; set; }

        public DbSet<BlogPost> BlogPost { get; set; }
        public DbSet<Comments> Comment { get; set; }
    }
}

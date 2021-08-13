using LibraryApp.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Database
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        protected override DbSet<Book> DbSet => _dbContext.Books;

        public BookRepository(AppDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Book> GetAllBooks()
        {
            return DbSet.Select(x => x);
        }
    }
}

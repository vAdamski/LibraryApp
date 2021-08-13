using LibraryApp.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Database
{
    public class BorrowRepository : BaseRepository<Borrow>, IBorrowRepository
    {
        protected override DbSet<Borrow> DbSet => _dbContext.Borrows;

        public BorrowRepository(AppDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Borrow> GetAllBooks()
        {
            return DbSet.Select(x => x);
        }
    }
}

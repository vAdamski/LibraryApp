using LibraryApp.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Database
{
    public class ReaderRepository : BaseRepository<Reader>, IReaderRepository
    {
        protected override DbSet<Reader> DbSet => _dbContext.Readers;

        public ReaderRepository(AppDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Reader> GetAllReaders()
        {
            return DbSet.Select(x => x);
        }
    }
}

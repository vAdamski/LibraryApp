using LibraryApp.Domain;
using System.Collections.Generic;

namespace LibraryApp.Domain
{
    public interface IBorrowRepository : IBaseRepository<Borrow>
    {
        IEnumerable<Borrow> GetAllBooks();
    }
}
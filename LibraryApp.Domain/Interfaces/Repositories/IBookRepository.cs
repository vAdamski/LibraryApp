using LibraryApp.Domain;
using System.Collections.Generic;

namespace LibraryApp.Domain
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        IEnumerable<Book> GetAllBooks();
    }
}
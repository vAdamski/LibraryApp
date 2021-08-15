using LibraryApp.Domain;
using System.Collections.Generic;

namespace LibraryApp.Domain
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        /// <summary>
        /// Get all unborrowed books from database
        /// </summary>
        /// <returns>Returns Ienuberable list of book</returns>
        IEnumerable<Book> GetAllUnborrowedBooks();
    }
}
using LibraryApp.Domain;
using System.Collections.Generic;

namespace LibraryApp.Domain
{
    public interface IBorrowRepository : IBaseRepository<Borrow>
    {
        /// <summary>
        /// Get all books from database
        /// </summary>
        /// <returns>Return IEnumerable borrowers list</returns>
        IEnumerable<Borrow> GetAllBorrowers();
    }
}
using LibraryApp.Domain;
using System.Collections.Generic;

namespace LibraryApp.Domain
{
    public interface IReaderRepository : IBaseRepository<Reader>
    {
        /// <summary>
        /// Get all readers from database
        /// </summary>
        /// <returns>Return IEnumerable readers list</returns>
        IEnumerable<Reader> GetAllReaders();
    }
}
using LibraryApp.Domain;
using System.Collections.Generic;

namespace LibraryApp.Domain
{
    public interface IReaderRepository : IBaseRepository<Reader>
    {
        IEnumerable<Reader> GetAllReaders();
    }
}
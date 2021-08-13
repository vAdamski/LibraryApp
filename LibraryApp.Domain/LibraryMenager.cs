using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain
{
    public class LibraryMenager : ILibraryMenager
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBorrowRepository _borrowRepository;
        private readonly IReaderRepository _readerRepository;
        private readonly IDtoMapper _dtoMapper;

        public LibraryMenager(IBookRepository bookRepository, IBorrowRepository borrowRepository, IReaderRepository readerRepository, IDtoMapper dtoMapper)
        {
            _bookRepository = bookRepository;
            _borrowRepository = borrowRepository;
            _readerRepository = readerRepository;
            _dtoMapper = dtoMapper;
        }

        public List<BookDto> GetAllBookDtos()
        {
            var bookEntities = _bookRepository.GetAllBooks().ToList();

            return _dtoMapper.Map(bookEntities);
        }

        public bool AddNewBook(BookDto bookDto)
        {
            var entity = _dtoMapper.Map(bookDto);

            return _bookRepository.Add(entity);
        }
    }
}

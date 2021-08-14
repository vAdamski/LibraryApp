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
        #region BookMengaer
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

        public bool DeleteBook(int bookId)
        {
            var book = new BookDto();

            book.Id = bookId;

            var bookEntity = _dtoMapper.Map(book);

            return _bookRepository.Delete(bookEntity);
        }

        public bool UpdateBook(BookDto bookDto)
        {
            var entity = _dtoMapper.Map(bookDto);

            return _bookRepository.Update(entity);
        }

        #endregion

        #region ReaderMenager
        public List<ReaderDto> GetAllReaderDtos()
        {
            var readerEntities = _readerRepository.GetAllReaders().ToList();

            return _dtoMapper.Map(readerEntities);
        }

        public bool AddNewReader(ReaderDto readerDto)
        {
            var entity = _dtoMapper.Map(readerDto);

            return _readerRepository.Add(entity);
        }

        public bool DeleteReader(int readerId)
        {
            var reader = new ReaderDto();

            reader.Id = readerId;

            var readerEntity = _dtoMapper.Map(reader);

            return _readerRepository.Delete(readerEntity);
        }

        public bool UpdateReader(ReaderDto readerDto)
        {
            var entity = _dtoMapper.Map(readerDto);

            return _readerRepository.Update(entity);
        }
        #endregion

        #region BorrowersMenager
        public List<BorrowDto> GetAllBorrowers()
        {
            var borrowers = _borrowRepository.GetAll();
            var books = _bookRepository.GetAll();
            var readers = _readerRepository.GetAll();

            var borrowerDtos = _dtoMapper.Map(borrowers);
            var bookDtos = _dtoMapper.Map(books);
            var readerDtos = _dtoMapper.Map(readers);

            borrowerDtos.ForEach(x => x.Book = bookDtos.FirstOrDefault(y => y.Id == x.BookId));
            borrowerDtos.ForEach(x => x.Reader = readerDtos.FirstOrDefault(y => y.Id == x.ReaderId));

            return borrowerDtos;
        }

        public bool AddNewBorrower(BorrowDto borrowDto)
        {
            var entity = _dtoMapper.Map(borrowDto);

            return _borrowRepository.Add(entity);
        }

        public bool DeleteBorrower(int borrowerId)
        {
            var borrowDto = new BorrowDto();

            borrowDto.Id = borrowerId;

            var borrower = _dtoMapper.Map(borrowDto);

            return _borrowRepository.Delete(borrower);
        }

        public bool UpdateBorrower(BorrowDto borrowDto)
        {
            var entity = _dtoMapper.Map(borrowDto);

            return _borrowRepository.Update(entity);
        }
        #endregion
    }
}

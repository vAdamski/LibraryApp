using System.Collections.Generic;

namespace LibraryApp.Domain
{
    public interface ILibraryMenager
    {
        bool AddNewBook(BookDto bookDto);
        List<BookDto> GetAllBookDtos();
        bool DeleteBook(int bookId);
        bool UpdateBook(BookDto bookDto);

        bool AddNewReader(ReaderDto readerDto);
        List<ReaderDto> GetAllReaderDtos();
        bool DeleteReader(int readerId);
        bool UpdateReader(ReaderDto readerDto);

        bool AddNewBorrower(BorrowDto borrowDto);
        bool DeleteBorrower(int borrowerId);
        List<BorrowDto> GetAllBorrowers();
        bool UpdateBorrower(BorrowDto borrowDto);
    }
}
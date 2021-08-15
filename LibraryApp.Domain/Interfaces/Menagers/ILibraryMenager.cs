using System.Collections.Generic;

namespace LibraryApp.Domain
{
    public interface ILibraryMenager
    {
        /// <summary>
        /// Add book to database
        /// </summary>
        /// <param name="bookDto">Book dto</param>
        /// <returns>Return true if adding goes fine, false in otherway</returns>
        bool AddNewBook(BookDto bookDto);
        /// <summary>
        /// Get all books dto
        /// </summary>
        /// <returns>Returns list of book dto</returns>
        List<BookDto> GetAllBookDtos();
        /// <summary>
        /// Deleting book from database
        /// </summary>
        /// <param name="bookId">Book id to delete</param>
        /// <returns>Return true if deleting goes fine, false in otherway</returns>
        bool DeleteBook(int bookId);
        /// <summary>
        /// Update book in database
        /// </summary>
        /// <param name="bookDto">Book dto to update</param>
        /// <returns>Return true if updating goes fine, false in otherway</returns>
        bool UpdateBook(BookDto bookDto);
        /// <summary>
        /// Get all unborrowed books dto
        /// </summary>
        /// <returns>Returns list of unborrowed book</returns>
        List<BookDto> GetAllUnborrowedBookDtos();
        /// <summary>
        /// Swap a book property Is Borrowed in database on reverse
        /// </summary>
        /// <param name="bookId">Book id</param>
        /// <returns>Return true if swap goes fine, false in otherway</returns>
        bool ChangeBookBorrowed(int bookId);

        /// <summary>
        /// Add new reader to database
        /// </summary>
        /// <param name="readerDto">Reader dto</param>
        /// <returns>Return true if adding goes fine, false in otherway</returns>
        bool AddNewReader(ReaderDto readerDto);
        /// <summary>
        /// Get list of readers from database
        /// </summary>
        /// <returns>Return list of reader dto</returns>
        List<ReaderDto> GetAllReaderDtos();
        /// <summary>
        /// Deleting reader from database
        /// </summary>
        /// <param name="readerId">Reader id</param>
        /// <returns>Return true if deleting goes fine, false in otherway</returns>
        bool DeleteReader(int readerId);
        /// <summary>
        /// Update reader in database
        /// </summary>
        /// <param name="readerDto">Reader dto</param>
        /// <returns>Return true if updating goes fine, false in otherway</returns>
        bool UpdateReader(ReaderDto readerDto);

        /// <summary>
        /// Add new borrower to database
        /// </summary>
        /// <param name="borrowDto">Borrower dto</param>
        /// <returns>Return true if adding goes fine, false in otherway</returns>
        bool AddNewBorrower(BorrowDto borrowDto);
        /// <summary>
        /// Deleting borrower from database
        /// </summary>
        /// <param name="borrowerId">Borrower id</param>
        /// <returns>Return true if deleting goes fine, false in otherway</returns>
        bool DeleteBorrower(int borrowerId);
        /// <summary>
        /// Get list of borrowers from database
        /// </summary>
        /// <returns>Returns list of borrowers</returns>
        List<BorrowDto> GetAllBorrowers();
        /// <summary>
        /// Update borrower in database
        /// </summary>
        /// <param name="borrowDto">Borrower dto</param>
        /// <returns>Return true if updating goes fine, false in otherway</returns>
        bool UpdateBorrower(BorrowDto borrowDto);
    }
}
using System.Collections.Generic;

namespace LibraryApp.Domain
{
    public interface ILibraryMenager
    {
        bool AddNewBook(BookDto bookDto);
        List<BookDto> GetAllBookDtos();
        bool DeleteBook(int bookId);
        bool UpdateBook(BookDto bookDto);
    }
}
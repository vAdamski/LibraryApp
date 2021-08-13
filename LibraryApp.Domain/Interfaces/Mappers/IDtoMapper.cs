using LibraryApp.Domain;
using System.Collections.Generic;

namespace LibraryApp.Domain
{
    public interface IDtoMapper
    {
        BookDto Map(Book book);
        Book Map(BookDto bookDto);
        BorrowDto Map(Borrow borrow);
        Borrow Map(BorrowDto borrowDto);
        List<BookDto> Map(List<Book> books);
        List<Book> Map(List<BookDto> bookDtos);
        List<BorrowDto> Map(List<Borrow> borrows);
        List<Borrow> Map(List<BorrowDto> borrowDtos);
        List<ReaderDto> Map(List<Reader> readers);
        List<Reader> Map(List<ReaderDto> readerDtos);
        ReaderDto Map(Reader reader);
        Reader Map(ReaderDto readerDto);
    }
}
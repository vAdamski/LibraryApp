using LibraryApp.Domain;
using System.Collections.Generic;

namespace LibraryApp.Domain
{
    /// <summary>
    /// Map dto on view model and reverse
    /// Map list dto on view model list reverse
    /// </summary>
    public interface IViewModelMapper
    {
        BookViewModel Map(BookDto bookDto);
        BookDto Map(BookViewModel bookViewModel);
        BorrowViewModel Map(BorrowDto borrowDto);
        BorrowDto Map(BorrowViewModel borrowViewModel);
        List<BookViewModel> Map(List<BookDto> bookDtos);
        List<BookDto> Map(List<BookViewModel> bookViewModels);
        List<BorrowViewModel> Map(List<BorrowDto> borrowDtos);
        List<BorrowDto> Map(List<BorrowViewModel> borrowViewModels);
        List<ReaderViewModel> Map(List<ReaderDto> readerDtos);
        List<ReaderDto> Map(List<ReaderViewModel> readerViewModels);
        ReaderViewModel Map(ReaderDto readerDto);
        ReaderDto Map(ReaderViewModel readerViewModel);
    }
}
using AutoMapper;
using LibraryApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Mapper
{
    public class DtoMapper : IDtoMapper
    {
        private readonly IMapper _mapper;
        public DtoMapper()
        {
            _mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Book, BookDto>().ReverseMap();
                config.CreateMap<Borrow, BorrowDto>().ReverseMap();
                config.CreateMap<Reader, ReaderDto>().ReverseMap();
            }).CreateMapper();
        }

        #region Book
        public Book Map(BookDto bookDto)
            => _mapper.Map<Book>(bookDto);

        public BookDto Map(Book book)
            => _mapper.Map<BookDto>(book);

        public List<Book> Map(List<BookDto> bookDtos)
            => _mapper.Map<List<Book>>(bookDtos);

        public List<BookDto> Map(List<Book> books)
            => _mapper.Map<List<BookDto>>(books);
        #endregion

        #region Borrow
        public Borrow Map(BorrowDto borrowDto)
            => _mapper.Map<Borrow>(borrowDto);

        public BorrowDto Map(Borrow borrow)
            => _mapper.Map<BorrowDto>(borrow);

        public List<Borrow> Map(List<BorrowDto> borrowDtos)
            => _mapper.Map<List<Borrow>>(borrowDtos);

        public List<BorrowDto> Map(List<Borrow> borrows)
            => _mapper.Map<List<BorrowDto>>(borrows);
        #endregion

        #region Reader
        public Reader Map(ReaderDto readerDto)
            => _mapper.Map<Reader>(readerDto);

        public ReaderDto Map(Reader reader)
            => _mapper.Map<ReaderDto>(reader);

        public List<Reader> Map(List<ReaderDto> readerDtos)
            => _mapper.Map<List<Reader>>(readerDtos);

        public List<ReaderDto> Map(List<Reader> readers)
            => _mapper.Map<List<ReaderDto>>(readers);
        #endregion
    }
}

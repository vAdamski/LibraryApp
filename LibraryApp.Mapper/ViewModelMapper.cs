using AutoMapper;
using LibraryApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Mapper
{
    public class ViewModelMapper : IViewModelMapper
    {
        private readonly IMapper _mapper;
        public ViewModelMapper()
        {
            _mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<BookDto, BookViewModel>().ReverseMap();
                config.CreateMap<BorrowDto, BorrowViewModel>().ReverseMap();
                config.CreateMap<ReaderDto, ReaderViewModel>().ReverseMap();
            }).CreateMapper();
        }

        #region Book
        public BookDto Map(BookViewModel bookViewModel)
            => _mapper.Map<BookDto>(bookViewModel);

        public BookViewModel Map(BookDto bookDto)
            => _mapper.Map<BookViewModel>(bookDto);

        public List<BookDto> Map(List<BookViewModel> bookViewModels)
            => _mapper.Map<List<BookDto>>(bookViewModels);

        public List<BookViewModel> Map(List<BookDto> bookDtos)
            => _mapper.Map<List<BookViewModel>>(bookDtos);
        #endregion

        #region Borrow
        public BorrowDto Map(BorrowViewModel borrowViewModel)
            => _mapper.Map<BorrowDto>(borrowViewModel);

        public BorrowViewModel Map(BorrowDto borrowDto)
            => _mapper.Map<BorrowViewModel>(borrowDto);

        public List<BorrowDto> Map(List<BorrowViewModel> borrowViewModels)
            => _mapper.Map<List<BorrowDto>>(borrowViewModels);

        public List<BorrowViewModel> Map(List<BorrowDto> borrowDtos)
            => _mapper.Map<List<BorrowViewModel>>(borrowDtos);
        #endregion

        #region Reader
        public ReaderDto Map(ReaderViewModel readerViewModel)
            => _mapper.Map<ReaderDto>(readerViewModel);

        public ReaderViewModel Map(ReaderDto readerDto)
            => _mapper.Map<ReaderViewModel>(readerDto);

        public List<ReaderDto> Map(List<ReaderViewModel> readerViewModels)
            => _mapper.Map<List<ReaderDto>>(readerViewModels);

        public List<ReaderViewModel> Map(List<ReaderDto> readerDtos)
            => _mapper.Map<List<ReaderViewModel>>(readerDtos);
        #endregion
    }
}

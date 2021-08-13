using LibraryApp.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Controllers
{
    [ApiController]
    [Route("book")]
    public class BooksController : ControllerBase
    {
        private readonly ILibraryMenager _libraryMenager;
        private readonly IViewModelMapper _viewModelMapper;

        public BooksController(ILibraryMenager libraryMenager, IViewModelMapper viewModelMapper)
        {
            _libraryMenager = libraryMenager;
            _viewModelMapper = viewModelMapper;

            ////Initialize books
            //_libraryMenager.AddNewBook(new BookDto { Title = "Harry Potter i Kamien Filozoficzny", Author = "J.K. Rowling", ISBN = "0-306-40615" });
            //_libraryMenager.AddNewBook(new BookDto { Title = "Harry Potter i Komnata Tajemnic", Author = "J.K. Rowling", ISBN = "0-306-40616" });
            //_libraryMenager.AddNewBook(new BookDto { Title = "Harry Potter i Wiezien Azkabanu", Author = "J.K. Rowling", ISBN = "0-306-40617" });
            //_libraryMenager.AddNewBook(new BookDto { Title = "Harry Potter i Czara Ognia", Author = "J.K. Rowling", ISBN = "0-306-40618" });
            //_libraryMenager.AddNewBook(new BookDto { Title = "Harry Potter i Zakon Feniksa", Author = "J.K. Rowling", ISBN = "0-306-40619" });
            //_libraryMenager.AddNewBook(new BookDto { Title = "Harry Potter i Ksiaze Polkrwi", Author = "J.K. Rowling", ISBN = "0-306-40620" });
            //_libraryMenager.AddNewBook(new BookDto { Title = "Harry Potter i Insygnia Smierci", Author = "J.K. Rowling", ISBN = "0-306-40621" });
        }

        [HttpGet]
        [Route("getAllBooks")]
        public IActionResult GetAllBooks()
        {
            var bookDtos = _libraryMenager.GetAllBookDtos();

            var bookViewModels = _viewModelMapper.Map(bookDtos);

            return Ok(bookViewModels);
        }
    }
}

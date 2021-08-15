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
        }

        [HttpGet]
        [Route("getAllBooks")]
        public IActionResult GetAllBooks()
        {
            try
            {
                var bookDtos = _libraryMenager.GetAllBookDtos();

                var bookViewModels = _viewModelMapper.Map(bookDtos);

                return Ok(bookViewModels);
            }
            catch (Exception ex)
            {
                //Add logger
                throw;
            }
        }

        [HttpGet]
        [Route("getAllUnborrowedBooks")]
        public IActionResult GetAllUnborrowedBooks()
        {
            try
            {
                var bookDtos = _libraryMenager.GetAllUnborrowedBookDtos();

                var bookViewModels = _viewModelMapper.Map(bookDtos);

                return Ok(bookViewModels);
            }
            catch (Exception ex)
            {
                //Add logger
                throw;
            }
        }

        [HttpPost]
        [Route("addBookToDatabase")]
        public IActionResult AddBookToDatabase([FromBody]BookViewModel bookViewModel)
        {
            try
            {
                if(bookViewModel == null)
                {
                    //Add logger
                    return NotFound();
                }

                var bookDto = _viewModelMapper.Map(bookViewModel);

                var result = _libraryMenager.AddNewBook(bookDto);

                if(!result)
                {
                    //Add logger
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                //Add logger
                throw;
            }
        }
        
        [HttpGet]
        [Route("deleteBookFromDatabase")]
        public IActionResult DeleteBookFromDatabase(int id)
        {
            try
            {
                var result = _libraryMenager.DeleteBook(id);

                if(!result)
                {
                    //Add logger
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                //Add logger
                throw;
            }
        }

        [HttpPost]
        [Route("editBookInDatabase")]
        public IActionResult EditBookChanges([FromBody]BookViewModel bookViewModel)
        {
            try
            {
                var bookDto = _viewModelMapper.Map(bookViewModel);

                if(bookDto == null)
                {
                    //Add logger
                    return NotFound();
                }

                var result = _libraryMenager.UpdateBook(bookDto);

                if(!result)
                {
                    //Add logger
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                //Add logger
                throw;
            }
        }

        [HttpGet]
        [Route("changeBookBorrowed")]
        public IActionResult ChangeBookBorrowed(int bookId)
        {
            var result = _libraryMenager.ChangeBookBorrowed(bookId);

            if(result)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}

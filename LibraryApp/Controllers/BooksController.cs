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

        /// <summary>
        /// Return all books from database to frontend
        /// </summary>
        /// <returns>Return Ok-200(list of books)</returns>
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

        /// <summary>
        /// Return all books unborrowed from database to frontend
        /// </summary>
        /// <returns>Return OK-200(list of unborrowed books)</returns>
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

        /// <summary>
        /// Add book to database
        /// </summary>
        /// <param name="bookViewModel">View model book</param>
        /// <returns>Return OK-200 if adding goes fine other way NotFound</returns>
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
        
        /// <summary>
        /// Deleting book from database
        /// </summary>
        /// <param name="id">Book id to delete</param>
        /// <returns>Return Ok-200 if deleting goes fine otherway NotFound</returns>
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

        /// <summary>
        /// Update book in database
        /// </summary>
        /// <param name="bookViewModel">View model book</param>
        /// <returns>Return Ok-200 if updating goes fine otherway NotFound</returns>
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

        /// <summary>
        /// Swap IsBorrowed property in database
        /// </summary>
        /// <param name="bookId">Book id</param>
        /// <returns>Return Ok-200 if swap goes fine otherway NotFound</returns>
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

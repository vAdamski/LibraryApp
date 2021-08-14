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

        [HttpPost]
        [Route("addBookToDatabase")]
        public IActionResult AddBookToDatabase([FromBody]BookViewModel bookViewModel)
        {
            try
            {
                if(bookViewModel == null)
                {
                    return NotFound();
                }

                var bookDto = _viewModelMapper.Map(bookViewModel);

                var result = _libraryMenager.AddNewBook(bookDto);

                if(!result)
                {
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
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

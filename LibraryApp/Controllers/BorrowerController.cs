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
    [Route("borrower")]
    public class BorrowerController : ControllerBase
    {
        private readonly ILibraryMenager _libraryMenager;
        private readonly IViewModelMapper _viewModelMapper;
        private readonly ILogger _logger;

        public BorrowerController(ILibraryMenager libraryMenager, IViewModelMapper viewModelMapper, ILogger  logger)
        {
            _libraryMenager = libraryMenager;
            _viewModelMapper = viewModelMapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("getAllBorrowers")]
        public IActionResult GetAllBorrowers()
        {
            try
            {
                var borrowerDtos = _libraryMenager.GetAllBorrowers();

                var borrowViewModels = _viewModelMapper.Map(borrowerDtos);

                return Ok(borrowViewModels);
            }
            catch (Exception ex)
            {
                _logger.Log(ex.ToString());
                throw;
            }
        }
        [HttpPost]
        [Route("addBorrowerToDatabase")]
        public IActionResult AddNewBorrower([FromBody]BorrowViewModel borrowViewModel)
        {
            try
            {
                if (borrowViewModel == null)
                {
                    return NotFound();
                }

                var borrowDto = _viewModelMapper.Map(borrowViewModel);

                borrowDto.ReturnDate = borrowDto.BorrowDate.AddDays(7);

                if (!(_libraryMenager.AddNewBorrower(borrowDto)))
                {
                    return NotFound();
                }

                if(!(_libraryMenager.ChangeBookBorrowed(borrowDto.BookId)))
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Log(ex.ToString());
                throw;
            }
        }

        [HttpGet]
        [Route("deleteBorrowerFromDatabase")]
        public IActionResult DeleteBorrowerFromDatabase(int id, int bookId)
        {
            try
            {
                var result = _libraryMenager.DeleteBorrower(id);

                if (!result)
                {
                    return NotFound();
                }

                if (!(_libraryMenager.ChangeBookBorrowed(bookId)))
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Log(ex.ToString());
                throw;
            }
        }

        [HttpPost]
        [Route("editBorrowerInDatabase")]
        public IActionResult EditBorrowers([FromBody] BorrowViewModel borrowViewModel)
        {
            try
            {
                var borrowDto = _viewModelMapper.Map(borrowViewModel);

                if (borrowDto == null)
                {
                    return NotFound();
                }

                var result = _libraryMenager.UpdateBorrower(borrowDto);

                if (!result)
                {
                    return NotFound();
                }

                if (!(_libraryMenager.ChangeBookBorrowed(borrowDto.BookId)))
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Log(ex.ToString());
                throw;
            }
        }
    }
}

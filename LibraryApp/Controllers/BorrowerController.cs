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

        public BorrowerController(ILibraryMenager libraryMenager, IViewModelMapper viewModelMapper)
        {
            _libraryMenager = libraryMenager;
            _viewModelMapper = viewModelMapper;
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
                //Add logger
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
                    //Add logger
                    return NotFound();
                }

                var borrowDto = _viewModelMapper.Map(borrowViewModel);

                var result = _libraryMenager.AddNewBorrower(borrowDto);

                if (!result)
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
        [Route("deleteBorrowerFromDatabase")]
        public IActionResult DeleteBorrowerFromDatabase(int id)
        {
            try
            {
                var result = _libraryMenager.DeleteBorrower(id);

                if (!result)
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
        [Route("editBorrowerInDatabase")]
        public IActionResult EditBorrowers([FromBody] BorrowViewModel borrowViewModel)
        {
            try
            {
                var borrowDto = _viewModelMapper.Map(borrowViewModel);

                if (borrowDto == null)
                {
                    //Add logger
                    return NotFound();
                }

                var result = _libraryMenager.UpdateBorrower(borrowDto);

                if (!result)
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
    }
}

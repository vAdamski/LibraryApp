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


    }
}

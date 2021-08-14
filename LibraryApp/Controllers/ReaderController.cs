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
    [Route("reader")]
    public class ReaderController : ControllerBase
    {
        private readonly ILibraryMenager _libraryMenager;
        private readonly IViewModelMapper _viewModelMapper;

        public ReaderController(ILibraryMenager libraryMenager, IViewModelMapper viewModelMapper)
        {
            _libraryMenager = libraryMenager;
            _viewModelMapper = viewModelMapper;
        }

        [HttpGet]
        [Route("getAllReaders")]
        public IActionResult GetAllReaders()
        {
            try
            {
                var readerDtos = _libraryMenager.GetAllReaderDtos();

                var readerViewModels = _viewModelMapper.Map(readerDtos);

                return Ok(readerViewModels);
            }
            catch (Exception ex)
            {
                //Add logger
                throw;
            }
        }

        [HttpPost]
        [Route("addReaderToDatabase")]
        public IActionResult AddreaderToDatabase([FromBody]ReaderViewModel readerViewModel)
        {
            try
            {
                if(readerViewModel == null)
                {
                    //Add logger
                    return NotFound();
                }

                var readerDto = _viewModelMapper.Map(readerViewModel);

                var result = _libraryMenager.AddNewReader(readerDto);

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
        [Route("deleteReaderFromDatabase")]
        public IActionResult DeleteBookFromDatabase(int id)
        {
            try
            {
                var result = _libraryMenager.DeleteReader(id);

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
        [Route("editReaderInDatabase")]
        public IActionResult EditBookChanges([FromBody]ReaderViewModel readerViewModel)
        {
            try
            {
                var readerDto = _viewModelMapper.Map(readerViewModel);

                if(readerDto == null)
                {
                    //Add logger
                    return NotFound();
                }

                var result = _libraryMenager.UpdateReader(readerDto);

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
    }
}

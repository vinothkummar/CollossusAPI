using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Colossus.Data;
using Colossus.ViewModel;
using Colossus.DomainModel;
using Colossus.Repository.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Colossus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileStorageController : ControllerBase
    {
        private readonly IFileStorageRepository _fileStorageRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<FileStorageController> _logger;

        public FileStorageController(IFileStorageRepository fileStorageRepository, IMapper mapper, ILogger<FileStorageController> logger)
        {
            _fileStorageRepository = fileStorageRepository;
            _mapper = mapper;
            _logger = logger;
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FileStorageViewModel>>> GetFileStorage()
        {
            try
            {
                var fileStorage = await _fileStorageRepository.GetFileStorageAsync().ConfigureAwait(false);

                return Ok(_mapper.Map<IEnumerable<FileStoreage>, IEnumerable<FileStorageViewModel>>(fileStorage));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get the Product List: {ex}");

            }

            return BadRequest("Failed to get the Product List");
            
        }

        [HttpPost("CreateFolder")]
        public IActionResult Post([FromBody] FileStorageViewModel model)
        {
            try
            {
                if (model != null)
                {
                    var newFolder = _mapper.Map<FileStorageViewModel, FileStoreage>(model);

                    var outPut = _fileStorageRepository.Create(newFolder).Result;

                    return Created($"/api/Folder/{outPut.Id}", _mapper.Map<FileStoreage, FileStorageViewModel>(outPut));
                }
            }
            catch (Exception ex)
            {

                _logger.LogError($"Failed to create a new Folder: {ex}");

            }

            return BadRequest("Failed to create a new Folder");
        }

        
    }
}

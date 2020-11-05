using AutoMapper;
using Colossus.DomainModel;
using Colossus.Repository.Interfaces;
using Colossus.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Threading.Tasks;

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
        public IActionResult Post(string folderName, string parentfolderName, string filePath)
        {
            try
            {   
                //DirectoryInfo di = Directory.CreateDirectory(@"filePath");
            
                var model = new FileStorageViewModel() { FolderName = folderName, ParentFolderName = parentfolderName, FilePath = filePath, FileCreationDate = DateTime.UtcNow };
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

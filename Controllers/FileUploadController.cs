using Microsoft.AspNetCore.Mvc;
using FilesApp.Data;
using FilesApp.Repository;

namespace FilesApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileUploadController : ControllerBase
    {
        private readonly IFileRepository _fileRepository;

        public FileUploadController(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        [HttpPost]
        public ActionResult Post(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file selected.");

            var fileModel = new FileData
            {
                Name = file.FileName,
                ContentType = file.ContentType
            };

            using (var stream = new MemoryStream())
            {
                file.CopyToAsync(stream);
                fileModel.Data = stream.ToArray();
            }

             _fileRepository.Add(fileModel);

            return Ok(new { fileModel.Id });
        }

        [HttpGet]
        public ActionResult<IEnumerable<FileData>> Get()
        {
            var files = _fileRepository.GetAll();
            return Ok(files);
        }
    }
}
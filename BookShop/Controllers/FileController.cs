using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly string _StoragePath;

        public FileController(IConfiguration configuration)
        {
            _StoragePath = configuration["FileUpload:StoragePath"];
        }
        [HttpGet("GetFile")]
        public IActionResult DownloadFile(string filename)
        {
            var filepath = Path.Combine(_StoragePath, filename);
            if (!System.IO.File.Exists(filepath))
            {
                return NotFound("File Not Found");
            }
            var fileBytes = System.IO.File.ReadAllBytes(filepath);
            var contentType = "application/octet-stream";
            return PhysicalFile(filepath, contentType, filename);
        }
    }
}

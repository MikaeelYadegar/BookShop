using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Core.FileUpload
{
    
    public class FileUploadService:IFileUploadService
    {
        private readonly string _StoragePath;
 
          public FileUploadService(IConfiguration configuration)
        {
            _StoragePath = configuration["FileUpload:StoragePath"];
        }
        public async Task<string> UploadFileAsync(IFormFile file)
        {
            if(!Directory.Exists(_StoragePath))
            {
                Directory.CreateDirectory(_StoragePath); 
            }
            if(file== null||file.Length==0)
            {
                throw new ArgumentNullException("File Are Empty");
            }

            var filename=Guid.NewGuid().ToString()+Path.GetExtension(file.FileName);
            var fullPath=Path.Combine(_StoragePath, filename);
            using(var stream=new FileStream(fullPath,FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return filename;
        }
    }
}

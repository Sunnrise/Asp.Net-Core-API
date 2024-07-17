using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/files")]
    public class FilesController: ControllerBase
    {
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            //folder
            var folder=Path.Combine(Directory.GetCurrentDirectory(), "Media");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            //file path
            var filePath = Path.Combine(folder, file.FileName);
            //stream
            using (var stream= new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            //response body

            return Ok(new
            {
                file = file.FileName,
                path = filePath,
                size = file.Length
            });
        }

        [HttpGet("download")]
        public async Task<IActionResult> Download(string fileName)
        {
            //file path
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Media", fileName);

            //content type(mime type)
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(fileName, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            //read
            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);

            return File(bytes, contentType, Path.GetFileName(fileName));

            //response body


        }

    }
}

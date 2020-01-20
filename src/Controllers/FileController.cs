using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoNibo.Services.Interfaces;

namespace ProjetoNibo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("upload"), DisableRequestSizeLimit]
        public async Task<IActionResult> Upload()
        {
            try
            {
                var files = Request.Form.Files;

                long size = files.Sum(f => f.Length);

                if (files.Any())
                {
                    await _fileService.Upload(files);
                }
                else
                {
                    return BadRequest(new { message = "No files.", count = files.Count, size });
                }

                return Ok(new { message = "Upload Complete.", count = files.Count, size });
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(new { message = $"Upload Failed:{ex}", count = 0, size = "0" });
            }
        }
    }
}
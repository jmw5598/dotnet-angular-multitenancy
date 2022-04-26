using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Xyz.Core.Interfaces;
using Xyz.Core.Models;
using Xyz.Multitenancy.Security;

namespace Xyz.Api.Controllers
{
    [Authorize(Policy = PolicyNames.RequireTenant)]
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private ILogger<FilesController> _logger;
        private IFilesService _fileUploadsService;

        public FilesController(ILogger<FilesController> logger, IFilesService fileUploadsService)
        {
            this._logger = logger;
            this._fileUploadsService = fileUploadsService;
        }

        [HttpPost("avatar")]
        public async Task<ActionResult<object>> UploadAvatar(IFormFile avatar)
        {
            long size = avatar.Length;

            
            var filePath = Path.GetTempFileName();

            using (var stream = System.IO.File.Create(filePath))
            {
                await avatar.CopyToAsync(stream);
            }
        

            // Process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { count = 1, size });
        }
    }
}
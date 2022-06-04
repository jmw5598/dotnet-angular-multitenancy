using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using System.Net.Http.Headers;

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

            // Process uploaded files
            // Don't rely on or trust the FileName property without validation.
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"') ?? "";
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
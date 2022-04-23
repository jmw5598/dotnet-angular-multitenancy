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
        public async Task<ActionResult<object>> UploadAvatar()
        {

            return Ok("");
        }
    }
}
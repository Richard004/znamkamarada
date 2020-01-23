using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using znamkamarada.Services.Library;
using znamkamarada.Services.Library.ModelsDto;
using znamkamarada.Services.Library.Tools;

namespace znamkamarada.Services.Validation.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValidateVignetteController : ControllerBase
    {
        private readonly IVignetteValidationService vignetteValidationService;
        private readonly ILogger<ValidateVignetteController> _logger;

        public ValidateVignetteController(
            IVignetteValidationService vignetteValidationService,
            ILogger<ValidateVignetteController> logger)
        {
            this.vignetteValidationService = vignetteValidationService;
            _logger = logger;
        }

        [HttpGet]
        [Route("/validate/{licencePlateInput}")]
        public ActionResult<VignetteValidationResult> Get(string licencePlateInput)
        {
            if (!LicencePlateTools.TrySanitizeInputToLicencePlate(licencePlateInput, out var licencePlate))
                return BadRequest(new { 
                    error = "Provided licence plate input is not a valid format", 
                    hint = "An example of valid input is 'CZ;1AB1234'"
                });

            var validationResult = vignetteValidationService.IsValidFor(licencePlate, DateTime.UtcNow);
            return validationResult;
        }
    }
}

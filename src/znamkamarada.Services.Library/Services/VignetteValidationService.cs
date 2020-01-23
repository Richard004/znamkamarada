using System;
using znamkamarada.Services.Library.ModelsDto;

namespace znamkamarada.Services.Library
{

    public class VignetteValidationService : IVignetteValidationService
    {
        private readonly IVignettePersistenceService vignettePersistenceService;

        public VignetteValidationService(IVignettePersistenceService vignettePersistenceService)
        {
            this.vignettePersistenceService = vignettePersistenceService;
        }

        public VignetteValidationResult IsValidFor(LicencePlate licencePlate, DateTimeOffset dateTime)
        {
            return new VignetteValidationResult
            {
                validatedOnUtc = DateTime.UtcNow,
                isValid = false
            };
        }
    }
}

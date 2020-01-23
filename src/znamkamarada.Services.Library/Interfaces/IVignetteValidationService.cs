using System;
using znamkamarada.Services.Library.ModelsDto;

namespace znamkamarada.Services.Library
{
    public interface IVignetteValidationService
    {
        VignetteValidationResult IsValidFor(LicencePlate licencePlate,DateTimeOffset dateTime);
    }
}

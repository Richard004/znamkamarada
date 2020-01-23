using System;

namespace znamkamarada.Services.Library
{
    public interface IVignetteRegistrationService
    {
        void Register(LicencePlate licencePlate, DateTimeOffset startingTime, LicenceDuration licenceDuration);
    }
}

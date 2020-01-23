using System;

namespace znamkamarada.Services.Library
{
    public interface IVignettePersistenceService
    {
        bool IsValidFor(LicencePlate licencePlate,DateTimeOffset dateTime);
        void Register(LicencePlate licencePlate,DateTimeOffset startingTime,LicenceDuration licenceDuration);
    }
}

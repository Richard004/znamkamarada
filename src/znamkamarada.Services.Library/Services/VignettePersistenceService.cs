using System;

namespace znamkamarada.Services.Library
{

    public class VignettePersistenceServiceTableStorage : IVignettePersistenceService
    {
        public bool IsValidFor(LicencePlate licencePlate, DateTimeOffset dateTime)
        {
            throw new NotImplementedException();
        }

        public void Register(LicencePlate licencePlate, DateTimeOffset startingTime, LicenceDuration licenceDuration)
        {
            throw new NotImplementedException();
        }
    }
}

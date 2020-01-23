using System;
using System.Threading.Tasks;

namespace znamkamarada.Services.Library
{


    public interface IVignettePersistenceService
    {
        Task SaveVignette(LicencePlate licencePlate, DateTime dateTime, LicenceDuration licenceDuration);
    }
}

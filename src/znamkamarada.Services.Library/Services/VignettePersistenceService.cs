using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Threading.Tasks;
using znamkamarada.Services.Library.ModelsDto;

namespace znamkamarada.Services.Library
{

    public class VignettePersistenceServiceTableStorage : IVignettePersistenceService
    {
        public VignettePersistenceServiceTableStorage(IVignettePersistenceConfiguration configuration)
        {
            this.configuration = configuration;
        }
        private readonly IVignettePersistenceConfiguration configuration;

        private CloudTable CreateTable()
        {
            var storageAccount = CloudStorageAccount.Parse(configuration.TableStorageConnectionString);
            var tableClient = storageAccount.CreateCloudTableClient();
            var tableReference = tableClient.GetTableReference(configuration.TableName);
            return tableReference;
        }

        private async Task<CloudTable> GetTable()
        {
            var t = CreateTable();
            if (await t.ExistsAsync() == false) {
                await t.CreateIfNotExistsAsync();
            }
            return t;
        }
        public Task SaveVignette(LicencePlate licencePlate, DateTime dateTime, LicenceDuration licenceDuration)
        {
            var t = GetTable();
            throw new NotImplementedException();
        }
    }
}

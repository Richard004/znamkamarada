using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Threading.Tasks;
using znamkamarada.Services.Library.ModelsDto;

namespace znamkamarada.Services.Library
{

    public class VignettePersistenceServiceTableStorage : IVignettePersistenceService
    {
        private Task<CloudTable> jobStatusTableTask;
        private string vignetteTableConnectionString = Environment.GetEnvironmentVariable("VIGNETTE-TABLE-CONNECTION-");
        private string vignetteTableName = "";



        private CloudTable CreateTable()
        {
            var storageAccount = CloudStorageAccount.Parse(vignetteTableConnectionString);
            var tableClient = storageAccount.CreateCloudTableClient();
            var tableReference = tableClient.GetTableReference(vignetteTableName);
            return tableReference;
        }

    }
}

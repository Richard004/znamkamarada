using Microsoft.Extensions.Configuration;

namespace znamkamarada.Services.Library
{
    public class VignettePersistenceConfiguration : IVignettePersistenceConfiguration
    {
        private readonly IConfiguration configuration;
        public VignettePersistenceConfiguration(IConfiguration Configuration)
        {
            configuration = Configuration;
        }
        public string TableStorageConnectionString => configuration["VignettePersistence:TableStorageConnectionString"];
        public string TableName => configuration["VignettePersistence:TableName"];
    }
}

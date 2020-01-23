namespace znamkamarada.Services.Library
{
    public interface IVignettePersistenceConfiguration
    {
        string TableStorageConnectionString { get; }
        string TableName { get; }
    }
}

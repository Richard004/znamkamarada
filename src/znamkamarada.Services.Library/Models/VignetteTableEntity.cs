using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace znamkamarada.Services.Library
{
    public class VignetteTableEntity : TableEntity
    {
        public string LicencePlateKey { get; set; }
        
        public DateTime StartDate { get; set; }
        
        // Serialized enum LicenceDuration
        public int LicenceDuration { get; set; }


        public VignetteTableEntity(LicencePlate licencePlate,DateTime startDate, LicenceDuration licenceDuration)
        {
            var licenceKey = licencePlate.ToKey();
            this.PartitionKey = ToPartitionKey(licenceKey);
            this.RowKey = licenceKey;
            StartDate = startDate;
            LicenceDuration = (int)licenceDuration;
        }


        // we try to take 'at most' last 3 characters from the licence plate to have somehow equally distributed partitions
        private string ToPartitionKey(string licencePlateKey)
        {
            var last3 = Math.Max(0, licencePlateKey.Length - 3);
            return licencePlateKey.Substring(last3);
        }
    }

}

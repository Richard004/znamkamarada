namespace znamkamarada.Services.Library
{
    public class LicencePlate
    {
        public string country;
        public string number;

        public LicencePlate(string country,string number)
        {
            this.country = country;
            this.number = number;
        }

        public string ToKey() => $"{country}*{number}";
        public override string ToString() => ToKey();
    }
}

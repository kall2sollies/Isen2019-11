namespace Isen.Dotnet.Library.Model
{
    public class City : BaseEntity
    {
        public string Name { get;set; }
        public string Zip { get;set; }
        public double Lat { get;set; }
        public double Lon { get;set; }
    }
}
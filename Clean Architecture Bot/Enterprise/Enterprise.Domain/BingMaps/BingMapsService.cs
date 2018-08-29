using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Domain.BingMaps
{
    public class BingMapsModel
    {
        public int EstimatedTotal { get; set; }
        public List<Location> Locations { get; set; }
    }
    public class Location
    {
        public string LocationType { get; set; }
        public List<double> BoundaryBox { get; set; }
        public string Name { get; set; }
        public GeocodePoint Point { get; set; }
        public Address Address { get; set; }
        public string Confidence { get; set; }
        public string EntityType { get; set; }
        public List<GeocodePoint> GeocodePoints { get; set; }
        public List<string> MatchCodes { get; set; }
    }
    public class Address
    {
        public string AddressLine { get; set; }
        
        public string AdminDistrict { get; set; }
        
        public string AdminDistrict2 { get; set; }
        
        public string CountryRegion { get; set; }
        
        public string FormattedAddress { get; set; }
        
        public string Locality { get; set; }
        
        public string PostalCode { get; set; }
    }
    public class GeocodePoint
    {
        public List<double> Coordinates { get; set; }
        public string CalculationMethod { get; set; }
        public List<string> UsageTypes { get; set; }
    }
    public class LocationApiResponse
    {
        public string AuthenticationResultCode { get; set; }
        public string BrandLogoUri { get; set; }
        public string Copyright { get; set; }
        public List<BingMapsModel> LocationSets { get; set; }
        public int SatusCode { get; set; }
        public string StatusDescription { get; set; }
        public string TraceId { get; set; }
        public string Latitude { get; set; }
        public string Lngitude { get; set; }
    }
}

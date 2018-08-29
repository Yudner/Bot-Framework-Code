using Enterprise.Application.Interfaces;
using Enterprise.Domain.BingMaps;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Enterprise.Infrastructure.BingMaps
{
    [Serializable]
    public class GetBingMaps : IBingMaps
    {
        private static readonly string FormCode = "BTCTRL";
        private readonly static string FindByQueryApiUrl = $"https://dev.virtualearth.net/REST/v1/Locations?form={FormCode}&q=";
        private readonly static string FindByPointUrl = $"https://dev.virtualearth.net/REST/v1/Locations/{{0}},{{1}}?form={FormCode}&q=";
        private readonly static string ImageUrlByPoint = $"https://dev.virtualearth.net/REST/V1/Imagery/Map/Road/{{0}},{{1}}/15?form={FormCode}&mapSize=500,280&pp={{0}},{{1}};1;{{2}}&dpi=1&logo=always";
        private readonly static string ImageUrlByBBox = $"https://dev.virtualearth.net/REST/V1/Imagery/Map/Road?form={FormCode}&mapArea={{0}},{{1}},{{2}},{{3}}&mapSize=500,280&pp={{4}},{{5}};1;{{6}}&dpi=1&logo=always";

        public string apiKey = "YOUR API KEY";
        public async Task<BingMapsModel> GetLocationsByQueryAsync(string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                throw new ArgumentNullException(nameof(address));
            }

            return await GetLocationsAsync(FindByQueryApiUrl + Uri.EscapeDataString(address) + "&key=" + apiKey);

        }

        public async Task<BingMapsModel> GetLocationsByPointAsync(double latitude, double longitude)
        {
            return await GetLocationsAsync(
                string.Format(CultureInfo.InvariantCulture, FindByPointUrl, latitude, longitude) + "&key=" + apiKey);
        }

        public string GetLocationMapImageUrl(Location location, int? index = null)
        {
            if (location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }

            var point = location.Point;
            if (point == null)
            {
                throw new ArgumentNullException(nameof(point));
            }

            if (location.BoundaryBox != null && location.BoundaryBox.Count >= 4)
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    ImageUrlByBBox,
                    location.BoundaryBox[0],
                    location.BoundaryBox[1],
                    location.BoundaryBox[2],
                    location.BoundaryBox[3],
                    point.Coordinates[0],
                    point.Coordinates[1], index)
                    + "&key=" + apiKey;
            }
            else
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    ImageUrlByPoint,
                    point.Coordinates[0],
                    point.Coordinates[1],
                    index) + "&key=" + apiKey;
            }
        }

        public async Task<BingMapsModel> GetLocationsAsync(string url)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(url);
                var apiResponse = JsonConvert.DeserializeObject<LocationApiResponse>(response);
                
                return apiResponse.LocationSets?.FirstOrDefault();

            }
        }
    }
}

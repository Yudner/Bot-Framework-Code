using Enterprise.Domain.BingMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enterprise.Application.Interfaces
{
    public interface IBingMaps
    {
        Task<BingMapsModel> GetLocationsByQueryAsync(string address);

        Task<BingMapsModel> GetLocationsByPointAsync(double latitude, double longitude);

        string GetLocationMapImageUrl(Location location, int? index = null);
    }
}

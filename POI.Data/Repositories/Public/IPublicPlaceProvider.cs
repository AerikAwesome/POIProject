using System.Collections.Generic;
using System.Threading.Tasks;
using POI.Common.Models;
using POI.Common.ViewModels;

namespace POI.Data.Repositories.Public
{
    public interface IPublicPlaceProvider
    {
        Task<IEnumerable<PlaceViewModel>> GetInRadius(double latitude, double longitude, double radius);
    }
}

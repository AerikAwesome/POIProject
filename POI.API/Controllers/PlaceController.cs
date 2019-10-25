using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POI.Common.Models;
using POI.Common.ViewModels;
using POI.Data.Repositories;
using POI.Data.Repositories.Public;

namespace POI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly IPublicPlaceProvider _placeProvider;

        public PlaceController(IPublicPlaceProvider placeProvider)
        {
            _placeProvider = placeProvider;
        }

        [HttpGet]
        public async Task<IEnumerable<PlaceViewModel>> GetInRadius(double latitude, double longitude, double radius)
        {
            return await _placeProvider.GetInRadius(latitude, longitude, radius);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POI.Common.Models;
using POI.Data.Repositories;
using POI.Data.Repositories.Places;

namespace POI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly IProvider<Place> _placeProvider;
        private readonly IProcessor<Place> _placeProcessor;

        public PlaceController(IProvider<Place> placeProvider, IProcessor<Place> placeProcessor)
        {
            _placeProvider = placeProvider;
            _placeProcessor = placeProcessor;
        }

        // GET: api/Place
        [HttpGet]
        public async Task<IEnumerable<Place>> Get()
        {
            return await _placeProvider.Get();
        }

        // GET: api/Place/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<Place> Get(int id)
        {
            return await _placeProvider.Get(id);
        }

        // POST: api/Place
        [HttpPost]
        public async Task Post([FromBody] Place place)
        {
            await _placeProcessor.Create(place);
        }

        // PUT: api/Place/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Place place)
        {
            await _placeProcessor.Update(place);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _placeProcessor.Delete(id);
        }
    }
}

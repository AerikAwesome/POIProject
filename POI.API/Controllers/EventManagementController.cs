using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POI.Common.Models;
using POI.Data.Repositories;
using POI.Data.Repositories.Management;

namespace POI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventManagementController : BaseManagementController, IManagementController<Event>
    {
        private readonly IEventProvider _eventProvider;
        private readonly IProcessor<Event> _eventProcessor;

        public EventManagementController(IEventProvider eventProvider, IProcessor<Event> eventProcessor)
        {
            _eventProvider = eventProvider;
            _eventProcessor = eventProcessor;
        }

        // GET: api/Event
        [HttpGet]
        public async Task<IEnumerable<Event>> Get()
        {
            return await _eventProvider.Get();
        }

        // GET: api/Event/5
        [HttpGet("{id}")]
        public async Task<Event> Get(int id)
        {
            return await _eventProvider.Get(id);
        }

        // POST: api/Event
        [HttpPost]
        public async Task<Event> Post([FromBody] Event value)
        {
            return await _eventProcessor.Create(value);
        }

        // PUT: api/Event/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Event value)
        {
            value.Id = id;
            await _eventProcessor.Update(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _eventProcessor.Delete(id);
        }
    }
}
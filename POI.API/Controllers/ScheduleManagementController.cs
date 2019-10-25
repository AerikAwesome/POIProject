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
    public class ScheduleManagementController : BaseManagementController, IManagementController<Schedule>
    {
        private readonly IProvider<Schedule> _scheduleProvider;
        private readonly IProcessor<Schedule> _scheduleProcessor;

        public ScheduleManagementController(IProvider<Schedule> scheduleProvider, IProcessor<Schedule> scheduleProcessor)
        {
            _scheduleProvider = scheduleProvider;
            _scheduleProcessor = scheduleProcessor;
        }

        // GET: api/ScheduleManagement
        [HttpGet]
        public async Task<IEnumerable<Schedule>> Get()
        {
            return await _scheduleProvider.Get();
        }

        // GET: api/ScheduleManagement/5
        [HttpGet("{id}")]
        public async Task<Schedule> Get(int id)
        {
            return await _scheduleProvider.Get(id);
        }

        // POST: api/ScheduleManagement
        [HttpPost]
        public async Task<Schedule> Post([FromBody] Schedule value)
        {
            return await _scheduleProcessor.Create(value);
        }

        // PUT: api/ScheduleManagement/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Schedule value)
        {
            value.Id = id;
            await _scheduleProcessor.Update(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _scheduleProcessor.Delete(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POI.Common.Models;

namespace POI.Data.Repositories.Management.Static
{
    public class StaticScheduleRepository : IScheduleProvider, IProcessor<Schedule>
    {
        private static readonly List<Schedule> _schedules = new List<Schedule>
        {
            new Schedule
            {
                Id = 1,
                EventId = 1,
                Enabled = true,
                FrequencyType = FrequencyType.Single,
                StartDate = new DateTime(2019, 11, 4, 20, 0, 0),
                EndDate = new DateTime(2019, 11, 4, 23, 0, 0)
            }
        };

        public async Task<IEnumerable<Schedule>> Get()
        {
            return _schedules;
        }

        public async Task<Schedule> Get(int id)
        {
            return _schedules.SingleOrDefault(s => s.Id == id);
        }

        public async Task<IEnumerable<Schedule>> GetSchedulesForEvent(int eventId)
        {
            return _schedules.Where(s => s.EventId == eventId);
        }

        public async Task<Schedule> Create(Schedule item)
        {
            _schedules.Add(item);
            return item;
        }

        public async Task Update(Schedule item)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int itemId)
        {
            _schedules.RemoveAll(s => s.Id == itemId);
        }
    }
}

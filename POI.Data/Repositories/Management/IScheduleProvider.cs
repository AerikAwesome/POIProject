using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using POI.Common.Models;

namespace POI.Data.Repositories.Management
{
    public interface IScheduleProvider : IProvider<Schedule>
    {
        Task<IEnumerable<Schedule>> GetSchedulesForEvent(int eventId);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using POI.Common.Models;

namespace POI.Common.ViewModels
{
    public class ScheduleViewModel
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ScheduleViewModel(){}

        [Obsolete("Do not use in production! Recurrence is not used with this!")]
        public ScheduleViewModel(Schedule schedule)
        {
            Name = schedule.Name;
            StartDate = schedule.StartDate;
            EndDate = schedule.EndDate;
        }

        public IEnumerable<ScheduleViewModel> GetSchedulesInRange(Schedule schedule, DateTime rangeStartDate,
            DateTime rangeEndDate)
        {
            throw new NotImplementedException();
        }
    }
}

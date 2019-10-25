using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POI.Common.Models;

namespace POI.Common.ViewModels
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ScheduleViewModel> Schedules { get; set; }

        public EventViewModel(){}

        public EventViewModel(Event @event, IEnumerable<ScheduleViewModel> schedules)
        {
            Id = @event.Id;
            Name = @event.Name;
            Description = @event.Description;
            Schedules = schedules.ToList();
        }
    }
}

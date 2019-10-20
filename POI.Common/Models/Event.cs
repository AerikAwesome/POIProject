using System;
using POI.Common.Models;

namespace POI.Common.Models
{
    public class Event
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //TODO add support for recurrence
    }
}

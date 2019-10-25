using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using POI.Common.Models;

namespace POI.Common.Models
{
    [Table("Events")]
    public class Event
    {
        public int Id { get; set; }
        public int PlaceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public virtual ICollection<Schedule> Schedules { get; set; }
    }
}

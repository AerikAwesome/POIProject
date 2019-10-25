using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.SqlServer.Types;

namespace POI.Common.Models
{
    [Table("Places")]
    public class Place
    {
        public int Id { get; set; }
        public bool Visible { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public SqlGeography Coordinates { get; set; }

        //public virtual ICollection<Event> Events { get; set; }
    }
}

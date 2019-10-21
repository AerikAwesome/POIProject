using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.SqlServer.Types;

namespace POI.Common.Models
{
    [Table("Places")]
    public class Place
    {
        public int Id { get; set; }
        public PlaceType Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public SqlGeography Coordinates { get; set; }
    }
}

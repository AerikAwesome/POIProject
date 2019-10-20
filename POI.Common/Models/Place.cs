namespace POI.Common.Models
{
    public class Place : BaseDatabaseObject
    {
        public PlaceType Type { get; set; }
        public string Name { get; set; }

        public Location Location { get; set; }
    }
}

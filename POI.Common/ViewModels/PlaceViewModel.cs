using System.Collections.Generic;
using System.Linq;
using POI.Common.Models;

namespace POI.Common.ViewModels
{
    public class PlaceViewModel
    {
        public int Id { get; set; }
        public bool Visible { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<EventViewModel> Events { get; set; }

        public PlaceViewModel(){}

        public PlaceViewModel(Place place, IEnumerable<EventViewModel> events)
        {
            Id = place.Id;
            Visible = place.Visible;
            Name = place.Name;
            Description = place.Description;
            Address = place.Address;
            Latitude = place.Coordinates.Lat.Value;
            Longitude = place.Coordinates.Long.Value;
            Events = events.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Types;
using POI.Common.Models;
using POI.Common.ViewModels;
using POI.Data.Repositories.Management;
using POI.Data.Repositories.Management.Static;

namespace POI.Data.Repositories.Public
{
    public class ReadOnlyStaticPlaceRepository : IPublicPlaceProvider
    {
        //For the database version, just do a join on the tables
        private readonly IProvider<Place> _placeProvider;
        private readonly IEventProvider _eventProvider;
        private readonly IScheduleProvider _scheduleProvider;

        public ReadOnlyStaticPlaceRepository(IEventProvider eventProvider, IScheduleProvider scheduleProvider, IProvider<Place> placeProvider)
        {
            _eventProvider = eventProvider;
            _scheduleProvider = scheduleProvider;
            _placeProvider = placeProvider;
        }

        public async Task<IEnumerable<PlaceViewModel>> GetInRadius(double latitude, double longitude, double radius)
        {
            var origin = SqlGeography.Point(latitude, longitude, 4326);
            var places = await _placeProvider.Get().ConfigureAwait(false);
            var placesInRadius = places.Where(p => p.Coordinates.STDistance(origin).Value <= radius).ToList();
            List<PlaceViewModel> placeResult = new List<PlaceViewModel>();
            foreach (var place in placesInRadius)
            {
                var events = (await _eventProvider.GetEventsForPlace(place.Id).ConfigureAwait(false)).ToList();
                var eventResult = new List<EventViewModel>();
                foreach (var placeEvent in events)
                {
                    var schedules = (await _scheduleProvider.GetSchedulesForEvent(placeEvent.Id).ConfigureAwait(false)).ToList();
                    eventResult.Add(new EventViewModel(placeEvent, schedules.Select(s => new ScheduleViewModel(s))));
                }
                placeResult.Add(new PlaceViewModel(place, eventResult));
            }

            return placeResult;
        }
    }
}

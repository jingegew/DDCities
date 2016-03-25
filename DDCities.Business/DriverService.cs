using System;
using System.Collections.Generic;
using System.Linq;
using DDCities.Data;

namespace DDCities.Business
{
    public class DriverService
    {
        private readonly UnitOfWork _work;

        public DriverService(UnitOfWork work)
        {
            _work = work;
        }

        public IEnumerable<RideRequest> FindBestRideRequests(TripModel model)
        {
            var requests = _work.RideRequestRepository.Get(r => r.Address.City == model.FromCity && r.Address1.City == model.ToCity);
            return requests.Where(ride => ride.LeaveAfter <= model.LeaveBefore && ride.LeaveBefore >= model.LeaveAfter);
        }
    }
}
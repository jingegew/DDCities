using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DDCities.Business;
using DDCities.Data;
using DDCities.WebAPI.Models;

namespace DDCities.WebAPI.Controllers
{
    [RoutePrefix("api/Rider")]
    public class RiderController : ApiController
    {
        private readonly UnitOfWork _work = new UnitOfWork();

        // POST api/Rider/RequestRide
        [Route("RequestRide")]
        public IHttpActionResult RequestRide(RideRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //if it is first time user, save it.
            User user = _work.UserRepository.Get(u => u.Email == model.Email).FirstOrDefault();
            if (user == null)
            {
                user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Phone = model.Phone
                };
                _work.UserRepository.Insert(user);
                _work.Save();
            }

            //if it is a new line, save it.
            TripService addressService = new TripService(_work);
            long fromAddressId = addressService.SaveOrigrinAddress(model);
            long toAddressId = addressService.SaveDestinationAddress(model);

            //Save Requset
            var request = new RideRequest
            {
                UserId = user.UserId,
                FromAddressId = fromAddressId,
                ToAddressId = toAddressId,
                LeaveAfter = model.LeaveAfter,
                LeaveBefore = model.LeaveBefore,
                NumberOfRider = 1,
                Comment = model.Comment,
                CreatedOn = DateTime.Today,
                LastUpdateOn = DateTime.Today
            };
            _work.RideRequestRepository.Insert(request);
            _work.Save();

            List<DriverSchedule> schedules = FindBestDriverSchedules(request).ToList();
            if (schedules.Any())
            {
                var service = new NotificationService();
                service.NotifyMatchedDriverSchedule(user.Email, schedules);
            }

            return Ok("success");
        }

        private IEnumerable<DriverSchedule> FindBestDriverSchedules(RideRequest reqeust)
        {
            List<DriverSchedule> schedules =
                _work.DriverScheduleRepository.Get(d => d.Address.City == reqeust.Address.City && d.Address1.City == reqeust.Address1.City)
                    .ToList();
            return schedules.Where(s => s.IsInRange(reqeust.LeaveAfter, reqeust.LeaveBefore));
        }

        // GET api/Rider/GetRideRequests
        [Route("GetRideRequests")]
        public IHttpActionResult GetRideRequests()
        {
            IEnumerable<RideRequest> rides = _work.RideRequestRepository.Get();

            var models = rides.Select(ride => new
            {
                ride.RideRequstId,
                ride.User.FirstName,
                ride.User.LastName,
                From = ride.Address.ToDisplayAddress(),
                To = ride.Address1.ToDisplayAddress(),
                ride.Comment
            });
            return Ok(models);
        }
    }
}
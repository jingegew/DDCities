using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DDCities.Business;
using DDCities.Data;
using DDCities.WebAPI.Models;

namespace DDCities.WebAPI.Controllers
{
    [RoutePrefix("api/Driver")]
    public class DriverController : ApiController
    {
        private readonly UnitOfWork _work = new UnitOfWork();

        // POST api/Driver/ProcessDriverSchedule
        [Route("ProcessDriverSchedule")]
        public IHttpActionResult ProcessDriverSchedule(DriverTripModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Save driver schedule
            long fromAddressId = SaveAddress(model.FromAddress, model.FromCity, model.FromState);
            long toAddressId = SaveAddress(model.ToAddress, model.ToCity, model.ToState);

            //Save Driver if he is not login
            var user = _work.UserRepository.Get(u => u.Email == model.DriverInfo.Email).FirstOrDefault();
            if (user == null)
            {
                user = new User
                {
                    FirstName = model.DriverInfo.FirstName,
                    LastName = model.DriverInfo.LastName,
                    Email = model.DriverInfo.Email,
                    Phone = model.DriverInfo.Phone
                };
                _work.UserRepository.Insert(user);
                _work.Save();
            }

            //Save car
            Car car = _work.CarRepository.Get(c => c.Make == model.CarInfo.Make && c.Model == model.CarInfo.Model && c.Year == model.CarInfo.Year && c.Type == (short)model.CarInfo.SelectedCarType).FirstOrDefault();
            if (car == null)
            {
                car = new Car
                {
                    Make = model.CarInfo.Make,
                    Model = model.CarInfo.Model,
                    Year = model.CarInfo.Year,
                    Type = (short)model.CarInfo.SelectedCarType
                };
                _work.CarRepository.Insert(car);
                _work.Save();
            }

            var schedule = new DriverSchedule
            {
                LeaveAfter = model.LeaveAfter,
                LeaveBefore = model.LeaveBefore,
                FromAddressId = fromAddressId,
                ToAddressId = toAddressId,
                NumberOfSeat = model.SeatNumber,
                UserId = user.UserId,
                CarId = car.CarId,
                Repeats = string.Join(",", model.Repeats),
                Comment = model.Comment,
                Fee = model.Fee,
                CreatedOn = DateTime.Today,
                LastUpdateOn = DateTime.Today
            };
            _work.DriverScheduleRepository.Insert(schedule);
            _work.Save();

            var driverService = new DriverService(_work);

            var rideRequests = driverService.FindBestRideRequests(model).ToList();
            if (rideRequests.Any())
            {
                var service = new NotificationService();
                service.NotifyMatchedRideRequest(user.Email, rideRequests);
            }

            return Ok("success");
        }

        private long SaveAddress(string street, string city, string state)
        {
            Address address = _work.AddressRepository.Get(a => a.Address1 == street && a.City == city && a.State == state).FirstOrDefault();
            //Save line if not there
            if (address == null)
            {
                address = new Address
                {
                    Address1 = street,
                    City = city,
                    State = state
                };
                _work.AddressRepository.Insert(address);
                _work.Save();
            }
            return address.AddressId;
        }

        // GET api/Driver/GetDriverSchedules
        [Route("GetDriverSchedules")]
        public IHttpActionResult GetDriverSchedules()
        {
            IEnumerable<DriverSchedule> schedules = _work.DriverScheduleRepository.Get();
            var data = schedules.Select(schedule => new
            {
                schedule.Car.Model,
                schedule.Car.Make,
                schedule.Car.Year,
                From = schedule.Address.ToDisplayAddress(),
                To = schedule.Address1.ToDisplayAddress(),
                schedule.LeaveAfter,
                schedule.LeaveBefore,
                schedule.Comment
            });
            return Ok(data);
        }
    }
}

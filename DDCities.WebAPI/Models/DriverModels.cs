using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DDCities.Business;

namespace DDCities.WebAPI.Models
{
    public class DriverInfo
    {
        public string DriverLicense { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class CarInfo
    {
        public int Year { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public CarType SelectedCarType { get; set; }
        public IEnumerable<SelectListItem> CarTypeList { get; set; }
    }

    public enum CarType
    {
        Sedan = 1,
        SUV = 2,
        Truck = 4,
        Minivan = 8,
        Convertible = 16,
        Coupe = 32,
        Wagon = 64,
        Luxury = 128
    }

    public class DriverTripModel : DriverScheduleModel
    {
        public DriverInfo DriverInfo { get; set; }
        public CarInfo CarInfo { get; set; }
        public int SeatNumber { get; set; }
    }
}
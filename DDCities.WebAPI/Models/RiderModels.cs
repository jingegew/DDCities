
using System;
using DDCities.Business;

namespace DDCities.WebAPI.Models
{
    public class RiderInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class RiderTripInfo : TripModel
    {
        public int RiderNumber { get; set; }
        public int LuggageNumber { get; set; }
    }

    public class RideRequestModel : TripModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; } 

    }
}
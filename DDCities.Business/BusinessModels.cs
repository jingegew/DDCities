using System;
using System.Collections.Generic;

namespace DDCities.Business
{
    public class TripModel
    {
        public string FromAddress { get; set; }
        public string FromCity { get; set; }
        public string FromState { get; set; }
        public string ToAddress { get; set; }
        public string ToCity { get; set; }
        public string ToState { get; set; }
        public DateTime LeaveAfter { get; set; }
        public DateTime LeaveBefore { get; set; }
        public string Comment { get; set; }
    }

    public class DriverScheduleModel : TripModel
    {
        public decimal? Fee { get; set; }
        public IEnumerable<string> Repeats { get; set; }
    }
}
using System;

namespace DDCities.Data
{
    public partial class Line
    {
        public bool Equals(Line line)
        {
            return From == line.From && To == line.To;
        }
    }

    public partial class DriverSchedule
    {
        public bool IsInRange(DateTime start, DateTime to)
        {
            if(!(LeaveBefore < start || to < LeaveAfter))
                return true;
            //TODO repeat, comparing again
            return false;
        }
    }

    public partial class Address
    {
        public string ToDisplayAddress()
        {
            return string.Format("{0}, {1}, {2} {3}", Address1, City, State, ZipCode);
        }
    }
}
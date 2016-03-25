using System;
using System.Collections.Generic;
using System.Linq;
using DDCities.Data;

namespace DDCities.Business
{
    public class RiderService
    {
        private readonly UnitOfWork _work;

        public RiderService(UnitOfWork work)
        {
            _work = work;
        }

        public IEnumerable<DriverSchedule> FindBestDriverSchedules(TripModel model)
        {
            IEnumerable<DriverSchedule> driverSchedules =
                _work.DriverScheduleRepository.Get(d => d.Address.City == model.FromCity && d.Address1.City == model.ToCity);

            foreach (var schedule in driverSchedules)
            {
                DateTime start = schedule.LeaveAfter;
                DateTime end = schedule.LeaveBefore;
                if (string.IsNullOrEmpty(schedule.Repeats))
                {
                    if (start <= model.LeaveAfter && end >= model.LeaveBefore)
                        yield return schedule;
                }
                else
                {
                    IEnumerable<string> days = schedule.Repeats.Split(',');
                    DayOfWeek day = model.LeaveAfter.DayOfWeek;
                    if (days.Contains((int)day + ""))
                    {
                        if (start.TimeOfDay <= model.LeaveBefore.TimeOfDay && end.TimeOfDay >= model.LeaveAfter.TimeOfDay)
                        {
                            yield return schedule;
                        }
                    }

                }
            }
        }
    }
}
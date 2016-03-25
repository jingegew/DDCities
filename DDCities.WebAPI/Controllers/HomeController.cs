using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DDCities.WebAPI.Models;

namespace DDCities.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult RequestRide()
        {
            ViewBag.Title = "New Ride Request Page";

            return View();
        }

        public ActionResult ProvideRide()
        {
            ViewBag.Title = "New Ride Request Page";
            var model = new DriverTripModel();
            var carInfo = new CarInfo();
            var items = new List<SelectListItem>();
            foreach (CarType type in Enum.GetValues(typeof (CarType)))
            {
                items.Add(new SelectListItem
                {
                    Text = type.ToString(),
                    Value = type.ToString()
                });;
            }
            carInfo.CarTypeList = items;
            model.CarInfo = carInfo;
            return View(model);
        }

        public ActionResult ViewDriverSchedule()
        {
            ViewBag.Title = "All Driver Schedules";
            return View();
        }

        public ActionResult ViewRideRequest()
        {
            ViewBag.Title = "All Ride Requests";
            return View();
        }

        public ActionResult Success()
        {
            ViewBag.Title = "Success";
            return View();
        }
    }
}

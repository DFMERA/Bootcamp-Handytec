using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicationML3.Models;
using WebApplicationML3ML.Model;

namespace WebApplicationML3.Controllers
{
    public class HotelBookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Predict()
        {
            HotelBooking hotelBooking = new HotelBooking()
            {
                HotelBookingData = new WebApplicationML3ML.Model.ModelInput()
                {
                    Lead_time = 0,
                    Arrival_date_month = "July",
                    Arrival_date_day_of_month = 1,
                    Stays_in_weekend_nights = 0,
                    Stays_in_week_nights = 2,
                    Adults = 2,
                    Children = 0,
                    Reserved_room_type = 0
                },
                HotelBookingRate = new WebApplicationML3ML.Model.ModelOutput()
                {
                    Score = 0
                }
            };

            return View(hotelBooking);
        }

        [HttpPost]
        public IActionResult Predict(HotelBooking hotelBooking)
        {
            hotelBooking.HotelBookingRate = ConsumeModel.Predict(hotelBooking.HotelBookingData);

            return View(hotelBooking);
        }
    }
}
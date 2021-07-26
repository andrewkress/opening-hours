using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OpeningHours.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpeningHours.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class OpenHourController : ControllerBase {

        private readonly ILogger<OpenHourController> _logger;

        public OpenHourController(ILogger<OpenHourController> logger) {
            _logger = logger;
        }

        [HttpPost]
        public String Post(OpenHour openHour) {
            String outputHours = new String("");
            List<Day> monday = openHour.monday.ConvertAll<Day>(convertDay);
            List<Day> tuesday = openHour.tuesday.ConvertAll<Day>(convertDay);
            List<Day> wednesday = openHour.wednesday.ConvertAll<Day>(convertDay);
            List<Day> thursday = openHour.thursday.ConvertAll<Day>(convertDay);
            List<Day> friday = openHour.friday.ConvertAll<Day>(convertDay);
            List<Day> saturday = openHour.saturday.ConvertAll<Day>(convertDay);
            List<Day> sunday = openHour.sunday.ConvertAll<Day>(convertDay);

            pushDay(monday, tuesday);
            pushDay(tuesday, wednesday);
            pushDay(wednesday, thursday);
            pushDay(thursday, friday);
            pushDay(friday, saturday);
            pushDay(saturday, sunday);
            pushDay(sunday, monday);
            outputHours += buildDayText(monday, "Monday");
            outputHours += buildDayText(tuesday, "Tuesday");
            outputHours += buildDayText(wednesday, "Wednesday");
            outputHours += buildDayText(thursday, "Thursday");
            outputHours += buildDayText(friday, "Friday");
            outputHours += buildDayText(saturday, "Saturday");
            outputHours += buildDayText(sunday, "Sunday");
            return outputHours.ToString();
        }

        private Day convertDay(IDayConverter input) => input.GetDay();

        private void pushDay(List<Day> firstDay, List<Day> secondDay) {
            Day secondTime = secondDay.FirstOrDefault();
            if (secondTime?.Type.Equals("close") ?? false) {
                firstDay.Add(secondTime);
                secondDay.RemoveAt(0);
            }
        }

        private String buildDayText(List<Day> dayIn, String dayName) {
            StringBuilder outputHours = new StringBuilder();
            outputHours.Append($"{dayName}: ");
            foreach (Day day in dayIn) {
                TimeSpan time = TimeSpan.FromSeconds(day.Value);
                string str = new DateTime(time.Ticks).ToString("h:mm tt");
                if (day.Type.Equals("close")) {
                    outputHours.Append(" - ");
                } 
                outputHours.Append(str);
                if (day.Type.Equals("close")) {
                    outputHours.Append(", ");
                }
            }
            if (dayIn.Count() == 0) {
                outputHours.Append("Closed");
            }
            if(outputHours.ToString().EndsWith("M")) {
                outputHours.Append(" -");
            }
            return outputHours.ToString().TrimEnd(new char[] { ',', ' ' }) + Environment.NewLine;
        }
    }
}

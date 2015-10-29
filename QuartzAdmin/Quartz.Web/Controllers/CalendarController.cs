using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace QuartzAdmin.web.Controllers
{
    public class CalendarController : Controller
    {
        Models.InstanceRepository instanceRepo = new QuartzAdmin.web.Models.InstanceRepository();

        //
        // GET: /Calendar/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(string instanceName, string itemName)
        {
            Models.InstanceModel instance = instanceRepo.GetInstance(instanceName);

            Models.CalendarRepository calRepo = new QuartzAdmin.web.Models.CalendarRepository(instance);
            Quartz.ICalendar cal = calRepo.GetCalendar(itemName);
            ViewData["calendarName"] = itemName;

            if (cal == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(cal);
            }
        }

    }
}

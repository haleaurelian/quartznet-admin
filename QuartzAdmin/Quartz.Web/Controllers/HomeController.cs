using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuartzAdmin.web.Controllers
{

    [HandleError]
    public class HomeController : Controller
    {

        //Models.GroupRepository groupRepo = new QuartzAdmin.web.Models.GroupRepository();
        Models.InstanceRepository repo = new QuartzAdmin.web.Models.InstanceRepository();

        public ActionResult Index()
        {
            var instances = repo.GetAll();
            //var groups = groupRepo.FindAllGroups().ToList();
            return View(instances);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}

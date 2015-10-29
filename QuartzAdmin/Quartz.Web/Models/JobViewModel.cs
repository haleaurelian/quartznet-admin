using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuartzAdmin.web.Models
{
    public class JobViewModel
    {
        public Quartz.IJobDetail JobDetail { get; set; }
        public IList<Quartz.ITrigger> Triggers { get; set; }
    }
}

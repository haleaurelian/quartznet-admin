using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuartzAdmin.web.Models
{
    public class InstanceViewModel
    {
        public InstanceModel Instance { get; set; }
        public List<Quartz.IJobDetail> Jobs { get; set; }
        public List<Quartz.ITrigger> Triggers { get; set; }
    }
}

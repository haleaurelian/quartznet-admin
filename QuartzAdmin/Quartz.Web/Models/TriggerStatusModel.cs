using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuartzAdmin.web.Models
{
    public class TriggerStatusModel
    {
        public string NextFireTime { get; set; }
        public string LastFireTime { get; set; }
        public string GroupName { get; set; }
        public string TriggerName { get; set; }
        public string JobName { get; set; }
        public Quartz.TriggerState State { get; set; }
        public string StateDesc
        {
            get
            {
                return State.ToString();
            }
        }
    }
}

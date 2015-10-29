using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Calendar;

namespace QuartzAdmin.web.Models
{
    public class CalendarRepository 
    {
        private InstanceModel quartzInstance;
        public CalendarRepository(Models.InstanceModel instance)
        {
            quartzInstance = instance;
        }
        public ICalendar GetCalendar(string calendarName)
        {
            IScheduler sched = quartzInstance.GetQuartzScheduler();
            return sched.GetCalendar(calendarName);
            
        }
    }
}

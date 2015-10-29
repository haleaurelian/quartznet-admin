using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.ActiveRecord;
using Castle.Components.Validator;
using Iesi.Collections.Generic;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Calendar;
using Quartz.Impl.Matchers;

namespace QuartzAdmin.web.Models
{
    [ActiveRecord(Table="QRTZ_SCHEDULER_STATE")]//"tbl_instances")]
    public class InstanceModel : ActiveRecordValidationBase<InstanceModel>
    {
        public InstanceModel()
        {
            //InstanceProperties = new HashedSet<InstancePropertyModel>();
        }

        //[PrimaryKey(Column = "SCHED_NAME")]
        [Property(Column = "SCHED_NAME")]
        public virtual string SchedulerName { get; set; }

        [Property(Column = "INSTANCE_NAME")]
        //[Property, ValidateNonEmpty]
        public virtual string InstanceName { get; set; }

        //[HasMany(typeof(InstancePropertyModel), Table = "tbl_instanceproperties",
        //         ColumnKey = "InstanceID",
        //         Cascade = ManyRelationCascadeEnum.All, Inverse=true)]
        //public virtual Iesi.Collections.Generic.ISet<InstancePropertyModel> InstanceProperties { get; set; }
        
        private IScheduler _CurrentScheduler = null;

        public IScheduler GetQuartzScheduler()
        {
            if (_CurrentScheduler == null)
            {
                System.Collections.Specialized.NameValueCollection props = new System.Collections.Specialized.NameValueCollection();

                //foreach (InstancePropertyModel prop in this.InstanceProperties)
                //{
                //    props.Add(prop.PropertyName, prop.PropertyValue);
                //}
                props.Add("quartz.scheduler.instanceName", this.SchedulerName);
                props.Add("quartz.scheduler.instanceId", this.InstanceName);

                props.Add("quartz.jobStore.clustered", "true");
                props.Add("quartz.jobStore.type", "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz");
                props.Add("quartz.jobStore.useProperties", "true");
                props.Add("quartz.jobStore.dataSource", "default");
                props.Add("quartz.jobStore.tablePrefix", "QRTZ_");
                // if running MS SQL Server we need this
                props.Add("quartz.jobStore.lockHandler.type", "Quartz.Impl.AdoJobStore.UpdateLockRowSemaphore, Quartz");

                props.Add("quartz.dataSource.default.connectionString", "Server=.\\SQLEXPRESS;Database=Scheduler;Trusted_Connection=True;");
                props.Add("quartz.dataSource.default.provider", "SqlServer-20");

                ISchedulerFactory sf = new StdSchedulerFactory(props);
                _CurrentScheduler = sf.GetScheduler();
            }

            return _CurrentScheduler;

        }

        public IQueryable<string> FindAllGroups()
        {
            IScheduler sched = this.GetQuartzScheduler();

            List<string> groups = new List<string>();

            IList<string> jobGroups = sched.GetJobGroupNames();
            IList<string> triggerGroups = sched.GetTriggerGroupNames();

            foreach (string jg in jobGroups)
            {
                groups.Add(jg);
            }

            foreach (string tg in triggerGroups)
            {
                if (!groups.Contains(tg))
                {
                    groups.Add(tg);
                }
            }

            return jobGroups.AsQueryable();
        }

        public List<IJobDetail> GetAllJobs(string groupName)
        {
            List<IJobDetail> jobs = new List<IJobDetail>();
            IScheduler sched = this.GetQuartzScheduler();
            string[] jobNames = sched.GetJobKeys(GroupMatcher<JobKey>.GroupEquals(groupName)).Select(tk => tk.Name).ToArray(); // GetJobNames(groupName);

            foreach (string jobName in jobNames)
            {
                jobs.Add(sched.GetJobDetail(new JobKey(jobName, groupName)));
            }

            return jobs;
        }

        public List<IJobDetail> GetAllJobs()
        {
            List<IJobDetail> jobs = new List<IJobDetail>();
            var groups = FindAllGroups();
            foreach (string group in groups)
            {
                List<IJobDetail> groupJobs = GetAllJobs(group);
                jobs.AddRange(groupJobs);
            }
            return jobs;
        }

        public List<ITrigger> GetAllTriggers(string groupName)
        {
            List<ITrigger> triggers = new List<ITrigger>();
            IScheduler sched = this.GetQuartzScheduler();
            string[] triggerNames = sched.GetTriggerKeys(GroupMatcher<TriggerKey>.GroupEquals(groupName)).Select(tk => tk.Name).ToArray();// GetTriggeNames(groupName);

            foreach (string triggerName in triggerNames)
            {
                triggers.Add(sched.GetTrigger(new TriggerKey(triggerName, groupName)));
            }

            return triggers;
        }

        public List<ITrigger> GetAllTriggers()
        {
            List<ITrigger> triggers = new List<ITrigger>();
            var groups = FindAllGroups();
            foreach (string group in groups)
            {
                List<ITrigger> groupTriggers = GetAllTriggers(group);
                triggers.AddRange(groupTriggers);
            }

            return triggers;
        }



    }
}

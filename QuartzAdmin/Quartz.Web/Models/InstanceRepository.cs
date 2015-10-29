using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using Castle.ActiveRecord;
using Iesi.Collections.Generic;


namespace QuartzAdmin.web.Models
{
    public class InstanceRepository: IInstanceRepository
    {
        public List<InstanceModel> GetAll()
        {
            if(!ActiveRecordStarter.IsInitialized)
                ActiveRecordStarter.Initialize();
            
            List<InstanceModel> instances = new List<InstanceModel>();

            InstanceModel[] tmp_instances = InstanceModel.FindAll();
            foreach (InstanceModel instance in tmp_instances)
            {
                instances.Add(instance);
            }

            return instances;
        }

        public InstanceModel GetInstanceByID(int instanceID)
        {
            if (!ActiveRecordStarter.IsInitialized)
                ActiveRecordStarter.Initialize();

            InstanceModel instance = new InstanceModel();

            instance = InstanceModel.Find(instanceID);
            
            return instance;
        }

        public InstanceModel GetByName(string instanceName)
        {
            if (!ActiveRecordStarter.IsInitialized)
                ActiveRecordStarter.Initialize();

            InstanceModel instance = new InstanceModel();

            instance = InstanceModel.FindFirst(Expression.Eq("InstanceName", instanceName));

            return instance;
        }

        public InstanceModel GetInstance(string instanceName)
        {
            if (!ActiveRecordStarter.IsInitialized)
                ActiveRecordStarter.Initialize();

            InstanceModel instance = new InstanceModel();

            instance = InstanceModel.FindFirst(Expression.Eq("InstanceName", instanceName));

            return instance;
        }


        public void Save(InstanceModel instance)
        {
            if (!ActiveRecordStarter.IsInitialized)
                ActiveRecordStarter.Initialize();


            instance.Save();
        }
        public void Delete(InstanceModel instance)
        {
            if (!ActiveRecordStarter.IsInitialized)
                ActiveRecordStarter.Initialize();


            instance.Delete();
        }

    }
}

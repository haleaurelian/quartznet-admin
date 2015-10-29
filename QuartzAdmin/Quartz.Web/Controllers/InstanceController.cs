using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Quartz;
using Quartz.Impl;

namespace QuartzAdmin.web.Controllers
{
    public class InstanceController : Controller
    {
        public Models.IInstanceRepository Repository { get; set; }

        public InstanceController()
        {
            Repository = new QuartzAdmin.web.Models.InstanceRepository();
        }
        public InstanceController(Models.IInstanceRepository repository)
        {
            Repository = repository;
        }

        //
        // GET: /Instance/

        public ActionResult Index()
        {
            return View(Repository.GetAll());
        }

        //
        // GET: /Instance/Details/5

        public ActionResult Details(string id)
        {
            Models.InstanceModel instance = Repository.GetByName(id);
            if (instance == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(instance);
            }
        }

        //
        // GET: /Instance/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Instance/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            Models.InstanceModel instance = new QuartzAdmin.web.Models.InstanceModel();
            instance.InstanceName = collection["InstanceName"];

            foreach (string key in collection.Keys)
            {
                if (key.Contains("InstancePropertyKey") && collection[key].Length > 0)
                {
                    string propIdx = key.Replace("InstancePropertyKey-", "");
                    //instance.InstanceProperties.Add(new QuartzAdmin.web.Models.InstancePropertyModel() { ParentInstance = instance, PropertyName = collection[key], PropertyValue = collection["InstancePropertyValue-" + propIdx.ToString()] });
                }
            }
            this.Repository.Save(instance);

            return RedirectToAction("Index");
        }

        //
        // GET: /Instance/Edit/5
 
        public ActionResult Edit(string id)
        {
            Models.InstanceModel instance = this.Repository.GetByName(id);

            return View(instance);
        }

        //
        // POST: /Instance/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(string id, FormCollection collection)
        {
            Models.InstanceModel instance = this.Repository.GetByName(id);
            //instance.InstanceProperties.Clear();
            //foreach (var p in instance.InstanceProperties)
            //{
            //    //instance.InstanceProperties.Remove(p);
            //    p.Delete();
            //}
            //instance.InstanceProperties.Clear();
            
            //foreach (string key in collection.Keys)
            //{
            //    if (key.Contains("InstancePropertyKey") && collection[key].Length>0)
            //    {
            //        string propIdx = key.Replace("InstancePropertyKey-", "");
            //        instance.InstanceProperties.Add(new QuartzAdmin.web.Models.InstancePropertyModel() { /*InstanceID=instance.InstanceID*/ ParentInstance=instance, PropertyName = collection[key], PropertyValue = collection["InstancePropertyValue-" + propIdx.ToString()] });
            //    }
            //}
            this.Repository.Save(instance);
    
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            Models.InstanceModel instance = this.Repository.GetByName(id);
            return View(instance);

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(string id, FormCollection collection)
        {
            Models.InstanceModel instance = this.Repository.GetByName(id);
            this.Repository.Delete(instance);
            return RedirectToAction("Index");
            
        }

        public ActionResult Connect(string id)
        {
            Models.InstanceModel instance = Repository.GetByName(id);
            if (instance == null)
            {
                return View("NotFound");
            }
            else
            {
                Models.InstanceViewModel ivm = new QuartzAdmin.web.Models.InstanceViewModel() { Instance = instance };
                IScheduler sched = instance.GetQuartzScheduler();
                if (sched == null)
                {
                    return View("NotFound");
                }
                else
                {
                    ivm.Jobs = instance.GetAllJobs();
                    ivm.Triggers = instance.GetAllTriggers();
                    return View(ivm);

                }

            }
        }

        public ActionResult WhatIsMyInstanceID(string id)
        {
            Models.InstanceModel instance = Repository.GetByName(id);
            this.ViewData["MyTime"] = DateTime.Now.ToString("HH:mm");
            return View(instance);
        }
    }
}

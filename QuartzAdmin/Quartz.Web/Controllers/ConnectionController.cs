using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using QuartzAdmin.web.Models;
using QuartzAdmin.web.Helpers;

namespace QuartzAdmin.web.Controllers
{
    public class ConnectionController : Controller
    {
        IConnectionRepository _connectionRepository = new ConnectionRepository();
        public ConnectionController() { }
        public ConnectionController(IConnectionRepository repository)
        {
            _connectionRepository = repository;
        }

        //
        // GET: /Connection/

        public ActionResult Index()
        {
            return View(this._connectionRepository.GetConnections());
        }

        //
        // GET: /Connection/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Connection/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Connection/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            ConnectionModel connection = null;

            try
            {
                connection = new ConnectionModel();
                this.UpdateModel(connection);
                connection.ConnectionParameters.Clear();
                connection.ConnectionParameters.AddRange(ConnectionParameterModel.FromFormCollection(collection));

                if (connection.IsValid)
                {
                    IEnumerable<RuleViolation> ruleViolations = null;
                    if (! this._connectionRepository.IsValid(connection, out ruleViolations))
                    {
                        ModelState.AddRuleViolations(ruleViolations);
                        return View(connection);
                    }
                    
                    this._connectionRepository.AddConnection(connection);
                    this._connectionRepository.Save();
                }
                else
                {
                    ModelState.AddRuleViolations(connection.GetRuleViolations());
                    return View(connection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Connection/Edit/5
 
        public ActionResult Edit(int id)
        {
            ViewResult viewResult = null;

            ConnectionModel connection = this._connectionRepository.GetConnection(id);
            if (connection == null)
            {
                viewResult = View("NotFound", "The specified connection was not found" );
            }
            else
            {
                viewResult = View(connection);
            }

            return viewResult;
            
        }

        //
        // POST: /Connection/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            ConnectionModel connection = null;

            try
            {
                connection = this._connectionRepository.GetConnection(id);
                if (connection == null)
                {
                    return View("NotFound", "The specified connection was not found");
                }

                this.UpdateModel(connection);
                connection.ConnectionParameters.Clear();
                connection.ConnectionParameters.AddRange(ConnectionParameterModel.FromFormCollection(collection));

                if (connection.IsValid)
                {
                    IEnumerable<RuleViolation> ruleViolations = null;
                    if (!this._connectionRepository.IsValid(connection, out ruleViolations))
                    {
                        ModelState.AddRuleViolations(ruleViolations);
                        return View(connection);
                    }
                    this._connectionRepository.Save();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddRuleViolations(connection.GetRuleViolations());
                    return View(connection);
                }
            }
            catch
            {
                return View();
            }
        }
    }
}

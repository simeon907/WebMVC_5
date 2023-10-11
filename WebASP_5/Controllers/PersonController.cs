using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebASP_5.Models.ViewModels;

namespace WebASP_5.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Data;
//using DatabaseDeployer;
using Domain.Entities;
using Domain.Services;
using System.Web.Mvc;
using Clasificados.Models;

namespace Clasificados.Controllers
{
    public class HomeController : Controller
    {
        readonly IReadOnlyRepository _readOnlyRepository;
        readonly IWriteOnlyRepository _writeOnlyRepository;

        public HomeController(IReadOnlyRepository readOnlyRepository, IWriteOnlyRepository writeOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository;
            _writeOnlyRepository = writeOnlyRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Posts()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel rm)
        {
            var user = new User();

            user.Name = rm.Name;
            user.LastName = rm.LastName;
            user.Mail = rm.Mail;
            user.Password = rm.Password;

            return View(rm);
        }

    }
}
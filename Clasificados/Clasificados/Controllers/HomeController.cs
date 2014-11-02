using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clasificados.Models;
using Domain.Entities;
using Domain.Services;

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

        public HomeController()
        {
            
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

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Posts()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel rm)
        {
            var user = new User();

            if (rm.Password.Equals(rm.ConfirmPassword))
            {
                user.Archived = false;
                user.Created = DateTime.Today;
                user.Id = 01;
                user.IsMaster = false;
                user.LastName = rm.LastName;
                user.Mail = rm.Mail;
                user.Name = rm.Name;
                user.Password = rm.Password;
                user.Views = 0;

                var createdUser = _writeOnlyRepository.Create(user);
                
            }
            return View(rm);
        }


    }
}
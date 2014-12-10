using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;
using Domain.Services;
using MiPrimerMVC.Models;
using Ninject;

namespace MiPrimerMVC.Controllers
{
    public class GuestController : Controller
    {

        private readonly IReadOnlyRepository _readOnlyRepository;
        private readonly IWriteOnlyRepository _writeOnlyRepository;

        public GuestController(IReadOnlyRepository readOnlyRepository, IWriteOnlyRepository writeOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository;
            _writeOnlyRepository = writeOnlyRepository;
        }

        public ActionResult Contact()
        {
            var cm = new ContactModel
            {
                Preguntas = _readOnlyRepository.GetAll<Contact>().ToList()
            };

            return View(cm);
        }

        public ActionResult Index()
        {
            Session["User"] = null;
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            if (Session["User"] == null)
            {
                return View(new LoginModel());
            }
            return RedirectToAction("HomeScreen", "Registered");
        }

        [HttpPost]
        public ActionResult Login(LoginModel lm)
        {
            var user = _readOnlyRepository.FirstOrDefault<Users>(x => x.Mail == lm.Mail);
            if (user == null)
            {
                return View(new LoginModel());
            }
            if (!user.CheckPassword(lm.Password))return View(new LoginModel());
           
            Session["User"] = user.Name + " " +user.LastName;
            Session["UserId"] = user.Id;
            Session["Role"] = user.IsMaster;
            return RedirectToAction("HomeScreen", "Registered");
        }

        [HttpPost]
        public ActionResult Contact(ContactModel cm)
        {
            const string cp = "ABCDEFGHIJKLMNOPQRSTUVXYZabcdefghijklmnopqrstuvxyz";
            var faq = new Contact();
            
            if (cm.Name.Any(c => !cp.Contains(c)))
            { 
                ViewBag.Message = "N@adie s3 llama as¡";
                return RedirectToAction("Contact");
            }
            if (cm.Name.Length < 3) { 
                ViewBag.Message = "Vamos, nadie tiene un nombre de tres letras.";
                return RedirectToAction("Contact");
            }
            if (cm.Message.Length > 250) {
                ViewBag.Message = "Intenta escribir lo mismo, pero con menos palabras :)";
                return RedirectToAction("Contact");
            }

            faq.Name = cm.Name;
            faq.Mail = cm.Mail;
            faq.Message = cm.Message;
            faq.IsAnswered = false;
            

            _writeOnlyRepository.Create(faq);
            cm.Preguntas = _readOnlyRepository.GetAll<Contact>().ToList();
            return View(cm);
        }


        [HttpPost]
        public ActionResult Register(RegisteredModel rm)
        {

            var user = new Users();
            user.Name = rm.Name;
            user.LastName = rm.LastName;
            user.Mail = rm.Mail;
            user.Password = rm.Password;
            user.IsMaster = false;
            user.Archived = false;
            user.Created = DateTime.Now;

            string cp = "ABCDEFGHIJKLMNOPQRSTUVXYZabcdefghijklmnopqrstuvxyz0123456789";
            if (rm.Password.Any(c => !cp.Contains(c)))
            {
                return RedirectToAction("Register");
            }

            SHA512 hashtool = SHA512.Create();
            byte[] pass1 = hashtool.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
            string pass = BitConverter.ToString(pass1);
            byte[] salt1 = hashtool.ComputeHash(Encoding.UTF8.GetBytes(user.Mail + user.Name));
            string salt = BitConverter.ToString(salt1);
            byte[] pass2 = hashtool.ComputeHash(Encoding.UTF8.GetBytes(pass.Replace("-", "") + salt.Replace("-", "")));
            string passFinal = BitConverter.ToString(pass2);
            user.Password = passFinal.Replace("-", "");
            user.Salt = salt.Replace("-", "");

            _writeOnlyRepository.Create(user);

          return RedirectToAction("Login");
        }
    }
}
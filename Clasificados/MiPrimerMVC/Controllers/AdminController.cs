using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI;
using Domain.Services;
using Domain.Entities;
using MiPrimerMVC.Models;
using NHibernate.Dialect.Function;
using NHibernate.Type;
using Twilio;

namespace MiPrimerMVC.Controllers
{
    public class AdminController :Controller
    {

        readonly IReadOnlyRepository _readOnlyRepository;
        readonly IWriteOnlyRepository _writeOnlyRepository;

        public AdminController(IReadOnlyRepository readOnlyRepository, IWriteOnlyRepository writeOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository;
            _writeOnlyRepository = writeOnlyRepository;
        }

        public void CheckSession()
        {
            if (Session["User"] == null)
            {
                RedirectToAction("Login", "Guest");
            }
        }


        public ActionResult BanPost(PostModel pm)
        {
            CheckSession();
            pm.Cosas = _readOnlyRepository.GetAll<Posts>().ToList();
            pm.Role = Convert.ToBoolean(Session["Role"].ToString());
            return View(pm);
        }

        public ActionResult AdminDisableEnable(long id)
        {
            var post = _readOnlyRepository.GetById<Posts>(id);

            if (post.AdminArchived == false)
            {
                post.AdminArchive();
                post.Archive();
            }
            else
            {
                post.AdminUnArchive();
            }
            _writeOnlyRepository.Update(post);

            return RedirectToAction("HomeScreen", "Registered");
        }

        public ActionResult AnswerFaq()
        {
            var cm = new ContactModel();
            cm.Preguntas = _readOnlyRepository.GetAll<Contact>().ToList();

            return View(cm);  
        }


        public ActionResult AnswerView(long id)
        {
            var faq = _readOnlyRepository.GetById<Contact>(id);

            var cm = new ContactModel();
            cm.Name = faq.Name;
            cm.Id = id;
            cm.Message = faq.Message;

            return View(cm);
        }

        [HttpPost]
        public ActionResult AnswerView(ContactModel cm)
        {
            var contact = new Contact();

            contact.Id = cm.Id;
            contact.Name = cm.Name;
            contact.Mail = cm.Mail;
            contact.Message = cm.Message;

            contact.SetAnswered();
            _writeOnlyRepository.Update(contact);
            return RedirectToAction("HomeScreen", "Registered");
        }
    }
}
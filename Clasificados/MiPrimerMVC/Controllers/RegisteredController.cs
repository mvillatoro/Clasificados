using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Services;
using Domain.Entities;
using MiPrimerMVC.Models;

namespace MiPrimerMVC.Controllers
{
    public class RegisteredController : Controller
    {

            readonly IReadOnlyRepository _readOnlyRepository;
            readonly IWriteOnlyRepository _writeOnlyRepository;

            public RegisteredController(IReadOnlyRepository readOnlyRepository, IWriteOnlyRepository writeOnlyRepository)
            {
                _readOnlyRepository = readOnlyRepository;
                _writeOnlyRepository = writeOnlyRepository;
            }

        public ActionResult HomeScreen()
        {

            var pm = new PostModel
            {
                Cosas =  _readOnlyRepository.GetAll<Posts>().ToList()
            };

            return View(pm);
        }

        public ActionResult UserProfile()
        {
            return View();
        }

        public ActionResult NewPost()
        {
            return View();
        }

        public ActionResult Detalle(long id)
        {
            var detalle = _readOnlyRepository.GetById<Posts>(id);
            return View(detalle);
        }

        [HttpPost]
        public ActionResult HomeScreen(PostModel pm)
        {
            pm.Cosas = _readOnlyRepository.GetAll<Posts>().ToList();
            return View(pm);
        }

        [HttpPost]
        public ActionResult NewPost(PostModel pm)
        {
            pm.AllTags = _readOnlyRepository.GetAll<Tags>().ToList();

            if (pm.Tittle.Length > 100)
                return RedirectToAction("NewPost");

            if(pm.Details.Length < 255)
                return RedirectToAction("NewPost");

            var post = new Posts();
            post.Tittle = pm.Tittle;
            post.Details = pm.Details;
            int uid = Convert.ToInt32(Session["UserId"]);
            post.OwnerId = uid;
            post.Created = DateTime.Now;
            post.OwnerName = Session["User"].ToString();
            post.Tag1 = pm.Tag1;
            post.Tag2 = pm.Tag2;
            post.Tag3 = pm.Tag3;
            post.Archived = false;

            _writeOnlyRepository.Create(post);
            return View(pm);
        }

    }
}
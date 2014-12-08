using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
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


        //Te envia a la pagina principal
        public ActionResult HomeScreen()
        {

            var pm = new PostModel
            {
                Cosas =  _readOnlyRepository.GetAll<Posts>().ToList()
            };

            return View(pm);
        }

        //Te envia a tu perfil
        public ActionResult UserProfile()
        {
            return View();
        }

        //New Post
        public ActionResult NewPost()
        {
            var pm = new PostModel
            {
                AllTags = _readOnlyRepository.GetAll<Tags>().ToList()

            };
    
            return View(pm);
        }

        //Ver el detalle de un post 
        public ActionResult Detalle(long id)
        {
            var detalle = _readOnlyRepository.GetById<Posts>(id);
            return View(detalle);
        }

        //Muestra los posts en la pantalla principal
        [HttpPost]
        public ActionResult HomeScreen(PostModel pm)
        {
            pm.Cosas = _readOnlyRepository.GetAll<Posts>().ToList();
            return View(pm);
        }

        //Post Nuevo
        [HttpPost]
        public ActionResult NewPost(PostModel pm)
        {
            if (pm.Tittle.Length > 100)
                return RedirectToAction("NewPost");

            if(pm.Details.Length > 255)
                return RedirectToAction("NewPost");

            var post = new Posts();
            post.Tittle = pm.Tittle;
            post.Details = pm.Details;
            int uid = Convert.ToInt32(Session["UserId"]);
            post.OwnerId = uid;
            post.Created = DateTime.Now;
            post.OwnerName = Session["User"].ToString();
            post.Price = pm.Price;
            post.BussType = pm.BussType;

            post.Img1 = pm.Img1 ?? "http://i.memeful.com/memes/wrD4EJR/YUNO.jpg";    
            
            post.Img2 = pm.Img2;
            post.Img3 = pm.Img3;
            post.Img4 = pm.Img5;
            post.Img6 = pm.Img6;
            post.Video = pm.Video;

            post.Tag1 = pm.Tag1;
            post.Tag2 = pm.Tag2;
            post.Tag3 = pm.Tag3;
            post.Archived = false;

            pm.AllTags = _readOnlyRepository.GetAll<Tags>().ToList();

            _writeOnlyRepository.Create(post);
            return RedirectToAction("HomeScreen");
        }


        //Muestra el detalle
        [HttpPost]
        public ActionResult Detalle(PostModel pm)
        {
            var nm = new Messages();
            nm.Receptor = pm.Receptor;
            nm.Sender = Session["User"].ToString();

            var oid = Convert.ToInt32(pm.OwnerId);
            nm.ReceptorId = oid;

            var uid = Convert.ToInt32(Session["UserId"]);
            nm.SenderId = uid;

            nm.Mail = pm.Mail;
            nm.Message = pm.Message;

            nm.Archived = false;

            return RedirectToAction("HomeScreen");
        }
    }
}




     
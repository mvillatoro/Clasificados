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
using Twilio;

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

        public void CheckSession()
        {
            if (Session["User"] == null)
            {
                RedirectToAction("Login", "Guest");
            }
        }

        //Te envia a los featured
        public ActionResult Featured()
        {

            CheckSession();

            var pm = new PostModel
            {
                Cosas = _readOnlyRepository.GetAll<Posts>().ToList(),
                Role = Convert.ToBoolean(Session["Role"].ToString())
            };

            return View(pm);
        }

        //Te envia a la lista de favoritos
        public ActionResult WatchListView()
        {
            CheckSession();

            var um = new PostModel
            {
                Cosas = _readOnlyRepository.GetAll<Posts>().ToList(),
                Role = Convert.ToBoolean(Session["Role"].ToString())
            };

            return View(um);
        }

        //Te envia a la pagina principal
        public ActionResult HomeScreen()
        {
            CheckSession();

            var pm = new PostModel
            {
                Cosas = _readOnlyRepository.GetAll<Posts>().ToList(),
                Role = Convert.ToBoolean(Session["Role"].ToString())
            };

            return View(pm);
        }

        //Te envia a tu perfil
        public ActionResult UserProfile()
        {
            CheckSession();

            return View();
        }

        //Muestra los posts en la pantalla principal
        [HttpPost]
        public ActionResult HomeScreen(PostModel pm)
        {

            CheckSession();
            pm.Cosas = _readOnlyRepository.GetAll<Posts>().ToList();
            pm.Role = Convert.ToBoolean(Session["Role"].ToString());
            return View(pm);
        }

        public ActionResult MyPostsView()
        {
            CheckSession();
            var pm = new PostModel
            {
                Cosas = _readOnlyRepository.GetAll<Posts>().ToList(),
                Myid = Convert.ToInt32(Session["UserId"]),
                Role = Convert.ToBoolean(Session["Role"].ToString())
            };
            return View(pm);
        }

        public ActionResult InboxView()
        {
            CheckSession();
            var mm = new MessagesModel()
            {
                MessageList = _readOnlyRepository.GetAll<Messages>().ToList(),
                Myid = Convert.ToInt32(Session["UserId"])
            };

            return View(mm);
        }

        public ActionResult OutboxView()
        {
            CheckSession();
            return View();
        }

        //Post Nuevo
       
        public ActionResult Detalle(long id)
        {
            CheckSession();
            var pm = new PostModel();

            var post = _readOnlyRepository.GetById<Posts>(id);

            pm.Img1 = post.Img1;
            pm.Img2 = post.Img2;
            pm.Img3 = post.Img3;
            pm.Video = post.Video;

            pm.Tittle = post.Tittle;
            pm.Details = post.Details;
            pm.Price = post.Price;
            pm.Created = post.Created;

            pm.Id = (int) post.Id;
            pm.OwnerId = post.OwnerId.ToString();
            pm.OwnerName = post.OwnerName;
            pm.BussType = post.BussType;
            //pm.Views = post.Views;
            pm.Archived = post.Archived;
            pm.IsFeatured = post.IsFeatured;

            return View(pm);
        }

        [HttpPost]
        public ActionResult NewPost(PostModel pm)
        {
            CheckSession();

            if (pm.Tittle.Length > 100)
                return RedirectToAction("NewPost");

            if (pm.Details.Length > 255)
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
            post.WasFlaged = false;

            post.Img1 = pm.Img1 ?? "http://i.memeful.com/memes/wrD4EJR/YUNO.jpg";

            post.Img2 = pm.Img2;
            post.Img3 = pm.Img3;
            post.Video = pm.Video;

            post.Tag1 = pm.Tag1;
            post.Tag2 = pm.Tag2;
            post.Tag3 = pm.Tag3;
            post.Archived = false;

            pm.AllTags = _readOnlyRepository.GetAll<Tags>().ToList();

            pm.Role = Convert.ToBoolean(Session["Role"].ToString());


            _writeOnlyRepository.Create(post);
            return RedirectToAction("HomeScreen");
        }

        //New Post
        public ActionResult NewPost()
        {
            CheckSession();

            var pm = new PostModel
            {
                AllTags = _readOnlyRepository.GetAll<Tags>().ToList(),
                Role = Convert.ToBoolean(Session["Role"].ToString())

            };

            return View(pm);
        }


        public ActionResult EditMode(long id)
        {
            var pm = new PostModel();
            pm.Id = (int) id;
            return View(pm);
        }

        [HttpPost]
        public ActionResult EditMode(Posts pm)
        {
            _writeOnlyRepository.Update(pm);
            return RedirectToAction("HomeScreen");
        }

        public ActionResult DisableEnable(long id)
        {
            var post = _readOnlyRepository.GetById<Posts>(id);

            if (post.Archived == false)
                post.Archive();
            else
                post.UnArchive();

            _writeOnlyRepository.Update(post);

            return RedirectToAction("HomeScreen");
        }

        public ActionResult Logout()
        {
            Session["User"] = null;
            Session["UserId"] = null;
            Session["Role"] = null;

            return RedirectToAction("Index", "Guest");
        }

        public ActionResult FlagPost(long id)
        {
            var post = _readOnlyRepository.GetById<Posts>(id);

            if (post.WasFlaged == false)
                post.Flag();
            
            _writeOnlyRepository.Update(post);

            return RedirectToAction("HomeScreen");
        }
    }
}
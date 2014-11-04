using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainDrivenDatabaseDeployer;
using Domain.Entities;
using NHibernate;

namespace DatabaseDeployer
{
    class PostSeeder : IDataSeeder
    {
        readonly ISession _session;
        public PostSeeder(ISession session)
        {
            _session = session;
        }
        public void Seed()
        {
           
            var post = new Posts()
            {
                Archived = false,
                Created = DateTime.Today,
                Details = "vento motorola atrix II 9/10",
                OwnerId = 01,
                Tittle = "vendo telefono",
                OwnerName = "Mario Villatoro",
                Views = 0,
                Img1 = "http://cdn2.ubergizmo.com/wp-content/uploads/2011/10/atrix-2-review-04.jpg",
                Img2 = "http://www.phonegg.com/Motorola/ATRIX-2/Motorola-ATRIX-2.jpg",
                Img3 = "http://cdn.slashgear.com/wp-content/uploads/2011/10/atrix2_electrify2wtmk.jpg",
                Video = "https://www.youtube.com/watch?v=M3rQTEjNi3Y"
                
            };
            _session.Save(post);
        }
    }
}


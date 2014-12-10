using System;
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
                Tittle = "vendo telefono",
                Details = "vento motorola atrix II 9/10",
                OwnerId = 01,
                OwnerName = "Mario Villatoro",
                Price = 100,
                BussType = "Cambio",
                //Views = 0,
                Created = DateTime.Now,
                Archived = false,
                IsFeatured = false,
                AdminArchived = false,
                WasFlaged = false,
                
                Img1 = "http://cdn2.ubergizmo.com/wp-content/uploads/2011/10/atrix-2-review-04.jpg",
                Img2 = "http://www.phonegg.com/Motorola/ATRIX-2/Motorola-ATRIX-2.jpg",
                Img3 = "http://cdn.slashgear.com/wp-content/uploads/2011/10/atrix2_electrify2wtmk.jpg",
                Video = "https://www.youtube.com/watch?v=M3rQTEjNi3Y",
                
                Tag1 = "Celulares",
                Tag2 = "Motorola",
                Tag3 = "Tecnologia"
                
                
            };
            _session.Save(post);

            var postFeatured = new Posts()
            {
                Tittle = "Laptop",
                Details = "Vendo dell inspiron negra",
                OwnerId = 02,
                OwnerName = "Mario Villatoro",
                Price = 300,
                BussType = "Sell",
                //Views = 0,
                Created = DateTime.Now,
                Archived = false,
                IsFeatured = true,
                AdminArchived = false,
                WasFlaged = false,

                Img1 = "http://images.amazon.com/images/G/01/electronics/detail-page/dell-inspiron-15-black-cover-450.jpg",
                Img2 = "http://images.amazon.com/images/G/01/electronics/dell/dell-15r-black-detail_2-lg.jpg",
                Img3 = "http://www.accomputerwarehouse.com/images/products/4196_3.jpg",
                Video = "http://youtu.be/7YSKHL18_5o",

                Tag1 = "Laptop",
                Tag2 = "DEll",
                Tag3 = "Tecnologia"


            };
            _session.Save(postFeatured);

            var postWatch = new Posts()
            {
                Tittle = "Vendo Xbox One",
                Details = "Barato, dos juegos COD: MW3 y FIFA 15 ",
                OwnerId = 01,
                OwnerName = "Mario Villatoro",
                Price = 100,
                BussType = "Cambio",
                //Views = 0,
                Created = DateTime.Now,
                Archived = false,
                IsFeatured = false,
                AdminArchived = false,
                WasFlaged = false,

                Img1 = "http://cnet4.cbsistatic.com/hub/i/r/2013/11/19/8cc6dd8e-67c2-11e3-a665-14feb5ca9861/thumbnail/770x433/d9917c19b167ee7ea244c0da6dece26c/XBox_One_35657846_15.jpg",
                Img2 = "http://media.melty.es/article-2549474-ajust_930-f1405417970/caratula-fifa-15-para-xbox-one.jpg",
                Img3 = "http://www.graingergames.co.uk/graphics/packshots/XO90.jpg",
                Video = "http://youtu.be/P9ENHiXed28",

                Tag1 = "Consolas",
                Tag2 = "Xbox",
                Tag3 = "Tecnologia"
            };
            _session.Save(postWatch);
        }
    }
}


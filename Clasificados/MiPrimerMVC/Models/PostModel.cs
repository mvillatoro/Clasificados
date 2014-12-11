using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace MiPrimerMVC.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string Details { get; set; }

        public string OwnerId { get; set; }
        public string OwnerName { get; set; }
        
        public int Price { get; set; }
        public string BussType { get; set; }

        public int Views { get; set; }
        public DateTime Created { get; set; }
        public bool Archived { get; set; }
        public bool AdminArchived { get; set; }
        public bool IsFeatured { get; set; }
        public bool WasFlaged { get; set; }

        public int Myid { get; set; }
        public bool Role { get; set; } 


        public string Img1 { get; set; }
        public string Img2 { get; set; }
        public string Img3 { get; set; }
        public string Video { get; set; }


        public string Tag1 { get; set; }
        public string Tag2 { get; set; }
        public string Tag3 { get; set; }
        public List<Posts> Cosas { get; set; }
        

        

        //Lo relevante a tags
        public List<Tags> AllTags { get; set; }

        //Lo relevante a Enviar mensaje a user
        public string Receptor { get; set; } //Done
        public string Message { get; set; } //Done
        public string Mail { get; set; } //Done

    }
}
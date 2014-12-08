using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace Domain.Entities
{
    public class Posts:IEntity
    {
        public virtual long Id { get; set; }
        public virtual string Tittle { get; set; }
        public virtual string Details { get; set; }
        public virtual int OwnerId { get; set; }
        public virtual string OwnerName { get; set; }
        public virtual int Price { get; set; }
        public virtual string BussType { get; set; }


        public virtual int Views { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual bool Archived { get; set; }
        public virtual bool AdminArchived { get; set; }
        public virtual bool IsFeatured { get; set; }


        public virtual string Img1 { get; set; }
        public virtual string Img2 { get; set; }
        public virtual string Img3 { get; set; }
        

        public virtual string Tag1 { get; set; }
        public virtual string Tag2 { get; set; }
        public virtual string Tag3 { get; set; }
        public virtual string Video { get; set; }

        public virtual void Archive()
        {
            Archived = true;
        }

    }
}

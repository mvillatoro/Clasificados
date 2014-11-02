using System;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User: IEntity
    {
        public virtual string Name { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Mail { get; set; }
        public virtual string Password { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual int Id { get; set; }
        public virtual bool Archived { get; set; }
        public virtual int Views { get; set; }
        public virtual bool IsMaster { get; set; }
        public virtual void Archive()
        {
            Archived = true;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Posts: IEntity
    {
        public virtual int Id { get; set; }
        public virtual bool Archived { get; set; }
        public virtual int Views { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual string Tittle { get; set; }
        public virtual Guid OwnerId { get; set; }
        public virtual string Details { get; set; }
        public virtual void Archive()
        {
            Archived = true;
        }
    }
}

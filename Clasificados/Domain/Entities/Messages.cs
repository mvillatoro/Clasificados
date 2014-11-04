using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Messages: IEntity
    {
        public virtual string Receptor { get; set; } //DONE
        public virtual string Sender { get; set; } //DONE
        public virtual string Message { get; set; } //DONE
        public virtual string Mail { get; set; } //DONE
        public virtual int ReceptorId { get; set; } //DONE
        public virtual int SenderId { get; set; } //DONE
        public virtual long Id { get; set; }
        public virtual bool Archived { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual void Archive()
        {
            Archived = true;
        }
    }
}

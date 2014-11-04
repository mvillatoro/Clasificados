using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    class Messages: IEntity
    {
        public virtual string Receptor { get; set; }
        public virtual string Sender { get; set; }
        public virtual string Message { get; set; }
        public virtual string Mail { get; set; }
        public virtual String ReceptorId { get; set; }
        public virtual String SenderId { get; set; }
        public virtual long Id { get; set; }
        public virtual bool Archived { get; set; }
        public virtual void Archive()
        {
            Archived = true;
        }
    }
}

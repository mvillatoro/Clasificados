using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Contact : IEntity
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Mail { get; set; }
        public virtual string Message { get; set; }
        public virtual bool Archived { get; set; }
        public virtual string Answer { get; set; }
        public virtual bool IsAnswered { get; set; }
        public virtual void Archive()
        {
            Archived = true;
        }
    }
}

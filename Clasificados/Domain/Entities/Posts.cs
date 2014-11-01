using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Posts: IEntity
    {
        public Guid Id { get; set; }
        public bool Archived { get; set; }
        public int Views { get; set; }
        public DateTime Created { get; set; }
        public string Tittle { get; set; }
        public Guid OwnerId { get; set; }
        public string Details { get; set; }
        public virtual void Archive()
        {
            Archived = true;
        }
    }
}

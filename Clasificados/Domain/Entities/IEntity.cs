using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
        bool Archived { get; set; }
        int Views { get; set; }
        DateTime Created { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public interface IEntity
    {
        long Id { get; set; }
        bool Archived { get; }
        void Archive();

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace MiPrimerMVC.Models
{
    public class ContactModel
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Message { get; set; }
        public List<Contact> Preguntas { get; set; } 
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace MiPrimerMVC.Models
{
    public class ContactModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Message { get; set; }
        public  string Answer { get; set; }
        public  bool IsAnswered { get; set; }
        public List<Contact> Preguntas { get; set; }
        public string User { get; set; } 
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiPrimerMVC.Models
{
    public class RegisteredModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        //public string ConfirmPassword { get; set; }
        public bool IsMaster { get; set; }
    }
}
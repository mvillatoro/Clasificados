using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clasificados.Models
{
    public class RegisterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTime Created { get; set; }
        public bool Archived { get; set; }
        public int Views { get; set; }
        public bool IsMaster { get; set; }

    }
}
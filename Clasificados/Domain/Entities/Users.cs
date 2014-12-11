using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Users : IEntity
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Mail { get; set; }
        public virtual string Password { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual bool Archived { get; set; }
        public virtual bool IsMaster { get; set; }

        public virtual string Salt { get; set; }
        public virtual void Archive()
        {
            Archived = true;
        }

        public virtual List<Users> Following { get; set; } 
        public virtual void AddFollowing(Users user)
        {
            Following.Add(user);
        }

        public virtual bool CheckPassword(string password)
        {
            SHA512 hashtool = SHA512.Create();
            byte[] pass1 = hashtool.ComputeHash(Encoding.UTF8.GetBytes(password));
            string pass = BitConverter.ToString(pass1);
            byte[] pass2 = hashtool.ComputeHash(Encoding.UTF8.GetBytes(pass.Replace("-", "") + Salt));
            string passFinal = BitConverter.ToString(pass2).Replace("-", "");
            if (Password.Equals(passFinal))
                return true;
            else
                return false;
        }

    }
}

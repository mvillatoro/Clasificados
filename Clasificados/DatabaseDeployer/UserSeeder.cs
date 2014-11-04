using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DomainDrivenDatabaseDeployer;
using Domain.Entities;
using NHibernate;

namespace DatabaseDeployer
{
    class UserSeeder : IDataSeeder
    {
        readonly ISession _session;

        public UserSeeder(ISession session)
        {
            _session = session;
        }

        public void Seed()
        {
            var user = new Users()
            {
                Name = "Mario",
                LastName = "Villatoro",
                Archived = false,
                Created = DateTime.Today,
                Id = 01,
                IsMaster = true,
                Mail = "mvilla@gmail.com",
                Password = "12345",
                Views = 0
            };

            SHA512 hashtool = SHA512.Create();
            byte[] pass1 = hashtool.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
            string pass = BitConverter.ToString(pass1);
            byte[] salt1 = hashtool.ComputeHash(Encoding.UTF8.GetBytes(user.Mail + user.Name));
            string salt = BitConverter.ToString(salt1);
            byte[] pass2 = hashtool.ComputeHash(Encoding.UTF8.GetBytes(pass.Replace("-", "") + salt.Replace("-", "")));
            string passFinal = BitConverter.ToString(pass2);
            user.Password = passFinal.Replace("-", "");
            user.Salt = salt.Replace("-", "");

            _session.Save(user);
            
        }
    }
}

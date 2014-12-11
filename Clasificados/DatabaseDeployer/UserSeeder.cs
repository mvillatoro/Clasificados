using System;
using System.Security.Cryptography;
using System.Text;
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
            var muser = new Users
            {
                Name = "Mario",
                LastName = "Villatoro",
                Mail = "mvilla@gmail.com",
                Password = "12345",
                Created = DateTime.Now,
                Archived = false,
                IsMaster = true
            };

            SHA512 hashtool = SHA512.Create();
            byte[] pass1 = hashtool.ComputeHash(Encoding.UTF8.GetBytes(muser.Password));
            string pass = BitConverter.ToString(pass1);
            byte[] salt1 = hashtool.ComputeHash(Encoding.UTF8.GetBytes(muser.Mail + muser.Name));
            string salt = BitConverter.ToString(salt1);
            byte[] pass2 = hashtool.ComputeHash(Encoding.UTF8.GetBytes(pass.Replace("-", "") + salt.Replace("-", "")));
            string passFinal = BitConverter.ToString(pass2);
            muser.Password = passFinal.Replace("-", "");
            muser.Salt = salt.Replace("-", "");

            _session.Save(muser);
            
        }
    }
}


//sabes que voy a hacer
//en vez de guardar el objeto completo solo voy a guardar el id, y despues solo voy a recorrer la tabla de todos los posts y solo muestro los id que tenfo en la lista
using System;
using Domain.Entities;
using DomainDrivenDatabaseDeployer;
using FizzWare.NBuilder;
using NHibernate;

namespace DatabaseDeployer
{
    class UsersSeeder : IDataSeeder
    {
        readonly ISession _session;

        public UsersSeeder(ISession session)
        {
            _session = session;
        }

        public void Seed()
        {
            var user = new User
            {
                Name = "Mario",
                LastName = "Villatoro",
                Archived = false,
                Created = new DateTime(2014,08,22),
                Id = 01,
                IsMaster = true,
                Mail = "mvilla@gmail.com",
                Password = "12345",
                Views = 0

            };

            _session.Save(user);

        }
    }
}
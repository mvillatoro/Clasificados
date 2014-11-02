using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainDrivenDatabaseDeployer;
using Domain.Entities;
using NHibernate;

namespace DatabaseDeployer
{
    class UserSeeder:IDataSeeder
    {
        readonly ISession _session;

        public UserSeeder(ISession session)
        {
            _session = session;
        }

        public void Seed()
        {
            /*
            var user = new User
            {
                Name = "Mario",
                LastName = "Villatoro",
                Archived = false,
                Created = new DateTime(),
                Id = new Guid(),
                IsMaster = true,
                Mail = "mvilla@gmail.com",
                Password = "12345",
                Views = 0

            };

            _session.Save(user);
            */
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainDrivenDatabaseDeployer;
using NHibernate;
using Domain.Entities;

namespace DatabaseDeployer
{
    internal class MessageSeeder : IDataSeeder
    {
        private readonly ISession _session;

        public MessageSeeder(ISession session)
        {
            _session = session;
        }

        public void Seed()
        {

            var msg = new Messages
            {
                Receptor = "Mario",
                Sender = "Thelma",
                Message = "Me interesa eso que usted vende",
                Mail = "thelma@gmail.com",
                Created = DateTime.Now,
                ReceptorId = 1,
                SenderId = 2,
                Archived = false,
            };
            _session.Save(msg);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using DomainDrivenDatabaseDeployer;
using NHibernate;
using NHibernate.Event;

namespace DatabaseDeployer
{
    class PostSeeder : IDataSeeder
    {
        readonly ISession _session;

        public PostSeeder(ISession session)
        {
            _session = session;
        }

        public void Seed()
        {
            var post = new Posts()
            {
                Archived = false,
                Created = new DateTime(),
                Details = "Vendo motorola Atrix II Lps 4000.00, negociable",
                Id = new Guid(),
                OwnerId = new Guid(),
                Tittle = "vendo Moto Atrix II",
                Views = 0

            };

            _session.Save(post);

        }
    }
}

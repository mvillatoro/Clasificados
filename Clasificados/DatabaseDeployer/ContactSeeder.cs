using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using DomainDrivenDatabaseDeployer;
using NHibernate;
using Domain.Services;

namespace DatabaseDeployer
{
    public class ContactSeeder : IDataSeeder
    {

        readonly ISession _session;
        public ContactSeeder(ISession session)
        {
            _session = session;
        }
        public void Seed()
        {
           
            var faq = new Contact() 
            {
                Answer = "Ni idea",
                Archived = false,
                Mail = "Admin",
                Message = "Como entras en la pagina",
                Name = "Luis",
                IsAnswered = true
            };
            _session.Save(faq);
        }

    }
}

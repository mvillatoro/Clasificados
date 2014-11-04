using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainDrivenDatabaseDeployer;
using Domain.Entities;
using Domain.Services;
using NHibernate;

namespace DatabaseDeployer
{
    class TagSeeder: IDataSeeder
    {
        readonly ISession _session;
        public TagSeeder(ISession session)
        {
            _session = session;
        }
        public void Seed()
        {
           
            var tag1 = new Tags()
            {
                TagName = "Tecnologia"
            };
            _session.Save(tag1);

            var tag2 = new Tags()
            {
                TagName = "Hogar"
            };
            _session.Save(tag2);

            var tag3 = new Tags()
            {
                TagName = "Animales"
            };
            _session.Save(tag1);

            var tag4 = new Tags()
            {
                TagName = "Xbox"
            };
            _session.Save(tag4);

            var tag5 = new Tags()
            {
                TagName = "Play Station"
            };
            _session.Save(tag5);

            var tag6 = new Tags()
            {
                TagName = "Ropa"
            };
            _session.Save(tag6);

            var tag7 = new Tags()
            {
                TagName = "Calulares"
            };
            _session.Save(tag7);

            var tag8 = new Tags()
            {
                TagName = "Computadoras"
            };
            _session.Save(tag8);

            var tag9 = new Tags()
            {
                TagName = "Accesorios"
            };
            _session.Save(tag8);

            var tag10 = new Tags()
            {
                TagName = "Zapatos"
            };
            _session.Save(tag10);

            var tag11 = new Tags()
            {
                TagName = "Viajes"
            };
            _session.Save(tag11);

            var tag12 = new Tags()
            {
                TagName = "Fotografia"
            };
            _session.Save(tag12);

            var tag13 = new Tags()
            {
                TagName = "Escuela"
            };
            _session.Save(tag13);

        }

    }
}

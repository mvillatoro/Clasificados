using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Services;
using NHibernate;

namespace Data
{
    public class WriteOnlyRepository : IWriteOnlyRepository
    {
        readonly ISession _session;

        public WriteOnlyRepository(ISession session)
        {
            _session = session;
        }

        public void Archive<T>(long id) where T : IEntity
        {
            throw new System.NotImplementedException();
        }

        public T Update<T>(T item) where T : IEntity
        {
            throw new System.NotImplementedException();
        }

        public T Create<T>(T itemToCreate) where T : IEntity
        {
            _session.Save(itemToCreate);
            return itemToCreate;
        }

        public void ArchiveAll<T>(IEnumerable<T> list) where T : class, IEntity
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> CreateAll<T>(IEnumerable<T> list) where T : IEntity
        {
            throw new System.NotImplementedException();
        }
    }
}
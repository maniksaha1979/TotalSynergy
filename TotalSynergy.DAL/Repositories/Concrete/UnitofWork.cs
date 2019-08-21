using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalSynergy.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TotalSynergyEntities DbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            DbContext = dbFactory.Init();
            Projects = new ProjectRepository(DbContext);
            Contacts = new ContactRepository(DbContext);
            ProjectContacts = new ProjectContactRepository(DbContext);
        }

        public IProjectRepository Projects { get; }
        public IContactRepository Contacts { get; }
        public IProjectContactRepository ProjectContacts { get; }

        public async Task<int> Complete()
        {
            return await DbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}

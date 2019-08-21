using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TotalSynergy.DAL.Repositories
{
    public class ProjectContactRepository: Repository<ProjectContact>, IProjectContactRepository
    {
        private readonly TotalSynergyEntities ProjectContactDbEntities;

        public ProjectContactRepository(TotalSynergyEntities context) : base(context)
        {
            ProjectContactDbEntities = context;
        }

        public async Task<bool> IsRecordExist(Guid projectId, Guid contactId)
        {
            var item = await ProjectContactDbEntities.ProjectContacts.Where(x => x.ProjectId.Equals(projectId) && x.ContactId.Equals(contactId)).ToListAsync();

            return item.Count > 0;
        }

        public async Task<IEnumerable<ProjectContact>> GetWithDetails()
        {
            var item =await ProjectContactDbEntities.ProjectContacts.Include(p => p.Project)
                                                                 .Include(c => c.Contact).ToListAsync();
            return item;
        }

        public async Task<IEnumerable<ProjectContact>> GetWithDetailsByContact(Guid contactId)
        {
            var item = await ProjectContactDbEntities.ProjectContacts.Where(i => i.ContactId.Equals(contactId))
                                                                .Include(p => p.Project)
                                                                .Include(c => c.Contact).ToListAsync();
            return item;
        }

        public async Task<IEnumerable<ProjectContact>> GetWithDetailsByProject(Guid projectId)
        {
            var item = await ProjectContactDbEntities.ProjectContacts.Where(i => i.ProjectId.Equals(projectId))
                                                                .Include(p => p.Project)
                                                                .Include(c => c.Contact).ToListAsync();
            return item;
        }

        Task<bool> IProjectContactRepository.IsRecordExist(Guid projectId, Guid contactId)
        {
            throw new NotImplementedException();
        }
    }
}

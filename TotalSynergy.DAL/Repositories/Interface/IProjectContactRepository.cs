using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TotalSynergy.DAL.Repositories
{
    public interface IProjectContactRepository: IRepository<ProjectContact>
    {
        Task<bool> IsRecordExist(Guid projectId, Guid contactId);
        Task<IEnumerable<ProjectContact>> GetWithDetailsByProject(Guid projectId);
        Task<IEnumerable<ProjectContact>> GetWithDetailsByContact(Guid contactId);
        Task<IEnumerable<ProjectContact>> GetWithDetails();
    }
}

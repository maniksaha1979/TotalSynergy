using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalSynergy.DAL;
using TotalSynergy.UI.BO;

namespace TotalSynergy.Service
{
    public interface IProjectContactService
    {
        Task<IEnumerable<ProjectContactVM>> GetAll();
        Task<IEnumerable<ProjectContactVM>> GetAllByProject(Guid projectId);
        Task<IEnumerable<ProjectContactVM>> GetAllByContact(Guid contactId);
        Task<bool> Create(ProjectContactVM projectContact);
    }
}

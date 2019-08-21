using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalSynergy.DAL;
using TotalSynergy.DAL.Repositories;
using AutoMapper;
using TotalSynergy.UI.BO;


namespace TotalSynergy.Service
{
    public class ProjectContactService : IProjectContactService
    {
        public readonly IUnitOfWork UnitOfWork;
        private readonly IMapper BOMapper;

        public ProjectContactService(IUnitOfWork uOW, IMapper mapper)
        {
            UnitOfWork = uOW;
            BOMapper = mapper;
        }

        public async Task<bool> Create(ProjectContactVM projectContact)
        {
            bool IsExist = await UnitOfWork.ProjectContacts.IsRecordExist(projectContact.ProjectId, projectContact.ContactId);
            if (IsExist)
            {
                return false;
            }
            else
            {
                ProjectContact data = BOMapper.Map<ProjectContactVM, ProjectContact>(projectContact);
                UnitOfWork.ProjectContacts.Add(data);
                await UnitOfWork.Complete();
                return true;
            }

        }

        public async Task<IEnumerable<ProjectContactVM>> GetAll()
        {
            IEnumerable<ProjectContact> data = await UnitOfWork.ProjectContacts.GetWithDetails();
            var result = BOMapper.Map<IEnumerable<ProjectContact>, IEnumerable<ProjectContactVM>>(data);
            return result ;
                
        }

        public async Task<IEnumerable<ProjectContactVM>> GetAllByContact(Guid contactId)
        {
            IEnumerable<ProjectContact> data = await UnitOfWork.ProjectContacts.GetWithDetailsByContact(contactId);
            var result = BOMapper.Map<IEnumerable<ProjectContact>, IEnumerable<ProjectContactVM>>(data);
            return result;
        }

        public async Task<IEnumerable<ProjectContactVM>> GetAllByProject(Guid projectId)
        {
            IEnumerable<ProjectContact> data = await UnitOfWork.ProjectContacts.GetWithDetailsByProject(projectId);
            var result = BOMapper.Map<IEnumerable<ProjectContact>, IEnumerable<ProjectContactVM>>(data);
            return result;
        }
    }
}

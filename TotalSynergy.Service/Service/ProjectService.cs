using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalSynergy.DAL;
using TotalSynergy.DAL.Repositories;
using TotalSynergy.UI.BO;
using AutoMapper;

namespace TotalSynergy.Service
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IMapper BOMapper;

        public ProjectService(IUnitOfWork uOW, IMapper mapper)
        {
            UnitOfWork = uOW;
            BOMapper = mapper;
        }

        public async Task<bool> Create(ProjectVM project)
        {
            
            bool IsExist = await UnitOfWork.Projects.IsProjectExist(project.Name);
            if (IsExist)
            {
                return false;
            }
            else
            { 
  
                Project data = BOMapper.Map<ProjectVM, Project>(project);
                UnitOfWork.Projects.Add(data);
                await UnitOfWork.Complete();
                return true;
            }
            
        }

        public async Task<IEnumerable<ProjectVM>> GetAll()
        {
            IEnumerable<Project> data = await UnitOfWork.Projects.GetAll();
            var result = BOMapper.Map<IEnumerable<Project>, IEnumerable<ProjectVM>>(data);
            return result;
        }
    }
}

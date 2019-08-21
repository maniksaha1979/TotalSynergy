using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TotalSynergy.DAL.Repositories
{
    public class ProjectRepository: Repository<Project>, IProjectRepository
    {
        private readonly TotalSynergyEntities ProjectDbEntities;

        public ProjectRepository(TotalSynergyEntities context) : base(context)
        {
            ProjectDbEntities = context;
        }

        public async Task<bool> IsProjectExist(string name)
        {
            var item = await ProjectDbEntities.Projects.Where(x => x.Name.ToUpper().Equals(name.ToUpper())).ToListAsync();

            return item.Count > 0;
        }
    }
}

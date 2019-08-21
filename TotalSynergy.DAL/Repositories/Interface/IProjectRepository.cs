using System;
using System.Threading.Tasks;

namespace TotalSynergy.DAL.Repositories
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<bool> IsProjectExist(string code);
    }
}

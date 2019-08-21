using System;
using System.Threading.Tasks;

namespace TotalSynergy.DAL.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IProjectRepository Projects { get; }
        IContactRepository Contacts { get; }
        IProjectContactRepository ProjectContacts { get; }

        Task<int> Complete();
    }
}

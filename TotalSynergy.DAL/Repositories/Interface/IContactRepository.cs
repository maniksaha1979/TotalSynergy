using System;
using System.Threading.Tasks;


namespace TotalSynergy.DAL.Repositories
{
    public interface IContactRepository : IRepository<Contact>
    {
        Task<bool> IsContactExist(string name);
    }

}

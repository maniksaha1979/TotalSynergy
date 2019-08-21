using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalSynergy.DAL;
using TotalSynergy.UI.BO;

namespace TotalSynergy.Service
{
    public interface IContactService
    {
        Task<IEnumerable<ContactVM>> GetAll();
        Task<bool> Create(ContactVM contact);
    }
}

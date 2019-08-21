using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TotalSynergy.DAL.Repositories
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        private readonly TotalSynergyEntities ContactDbEntities;

        public ContactRepository(TotalSynergyEntities context) : base(context)
        {
            ContactDbEntities = context;
        }

        public async Task<bool> IsContactExist(string name)
        {
            var item = await ContactDbEntities.Contacts.Where(x => x.Name.ToUpper().Equals(name.ToUpper())).ToListAsync();

            return item.Count > 0;
        } 

    }
}

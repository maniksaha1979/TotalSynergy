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
    public class ContactService: IContactService
    {
        public readonly IUnitOfWork UnitOfWork;
        private readonly IMapper BOMapper;

        public ContactService(IUnitOfWork uOW, IMapper mapper)
        {
            UnitOfWork = uOW;
            BOMapper = mapper;
        }

        public async Task<bool> Create(ContactVM contact)
        {
            bool IsExist = await UnitOfWork.Contacts.IsContactExist(contact.Name);
            if (IsExist)
            {
                return false;
            }
            else
            {
                Contact data = BOMapper.Map<ContactVM, Contact>(contact);
                data.Id = Guid.NewGuid();
                UnitOfWork.Contacts.Add(data);
                await UnitOfWork.Complete();
                return true;
            }

        }

        public async Task<IEnumerable<ContactVM>> GetAll()
        {
            IEnumerable<Contact> data = await UnitOfWork.Contacts.GetAll();
            var result = BOMapper.Map<IEnumerable<Contact>, IEnumerable<ContactVM>>(data);
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TotalSynergy.DAL;

namespace TotalSynergy.UI.BO
{
    public  class BODALMapperConfig:Profile
    {
        
        public BODALMapperConfig()
        {
            CreateMap<Contact, ContactVM>().ReverseMap();
            CreateMap<Project, ProjectVM>().ReverseMap();

            CreateMap<ProjectContact, ProjectContactVM>()
                 .ForMember(d => d.ProjectName, o => o.MapFrom(s => s.Project.Name))
                 .ForMember(d => d.ContactName, o => o.MapFrom(s => s.Contact.Name))
                 .ForMember(d => d.ProjectId, o => o.MapFrom(s => s.ProjectId))
                 .ForMember(d => d.ContactId, o => o.MapFrom(s => s.ContactId))
                 .ForMember(d => d.Id, o => o.MapFrom(s => s.Id));

            CreateMap<ProjectContactVM, ProjectContact>()
                 .ForMember(d => d.ProjectId, o => o.MapFrom(s => s.ProjectId))
                 .ForMember(d => d.ContactId, o => o.MapFrom(s => s.ContactId))
                 .ForMember(d => d.Id, o => o.MapFrom(s => s.Id));

            
        }
    }
}

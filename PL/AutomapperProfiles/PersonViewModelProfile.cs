using AutoMapper;
using BLL.DTO;
using PL.ViewModels;

namespace PL.AutomapperProfiles
{
    public class PersonViewModelProfile:Profile
    {
        public PersonViewModelProfile()
        {
            CreateMap<PersonViewModel,PersonDTO>().ReverseMap();
        }
    }
}

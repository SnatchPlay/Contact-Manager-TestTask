using AutoMapper;
using BLL.DTO;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AutomapperProfiles
{
    public class PersonProfile:Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonDTO, Person>().ReverseMap();
        }
    }
}

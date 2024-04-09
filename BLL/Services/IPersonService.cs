using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IPersonService
    {
        public List<PersonDTO> GetAll();
        public PersonDTO GetById(int id);
        public PersonDTO Add(PersonDTO person);
        public PersonDTO Update(PersonDTO person);
        public void Delete(int id);
    }
}

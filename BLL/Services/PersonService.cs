using AutoMapper;
using BLL.DTO;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PersonService:IPersonService
    {
        private readonly IRepository<Person> _repository;
        private readonly IMapper _mapper;

        public PersonService(IRepository<Person> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public List<PersonDTO> GetAll()
        {
            var data = _repository.GetAll();
            return _mapper.Map<List<PersonDTO>>(data);
        }
        public PersonDTO GetById(int id)
        {
            var data = _repository.Get(id);
            return _mapper.Map<PersonDTO>(data);
        }
        public PersonDTO Add(PersonDTO person)
        {
            var data = _mapper.Map<Person>(person);
            _repository.Add(data);
            return _mapper.Map<PersonDTO>(data);
        }

        public PersonDTO Update(PersonDTO person)
        {
            var data = _mapper.Map<Person>(person);
            _repository.Update(data);
            return _mapper.Map<PersonDTO>(data);
        }

        public void Delete(int id)
        {
            _repository.Remove(id);
        }

    }
}

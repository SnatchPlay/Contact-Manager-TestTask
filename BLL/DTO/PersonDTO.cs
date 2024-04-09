using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public bool IsMarried { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Salary { get; set; }
        public PersonDTO() { }
    }
}

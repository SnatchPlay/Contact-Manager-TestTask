using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public bool IsMarried { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Salary { get; set; }
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }
        public Person(int id, string name, DateOnly dateOfBirth, bool isMarried, string phoneNumber, decimal salary, DateTime rowInsertTime, DateTime rowUpdateTime)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            IsMarried = isMarried;
            PhoneNumber = phoneNumber;
            Salary = salary;
            RowInsertTime = rowInsertTime;
            RowUpdateTime = rowUpdateTime;
        }
        public Person() { }
    }
}

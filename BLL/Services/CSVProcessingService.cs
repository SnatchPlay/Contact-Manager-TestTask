using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CSVProcessingService:ICSVProcessing
    {
        public List<PersonDTO> ParseCSV(Stream fileStream)
        {
            List<PersonDTO> data = new List<PersonDTO>();
            try
            {
                using (var reader = new StreamReader(fileStream))
                {
                     reader.ReadLine(); 
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        PersonDTO newData = new PersonDTO
                        {
                            Name = values[0],
                            DateOfBirth = DateOnly.Parse(values[1]), 
                            IsMarried = bool.Parse(values[2]), 
                            PhoneNumber = values[3],
                            Salary = decimal.Parse(values[4], CultureInfo.InvariantCulture) 
                        };

                        data.Add(newData);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing CSV file: {ex.Message}");
            }
            return data;
        }
    }
}


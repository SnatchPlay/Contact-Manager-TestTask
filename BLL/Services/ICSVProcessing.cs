﻿using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface ICSVProcessing
    {
        public List<PersonDTO> ParseCSV(Stream fileStream);
    }
}

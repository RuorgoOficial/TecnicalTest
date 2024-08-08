using CodereTecnicalTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTecnicalTest.Domain.DTOs
{
    public class WebchannelDTO
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public CountryDTO country { get; set; } = new CountryDTO();
        public string officialSite { get; set; } = string.Empty;
    }
}

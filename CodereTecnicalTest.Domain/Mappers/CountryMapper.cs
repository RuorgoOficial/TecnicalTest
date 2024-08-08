using CodereTecnicalTest.Domain.DTOs;
using CodereTecnicalTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTecnicalTest.Domain.Mappers
{
    public static class CountryMapper
    {
        public static CountryDTO Map(Country country)
        {
            return new CountryDTO()
            {
                name = country.name,
                code = country.code,
                timezone = country.timezone,

            };
        }

        public static Country Map(CountryDTO country)
        {
            return new Country()
            {
                name = country.name,
                code = country.code,
                timezone = country.timezone,
            };
        }
    }
}

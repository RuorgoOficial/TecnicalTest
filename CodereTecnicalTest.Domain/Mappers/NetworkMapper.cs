using CodereTecnicalTest.Domain.DTOs;
using CodereTecnicalTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTecnicalTest.Domain.Mappers
{
    public static class NetworkMapper
    {
        public static NetworkDTO Map(Network network)
        {
            var country = network.country is null ? null : CountryMapper.Map(network.country);
            return new NetworkDTO
            {
                id = network.id,
                name = network.name,
                country  = country,
                officialSite = network.officialSite,
            };
        }

        public static Network Map(NetworkDTO network)
        {
            var country = network.country is null ? null : CountryMapper.Map(network.country);
            return new Network
            {
                id = network.id,
                name = network.name,
                country = country,
                officialSite = network.officialSite,
            };
        }
    }
}

using CodereTecnicalTest.Domain.DTOs;
using CodereTecnicalTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTecnicalTest.Domain.Mappers
{
    public static class ExternalMapper
    {
        public static ExternalsDTO Map(Externals externals)
        {
            return new ExternalsDTO
            {
                tvrage = externals.tvrage,
                imdb = externals.imdb,
                thetvdb = externals.thetvdb
            };
        }

        public static Externals Map(ExternalsDTO externals)
        {
            return new Externals
            {
                tvrage = externals.tvrage,
                imdb = externals.imdb,
                thetvdb = externals.thetvdb
            };
        }
    }
}

using CodereTecnicalTest.Domain.DTOs;
using CodereTecnicalTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTecnicalTest.Domain.Mappers
{
    public static class PreviousepisodeMapper
    {
        public static PreviousepisodeDTO Map(Previousepisode previousepisode)
        {
            return new PreviousepisodeDTO()
            {
                href = previousepisode.href,
                name = previousepisode.name,
            };
        }

        public static Previousepisode Map(PreviousepisodeDTO previousepisode)
        {
            return new Previousepisode()
            {
                href = previousepisode.href,
                name = previousepisode.name,
            };
        }
    }
}

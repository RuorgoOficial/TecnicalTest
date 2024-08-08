using CodereTecnicalTest.Domain.DTOs;
using CodereTecnicalTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTecnicalTest.Domain.Mappers
{
    public static class LinkMapper
    {
        public static LinksDTO Map(Links links)
        {
            var self = SelfMapper.Map(links.self);
            var previousepisode = PreviousepisodeMapper.Map(links.previousepisode);   
            return new LinksDTO()
            {
                self = self,
                previousepisode = previousepisode,
            };
        }

        public static Links Map(LinksDTO links)
        {
            var self = SelfMapper.Map(links.self);
            var previousepisode = PreviousepisodeMapper.Map(links.previousepisode);
            return new Links()
            {
                self = self,
                previousepisode = previousepisode,
            };
        }
    }
}

using CodereTecnicalTest.Domain.DTOs;
using CodereTecnicalTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTecnicalTest.Domain.Mappers
{
    public static class ShowMapper
    {
        public static ShowDTO Map(Show show)
        {
            var genres = show.genres.Select(g => g.Name).ToArray();
            var shedule = ScheduleMapper.Map(show.schedule);
            var rating = RatingMapper.Map(show.rating);
            var externals = ExternalMapper.Map(show.externals);
            var image = show.image is null ? null : ImageMapper.Map(show.image);
            var links = LinkMapper.Map(show._links);
            var network = show.network is null ? null : NetworkMapper.Map(show.network);
            var webChannel = show.webChannel is null ? null : NetworkMapper.Map(show.webChannel);
            var dvdCountry = show.dvdCountry is null ? null : CountryMapper.Map(show.dvdCountry);

            return new ShowDTO()
            {
                id = show.id,
                url = show.url,
                name = show.name,
                type = show.type,
                language = show.language,
                genres = genres,
                status = show.status,
                runtime = show.runtime,
                averageRuntime = show.averageRuntime,
                premiered = show.premiered,
                ended = show.ended,
                officialSite = show.officialSite,
                schedule = shedule,
                rating = rating,
                weight = show.weight,
                network = network,
                webChannel = webChannel,
                dvdCountry = dvdCountry,
                externals = externals,
                image = image,
                summary = show.summary,
                updated = show.updated,
                _links = links,
            };
        }

        public static Show Map(ShowDTO show)
        {
            var genres = show.genres.Select(x => new Genre() { Name = x }).ToList();
            var shedule = ScheduleMapper.Map(show.schedule);
            var rating = RatingMapper.Map(show.rating);
            var externals = ExternalMapper.Map(show.externals);
            var image = show.image is null ? null : ImageMapper.Map(show.image);
            var links = LinkMapper.Map(show._links);
            var network = show.network is null ? null : NetworkMapper.Map(show.network);
            var webChannel = show.webChannel is null ? null : NetworkMapper.Map(show.webChannel);
            var dvdCountry = show.dvdCountry is null ? null : CountryMapper.Map(show.dvdCountry);

            return new Show()
            {
                id = show.id,
                url = show.url,
                name = show.name,
                type = show.type,
                language = show.language,
                genres = genres,
                status = show.status,
                runtime = show.runtime,
                averageRuntime = show.averageRuntime,
                premiered = show.premiered,
                ended = show.ended,
                officialSite = show.officialSite,
                schedule = shedule,
                rating = rating,
                weight = show.weight,
                network = network,
                webChannel = webChannel,
                dvdCountry = dvdCountry,
                externals = externals,
                image = image,
                summary = show.summary,
                updated = show.updated,
                _links = links,
            };
        }
    }
}

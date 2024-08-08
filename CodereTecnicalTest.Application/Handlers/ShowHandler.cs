using CodereTecnicalTest.Application.Events.Commands;
using CodereTecnicalTest.Application.Events.Queries;
using CodereTecnicalTest.Application.Specs;
using CodereTecnicalTest.Domain.Abstractions;
using CodereTecnicalTest.Domain.DTOs;
using CodereTecnicalTest.Domain.Entities;
using CodereTecnicalTest.Domain.Includes;
using CodereTecnicalTest.Domain.Mappers;
using LanguageExt.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CodereTecnicalTest.Application.Handlers
{
    public class ShowHandler(
        IHttpRepository<ShowDTO> httpRepository,
        IRepository<Show> showRepository,
        IRepository<Genre> genreRepository,
        IRepository<Network> networkRepository,
        IRepository<Country> countryRepository,
        IRepository<Schedule> scheduleRepository,
        IRepository<Rating> ratingRepository,
        IRepository<Externals> externalsRepository,
        IRepository<Image> imageRepository,
        IRepository<Links> linksRepository,
        IUnitOfWork codereTecnicalTestUnitOfWork
        )
        : IRequestHandler<ManageShowById, Result<int>>,
        IRequestHandler<Get<ShowDTO>, IEnumerable<ShowDTO>>,
        IRequestHandler<Insert<ShowDTO>, ShowDTO>
    {

        private readonly IHttpRepository<ShowDTO> _httpRepository = httpRepository;
        private readonly IRepository<Show> _showRepository = showRepository;
        private readonly IRepository<Genre> _genreRepository = genreRepository;
        private readonly IRepository<Network> _networkRepository = networkRepository;
        private readonly IRepository<Country> _countryRepository = countryRepository;
        private readonly IRepository<Schedule> _scheduleRepository = scheduleRepository;
        private readonly IRepository<Rating> _ratingRepository = ratingRepository;
        private readonly IRepository<Externals> _externalsRepository = externalsRepository;
        private readonly IRepository<Image> _imageRepository = imageRepository;
        private readonly IRepository<Links> _linksRepository = linksRepository;
        private readonly IUnitOfWork _codereTecnicalTestUnitOfWork = codereTecnicalTestUnitOfWork;

        #region Handlers
        public async Task<Result<int>> Handle(ManageShowById request, CancellationToken cancellationToken)
        {
            //Get entity from the api
            var response = await _httpRepository.GetAsync(request.Id);
            //Check if exist in the database
            var existingShow = await _showRepository.FindByIdAsync(request.Id, cancellationToken, false, GetIncludes());

            try
            {
                await response.Match(async r =>
                {
                    var coreEntity = ShowMapper.Map(r);
                    coreEntity = await CheckGenres(coreEntity, cancellationToken);
                    if (coreEntity.network is not null)
                        coreEntity = await CheckNetwork(coreEntity, cancellationToken);
                    if (coreEntity.webChannel is not null)
                        coreEntity = await CheckWebchannel(coreEntity, cancellationToken);

                    if (coreEntity.dvdCountry is not null)
                        coreEntity = await CheckDvdcountry(coreEntity, cancellationToken);

                    if (existingShow is null)
                        await _showRepository.AddAsync(coreEntity);
                    else
                        UpdateEntity(existingShow, coreEntity);
                },
                    async () =>
                    {
                        if (existingShow is not null)
                            await DeleteShow(existingShow);
                        else
                            throw new Exception($"Not found show with id: {request.Id} in the server");
                    });
                await _codereTecnicalTestUnitOfWork.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex) { 
                return new Result<int>(new Exception(ex.Message));
            }

            return request.Id;
        }

        private async Task DeleteShow(Show existingShow)
        {
            await _scheduleRepository.RemoveAsync(existingShow.schedule);
            await _ratingRepository.RemoveAsync(existingShow.rating);
            await _externalsRepository.RemoveAsync(existingShow.externals);
            await _linksRepository.RemoveAsync(existingShow._links);
            if (existingShow.image is not null)
                await _imageRepository.RemoveAsync(existingShow.image);
            if (existingShow.dvdCountry is not null)
                await _countryRepository.RemoveAsync(existingShow.dvdCountry);
            if (existingShow.network is not null)
                await _networkRepository.RemoveAsync(existingShow.network);
            if (existingShow.webChannel is not null)
                await _networkRepository.RemoveAsync(existingShow.webChannel);
            await _showRepository.RemoveAsync(existingShow);
        }

        public async Task<IEnumerable<ShowDTO>> Handle(Get<ShowDTO> request, CancellationToken cancellationToken)
        {
            var entities = await _showRepository.GetAllAsync(cancellationToken, false, GetIncludes());
            return entities.Select(e => ShowMapper.Map(e));
        }

        public async Task<ShowDTO> Handle(Insert<ShowDTO> request, CancellationToken cancellationToken)
        {
            var coreEntity = ShowMapper.Map(request.Entity);
            await _showRepository.AddAsync(coreEntity);
            await _codereTecnicalTestUnitOfWork.SaveChangesAsync(cancellationToken);

            return ShowMapper.Map(coreEntity);
        }
        #endregion

        #region Private Methods
        private void UpdateEntity(Show existingShow, Show coreEntity)
        {
            existingShow = UpdateShow(existingShow, coreEntity);
            existingShow.genres = UpdateGenres(existingShow.genres, coreEntity.genres);

            if (existingShow.network is not null && coreEntity.network is not null)
                existingShow.network = UpdateNetwork(existingShow.network, coreEntity.network);
            if (existingShow.webChannel is not null && coreEntity.webChannel is not null)
                existingShow.webChannel = UpdateNetwork(existingShow.webChannel, coreEntity.webChannel);
            if (existingShow.dvdCountry is not null && coreEntity.dvdCountry is not null)
                existingShow.dvdCountry = UpdateCountry(existingShow.dvdCountry, coreEntity.dvdCountry);
            existingShow.schedule = UpdateSchedule(existingShow.schedule, coreEntity.schedule);
            existingShow.rating = UpdateRatting(existingShow.rating, coreEntity.rating);
            existingShow.externals = UpdateExternals(existingShow.externals, coreEntity.externals);
            if (existingShow.image is not null && coreEntity.image is not null)
                existingShow.image = UpdateImage(existingShow.image, coreEntity.image);
            existingShow._links = UpdateLinks(existingShow._links, coreEntity._links);
        }

        private Links UpdateLinks(Links existingShowLinks, Links coreEntityLinks)
        {
            UpdateSelf(existingShowLinks.self, coreEntityLinks.self);
            UpdatePreviousEpisode(existingShowLinks.previousepisode, coreEntityLinks.previousepisode);

            return existingShowLinks;
        }

        private Previousepisode UpdatePreviousEpisode(Previousepisode existingShowLinksPreviousepisode, Previousepisode coreEntityLinksPreviousepisode)
        {
            existingShowLinksPreviousepisode.href = coreEntityLinksPreviousepisode.href;
            existingShowLinksPreviousepisode.name = coreEntityLinksPreviousepisode.name;

            return existingShowLinksPreviousepisode;
        }

        private Self UpdateSelf(Self existingShowLinksSelf, Self coreEntityLinksSelf)
        {
            existingShowLinksSelf.href = coreEntityLinksSelf.href;

            return existingShowLinksSelf;
        }

        private Image UpdateImage(Image existingShowImage, Image coreEntityImage)
        {
            existingShowImage.medium = coreEntityImage.medium;
            existingShowImage.original = coreEntityImage.original;

            return existingShowImage;
        }

        private Externals UpdateExternals(Externals existingShowExternals, Externals coreEntityExternals)
        {
            existingShowExternals.tvrage = coreEntityExternals.tvrage;
            existingShowExternals.thetvdb = coreEntityExternals.thetvdb;
            existingShowExternals.imdb = coreEntityExternals.imdb;

            return existingShowExternals;
        }

        private Rating UpdateRatting(Rating existingShowRating, Rating coreEntityRating)
        {
            existingShowRating.average = coreEntityRating.average;

            return existingShowRating;
        }

        private Schedule UpdateSchedule(Schedule existingShowSchedule, Schedule coreEntitySchedule)
        {
            existingShowSchedule.time = coreEntitySchedule.time;
            existingShowSchedule.days = coreEntitySchedule.days;

            return existingShowSchedule;
        }

        private Network UpdateNetwork(Network existingShowNetwork, Network coreEntityNetwork)
        {
            if (existingShowNetwork.id == coreEntityNetwork.id)
            {
                existingShowNetwork.name = coreEntityNetwork.name;
                existingShowNetwork.officialSite = coreEntityNetwork.officialSite;
                if (existingShowNetwork.country is not null && coreEntityNetwork.country is not null)
                    UpdateCountry(existingShowNetwork.country, coreEntityNetwork.country);
            }
            else
            {
                existingShowNetwork = coreEntityNetwork;
            }
            return existingShowNetwork;
        }

        private Country UpdateCountry(Country existingShowNetworkCountry, Country coreEntityNetworkCountry)
        {
            if (existingShowNetworkCountry.id == coreEntityNetworkCountry.id)
            {
                coreEntityNetworkCountry.name = coreEntityNetworkCountry.name;
                coreEntityNetworkCountry.code = coreEntityNetworkCountry.code;
                coreEntityNetworkCountry.timezone = coreEntityNetworkCountry.timezone;
            }
            else
            {
                existingShowNetworkCountry = coreEntityNetworkCountry;
            }
            return existingShowNetworkCountry;
        }

        private ICollection<Genre> UpdateGenres(ICollection<Genre> existingShowGenres, ICollection<Genre> coreEntityGenres)
        {
            existingShowGenres = coreEntityGenres;

            return existingShowGenres;
        }

        private Show UpdateShow(Show existingShow, Show coreEntity)
        {
            existingShow.url = coreEntity.url;
            existingShow.name = coreEntity.name;
            existingShow.type = coreEntity.type;
            existingShow.status = coreEntity.status;
            existingShow.runtime = coreEntity.runtime;
            existingShow.averageRuntime = coreEntity.averageRuntime;
            existingShow.premiered = coreEntity.premiered;
            existingShow.ended = coreEntity.ended;
            existingShow.officialSite = coreEntity.officialSite;
            existingShow.weight = coreEntity.weight;
            existingShow.dvdCountry = coreEntity.dvdCountry;
            existingShow.summary = coreEntity.summary;
            existingShow.updated = coreEntity.updated;

            return existingShow;
        }

        private async Task<Show> CheckGenres(Show showCore, CancellationToken cancellationToken)
        {
            var genresSpecification = new GenreSpecs(showCore.genres.Select(x => x.Name));
            var genres = await _genreRepository.FindAsync(genresSpecification, cancellationToken);
            List<Genre> coreGenres = new List<Genre>();
            for (int i = 0; i < showCore.genres.Count; i++)
            {
                var genere = showCore.genres.ToArray()[i];
                if (genres.Where(g => g.Name == genere.Name).Any())
                    coreGenres.Add(genres.First(g => g.Name == genere.Name));
                else
                    coreGenres.Add(genere);
            }
            showCore.genres = coreGenres;
            return showCore;
        }

        private async Task<Show> CheckNetwork(Show show, CancellationToken cancellationToken)
        {
            var currentNetwork = await _networkRepository.FindByIdAsync(show.network!.id, cancellationToken);
            if (currentNetwork is not null)
            {
                var networkCountry = show.network.country;
                show.network = currentNetwork;
                show.network.country = networkCountry;
            }
            var countrySpecifications = new CountrySpecs(show.network!.country!.name);
            var countries = await _countryRepository.FindAsync(countrySpecifications, cancellationToken);
            if (countries.Any())
                show.network.country = countries.First();

            return show;
        }

        private async Task<Show> CheckWebchannel(Show show, CancellationToken cancellationToken)
        {
            var currentWebchannel = await _networkRepository.FindByIdAsync(show.webChannel!.id, cancellationToken);
            if (currentWebchannel is not null)
            {
                var webChannelCountry = show.webChannel.country;
                show.webChannel = currentWebchannel;
                show.webChannel.country = webChannelCountry;
            }
            if (show.network?.country is not null && show.network.country.name == show.webChannel?.country?.name)
                show.webChannel.country = show.network.country;
            else
            {
                if (show.webChannel?.country is not null)
                {
                    var countrySpecifications = new CountrySpecs(show.webChannel.country.name);
                    var countries = await _countryRepository.FindAsync(countrySpecifications, cancellationToken);
                    if (countries.Any())
                        show.webChannel.country = countries.First();
                }
            }

            return show;
        }


        private async Task<Show> CheckDvdcountry(Show coreEntity, CancellationToken cancellationToken)
        {
            var countrySpecifications = new CountrySpecs(coreEntity.dvdCountry!.name);
            var countries = await _countryRepository.FindAsync(countrySpecifications, cancellationToken);
            if (countries.Any())
                coreEntity.dvdCountry = countries.First();

            return coreEntity;
        }

        private Includes GetIncludes()
        {
            var listIncludes = new List<string>();
            listIncludes.Add("genres");
            listIncludes.Add("schedule");
            listIncludes.Add("rating");
            listIncludes.Add("network");
            listIncludes.Add("network.country");
            listIncludes.Add("webChannel");
            listIncludes.Add("webChannel.country");
            listIncludes.Add("externals");
            listIncludes.Add("image");
            listIncludes.Add("_links");
            listIncludes.Add("_links.self");
            listIncludes.Add("_links.previousepisode");

            var includes = new Includes(listIncludes);

            return includes;
        }


        #endregion
    }
}

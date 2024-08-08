using CodereTecnicalTest.Application.Events.Queries;
using CodereTecnicalTest.Application.Extensions;
using CodereTecnicalTest.Application.Services;
using CodereTecnicalTest.Domain.Abstractions;
using CodereTecnicalTest.Domain.DTOs;
using CodereTecnicalTest.Domain.Entities;
using CodereTecnicalTest.Infrastructure.Access;
using CodereTecnicalTest.Infrastructure.Context;
using CodereTecnicalTest.Infrastructure.Http;
using CodereTecnicalTest.Test.Integration.Mocks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AutoFixture;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodereTecnicalTest.Application.Events.Commands;
using LanguageExt.Pipes;
using Azure;
using LanguageExt.Common;

namespace CodereTecnicalTest.Test.Integration.Application
{
    public class ShowTest
    {
        private ServiceProvider _serviceProvider;
        private readonly Fixture _fixture;

        public ShowTest()
        {
            var services = new ServiceCollection();
            services.AddDbContext<CodereTecnicalTestDBContext>(options => options.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()));
            services.AddScoped<IUnitOfWork, CodereTecnicalTestUnitOfWork>();
            services.AddScoped<IRepository<Show>, CodereTecnicalTestRepository<Show>>();
            services.AddScoped<IRepository<Genre>, CodereTecnicalTestRepository<Genre>>();
            services.AddScoped<IRepository<Network>, CodereTecnicalTestRepository<Network>>();
            services.AddScoped<IRepository<Country>, CodereTecnicalTestRepository<Country>>();
            services.AddScoped<IRepository<Schedule>, CodereTecnicalTestRepository<Schedule>>();
            services.AddScoped<IRepository<Rating>, CodereTecnicalTestRepository<Rating>>();
            services.AddScoped<IRepository<Externals>, CodereTecnicalTestRepository<Externals>>();
            services.AddScoped<IRepository<Image>, CodereTecnicalTestRepository<Image>>();
            services.AddScoped<IRepository<Links>, CodereTecnicalTestRepository<Links>>();
            services.AddMediatR(cfg =>
                {
                    cfg.RegisterServicesFromAssemblies(typeof(VersionExtensions).Assembly);
                });
            services.AddSingleton<IVersionService, VersionService>();
            services.AddScoped<IHttpRepository<ShowDTO>, ShowHttpRepositoryMock>();
            _serviceProvider = services.BuildServiceProvider();

            _fixture = new Fixture();
        }

        [Fact]
        public async Task GetShows_From_InMemory_Database()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var _mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                var query = new Get<ShowDTO>();
                var cancelationToken = new CancellationToken();
                var response = await _mediator.Send(query, cancelationToken);

                response.Should().NotBeNull();
                response.Should().HaveCount(0);
            }
        }

        [Fact]
        public async Task InsertShows_Into_InMemory_Database()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var showId = 1;

                var _mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                var manageQuery = new ManageShowById(showId);
                var cancelationToken = new CancellationToken();
                var manageResponse = await _mediator.Send(manageQuery, cancelationToken);

                manageResponse.Should().BeOfType<Result<int>>();

                var success = await manageResponse.Match<Task<bool>>(
                    async r =>
                    {
                        _mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                        var getQuery = new Get<ShowDTO>();
                        var getResponse = await _mediator.Send(getQuery, cancelationToken);

                        getResponse.Should().HaveCount(1);
                        getResponse.First().id.Should().Be(r);
                        return true;
                    },
                    ex => {
                        ex.Should().BeNull();
                        return Task.FromResult(false);
                    }
                );
            }
        }

        [Fact]
        public async Task InsertAndUpdateShows_Into_InMemory_Database()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var showId = 1;

                var _mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                var manageQuery = new ManageShowById(showId);
                var cancelationToken = new CancellationToken();
                var manageResponse = await _mediator.Send(manageQuery, cancelationToken);

                manageResponse.Should().BeOfType<Result<int>>();

                var success = await manageResponse.Match<Task<bool>>(
                    async r =>
                    {
                        var getQuery = new Get<ShowDTO>();
                        var getResponse = await _mediator.Send(getQuery, cancelationToken);

                        getResponse.First().id.Should().Be(r);
                        var firstResponse = getResponse.First();

                        var manageUpdateQuery = new ManageShowById(showId);
                        var manageUpdateResponse = await _mediator.Send(manageQuery, cancelationToken);

                        var updateSuccess = await manageUpdateResponse.Match<Task<bool>>(
                            async ur => 
                            {
                                var getQuery = new Get<ShowDTO>();
                                var getResponse = await _mediator.Send(getQuery, cancelationToken);

                                getResponse.First().id.Should().Be(r);
                                var secondResponse = getResponse.First();

                                getResponse.First().id.Should().Be(ur);
                                firstResponse.url.Should().NotBe(secondResponse.url);
                                firstResponse.network!.name.Should().NotBe(secondResponse.network!.name);
                                firstResponse.webChannel!.name.Should().NotBe(secondResponse.webChannel!.name);

                                return true; 
                            },
                            ex => { return Task.FromResult(false); }
                        );
                        return updateSuccess;
                    },
                    ex => {
                        ex.Should().BeNull();
                        return Task.FromResult(false);
                    }
                );
            }
        }

        [Fact]
        public async Task InsertAndDeleteShows_Into_InMemory_Database()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var cancelationToken = new CancellationToken();
                var _mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                var _networkRepository = scope.ServiceProvider.GetRequiredService<IRepository<Network>>();
                var _linksRepository = scope.ServiceProvider.GetRequiredService<IRepository<Links>>();
                var showId = 100;

                var showDTO = _fixture.Build<ShowDTO>()
                                .With(s => s.id, showId)
                                .Create();

                var insertCommand = new Insert<ShowDTO>(showDTO);
                var insertResponse = await _mediator.Send(insertCommand, cancelationToken);
                insertResponse.Should().BeOfType<ShowDTO>();

                _mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                var getQuery = new Get<ShowDTO>();
                var getResponse = await _mediator.Send(getQuery, cancelationToken);

                getResponse.Should().HaveCount(1);
                getResponse.First().id.Should().Be(insertResponse.id);
                var firstResponse = getResponse.First();

                var manageQuery = new ManageShowById(showId);
                var manageResponse = await _mediator.Send(manageQuery, cancelationToken);

                var success = await manageResponse.Match<Task<bool>>(
                    async r =>
                    {

                        var networks = await _networkRepository.GetAllAsync(cancelationToken);
                        var links = await _linksRepository.GetAllAsync(cancelationToken);
                        networks.Where(x => x.id == firstResponse.network!.id).Should().HaveCount(0);
                        links.Where(x => x.id == firstResponse._links!.id).Should().HaveCount(0);

                        return true;
                    },
                    ex => {
                        ex.Should().NotBeNull();
                        return Task.FromResult(false);
                    }
                );


            }
        }
    }
}

using AutoFixture;
using FluentAssertions;
using CodereTecnicalTest.Domain.DTOs;
using CodereTecnicalTest.Domain.Entities;
using CodereTecnicalTest.Domain.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTecnicalTest.Test.Unit.Dommain
{
    public class ShowMapperTest
    {
        public readonly Fixture _fixture;
        public ShowMapperTest() { _fixture = new Fixture(); }

        [Fact]
        public void Map_MapsEvent_ToShowDTO()
        {
            //Act
            ICollection<Genre> genres = _fixture.Build<Genre>().Without(x => x.shows).CreateMany(2).ToList();
            Show shows = _fixture.Build<Show>()
                .With(x => x.genres, genres)
                .Create();

            //Arrange
            var result = ShowMapper.Map(shows);

            //Assert
            result.Should().BeOfType<ShowDTO>();
            result.id.Should().Be(shows.id);
            result.url.Should().Be(shows.url);
            result.name.Should().Be(shows.name);
            result.type.Should().Be(shows.type);
            result.language.Should().Be(shows.language);
            result.status.Should().Be(shows.status);
            result.runtime.Should().Be(shows.runtime);
            result.averageRuntime.Should().Be(shows.averageRuntime);
            result.premiered.Should().Be(shows.premiered);
            result.ended.Should().Be(shows.ended);
            result.officialSite.Should().Be(shows.officialSite);
            result.weight.Should().Be(shows.weight);
            result.summary.Should().Be(shows.summary);
            result.updated.Should().Be(shows.updated);
        }

        [Fact]
        public void Map_MapsEvent_ToShow()
        {
            //Act
            ShowDTO shows = _fixture.Build<ShowDTO>()
                .Create();

            //Arrange
            var result = ShowMapper.Map(shows);

            //Assert
            result.Should().BeOfType<Show>();
            result.id.Should().Be(shows.id);
            result.url.Should().Be(shows.url);
            result.name.Should().Be(shows.name);
            result.type.Should().Be(shows.type);
            result.language.Should().Be(shows.language);
            result.status.Should().Be(shows.status);
            result.runtime.Should().Be(shows.runtime);
            result.averageRuntime.Should().Be(shows.averageRuntime);
            result.premiered.Should().Be(shows.premiered);
            result.ended.Should().Be(shows.ended);
            result.officialSite.Should().Be(shows.officialSite);
            result.weight.Should().Be(shows.weight);
            result.summary.Should().Be(shows.summary);
            result.updated.Should().Be(shows.updated);
        }
    }
}

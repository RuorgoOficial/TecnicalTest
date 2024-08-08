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
using System.Net;

namespace CodereTecnicalTest.Test.Unit.Dommain
{
    public class ExternalMapperTest
    {
        public readonly Fixture _fixture;
        public ExternalMapperTest() { _fixture = new Fixture(); }

        [Fact]
        public void Map_MapsEvent_ToExternalsDTO()
        {
            //Act
            Externals country = _fixture.Build<Externals>()
                .Create();

            //Arrange
            var result = ExternalMapper.Map(country);

            //Assert
            result.Should().BeOfType<ExternalsDTO>();
            result.tvrage.Should().Be(country.tvrage);
            result.thetvdb.Should().Be(country.thetvdb);
            result.imdb.Should().Be(country.imdb);
        }

        [Fact]
        public void Map_MapsEvent_ToExternals()
        {
            //Act
            ExternalsDTO country = _fixture.Build<ExternalsDTO>()
                .Create();

            //Arrange
            var result = ExternalMapper.Map(country);

            //Assert
            result.Should().BeOfType<Externals>();
            result.tvrage.Should().Be(country.tvrage);
            result.thetvdb.Should().Be(country.thetvdb);
            result.imdb.Should().Be(country.imdb);
        }
    }
}

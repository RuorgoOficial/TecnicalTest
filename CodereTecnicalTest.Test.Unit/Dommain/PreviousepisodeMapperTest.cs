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
    public class PreviousepisodeMapperTest
    {
        public readonly Fixture _fixture;
        public PreviousepisodeMapperTest() { _fixture = new Fixture(); }

        [Fact]
        public void Map_MapsEvent_ToPreviousepisodeDTO()
        {
            //Act
            Previousepisode previousepisode = _fixture.Build<Previousepisode>()
                .Create();

            //Arrange
            var result = PreviousepisodeMapper.Map(previousepisode);

            //Assert
            result.Should().BeOfType<PreviousepisodeDTO>();
            result.href.Should().Be(previousepisode.href);
            result.name.Should().Be(previousepisode.name);
        }

        [Fact]
        public void Map_MapsEvent_ToPreviousepisode()
        {
            //Act
            PreviousepisodeDTO previousepisode = _fixture.Build<PreviousepisodeDTO>()
                .Create();

            //Arrange
            var result = PreviousepisodeMapper.Map(previousepisode);

            //Assert
            result.Should().BeOfType<Previousepisode>();
            result.href.Should().Be(previousepisode.href);
            result.name.Should().Be(previousepisode.name);
        }
    }
}

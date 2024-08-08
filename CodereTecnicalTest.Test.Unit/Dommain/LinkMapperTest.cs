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
    public class LinkMapperTest
    {
        public readonly Fixture _fixture;
        public LinkMapperTest() { _fixture = new Fixture(); }

        [Fact]
        public void Map_MapsEvent_ToLinkDTO()
        {
            //Act
            Links links = _fixture.Build<Links>()
                .Create();

            //Arrange
            var result = LinkMapper.Map(links);

            //Assert
            result.Should().BeOfType<LinksDTO>();
            result.self.href.Should().Be(links.self.href);
            result.previousepisode.href.Should().Be(links.previousepisode.href);
        }

        [Fact]
        public void Map_MapsEvent_ToLink()
        {
            //Act
            LinksDTO links = _fixture.Build<LinksDTO>()
                .Create();

            //Arrange
            var result = LinkMapper.Map(links);

            //Assert
            result.Should().BeOfType<Links>();
            result.self.href.Should().Be(links.self.href);
            result.previousepisode.href.Should().Be(links.previousepisode.href);
        }
    }
}

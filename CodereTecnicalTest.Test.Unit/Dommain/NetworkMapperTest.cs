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
    public class NetworkMapperTest
    {
        public readonly Fixture _fixture;
        public NetworkMapperTest() { _fixture = new Fixture(); }

        [Fact]
        public void Map_MapsEvent_ToNetworkDTO()
        {
            //Act
            Network network = _fixture.Build<Network>()
                .Without(x => x.country)
                .Create();

            //Arrange
            var result = NetworkMapper.Map(network);

            //Assert
            result.Should().BeOfType<NetworkDTO>();
            result.name.Should().Be(network.name);
            result.officialSite.Should().Be(network.officialSite);
        }

        [Fact]
        public void Map_MapsEvent_ToNetwork()
        {
            //Act
            NetworkDTO network = _fixture.Build<NetworkDTO>()
                .Create();

            //Arrange
            var result = NetworkMapper.Map(network);

            //Assert
            result.Should().BeOfType<Network>();
            result.name.Should().Be(network.name);
            result.officialSite.Should().Be(network.officialSite);
        }
    }
}

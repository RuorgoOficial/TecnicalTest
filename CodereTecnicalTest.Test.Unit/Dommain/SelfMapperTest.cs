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
    public class SelfMapperTest
    {
        public readonly Fixture _fixture;
        public SelfMapperTest() { _fixture = new Fixture(); }

        [Fact]
        public void Map_MapsEvent_ToSelfDTO()
        {
            //Act
            Self country = _fixture.Build<Self>()
                .Create();

            //Arrange
            var result = SelfMapper.Map(country);

            //Assert
            result.Should().BeOfType<SelfDTO>();
            result.href.Should().Be(country.href);
        }

        [Fact]
        public void Map_MapsEvent_ToSelf()
        {
            //Act
            SelfDTO country = _fixture.Build<SelfDTO>()
                .Create();

            //Arrange
            var result = SelfMapper.Map(country);

            //Assert
            result.Should().BeOfType<Self>();
            result.href.Should().Be(country.href);
        }
    }
}

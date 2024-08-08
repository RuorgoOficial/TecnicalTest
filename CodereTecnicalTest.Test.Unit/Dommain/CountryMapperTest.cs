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
    public class CountryMapperTest
    {
        public readonly Fixture _fixture;
        public CountryMapperTest() { _fixture = new Fixture(); }

        [Fact]
        public void Map_MapsEvent_ToCountryDTO()
        {
            //Act
            Country country = _fixture.Build<Country>()
                .Create();

            //Arrange
            var result = CountryMapper.Map(country);

            //Assert
            result.Should().BeOfType<CountryDTO>();
            result.name.Should().Be(country.name);
            result.code.Should().Be(country.code);
            result.timezone.Should().Be(country.timezone);
        }

        [Fact]
        public void Map_MapsEvent_ToCountry()
        {
            //Act
            CountryDTO country = _fixture.Build<CountryDTO>()
                .Create();

            //Arrange
            var result = CountryMapper.Map(country);

            //Assert
            result.Should().BeOfType<Country>();
            result.name.Should().Be(country.name);
            result.code.Should().Be(country.code);
            result.timezone.Should().Be(country.timezone);
        }
    }
}

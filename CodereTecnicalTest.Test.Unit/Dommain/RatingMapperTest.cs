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
    public class RatingMapperTest
    {
        public readonly Fixture _fixture;
        public RatingMapperTest() { _fixture = new Fixture(); }

        [Fact]
        public void Map_MapsEvent_ToRatingDTO()
        {
            //Act
            Rating rating = _fixture.Build<Rating>()
                .Create();

            //Arrange
            var result = RatingMapper.Map(rating);

            //Assert
            result.Should().BeOfType<RatingDTO>();
            result.average.Should().Be(rating.average);
        }

        [Fact]
        public void Map_MapsEvent_ToRating()
        {
            //Act
            RatingDTO rating = _fixture.Build<RatingDTO>()
                .Create();

            //Arrange
            var result = RatingMapper.Map(rating);

            //Assert
            result.Should().BeOfType<Rating>();
            result.average.Should().Be(rating.average);
        }
    }
}

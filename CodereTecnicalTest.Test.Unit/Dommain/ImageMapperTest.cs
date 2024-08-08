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
    public class ImageMapperTest
    {
        public readonly Fixture _fixture;
        public ImageMapperTest() { _fixture = new Fixture(); }

        [Fact]
        public void Map_MapsEvent_ToImageDTO()
        {
            //Act
            Image image = _fixture.Build<Image>()
                .Create();

            //Arrange
            var result = ImageMapper.Map(image);

            //Assert
            result.Should().BeOfType<ImageDTO>();
            result.medium.Should().Be(image.medium);
            result.original.Should().Be(image.original);
        }

        [Fact]
        public void Map_MapsEvent_ToImage()
        {
            //Act
            ImageDTO image = _fixture.Build<ImageDTO>()
                .Create();

            //Arrange
            var result = ImageMapper.Map(image);

            //Assert
            result.Should().BeOfType<Image>();
            result.medium.Should().Be(image.medium);
            result.original.Should().Be(image.original);
        }
    }
}

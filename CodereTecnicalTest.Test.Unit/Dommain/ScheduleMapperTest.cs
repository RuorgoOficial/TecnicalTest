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
    public class ScheduleMapperTest
    {
        public readonly Fixture _fixture;
        public ScheduleMapperTest() { _fixture = new Fixture(); }

        [Fact]
        public void Map_MapsEvent_ToScheduleDTO()
        {
            //Act
            Schedule schedule = _fixture.Build<Schedule>()
                .Create();

            //Arrange
            var result = ScheduleMapper.Map(schedule);

            //Assert
            result.Should().BeOfType<ScheduleDTO>();
            result.time.Should().Be(schedule.time);
            result.days.Should().HaveCount(schedule.days.Count());
            result.days.First().Should().Be(schedule.days.First());
        }

        [Fact]
        public void Map_MapsEvent_ToSchedule()
        {
            //Act
            ScheduleDTO schedule = _fixture.Build<ScheduleDTO>()
                .Create();

            //Arrange
            var result = ScheduleMapper.Map(schedule);

            //Assert
            result.Should().BeOfType<Schedule>();
            result.time.Should().Be(schedule.time);
            result.days.Should().HaveCount(schedule.days.Count());
            result.days.First().Should().Be(schedule.days.First());
        }
    }
}

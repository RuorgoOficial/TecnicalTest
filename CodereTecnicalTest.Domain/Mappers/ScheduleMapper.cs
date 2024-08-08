using CodereTecnicalTest.Domain.DTOs;
using CodereTecnicalTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTecnicalTest.Domain.Mappers
{
    public static class ScheduleMapper
    {
        public static ScheduleDTO Map(Schedule schedule)
        {
            return new ScheduleDTO()
            {
                time = schedule.time,
                days = schedule.days,
            };
        }

        public static Schedule Map(ScheduleDTO schedule)
        {
            return new Schedule()
            {
                time = schedule.time, 
                days = schedule.days,
            };
        }
    }
}

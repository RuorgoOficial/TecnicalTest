using CodereTecnicalTest.Domain.DTOs;
using CodereTecnicalTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTecnicalTest.Domain.Mappers
{
    public static class RatingMapper
    {
        public static RatingDTO Map(Rating rating)
        {
            return new RatingDTO
            {
                average = rating.average
            };
        }

        public static Rating Map(RatingDTO rating)
        {
            return new Rating
            {
                average = rating.average
            };
        }
    }
}

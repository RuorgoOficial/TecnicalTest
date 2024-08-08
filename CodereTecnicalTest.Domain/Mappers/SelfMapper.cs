using CodereTecnicalTest.Domain.DTOs;
using CodereTecnicalTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTecnicalTest.Domain.Mappers
{
    public static class SelfMapper
    {
        public static SelfDTO Map(Self self)
        {
            return new SelfDTO()
            {
                href = self.href,
                id = self.id,
                
            };
        }

        public static Self Map(SelfDTO self)
        {
            return new Self()
            {
                href = self.href,
                id = self.id,
            };
        }
    }
}

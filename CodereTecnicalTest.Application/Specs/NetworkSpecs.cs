using CodereTecnicalTest.Domain.Abstractions;
using CodereTecnicalTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTecnicalTest.Application.Specs
{
    public class NetworkSpecs : SpecificationBase<Network>
    {
        public NetworkSpecs(string name) 
            : base(x => x.name == name) 
        { 

        }
    }
}

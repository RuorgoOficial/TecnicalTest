using CodereTecnicalTest.Domain.Abstractions;
using CodereTecnicalTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTecnicalTest.Application.Specs
{
    public class GenreSpecs: SpecificationBase<Genre>
    {
        public GenreSpecs(IEnumerable<string> genresName)
            : base(x => genresName.Contains(x.Name))
        {

        }
    }
}

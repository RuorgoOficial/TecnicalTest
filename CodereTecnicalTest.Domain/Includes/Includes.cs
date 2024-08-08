using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTecnicalTest.Domain.Includes
{
    public class Includes(List<string> includeList, Includes? includesChild = null)
    {
        public List<string> IncludeList { get; set; } = includeList;
        public Includes? IncludeChild { get; set; } = includesChild;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTecnicalTest.Domain.Entities
{
    public class Webchannel : Base
    {
        public string name { get; set; } = string.Empty;
        public Country country { get; set; } = new Country();
        public string officialSite { get; set; } = string.Empty;
    }

}

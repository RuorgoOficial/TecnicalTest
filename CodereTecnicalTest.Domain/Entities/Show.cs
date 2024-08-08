using CodereTecnicalTest.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTecnicalTest.Domain.Entities
{

    public class Show : Base
    {
        public string url { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;
        public string? language { get; set; }
        public ICollection<Genre> genres { get; set; } = new List<Genre>();
        public string status { get; set; } = string.Empty;
        public int? runtime { get; set; }
        public int? averageRuntime { get; set; }
        public string? premiered { get; set; }
        public string? ended { get; set; }
        public string? officialSite { get; set; }
        public Schedule schedule { get; set; } = new Schedule();
        public Rating rating { get; set; } = new Rating();
        public int weight { get; set; } 
        public Network? network { get; set; } = null;
        public Network? webChannel { get; set; } = null;
        public Country? dvdCountry { get; set; } = null;
        public Externals externals { get; set; } = new Externals();
        public Image? image { get; set; } = null;
        public string? summary { get; set; }
        public int updated { get; set; }
        public Links _links { get; set; } = new Links();
    }
}

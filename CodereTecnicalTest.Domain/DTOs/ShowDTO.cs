using CodereTecnicalTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTecnicalTest.Domain.DTOs
{
    public class ShowDTO : BaseDTO
    {
        public string url { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;
        public string? language { get; set; }
        public string[] genres { get; set; } = { };
        public string status { get; set; } = string.Empty;
        public int? runtime { get; set; }
        public int? averageRuntime { get; set; }
        public string? premiered { get; set; }
        public string? ended { get; set; }
        public string? officialSite { get; set; }
        public ScheduleDTO schedule { get; set; } = new ScheduleDTO();
        public RatingDTO rating { get; set; } = new RatingDTO();
        public int weight { get; set; }
        public NetworkDTO? network { get; set; } = null;
        public NetworkDTO? webChannel { get; set; } = null;
        public CountryDTO? dvdCountry { get; set; } = null;
        public ExternalsDTO externals { get; set; } = new ExternalsDTO();
        public ImageDTO? image { get; set; } = null;
        public string? summary { get; set; } = string.Empty;
        public int updated { get; set; }
        public LinksDTO _links { get; set; } = new LinksDTO();
    }
}

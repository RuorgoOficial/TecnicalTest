using CodereTecnicalTest.Domain.Entities;

namespace CodereTecnicalTest.Domain.DTOs
{
    public class NetworkDTO : BaseDTO
    {
        public string name { get; set; } = string.Empty;
        public CountryDTO? country { get; set; } = null;
        public string officialSite { get; set; } = string.Empty;
    }
}
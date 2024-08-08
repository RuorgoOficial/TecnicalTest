namespace CodereTecnicalTest.Domain.DTOs
{
    public class CountryDTO : BaseDTO
    {
        public string name { get; set; } = string.Empty;
        public string code { get; set; } = string.Empty;
        public string timezone { get; set; } = string.Empty;
    }
}
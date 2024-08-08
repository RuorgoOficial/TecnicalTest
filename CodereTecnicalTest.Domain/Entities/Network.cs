namespace CodereTecnicalTest.Domain.Entities
{
    public class Network : Base
    {

        public string name { get; set; } = string.Empty;
        public Country? country { get; set; } = null;
        public string officialSite { get; set; } = string.Empty;
    }

}

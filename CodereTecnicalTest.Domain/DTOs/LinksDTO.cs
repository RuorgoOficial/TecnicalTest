using CodereTecnicalTest.Domain.Entities;

namespace CodereTecnicalTest.Domain.DTOs
{
    public class LinksDTO : BaseDTO
    {

        public SelfDTO self { get; set; } = new SelfDTO();
        public PreviousepisodeDTO previousepisode { get; set; } = new PreviousepisodeDTO();
    }
}
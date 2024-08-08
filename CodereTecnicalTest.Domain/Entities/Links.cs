namespace CodereTecnicalTest.Domain.Entities
{
    public class Links : Base
    {
        public Self self { get; set; } = new Self();
        public Previousepisode previousepisode { get; set; } = new Previousepisode();
    }

}

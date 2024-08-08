namespace CodereTecnicalTest.Domain.Entities
{
    public class Genre : Base
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Show> shows { get; set; } = new List<Show>();
    }
}
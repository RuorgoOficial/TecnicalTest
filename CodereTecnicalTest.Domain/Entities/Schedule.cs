namespace CodereTecnicalTest.Domain.Entities
{
    public class Schedule : Base
    {
        public string time { get; set; } = string.Empty;
        public string[] days { get; set; } = new string[0];
    }

}

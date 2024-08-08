namespace CodereTecnicalTest.Domain.DTOs
{
    public class ScheduleDTO : BaseDTO
    {
        public string time { get; set; } = string.Empty;
        public string[] days { get; set; } = new string[0];
    }
}
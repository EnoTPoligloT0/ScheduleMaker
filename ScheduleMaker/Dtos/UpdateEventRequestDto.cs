namespace ScheduleMaker.DTO;

public class UpdateEventRequestDto
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    
    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }
}
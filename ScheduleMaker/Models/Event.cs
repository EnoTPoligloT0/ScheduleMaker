namespace ScheduleMaker.Models;

public class Event
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    
    public DateTime startTime { get; set; }

    public DateTime endTime { get; set; }

}
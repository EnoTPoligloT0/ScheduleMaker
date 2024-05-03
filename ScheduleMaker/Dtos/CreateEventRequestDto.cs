using System.ComponentModel.DataAnnotations;

namespace ScheduleMaker.Dtos;


public class CreateEventRequestDto
{

    [Required]
    [MaxLength(30, ErrorMessage = "Title must be maximum 30 characters long.") ]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MaxLength(200, ErrorMessage = "Title must be maximum 200 characters long.") ]
    public string Description { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "StartTime is required")]
    [DataType(DataType.DateTime, ErrorMessage = "Invalid format for StartTime")]
    public DateTime StartTime { get; set; }

    [Required(ErrorMessage = "EndTime is required")]
    [DataType(DataType.DateTime, ErrorMessage = "Invalid format for EndTime")]
    public DateTime EndTime { get; set; }
    
}
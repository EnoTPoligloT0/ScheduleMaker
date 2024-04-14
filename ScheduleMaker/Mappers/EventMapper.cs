using ScheduleMaker.DTO;
using ScheduleMaker.Dtos;
using ScheduleMaker.Models;

namespace ScheduleMaker.Mappers;

public static class EventMapper
{
    public static EventDto ToCommentDto(this Event eventModel)
    {
        return new EventDto
        {
            Id = eventModel.Id,
            Title = eventModel.Title,
            Description = eventModel.Discription,
            StartTime = eventModel.startTime,
            EndTime = eventModel.endTime
        };
    }
    public static EventDto ToCommentFromCreateDto(this CreateEventRequestDto eventDto)
    {
        return new EventDto
        {
            Title = eventDto.Title,
            Description = eventDto.Description,
            StartTime = eventDto.StartTime,
            EndTime = eventDto.EndTime
        };
    }
}
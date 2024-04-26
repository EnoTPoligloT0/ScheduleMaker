using ScheduleMaker.Dtos;
using ScheduleMaker.Dtos;
using ScheduleMaker.Models;

namespace ScheduleMaker.Mappers;

public static class EventMapper
{
    public static EventDto ToEventDto(this Event eventModel)
    {
        return new EventDto
        {
            Id = eventModel.Id,
            Title = eventModel.Title,
            Description = eventModel.Description,
            StartTime = eventModel.StartTime,
            EndTime = eventModel.EndTime
        };
    }

    public static Event ToEventFromCreateDto(this CreateEventRequestDto eventDto)
    {
        return new Event
        {
            Title = eventDto.Title,
            Description = eventDto.Description,
            StartTime = eventDto.StartTime,
            EndTime = eventDto.EndTime
        };
    }
}
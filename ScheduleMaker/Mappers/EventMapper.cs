using ScheduleMaker.DTO;
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
            Description = eventModel.Discription,
            StartTime = eventModel.startTime,
            EndTime = eventModel.endTime
        };
    }

    public static Event ToEventFromCreateDto(this CreateEventRequestDto eventDto)
    {
        return new Event
        {
            Title = eventDto.Title,
            Discription = eventDto.Description,
            startTime = eventDto.StartTime,
            endTime = eventDto.EndTime
        };
    }
}
using Microsoft.EntityFrameworkCore;
using ScheduleMaker.Data;
using ScheduleMaker.DTO;
using ScheduleMaker.Interfaces;
using ScheduleMaker.Models;

namespace ScheduleMaker.Repository;

public class EventRepository : IEventRepository
{
    private readonly ApplicationDBcontex  _context;

    public EventRepository(ApplicationDBcontex context)
    {
        _context = context;
    }
    
    public async Task<List<Event>> GetAllAsync()
    {
        return await _context.Events.ToListAsync();
    }

    public async Task<Event?> GetAllByIdAsync(int id)
    {
        return await _context.Events.FindAsync(id);
    }

    public async Task<Event> CreateAsync(Event eventModel)
    {
        await _context.Events.AddAsync(eventModel);
        await _context.SaveChangesAsync();
        return eventModel;
    }

    public async Task<Event?> UpdateAsync(int id, UpdateEventRequestDto eventDto)
    {
        var existingEvent = await _context.Events.FindAsync(id);

        if (existingEvent == null)
        {
            return null;
        }

        existingEvent.Title = eventDto.Title;
        existingEvent.Discription = eventDto.Description;
        existingEvent.startTime = eventDto.StartTime;
        existingEvent.endTime = eventDto.EndTime;

        _context.Events.Update(existingEvent);

        await _context.SaveChangesAsync();

        return existingEvent;
    }

    public async Task<Event?> DeleteAsync(int id)
    {
        var eventModel = _context.Events.FirstOrDefault(x => x.Id == id);
        
        if (eventModel == null)
        {
            return null;
        }

        _context.Events.Remove(eventModel);

        await _context.SaveChangesAsync();

        return eventModel;

    }

    public Task<bool> EventExists(int id)
    {
        return _context.Events.AnyAsync(x => x.Id == id);
    }
}
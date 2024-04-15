using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScheduleMaker.Dtos;
using ScheduleMaker.Models;


namespace ScheduleMaker.Interfaces;


public interface IEventRepository
{
    Task<List<Event>> GetAllAsync();
    Task<Event?> GetByIdAsync(int id);
    Task<Event> CreateAsync( Event eventModel);
    Task<Event?> UpdateAsync(int id, UpdateEventRequestDto eventDto);
    Task<Event?> DeleteAsync(int id);
    Task<bool> EventExists(int id);
}
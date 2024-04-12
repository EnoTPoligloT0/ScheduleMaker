using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScheduleMaker.Models;

namespace ScheduleMaker.Interfaces;


public interface IEventRepository
{
    Task<List<Event>> GetAllAsync();
    Task<Event?> GetAllByIdAsync();
    Task<Event> CreateAsync();
    Task<Event> UpdateAsync();
    Task<Event> DeleteAsync();

}
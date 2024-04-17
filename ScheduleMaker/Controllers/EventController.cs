using Microsoft.AspNetCore.Mvc;
using ScheduleMaker.Data;
using ScheduleMaker.Dtos;
using ScheduleMaker.Dtos;
using ScheduleMaker.Interfaces;
using ScheduleMaker.Mappers;

namespace ScheduleMaker.Controllers;

[Route("ScheduleMaker/event")]
[ApiController]
public class EventController : ControllerBase
{
    private readonly IEventRepository _eventRepository;
    private readonly ApplicationDBcontext _context;

    public EventController(ApplicationDBcontext context, IEventRepository eventRepository)
    {
        _context = context;
        _eventRepository = eventRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var events = await _eventRepository.GetAllAsync();

        var eventDto = events.Select(x => x.ToEventDto()).ToList();

        return Ok(eventDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var foundEvent = await _eventRepository.GetByIdAsync(int.Parse(id));

        if (foundEvent == null)
        {
            return NotFound();
        }

        return Ok(foundEvent.ToEventDto());
    }

    [HttpPost]

    public async Task<IActionResult> Create([FromBody] CreateEventRequestDto eventRequestDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var eventModel = eventRequestDto.ToEventFromCreateDto();
        await _eventRepository.CreateAsync(eventModel);
        return CreatedAtAction(nameof(GetById), new { id = eventModel.Id }, eventModel.ToEventDto());
    }

    [HttpPut]
    [Route("{id}")]

    public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateEventRequestDto eventRequestDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var eventModel = await _eventRepository.UpdateAsync(id, eventRequestDto);

        if (eventModel == null)
        {
            return NotFound();
        }

        await _context.SaveChangesAsync();

        return Ok(eventModel.ToEventDto());
    }

    [HttpDelete]
    [Route("{id}")]
    
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var eventModel = await _eventRepository.DeleteAsync(id);

        if (eventModel == null)
        {
            return null;
        }

        return NoContent();
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScheduleMaker.Dtos;
using ScheduleMaker.Interfaces;
using Newtonsoft.Json; 
using System;

namespace ScheduleMaker.Pages
{
    public class CreateEventModalModel2 : PageModel
    {
        private readonly IEventRepository _eventRepository;

        public CreateEventModalModel2(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [BindProperty]
        public CreateEventRequestDto EventDto { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Combine date and time into a single DateTime object
            EventDto.StartTime = CombineDateTime(EventDto.StartTime.Date, EventDto.StartTime.TimeOfDay);
            EventDto.EndTime = CombineDateTime(EventDto.EndTime.Date, EventDto.EndTime.TimeOfDay);

            // Convert CreateEventRequestDto to Event
            var eventModel = new ScheduleMaker.Models.Event
            {
                Title = EventDto.Title,
                Description = EventDto.Description,
                StartTime = EventDto.StartTime,
                EndTime = EventDto.EndTime
            };

            // Call the MVC controller action to create the event
            var result = _eventRepository.CreateAsync(eventModel).Result; // Synchronous call for simplicity

            if (result == null)
            {
                // Handle failure
                return Page();
            }

            // Handle success
            return RedirectToPage("/Index"); // Redirect to the desired page after event creation
        }

        // Method to combine date and time into a DateTime object
        private DateTime CombineDateTime(DateTime date, TimeSpan time)
        {
            return date.Date + time;
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScheduleMaker.Dtos;
using ScheduleMaker.Interfaces;
using Newtonsoft.Json; 
using System;
using System.Text;
using ScheduleMaker.Models;

namespace ScheduleMaker.Pages
{
    public partial class CreateEventModalModel : PageModel
    {
        private readonly IEventRepository _eventRepository;

        public CreateEventModalModel(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [BindProperty]
        public CreateEventRequestDto EventDto { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost(Event eventDto)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Serialize the form data into JSON format
            var eventDataJson = JsonConvert.SerializeObject(EventDto);

            // Create a StringContent object with JSON data
            var content = new StringContent(eventDataJson, Encoding.UTF8, "application/json");

            // Call the controller action with the JSON data
            var response = _eventRepository.CreateAsync(eventDto).Result; // Assuming CreateAsync accepts StringContent

            // Handle the response as needed

            return RedirectToPage("/Index"); // Redirect to the desired page after event creation
        }
    }
}
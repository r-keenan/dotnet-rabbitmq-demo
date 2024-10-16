using System.Linq;
using FormulaAirline.API.Models;
using FormulaAirline.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FormulaAirline.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
       private readonly ILogger<BookingsController> _logger;
       private readonly IMessageProducer _messageProducer;

       // In-memory "database"
       public static readonly List<Booking> _bookings = new();

        public BookingsController(ILogger<BookingsController> logger, IMessageProducer messageProducer)
        {
            _logger = logger;
            _messageProducer = messageProducer;
        }

        [HttpPost]
        public IActionResult CreateBooking(Booking newBooking) {
            if (!ModelState.IsValid) return BadRequest();

            _bookings.Add(newBooking);

            try
            {
                
            _messageProducer.SendingMessages<Booking>(newBooking);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);    
            }

            return Ok();
        }

        [HttpGet]
        public IActionResult GetBookings()
        {
            return Ok(_bookings ?? []);
        }
    }
}
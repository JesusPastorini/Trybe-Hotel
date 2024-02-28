using Microsoft.AspNetCore.Mvc;
using TrybeHotel.Models;
using TrybeHotel.Repository;
using TrybeHotel.Dto;

namespace TrybeHotel.Controllers
{
    [ApiController]
    [Route("hotel")]
    public class HotelController : Controller
    {
        private readonly IHotelRepository _repository;

        public HotelController(IHotelRepository repository)
        {
            _repository = repository;
        }

        // 4. Desenvolva o endpoint GET /hotel
        [HttpGet]
        public IActionResult GetHotels()
        {
            var hotels = _repository.GetHotels();

            // Retorna a lista de hotéis com o status 200 OK
            return Ok(hotels);
        }

        // 5. Desenvolva o endpoint POST /hotel
        [HttpPost]
        public IActionResult PostHotel([FromBody] Hotel hotel)
        {
            var result = _repository.AddHotel(hotel);

            if (result == null)
            {
                // Se a cidade não existe, erro com status 400 Bad Request
                return BadRequest("City not found");
            }

            // Retorna o resultado com o status 201 Created
            return CreatedAtAction(nameof(PostHotel), new { id = result.HotelId }, result);
        }


    }
}
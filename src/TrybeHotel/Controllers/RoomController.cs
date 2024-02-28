using Microsoft.AspNetCore.Mvc;
using TrybeHotel.Models;
using TrybeHotel.Repository;

namespace TrybeHotel.Controllers
{
    [ApiController]
    [Route("room")]
    public class RoomController : Controller
    {
        private readonly IRoomRepository _repository;
        public RoomController(IRoomRepository repository)
        {
            _repository = repository;
        }

        // 6. Desenvolva o endpoint GET /room/:hotelId
        [HttpGet("{HotelId}")]
        public IActionResult GetRoom(int HotelId)
        {
            var rooms = _repository.GetRooms(HotelId);

            // Retorna a lista de quartos com o status 200 OK
            return Ok(rooms); ;
        }

        // 7. Desenvolva o endpoint POST /room
        [HttpPost]
        public IActionResult PostRoom([FromBody] Room room)
        {
            var result = _repository.AddRoom(room);

            if (result == null)
            {
                // Se o hotel associado não existe, retorna erro com status 400 Bad Request
                return BadRequest("Hotel not found");
            }

            // Retorna o resultado com o status 201 Created
            return CreatedAtAction(nameof(PostRoom), new { id = result.RoomId }, result);
        }

        // 8. Desenvolva o endpoint DELETE /room/:roomId
        [HttpDelete("{RoomId}")]
        public IActionResult Delete(int RoomId)
        {
            throw new NotImplementedException();
        }
    }
}
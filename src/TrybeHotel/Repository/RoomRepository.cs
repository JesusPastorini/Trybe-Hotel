using TrybeHotel.Models;
using TrybeHotel.Dto;
using Microsoft.EntityFrameworkCore;

namespace TrybeHotel.Repository
{
    public class RoomRepository : IRoomRepository
    {
        protected readonly ITrybeHotelContext _context;
        public RoomRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        // 6. Desenvolva o endpoint GET /room/:hotelId
        public IEnumerable<RoomDto> GetRooms(int HotelId)
        {
            // Utiliza LINQ para obter os quartos com informações do hotel e da cidade
            var rooms = _context.Rooms
                .Where(r => r.HotelId == HotelId)
                .Include(r => r.Hotel.City)
                .Select(r => new RoomDto
                {
                    RoomId = r.RoomId,
                    Name = r.Name,
                    Capacity = r.Capacity,
                    Image = r.Image,
                    Hotel = new HotelDto
                    {
                        HotelId = r.Hotel.HotelId,
                        Name = r.Hotel.Name,
                        Address = r.Hotel.Address,
                        CityId = r.Hotel.City.CityId,
                        CityName = r.Hotel.City.Name
                    }
                })
                .ToList();

            return rooms;
        }

        // 7. Desenvolva o endpoint POST /room
        public RoomDto AddRoom(Room room)
        {
            // Adiciona o novo quarto ao contexto e salva as mudanças no banco de dados
            _context.Rooms.Add(room);
            _context.SaveChanges();
            // Se o quarto já existe, retorna o existente
            return new RoomDto
            {
                RoomId = room.RoomId,
                Name = room.Name,
                Capacity = room.Capacity,
                Image = room.Image,
                Hotel = _context.Hotels.Where(h => h.HotelId == room.HotelId).Select(h => new HotelDto
                {
                    HotelId = h.HotelId,
                    Name = h.Name,
                    Address = h.Address,
                    CityId = h.CityId,
                    CityName = _context.Cities.Where(c => c.CityId == h.CityId).Select(c => c.Name).FirstOrDefault()
                }).FirstOrDefault()
            };
        }

        // 8. Desenvolva o endpoint DELETE /room/:roomId
        public void DeleteRoom(int RoomId)
        {
            // Busca o quarto no banco de dados
            var room = _context.Rooms.FirstOrDefault(r => r.RoomId == RoomId);

            if (room != null)
            {
                // Remove o quarto do contexto e salva as mudanças no banco de dados
                _context.Rooms.Remove(room);
                _context.SaveChanges();
            }
        }
    }
}
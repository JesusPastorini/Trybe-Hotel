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
            // Verifica se o quarto já existe no banco de dados
            var existingRoom = _context.Rooms.FirstOrDefault(r => r.Name == room.Name && r.HotelId == room.Hotel.HotelId);

            if (existingRoom != null)
            {
                // Se o quarto já existe, retorna o existente
                return new RoomDto
                {
                    RoomId = existingRoom.RoomId,
                    Name = existingRoom.Name,
                    Capacity = existingRoom.Capacity,
                    Image = existingRoom.Image,
                    Hotel = new HotelDto
                    {
                        HotelId = existingRoom.Hotel.HotelId,
                        Name = existingRoom.Hotel.Name,
                        Address = existingRoom.Hotel.Address,
                        CityId = existingRoom.Hotel.City.CityId,
                        CityName = existingRoom.Hotel.City.Name
                    }
                };
            }

            // Verifica se o hotel associado ao quarto existe
            var existingHotel = _context.Hotels.FirstOrDefault(h => h.HotelId == room.Hotel.HotelId);

            if (existingHotel == null)
            {
                // Se o hotel não existe, retorna erro
                return null;
            }

            // Cria um novo quarto
            var newRoom = new Room
            {
                Name = room.Name,
                Capacity = room.Capacity,
                Image = room.Image,
                HotelId = room.Hotel.HotelId
            };

            // Adiciona o novo quarto ao contexto e salva as mudanças no banco de dados
            _context.Rooms.Add(newRoom);
            _context.SaveChanges();

            // Retorna os dados do novo quarto
            return new RoomDto
            {
                RoomId = newRoom.RoomId,
                Name = newRoom.Name,
                Capacity = newRoom.Capacity,
                Image = newRoom.Image,
                Hotel = new HotelDto
                {
                    HotelId = newRoom.Hotel.HotelId,
                    Name = newRoom.Hotel.Name,
                    Address = newRoom.Hotel.Address,
                    CityId = newRoom.Hotel.City.CityId,
                    CityName = newRoom.Hotel.City.Name
                }
            };
        }

        // 8. Desenvolva o endpoint DELETE /room/:roomId
        public void DeleteRoom(int RoomId)
        {
            throw new NotImplementedException();
        }
    }
}
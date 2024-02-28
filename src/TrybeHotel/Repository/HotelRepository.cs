using TrybeHotel.Models;
using TrybeHotel.Dto;
using Microsoft.EntityFrameworkCore;

namespace TrybeHotel.Repository
{
    public class HotelRepository : IHotelRepository
    {
        protected readonly ITrybeHotelContext _context;
        public HotelRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        // 4. Desenvolva o endpoint GET /hotel
        public IEnumerable<HotelDto> GetHotels()
        {
            // Utiliza LINQ para obter os hotéis com informações da cidade
            var hotels = _context.Hotels
                .Include(h => h.City)
                .Select(h => new HotelDto
                {
                    HotelId = h.HotelId,
                    Name = h.Name,
                    Address = h.Address,
                    CityId = h.City.CityId,
                    CityName = h.City.Name
                })
                .ToList();

            return hotels;
        }

        // 5. Desenvolva o endpoint POST /hotel
        public HotelDto AddHotel(Hotel hotel)
        {
            // Verifica se o hotel já existe no banco de dados
            var existingHotel = _context.Hotels.FirstOrDefault(h => h.Name == hotel.Name && h.CityId == hotel.CityId);

            if (existingHotel != null)
            {
                // Se o hotel já existe, retorna o existente
                return new HotelDto
                {
                    HotelId = existingHotel.HotelId,
                    Name = existingHotel.Name,
                    Address = existingHotel.Address,
                    CityId = existingHotel.City.CityId,
                    CityName = existingHotel.City.Name
                };
            }

            // Verifica se a cidade associada ao hotel existe
            var existingCity = _context.Cities.FirstOrDefault(c => c.CityId == hotel.CityId);

            if (existingCity == null)
            {
                // Se a cidade não existe, retorna erro
                return null;
            }

            // Cria um novo hotel
            var newHotel = new Hotel
            {
                Name = hotel.Name,
                Address = hotel.Address,
                CityId = hotel.CityId
            };

            // Adiciona o novo hotel ao contexto e salva as mudanças no banco de dados
            _context.Hotels.Add(newHotel);
            _context.SaveChanges();

            // Retorna os dados do novo hotel
            return new HotelDto
            {
                HotelId = newHotel.HotelId,
                Name = newHotel.Name,
                Address = newHotel.Address,
                CityId = newHotel.City.CityId,
                CityName = newHotel.City.Name
            };
        }
    }
}
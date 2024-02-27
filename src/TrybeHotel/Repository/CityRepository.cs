using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class CityRepository : ICityRepository
    {
        protected readonly ITrybeHotelContext _context;
        public CityRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        // 2. Desenvolva o endpoint GET /city
        public IEnumerable<CityDto> GetCities()
        {
            return _context.Cities.Select(c => new CityDto
            {
                CityId = c.CityId,
                Name = c.Name,
            });
        }

        // 3. Desenvolva o endpoint POST /city
        public CityDto AddCity(City city)
        {
            //verifca se a cidade já existe no banco de dados
            var existingCity = _context.Cities.FirstOrDefault(c => c.Name == city.Name);

            if (existingCity != null)
            {
                // Se cidade existe, retorna
                return new CityDto
                {
                    CityId = existingCity.CityId,
                    Name = existingCity.Name
                };
            }

            // Cria uma nova cidade
            var newCity = new City
            {
                Name = city.Name
            };

            // Adiciona a nova cidade ao contexto e salva as mudanças no banco de dados
            _context.Cities.Add(newCity);
            _context.SaveChanges();

            // Retorna os dados da nova cidade
            return new CityDto
            {
                CityId = newCity.CityId,
                Name = newCity.Name
            };
        }

    }
}
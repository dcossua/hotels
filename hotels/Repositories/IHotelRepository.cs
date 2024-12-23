using hotels.Models;

namespace hotels.Repositories
{
    public interface IHotelRepository
    {
        List<Hotel> GetHotels();
    }
}

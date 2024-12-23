using hotels.Models;

namespace hotels.Repositories
{
    /// <summary>
    /// Defines the methods to obtain hotel data.
    /// </summary>
    public interface IHotelRepository
    {
        /// <summary>
        /// Gets all hotels.
        /// </summary>
        /// <returns>A list of <see cref="Hotel"/></returns>
        List<Hotel> GetHotels();
    }
}

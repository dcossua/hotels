using hotels.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace hotels.Repositories.Impl
{
    /// <summary>
    /// Implements the methods from <see cref="IHotelRepository"/>.
    /// </summary>
    public class HotelRepository : IHotelRepository
    {
        /// <summary>
        /// Path to hotels database.
        /// </summary>
        private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "App_Data", "hotels.json");

        /// <summary>
        /// Gets all hotels.
        /// </summary>
        /// <returns>A list of <see cref="Hotel"/></returns>
        public List<Hotel> GetHotels()
        {
            // If the file does not exists, we return an empty array
            if (!File.Exists(_filePath))
            {
                return new List<Hotel>();
            }

            // Read the file content
            var json = File.ReadAllText(_filePath);

            // Deserialize the content
            return JsonConvert.DeserializeObject<List<Hotel>>(json) ?? new List<Hotel>(); // Deserialization
        }
    }
}


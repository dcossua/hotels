using hotels.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace hotels.Repositories.Impl
{
    public class HotelRepository : IHotelRepository
    {
        private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "App_Data", "hotels.json");

        // Get all hotels from JSON file
        public List<Hotel> GetHotels()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Hotel>(); // If the file does not exists, we return an empty array
            }

            var json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<Hotel>>(json) ?? new List<Hotel>(); // Deserialization
        }
    }
}


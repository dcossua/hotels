using hotels.Enums;

namespace hotels.Models
{
    /// <summary>
    /// Represents a hotel.
    /// </summary>
    public class Hotel
    {
        /// <summary>
        /// Get or set the hotel id.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Get or set the hotel name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Get or set the hotel location.
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Get or set the hotel rating.
        /// </summary>
        public float Rating { get; set; }
        /// <summary>
        /// Get or set the hotel image URL.
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// Get or set the hotel dates of travel.
        /// </summary>
        public List<string> DatesOfTravel { get; set; }
        /// <summary>
        /// Get or set the hotel board basis.
        /// </summary>
        public EBoardBasis BoardBasis { get; set; }
        /// <summary>
        /// Get or set the hotel rooms.
        /// </summary>
        public List<Room> Rooms { get; set; }
    }
}

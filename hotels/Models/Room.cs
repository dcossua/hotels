using hotels.Enums;

namespace hotels.Models
{
    /// <summary>
    /// Represents a room in a hotel.
    /// </summary>
    public class Room
    {
        /// <summary>
        /// Get or set the room type.
        /// </summary>
        public ERoomType RoomType { get; set; }
        /// <summary>
        /// Get or set the amount.
        /// </summary>
        public int amount { get; set; }
    }
}

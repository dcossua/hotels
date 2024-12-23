using hotels.Enums;
using hotels.Models;
using hotels.Repositories;
using Moq;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace hotels.Tests
{
    public class HotelRepositoryTests
    {
        private readonly Mock<IHotelRepository> _mockRepository;
        private readonly List<Hotel> _hotels;

        public HotelRepositoryTests()
        {
            _mockRepository = new Mock<IHotelRepository>();
            _hotels = new List<Hotel>
            {
                new Hotel
                {
                    Id = 1,
                    Name = "Hotel 1",
                    Location = "Location 1",
                    Rating = 4.5f,
                    ImageUrl = "url1",
                    BoardBasis = EBoardBasis.AllInclusive,
                    Rooms = new List<Room>
                    {
                        new Room { RoomType = ERoomType.DeluxeSuite, Amount = 5 }
                    }
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Hotel 2",
                    Location = "Location 2",
                    Rating = 4.0f,
                    ImageUrl = "url2",
                    BoardBasis = EBoardBasis.FullBoard,
                    Rooms = new List<Room>
                    {
                        new Room { RoomType = ERoomType.StandardRoom, Amount = 10 }
                    }
                }
            };

            _mockRepository.Setup(repo => repo.GetHotels()).Returns(_hotels);
        }

        [Fact]
        public void GetHotels_ReturnsListOfHotels()
        {
            // Act
            var hotels = _mockRepository.Object.GetHotels();

            // Assert
            Assert.NotNull(hotels);
            Assert.Equal(2, hotels.Count);
        }

        [Fact]
        public void GetHotels_ReturnsCorrectHotelDetails()
        {
            // Act
            var hotel1 = _mockRepository.Object.GetHotels().FirstOrDefault(m => m.Id == 1);

            // Assert
            Assert.NotNull(hotel1);
            Assert.Equal(1, hotel1.Id);
            Assert.Equal("Hotel 1", hotel1.Name);
            Assert.Equal("Location 1", hotel1.Location);
            Assert.Equal(4.5f, hotel1.Rating);
            Assert.Equal("url1", hotel1.ImageUrl);
            Assert.Equal(EBoardBasis.AllInclusive, hotel1.BoardBasis);
            Assert.Single(hotel1.Rooms);
            Assert.Equal(ERoomType.DeluxeSuite, hotel1.Rooms[0].RoomType);
            Assert.Equal(5, hotel1.Rooms[0].Amount);
        }

        [Fact]
        public void GetHotels_ReturnNullHotel()
        {
            // Act
            var hotel1 = _mockRepository.Object.GetHotels().FirstOrDefault(m => m.Id == 3);

            // Assert
            Assert.Null(hotel1);
        }
    }
}
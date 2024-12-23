using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using hotels.Models;
using hotels.Resources;
using hotels.Repositories.Impl;
using hotels.Repositories;

namespace hotels.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/hotels")]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelRepository _repository;

        public HotelsController(IHotelRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Get all hotels.
        /// </summary>
        /// <returns>A list of hotels</returns>
        // GET: /api/hotels
        [HttpGet]
        public ActionResult<IEnumerable<Hotel>> GetAllHotels() => Ok(_repository.GetHotels());

        /// <summary>
        /// Get the details of a hotel.
        /// </summary>
        /// <param name="id">Hotel ID</param>
        /// <returns>The specified hotel or an error message if it was not found</returns>
        // GET: /api/hotels/{id}
        [HttpGet("{id}")]
        public ActionResult<Hotel> GetHotelDetail(int? id)
        {
            // Check if the hotel ID is null
            if (id == null)
            {
                return NotFound(Messages.GetMessage("Error_HotelNotFound"));
            }

            // Get the hotel by ID
            var hotel = _repository.GetHotels().FirstOrDefault(m => m.Id == id);

            // Check if the hotel is null
            if (hotel == null)
            {
                return NotFound(Messages.GetMessage("Error_HotelNotFound"));
            }

            // Return the hotel
            return Ok(hotel);
        }
    }
}

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

        // GET: /api/hotels
        [HttpGet]
        public ActionResult<IEnumerable<Hotel>> GetAllHotels() => Ok(_repository.GetHotels());

        // GET: /api/hotels/{id}
        [HttpGet("{id}")]
        public ActionResult<Hotel> GetHotelDetail(int? id)
        {
            if (id == null)
            {
                return NotFound(Messages.GetMessage("Error_HotelNotFound"));
            }

            var hotel = _repository.GetHotels().FirstOrDefault(m => m.Id == id);
            if (hotel == null)
            {
                return NotFound(Messages.GetMessage("Error_HotelNotFound"));
            }

            return Ok(hotel);
        }
    }
}

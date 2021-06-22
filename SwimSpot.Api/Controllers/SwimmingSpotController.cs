using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SwimSpot.Shared;
using SwimSpot.Api.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SwimSpot.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SwimmingSpotController : ControllerBase
        
    {
        private readonly ISwimmingSpotRepository _swimmingSpotRepository;

        public SwimmingSpotController(ISwimmingSpotRepository swimmingSpotRepository)
        {
            _swimmingSpotRepository = swimmingSpotRepository;
        }

        // GET: api/<SwimSpotController>
        [HttpGet]
        public IActionResult GetAllSwimmingSpots()
        {
            return Ok(_swimmingSpotRepository.GetAllSwimmingSpots());
        }

        // GET api/<SwimSpotController>/5
        [HttpGet("{id}")]
        public IActionResult GetSwimmingSpotById(int id)
        {
            var swimmingSpot = _swimmingSpotRepository.GetSwimmingSpotById(id);

            if (swimmingSpot == null)
                return NotFound();

            return Ok(swimmingSpot);
        }

        // POST api/<SwimSpotController>
        [HttpPost]
        public IActionResult CreateSwimmingSpot([FromBody] SwimmingSpot swimmingSpot)
        {
            if(swimmingSpot == null || swimmingSpot.Latitude == 0 || swimmingSpot.Longitude == 0)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newSwimmingSpot = _swimmingSpotRepository.AddSwimmingSpot(swimmingSpot);
            return Created("Swimming spot", newSwimmingSpot);
            

        }

        // PUT api/<SwimSpotController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateSwimmingSpot(int id, [FromBody] SwimmingSpot swimmingSpot)
        {
            if (swimmingSpot == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var swimmingSpotToUpdate = _swimmingSpotRepository.GetSwimmingSpotById(id);

            if (swimmingSpotToUpdate == null)
                return NotFound();

            _swimmingSpotRepository.UpdateSwimmingSpot(swimmingSpot);
            return NoContent();
        }

        // DELETE api/<SwimSpotController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            var swimmingSpotToDelete = _swimmingSpotRepository.GetSwimmingSpotById(id);
            if (swimmingSpotToDelete == null)
                return NotFound();

            _swimmingSpotRepository.DeleteSwimmingSpot(id);

            return NoContent();//success
        }
    }
}

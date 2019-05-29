using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WineCloud2.Domain.Abstract;
using WineCloud2.Domain.Concrete;
using WineCloud2.Models.ViewModels;

namespace WineCloud2.API.Controllers
{
    [Route("api/bottles")]
    [ApiController]
    [Authorize]
    public class BottlesController : Controller
    {
        private IBottleService _bottleService;

        public BottlesController(IBottleService service)
        {
            _bottleService = service;
        }

        // GET api/bottles
        [HttpGet]
        public async Task<IActionResult> GetBottles()
        {
            try
            {
                var bottles = await _bottleService.GetBottleTypes();

                return Ok(bottles);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET api/bottles/5
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {

                var bottle = await _bottleService.GetBottleTypeById(id);

                return Ok(bottle);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // POST api/bottles
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBottleTypeVM bottleType)
        {
            try
            {

                var newBottle = await _bottleService.AddBottleType(bottleType);

                return Ok(newBottle);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT api/bottles/5
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] BottleVM bottle)
        {
            try
            {
                var updateBottle = await _bottleService.UpdateBottle(id, bottle);

                return Ok(updateBottle);
            }
            catch
            {
                return StatusCode(500, "Interal server error");
            }
        }

        // DELETE api/bottles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _bottleService.RemoveBottle(id);

                return Ok();
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using RestAPI.Models;
using RestAPI.Services;

namespace RestAPI.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class RacerController : Controller
    {

        private readonly MongoDBService _mongoDBService;
        public RacerController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }
        [HttpGet]
        public async Task<List<Racer>> Get()
        {
            return await _mongoDBService.GetAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Racer racer)
        {
            await _mongoDBService.CreateAsync(racer);
            return CreatedAtAction(nameof(Get), new { id = racer.Id }, racer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AddRacer(string id, [FromBody] string racerId)
        {
            await _mongoDBService.AddRacerAsync(id, racerId);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _mongoDBService.DeleteAsync(id);
            return NoContent();
        }
    }
    }

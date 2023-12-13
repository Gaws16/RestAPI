using Microsoft.AspNetCore.Mvc;
using RestAPI.Models;
using RestAPI.Services;

namespace RestAPI.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class ChipsController:Controller
    {
        private readonly MongoDBService _mongoDBService;

        public ChipsController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }
        [HttpGet]
        public async Task<List<Chip>> Get()
        {
            return await _mongoDBService.GetChipAsync();
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Chip chip)
        {
            await _mongoDBService.CreateChipAsync(chip);
            return CreatedAtAction(nameof(Get), new { id = chip.Id }, chip);
        }
    }
}

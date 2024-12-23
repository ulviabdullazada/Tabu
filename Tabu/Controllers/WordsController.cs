using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tabu.DTOs.Words;
using Tabu.Services.Abstracts;

namespace Tabu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController(IWordService _service) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Post(WordCreateDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }

        [HttpPost("AddRange")]
        public async Task<IActionResult> PostMany(IEnumerable<WordCreateDto> dto)
        {
            foreach (var item in dto)
            {
                await _service.CreateAsync(item);
            }
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }
    }
}

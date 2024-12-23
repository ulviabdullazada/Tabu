using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Tabu.DAL;
using Tabu.DTOs.Languages;
using Tabu.Entities;
using Tabu.Exceptions;
using Tabu.ExternalServices.Abstracts;
using Tabu.ExternalServices.Implements;
using Tabu.Services.Abstracts;

namespace Tabu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController(ILanguageService _service) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post(LanguageCreateDto dto)
        {
            await _service.CreateAsync(dto);
            return Created();
        }

        [HttpPut]
        [Route("{code}")]
        public async Task<IActionResult> Update(string code, LanguageUpdateDto dto)
        {
            await _service.UpdateAsync(code, dto);
            return Ok();
        }

        [HttpDelete]
        [Route("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            return NoContent();
        }
    }
}

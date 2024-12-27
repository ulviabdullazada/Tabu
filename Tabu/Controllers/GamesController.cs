using Microsoft.AspNetCore.Mvc;
using Tabu.DTOs.Games;
using Tabu.ExternalServices.Abstracts;
using Tabu.Services.Abstracts;

namespace Tabu.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GamesController(IGameService _service, IErrorService _error) : ControllerBase
{

    [HttpGet("[action]")]
    public async Task<IActionResult> Get()
    {
        return Ok(_error.GetField("Language"));
    }
	[HttpPost]
	public async Task<IActionResult> Create(GameCreateDto dto)
	{
		return Ok(await _service.AddAsync(dto));
	}
    [HttpPost("[action]/{id}")]
    public async Task<IActionResult> Start(Guid id)
    {
        return Ok(await _service.StartAsync(id));
    }
    [HttpPost("[action]/{id}")]
    public async Task<IActionResult> Success(Guid id)
    {
        return Ok(await _service.SuccessAsync(id));
    }
    [HttpGet]
    public async Task<IActionResult> GetGameData(Guid id)
    {
        return Ok(await _service.GetCurrentStatus(id));
    }

}

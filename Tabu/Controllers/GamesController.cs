﻿using Microsoft.AspNetCore.Mvc;

namespace Tabu.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GamesController : ControllerBase
{

	[HttpGet]
	public async Task<IActionResult> Get()
	{
		return BadRequest("Salam");
	}
}

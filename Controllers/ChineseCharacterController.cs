namespace ccex_api.Controllers;

using ccex_api.DTOs;
using ccex_api.Mappers;
using ccex_api.Models;
using ccex_api.Repositories;
using Microsoft.AspNetCore.Mvc;

[Route("char")]
[ApiController]
public class ChineseCharacterController : ControllerBase
{
  private readonly IChineseCharacterRepository _repo;

  public ChineseCharacterController(IChineseCharacterRepository repo)
  {
    _repo = repo;
  }

  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    List<ChineseCharacter> chars = await _repo.GetAllAsync();

    var basicChars = chars.Select(c => c.ToBasicDTO());

    return Ok(basicChars);
  }

  [HttpGet("{id:int}")]
  public async Task<IActionResult> GetById([FromRoute] int id)
  {
    var cchar = await _repo.GetByIdAsync(id);

    if (cchar == null)
    {
      return NotFound();
    }

    return Ok(cchar.ToDTO());
  }

  [HttpGet("{chineseCharacter}")]
  public async Task<IActionResult> GetByChar([FromRoute] string chineseCharacter)
  {
    var cchar = await _repo.GetByCharAsync(chineseCharacter);

    if (cchar == null)
    {
      return NotFound();
    }

    return Ok(cchar.ToDTO());
  }
  
}
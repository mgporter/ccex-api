namespace ccex_api.Controllers;

using ccex_api.Mappers;
using ccex_api.Models;
using ccex_api.Repositories;
using Microsoft.AspNetCore.Mvc;

[Route("tradstub")]
[ApiController]
public class TradCharacterStubController : ControllerBase
{
  private readonly ITradCharacterStubRepository _repo;

  public TradCharacterStubController(ITradCharacterStubRepository repo)
  {
    _repo = repo;
  }

  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    List<TradCharacterStub> chars = await _repo.GetAllAsync();

    var charDTOs = chars.Select(c => c.ToDTO());

    return Ok(charDTOs);
  }

  [HttpGet("{id:int}")]
  public async Task<IActionResult> GetById([FromRoute] int id)
  {
    var tchar = await _repo.GetByIdAsync(id);

    if (tchar == null)
    {
      return NotFound();
    }

    return Ok(tchar.ToDTO());
  }

  [HttpGet("{chineseCharacter}")]
  public async Task<IActionResult> GetByChar([FromRoute] string chineseCharacter)
  {
    var tchar = await _repo.GetByCharAsync(chineseCharacter);

    if (tchar == null)
    {
      return NotFound();
    }

    return Ok(tchar.ToDTO());
  }
}
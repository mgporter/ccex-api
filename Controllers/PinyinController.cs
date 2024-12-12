namespace ccex_api.Controllers;

using ccex_api.Mappers;
using ccex_api.Models;
using ccex_api.Repositories;
using Microsoft.AspNetCore.Mvc;

[Route("pinyin")]
[ApiController]
public class PinyinController : ControllerBase
{
  private readonly IPinyinRepository _repo;

  public PinyinController(IPinyinRepository repo)
  {
    _repo = repo;
  }

  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    List<Pinyin> pinyins = await _repo.GetAllAsync();

    var basicPinyins = pinyins.Select(p => p.ToBasicDTO());

    return Ok(basicPinyins);
  }

  [HttpGet("{id:int}")]
  public async Task<IActionResult> GetById([FromRoute] int id)
  {
    var pinyin = await _repo.GetByIdAsync(id);

    if (pinyin == null)
    {
      return NotFound();
    }

    return Ok(pinyin.ToDTO());
  }

  [HttpGet("{syllable}")]
  public async Task<IActionResult> GetBySyllable([FromRoute] string syllable)
  {
    var pinyin = await _repo.GetBySyllableAndToneMarkAsync(syllable);

    if (pinyin == null)
    {
      return NotFound();
    }

    return Ok(pinyin.ToDTO());
  }
}
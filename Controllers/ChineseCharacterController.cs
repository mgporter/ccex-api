namespace ccex_api.Controllers;

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

  
}
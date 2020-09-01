using Microsoft.AspNetCore.Mvc;
using timsTacos.Models;
using timsTacos.Services;

namespace timsTacos.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TacoIngredientsController : ControllerBase
  {
    private readonly TacoIngredientsService _service;

    public TacoIngredientsController(TacoIngredientsService service)
    {
      _service = service;
    }

    [HttpPost]
    public ActionResult<TacoIngredient> Post([FromBody] TacoIngredient newTacoIngredient)
    {
      try
      {
        return Ok(_service.Create(newTacoIngredient));
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<TacoIngredient> Delete(int id)
    {
      try
      {
        return Ok(_service.Delete(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
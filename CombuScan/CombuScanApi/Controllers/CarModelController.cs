using Microsoft.AspNetCore.Mvc;
using CombuScanModel;
using Microsoft.EntityFrameworkCore;

namespace CombuScanApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CarModelController : ControllerBase
  {
    private readonly CombuScanDbContext _context;

    public CarModelController(CombuScanDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CarModel>>> GetCarModels()
    {
      return await _context.CarModels.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<Car>>> GetCarModel(int id)
    {
      var carModel = await _context.CarModels.FindAsync(id);

      if (carModel == null)
      {
        return NotFound();
      }

      return Ok(carModel);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutCar(int id, CarModel carModel)
    {
      if (id != carModel.Id)
      {
        return BadRequest();
      }

      _context.Entry(carModel).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!CarModelExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> PostCar(CarModel carModel)
    {
      _context.CarModels.Add(carModel);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetCarModel", new { id = carModel.Id }, carModel);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCarModel(int id)
    {
      var carModel = await _context.CarModels.FindAsync(id);

      if (carModel == null)
      {
        return NotFound();
      }

      _context.CarModels.Remove(carModel);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool CarModelExists(int id)
    {
      return _context.CarModels.Any(a => a.Id == id);
    }
  }
}

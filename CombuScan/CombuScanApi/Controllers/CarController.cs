using Microsoft.AspNetCore.Mvc;
using CombuScanModel;
using Microsoft.EntityFrameworkCore;

namespace CombuScanApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CarController : ControllerBase
  {
    private readonly CombuScanDbContext _context;

    public CarController(CombuScanDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Car>>> GetAllCars()
    {
      return await _context.Cars.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<Car>>> GetCar(int id)
    {
      var car = await _context.Cars.FindAsync(id);

      if (car == null)
      {
        return NotFound();
      }

      return Ok(car);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutCar(int id, Car car)
    {
      if (id != car.Id)
      {
        return BadRequest();
      }

      _context.Entry(car).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!CarExists(id))
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
    public async Task<IActionResult> PostCar(Car car)
    {
      _context.Cars.Add(car);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetCar", new { id = car.Id }, car);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCar(int id)
    {
      var car = await _context.Cars.FindAsync(id);

      if (car == null)
      {
        return NotFound();
      }

      _context.Cars.Remove(car);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool CarExists(int id)
    {
      return _context.Cars.Any(a => a.Id == id);
    }
  }
}

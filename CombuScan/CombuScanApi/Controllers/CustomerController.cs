#nullable disable
using CombuScanModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdqLibrary;

namespace CombuScanApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CustomerController : Controller
  {
    private readonly CombuScanDbContext _context;

    public CustomerController(CombuScanDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
    {
      return await _context.Customers.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> GetCustomer(int id)
    {
      var comm = CommunicationMgr.GetInstance();

      return await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
    }
  }
}

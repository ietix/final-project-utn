using AdquisitionWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AdquisitionWebApi.Controllers
{
  public class CarModelController : ApiController
  {

    private SQLiteContext _context;

    public CarModelController()
    {
      _context = SQLiteContext.GetInstance();
    }

    /// <summary>
    /// Gets car model
    /// Route: GET api/CarModel
    /// </summary>
    /// <returns>A list of CarModel</returns>
    public IHttpActionResult GetCarModels()
    {
      try
      {
        return Ok(_context.CarModels.ToList());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
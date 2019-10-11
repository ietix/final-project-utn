using AdquisitionWebApi.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace AdquisitionWebApi.Controllers
{
  public class BrandController : ApiController
  {

    private SQLiteContext _context;

    public BrandController()
    {
      _context = SQLiteContext.GetInstance();  
    }

    /// <summary>
    /// Gets brands
    /// Route: GET api/Brand
    /// </summary>
    /// <returns>A list of Brand class</returns>
    public IHttpActionResult GetBrands()
    {
      try
      {
        return Ok(_context.Brands.ToList());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    /// <summary>
    /// Gets brand by Id
    /// Route: GET api/Brand/Id
    /// </summary>
    /// <returns>A Brand class instance</returns>
    public IHttpActionResult GetBrands(int Id)
    {
      try
      {
        return Ok<Brand>(_context.Brands.FirstOrDefault(x => x.Id == Id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    /// <summary>
    /// Creates a brand
    /// Route: POST api/Brand
    /// </summary>
    /// <returns>A new instance of Brand</returns>
    public IHttpActionResult PostBrands([FromBody] Brand brand)
    {
      try
      {
        var createdBrand = _context.Brands.Add(brand);

        _context.SaveChanges();

        return CreatedAtRoute<Brand>("/api/Brand", createdBrand.Id, createdBrand);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    /// <summary>
    /// Updates a brand
    /// Route: PUT api/Brand/Id
    /// </summary>
    /// <returns>No content status code when updating is successful</returns>
    public IHttpActionResult PutBrands(int Id, [FromBody] Brand brand)
    {
      try
      {
        if (Id != brand.Id)
        {
          return BadRequest("Provided Id does not match with object.");
        }

        var lookedBrand = _context.Brands.FirstOrDefault(x => x.Id == Id);

        if (lookedBrand == null)
        {
          return NotFound();
        }
        
        _context.Entry(brand).State = EntityState.Modified;
        _context.SaveChanges();

        return StatusCode(HttpStatusCode.NoContent);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    public IHttpActionResult DeleteBrands(int Id)
    {
      try
      {
        var lookedBrand = _context.Brands.FirstOrDefault(x => x.Id == Id);

        if (lookedBrand == null)
        {
          return NotFound();
        }

        _context.Entry(lookedBrand).State = EntityState.Deleted;
        _context.SaveChanges();

        return Ok();
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
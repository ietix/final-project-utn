using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AdquisitionWebApi.Utils;
using AdquisitionWebApi.ApiDbContext;

namespace AdquisitionWebApi.Controllers
{
  public class AnalysisController : ApiController
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name=""></param>
    /// <returns></returns>
    public IHttpActionResult PostAnalysis([FromUri] int diagnosticId, [FromBody] IEnumerable<ValuePoint> valuePoints)
    {
      try
      {
        

        return Ok();
      }
      catch (Exception)
      {

        throw;
      }
    }
  }
}

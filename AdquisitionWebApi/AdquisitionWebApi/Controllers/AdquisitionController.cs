using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AdqLibrary;

namespace AdquisitionWebApi.Controllers
{
  public class AdquisitionController : ApiController
  {
    /// <summary>
    /// Starts or stops the adquisition
    /// Route: POST api/Adquisition?start=1
    /// </summary>
    /// <param name="start"></param>
    /// <returns>Http 200 Ok when the action is completed</returns>
    public IHttpActionResult PostAdquisition([FromUri] int start)
    {
      try
      {
        if (start == 0)
        {
          CommunicationMgr.GetInstance().StopAdquisition();
        }
        else
        {
          CommunicationMgr.GetInstance().StartAdquisition();
        }

        return Ok();
      }
      catch (Exception)
      {

        throw;
      }
    }
  }
}

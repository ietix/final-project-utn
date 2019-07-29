using AdqLibrary;
using AdqLibrary.Classes;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Web.Http;
using AdquisitionWebApi.Utils;

namespace AdquisitionWebApi.Controllers
{
  public class AdquisitionController : ApiController
  {
    /// <summary>
    /// Gets a stream of ValuePoint class
    /// Route: POST api/Adquisition
    /// </summary>
    /// <returns>A stream of ValuePoint class with online data comming from AdqLibrary</returns>
    [HttpGet]
    public HttpResponseMessage GetOnlineData()
    {
      var response = Request.CreateResponse();

      response.Content = new PushStreamContent((stream, content, context) =>
      {
        foreach (var point in CommunicationMgr.GetInstance().AdquisitionMQueue.GetAllMessages())
        {
          var serializer = new JsonSerializer();

          using (var writer = new StreamWriter(stream))
          {
            serializer.Serialize(writer, ((Point)point.Body).ToValuePoint());
            stream.Flush();
          }
        }
      });

      return response;
    }

    /// <summary>
    /// Starts or stops the adquisition
    /// Route: POST api/Adquisition/Adquisition?start=1
    /// </summary>
    /// <param name="start">Paraameter with value=1 starts adquisition and value=0 stops it</param>
    /// <returns>Http 200 Ok when the action is completed</returns>
    public IHttpActionResult PostAdquisition([FromUri] int start)
    {
      try
      {
        if (start == 0)
        {
          CommunicationMgr.GetInstance(Utilities.Log()).StopAdquisition();
        }
        else
        {
          CommunicationMgr.GetInstance(Utilities.Log()).StartAdquisition();
        }

        return Ok();
      }
      catch (Exception)
      {

        throw;
      }
    }

    /// <summary>
    /// Saves the current adquisition to a file
    /// Route: POST api/Adquisition/Save
    /// </summary>
    /// <returns>Http 200 Ok when the action is completed</returns>
    public IHttpActionResult PostSave()
    {
      try
      {
        CurvesMgr.GetInstance().SaveCurveIntoBin();

        return Ok();
      }
      catch (Exception)
      {

        throw;
      }
    }
  }
}

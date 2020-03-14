using System;
using AdquisitionWebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;


namespace AdquisitionWebApi.Controllers
{
  public class LoginController : ApiController
  {
    #region Private Fields

    private SQLiteContext _context;

    #endregion

    public IHttpActionResult Login(string username, string password)
    {
      return _context.Users.Count(x => x.Username.Equals(username) && x.Password.Equals(password)) > 0 ? (IHttpActionResult)Ok() : (IHttpActionResult)BadRequest("User or password incorrect");
    }
  }
}
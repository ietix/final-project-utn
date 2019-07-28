using System;
using System.Linq;
using System.Reflection;
using AdqLibrary.Classes;

namespace AdquisitionWebApi.Utils
{
  public static class Utilities
  {
    #region Public Methods

    /// <summary>
    /// Convertion method for wrrapper class
    /// </summary>
    /// <param name="point">An instance of Point class</param>
    /// <returns>An equivalent instance of ValuePoint</returns>
    public static ValuePoint ToValuePoint(this Point point)
    {
      return new ValuePoint
      {
        TimeStamp = point.TimeStamp,
        Value = point.Value
      };
    }

    public static Curve ToCurve(this ValuePoint[] points)
    {
      var pointList = points.ToList().Select(x => new Point { TimeStamp = x.TimeStamp, Value = x.Value }).ToList();

      return new Curve
      {
        Id = Convert.ToInt32(DateTime.Now.ToString("yyyyMMddHHmmss")),
        Points = pointList
      };
    }

    #endregion
  }
}
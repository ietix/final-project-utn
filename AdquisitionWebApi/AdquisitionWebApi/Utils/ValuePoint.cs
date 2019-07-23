using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AdquisitionWebApi.Utils
{
  /// <summary>
  /// Wrapper class for AdqLibrary Point
  /// </summary>
  [DataContract]
  public class ValuePoint
  {
    #region Constructors

    /// <summary>
    /// Default class constructor
    /// </summary>
    public ValuePoint()
    {
    }

    /// <summary>
    /// Constructor from time and value
    /// </summary>
    /// <param name="timeStamp">UNIX timesatmp value</param>
    /// <param name="value">Real value for given timestamp</param>
    public ValuePoint(long timeStamp, double value)
    {
      TimeStamp = timeStamp;
      Value = value;
    }
    
    #endregion

    #region Public Properties
    
    /// <summary>
    /// Gets or set TimeStamp in Milliseconds
    /// </summary>
    [DataMember]
    public long TimeStamp { get; set; }

    /// <summary>
    /// Gets or sets value for a given point in time
    /// </summary>
    [DataMember]
    public double Value { get; set; }

    #endregion
  }
}
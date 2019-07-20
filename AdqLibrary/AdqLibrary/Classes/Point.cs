using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdqLibrary.Classes
{
    /// <summary>
    /// Represents a point inside a curve
    /// </summary>
    public class Point
    {
        #region Public Properties

        /// <summary>
        /// Gets or set TimeStamp in Milliseconds
        /// </summary>
        public long TimeStamp { get; set; }

        /// <summary>
        /// Gets or sets value for a given point in time
        /// </summary>
        public double Value { get; set; }

        #endregion
    }
}

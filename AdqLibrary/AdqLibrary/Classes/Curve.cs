using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdqLibrary.Classes
{
    /// <summary>
    /// Represents a curve
    /// </summary>
    public class Curve
    {
        #region Private Fields

        private static Curve _curve = null;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets Curve's Identification
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets Point inside a  given Curve
        /// </summary>
        public List<Point> Points { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Curve"/> class.
        /// </summary>
        public Curve()
        {
            this.Points = new List<Point>();
        }
        
        #endregion

        #region Public Methods

        /// <summary>
        /// Gets a single instance of Curve
        /// </summary>
        /// <returns>an instance of Curve</returns>
        public static Curve GetInstance()
        {
            if (_curve == null)
                _curve = new Curve();

            return _curve;
        }

        #endregion
    }
}

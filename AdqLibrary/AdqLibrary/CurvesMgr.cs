using AdqLibrary.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdqLibrary
{
    /// <summary>
    /// Exposes all methods necessary 
    /// to handle Curves aquired from field
    /// </summary>
    public class CurvesMgr
    {
        #region Private Fields

        private static CurvesMgr _curveMgr = null;

        private Curve _currentCurve = null;
        
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets last Curve acquired from field
        /// </summary>
        public Curve CurveAcquired
        {
            get
            {
                return _currentCurve;
            }
            set
            {
                _currentCurve = value;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets a single instance of CurvesMgr
        /// </summary>
        /// <returns>an instance of CurvesMgr</returns>
        public static CurvesMgr GetInstance()
        {
            if (_curveMgr == null)
                _curveMgr = new CurvesMgr();

            return _curveMgr;
        }

        /// <summary>
        /// Saves Current Curve into a bin file
        /// </summary>
        /// <returns>True if the process was successfully completed</returns>
        public bool SaveCurveIntoBin()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves Current Curve into a bin file
        /// </summary>
        /// <param name="curve">Curve instance to be saved</param>
        /// <returns>True if the process was successfully completed</returns>
        public bool SaveCurveIntoBin(Curve curve)
        {
            throw new NotImplementedException();
        }
        
        #endregion
    }
}

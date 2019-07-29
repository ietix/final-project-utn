using AdqLibrary.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
        /// Gets a given Curve saved in disk
        /// </summary>
        /// <param name="idCurve">Curve's Identification</param>
        /// <returns>a Curve instance</returns>
        public Curve GetCurve(long idCurve)
        {
            Curve result = null;

            try
            {
                //Format the object as Binary
                BinaryFormatter formatter = new BinaryFormatter();

                //Reading the file from the server
                FileStream fs = File.Open((Constants.BasePath + idCurve.ToString() + ".bin"), FileMode.Open);
                object obj = formatter.Deserialize(fs);
                result = (Curve)obj;
                fs.Flush();
                fs.Close();
                fs.Dispose();
            }
            catch (Exception ex)
            {
                CommunicationMgr.Log.Error(string.Format("ERROR recuperando curva desde archivo binario. Error [{0}]", ex.Message));
            }

            return result;
        }

        /// <summary>
        /// Saves Current Curve into a bin file
        /// </summary>
        /// <param name="curve">Curve instance to be saved</param>
        /// <returns>True if the process was successfully completed</returns>
        public long SaveCurveIntoBin()
        {
            return SaveCurveIntoBin(_currentCurve);
        }

        /// <summary>
        /// Saves Current Curve into a bin file
        /// </summary>
        /// <param name="curve">Curve instance to be saved</param>
        /// <returns>True if the process was successfully completed</returns>
        public long SaveCurveIntoBin(Curve curve)
        {
            long result = 0;

            try
            {
                curve.Id = result = Functions.TimeStampMS();

                //Create the stream to add object into it.
                System.IO.Stream ms = File.OpenWrite(Constants.BasePath + curve.Id.ToString() + ".bin");

                //Format the object as Binary
                BinaryFormatter formatter = new BinaryFormatter();

                //Serialize the curve object
                formatter.Serialize(ms, curve);
                ms.Flush();
                ms.Close();
                ms.Dispose();
            }
            catch (Exception ex)
            {
                CommunicationMgr.Log.Error(string.Format("ERROR guardando objeto en archivo binario. Error [{0}]", ex.Message));
            }

            return result;
        }
        
        #endregion
    }
}

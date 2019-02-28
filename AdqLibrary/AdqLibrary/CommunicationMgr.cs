using log4net;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdqLibrary
{
    /// <summary>
    /// Exposes all methods necessary 
    /// to communicates against field circuits
    /// </summary>
    public class CommunicationMgr
    {
        #region Private Fields 

        /// <summary>
        /// Singleton object
        /// </summary>
        private static CommunicationMgr _communicationMgr = null;

        /// <summary>
        /// SerialPort's instance
        /// </summary>
        private SerialPort _serialPort = null;

        /// <summary>
        /// Log4Net's instance
        /// </summary>
        private static ILog _log = null;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CommunicationMgr"/> class
        /// </summary>
        public CommunicationMgr()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommunicationMgr"/> class
        /// </summary>
        /// <param name="log4NetInstance">Log4Net instance</param>
        public CommunicationMgr(ILog log4NetInstance)
        {
            // Inits Log4Net
            _log = log4NetInstance;

            // Inits Serial Port
            InitSerialPort();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets a single instance of CommunicationMgr
        /// </summary>
        /// <returns>an instance of CommunicationMgr</returns>
        public static CommunicationMgr GetInstance()
        {
            if (_communicationMgr == null)
                _communicationMgr = new CommunicationMgr();

            return _communicationMgr;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Initializes a Serial Port
        /// </summary>
        private void InitSerialPort()
        {
            _serialPort = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
        }

        #endregion
    }
}
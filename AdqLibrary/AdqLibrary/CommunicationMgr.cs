using AdqLibrary.Classes;
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
        {
            // Inits Serial Port
            InitSerialPort();
        }

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

        /// <summary>
        /// Starts adquisition from field through serial port
        /// </summary>
        public void StartAdquisition()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Stops adquisition from field through serial port
        /// </summary>
        public void StopAdquisition()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Initializes a Serial Port
        /// </summary>
        private void InitSerialPort()
        {
            // Port Instance
            _serialPort = new SerialPort();

            // Initialization
            _serialPort.PortName = Constants.PortName;
            _serialPort.BaudRate = Constants.BaudRate;
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = Constants.DataBits;
            _serialPort.StopBits = StopBits.None;

            _log.Info(string.Format("{0} ==> Se inicializa Puerto Serie con los siguientes parametros: PortName [{1}] - BaudRate [{2}] - Parity [{3}] - DataBits [{4}] - StopBits [{5}]", 
                _serialPort.PortName, _serialPort.BaudRate, _serialPort.BaudRate, ((Parity)_serialPort.Parity).ToString(), _serialPort.DataBits, ((StopBits)_serialPort.StopBits).ToString()));
        }

        /// <summary>
        /// Acquires point from flied and publishe them into a MsQueue
        /// </summary>
        private void AcquirePoints()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
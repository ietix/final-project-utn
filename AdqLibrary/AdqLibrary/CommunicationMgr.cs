using AdqLibrary.Classes;
using log4net;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Messaging;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading;
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
        /// Message Queue for real time adquisition
        /// </summary>
        internal MessageQueue _adquisitionQueue = null;

        /// <summary>
        /// Log4Net's instance
        /// </summary>
        private static ILog _log = null;
        
        /// <summary>
        /// Lock used to manage access to a resource
        /// </summary>
        private ReaderWriterLockSlim _readerWriteLockSlim = new ReaderWriterLockSlim();

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets Adquisition MQueue
        /// </summary>
        public MessageQueue AdquisitionMQueue
        {
            get 
            {
                if (_adquisitionQueue == null)
                    InitMqueue(Constants.MQueue, Constants.MQueueLabel);

                return _adquisitionQueue;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CommunicationMgr"/> class
        /// </summary>
        public CommunicationMgr()
        {
            // Inits Serial Port
            InitSerialPort();

            // Inits Msg Queue
            InitMqueue(Constants.MQueue, Constants.MQueueLabel);
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

            // Inits Msg Queue
            InitMqueue(Constants.MQueue, Constants.MQueueLabel);
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
        /// Initializes Mqueue instance to exchange messages
        /// </summary>
        /// <param name="label">Label associated to the queue</param>
        /// <returns>an instance of a Mqueue</returns>
        private MessageQueue InitMqueue(string queue, string label)
        {
            _readerWriteLockSlim.EnterWriteLock();
            try
            {
                if (MessageQueue.Exists(queue) == false)
                {
                    _log.Info(string.Format("{0} ==> ERROR: No existe la Cola [{1}], se procede a crearla", MethodBase.GetCurrentMethod().Name, queue));

                    // Si no existe crea la cola de comunicacion
                    MessageQueue.Create(queue);
                }

                // Abre la cola de comunicacion
                _adquisitionQueue = new MessageQueue(queue);

                // Create a new trustee to represent the "Everyone" user group.
                SecurityIdentifier everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);

                var account = (NTAccount)everyone.Translate(typeof(NTAccount));
                Trustee tr = new Trustee(account.Value);

                // Create a MessageQueueAccessControlEntry, granting the trustee the right to receive messages from the queue.
                MessageQueueAccessControlEntry entry = new MessageQueueAccessControlEntry(tr, MessageQueueAccessRights.FullControl, AccessControlEntryType.Allow);

                // Apply the MessageQueueAccessControlEntry to the queue.
                _adquisitionQueue.SetPermissions(entry);

                _adquisitionQueue.Label = string.Format("POINTS - {0}", label);
                _adquisitionQueue.DefaultPropertiesToSend.TimeToReachQueue = new TimeSpan(0, 0, 1); // Timeout 1 segundo

                if (_adquisitionQueue != null)
                {
                    Point point = new Point();
                    Object o = new Object();
                    System.Type[] arrTypes = new System.Type[2];

                    arrTypes[0] = point.GetType();
                    arrTypes[1] = o.GetType();

                    _adquisitionQueue.Formatter = new XmlMessageFormatter(arrTypes);
                }

                return _adquisitionQueue;
            }
            finally
            {
                _readerWriteLockSlim.ExitWriteLock();
            }
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
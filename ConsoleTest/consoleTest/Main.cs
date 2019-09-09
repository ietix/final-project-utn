using AdqLibrary.Classes;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace consoleTest
{
    public class Main
    {
        #region Private Fields

        /// <summary>
        /// Singleton object
        /// </summary>
        private static Main _main = null;

        /// <summary>
        /// Log4Net's instance
        /// </summary>
        private static readonly ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// AdqLibreary Communication Manager
        /// </summary>
        private AdqLibrary.CommunicationMgr _adqCommMgr = null;

        /// <summary>
        /// Indicates if main loop should remain active
        /// </summary>
        private bool _loop = true;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Main"/> class.
        /// </summary>
        public Main()
        {
            _adqCommMgr = AdqLibrary.CommunicationMgr.GetInstance(_log);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets a single instance of Main
        /// </summary>
        /// <returns>an instance of Main</returns>
        public static Main GetInstance()
        {
            if (_main == null)
                _main = new Main();

            return _main;
        }

        /// <summary>
        /// Adquires from Arduion, only testing
        /// </summary>
        public void AdquireFromArduino()
        {
            string methodName = MethodBase.GetCurrentMethod().Name;

            Point point = null;

            // Msg Queue
            MessageQueue msgQueue = AdqLibrary.CommunicationMgr.GetInstance().AdquisitionMQueue;

            // Start Adquisition
            AdqLibrary.CommunicationMgr.GetInstance().StartAdquisition();

            // Stop Adquisition
            Thread thread = new Thread(StopAdquireFromArduino);
            thread.Start();

            do
            {
                try
                {
                    var pendingMessages = msgQueue.GetAllMessages().Length;
                    if (pendingMessages > 0)
                    {
                        var msgEnumerator = msgQueue.GetMessageEnumerator2();
                        while (msgEnumerator.MoveNext(new TimeSpan(0, 0, 1)))
                        {
                            point = (Point)msgQueue.ReceiveById(msgEnumerator.Current.Id, new TimeSpan(0, 0, 1)).Body;
                            
                        }
                    }
                    else
                        _log.InfoFormat("{0} ==> No se detectan << Mensajes Pendientes >> en Cola: << {1} >>.", methodName, msgQueue.FormatName);
                }
                catch (Exception ex)
                {
                    _log.ErrorFormat("{0} ==> Error al Recibir Mensaje en Cola: << {1} >> | Error: << {2} >>.", methodName, msgQueue.FormatName, ex.Message);
                }

                Thread.Sleep(1000);
            }
            while (_loop);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Stops Adquisition from Arduino
        /// </summary>
        private void StopAdquireFromArduino()
        {
            Thread.Sleep(50000);
            AdqLibrary.CommunicationMgr.GetInstance().StopAdquisition();
            Thread.Sleep(10000);
            _loop = false;
        }

        #endregion
    }
}

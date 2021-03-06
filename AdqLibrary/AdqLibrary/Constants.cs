﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdqLibrary
{
    /// <summary>
    /// Contains all constants
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// Port's Name
        /// </summary>
        public static string PortName = "COM6";
        
        /// <summary>
        /// Baud Rate
        /// </summary>
        public static int BaudRate = 9600;
        
        /// <summary>
        /// Data Bits Length
        /// </summary>
        public static int DataBits = 8;

        /// <summary>
        /// Msg Queue where points acquired are saved in online mode
        /// </summary>
        public static string MQueue = "real_time_curve";

        /// <summary>
        /// Msg Queue's label where points acquired are saved in online mode
        /// </summary>
        public static string MQueueLabel = "Real Time Curve";

        /// <summary>
        /// Base path where bin files are saved
        /// </summary>
        public static string BasePath = @"D:\";
    }
}

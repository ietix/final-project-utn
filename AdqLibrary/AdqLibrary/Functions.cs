using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdqLibrary
{
    public class Functions
    {
        #region Public Methods

        /// <summary>
        /// Gets TimeStamp in milliseconds
        /// </summary>
        /// <returns>timestamp MS</returns>
        public static long TimeStampMS()
        {
            long CurrentTimestampSeconds = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds;

            return CurrentTimestampSeconds;
        }

        #endregion
    }
}

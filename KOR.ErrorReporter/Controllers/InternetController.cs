using System;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;

namespace KOR.ErrorReporter.Controllers
{
    /// <summary>
    /// InternetController contains
    /// </summary>
    public class InternetController
    {
        /// <summary>
        /// Internet connection check
        /// </summary>
        /// <returns>bool value</returns>
        public static bool InternetCheck()
        {
            try
            {
                if (NetworkInterface.GetIsNetworkAvailable())
                {
                    NetworkInterface[] netinterface = NetworkInterface.GetAllNetworkInterfaces();
                    return (from system in netinterface where system.OperationalStatus == OperationalStatus.Up where (system.NetworkInterfaceType != NetworkInterfaceType.Tunnel) && (system.NetworkInterfaceType != NetworkInterfaceType.Loopback) select system.GetIPv4Statistics()).Any(statistics => (statistics.BytesReceived > 0) && (statistics.BytesSent > 0));
                }

                return false;
            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp.ToString());
                // save error log
                return false;
            }
        }
    }
}

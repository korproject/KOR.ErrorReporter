using System.Security.Principal;

namespace KOR.ErrorReporter.Models
{
    // Client Definitions
    public class Client
    {
        /// <summary>
        /// Unique CPU based machine ID
        /// </summary>
        public static readonly string CPUId = Info.GetCpuid();

        /// <summary>
        /// Current username on this session
        /// </summary>
        public static readonly string Username = WindowsIdentity.GetCurrent().Name;
    }
}

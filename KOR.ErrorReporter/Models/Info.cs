using System.Diagnostics;
using System.Management;

namespace KOR.ErrorReporter.Models
{
    public class Info
    {
        #region Get CPU Info

        /// <summary>
        /// Get current machine on installed CPU ID
        /// </summary>
        /// <returns></returns>
        public static string GetCpuid()
        {
            string ret = string.Empty;

            try
            {
                ManagementClass managClass = new ManagementClass("win32_processor");
                ManagementObjectCollection managCollec = managClass.GetInstances();

                foreach (ManagementObject managObj in managCollec)
                {
                    ret = managObj.Properties["processorId"].Value.ToString();
                }
            }
            catch (ManagementException manaExp)
            {
                Debug.WriteLine(manaExp);
            }

            return ret;
        }

        #endregion
    }
}

using System.Net;

namespace KOR.ErrorReporter.Models
{
    public class ApiResponse
    {
        #region Response

        /// <summary>
        /// Returned API resquest code (must check before ResponseStatus for 5xx server errors)
        /// </summary>
        public int ResponseAPICode { get; set; }

        /// <summary>
        /// Response Http Status Code
        /// </summary>
        public HttpStatusCode ResponseStatus;

        /// <summary>
        /// Response data from API request
        /// </summary>
        public string ResponseData { get; set; }

        /// <summary>
        /// Respond string (if there is any update or there are error/warning)
        /// </summary>
        public string ResponseResultString { get; set; }

        /// <summary>
        /// Returned API request error message
        /// </summary>
        public string ResponseAPIErrorMessage { get; set; }

        /// <summary>
        /// Retured API request warning message
        /// </summary>
        public string ResponseAPIWarningMessage { get; set; }

        #endregion
    }
}

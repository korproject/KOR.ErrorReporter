namespace KOR.ErrorReporter.Models
{
    public class Api
    {
        /// <summary>
        /// API key
        /// </summary>
        public static string API_KEY { get; set; }

        /// <summary>
        /// API Secret
        /// </summary>
        public static string API_SECRET { get; set; }

        /// <summary>
        /// Output type for API request response data
        /// </summary>
        public enum OutputTypes
        {
            Json, Xml
        };

        /// <summary>
        /// OutputType
        /// </summary>
        public static OutputTypes OutputType { get; set; }
    }
}

using System;

namespace KOR.ErrorReporter.Models
{
    public class Error
    {
        /// <summary>
        /// Error occured time, default Now
        /// </summary>
        public DateTime Date = DateTime.Now;

        /// <summary>
        /// Error title, required for categorizing
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Error content, required
        /// </summary>
        public object Content { get; set; }

        /// <summary>
        /// KOR.Updater UpdateId, optional
        /// </summary>
        public string UpdateId { get; set; }

        /// <summary>
        /// Error severity (1-10) if is null saves 1 (default)
        /// </summary>
        public int Severity { get; set; }

        /// <summary>
        /// Error custom comment or predefined possible notes, optional
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Error description or addinal info, optinal
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// System info maybe needed, it must be JSON format, opitnal
        /// </summary>
        public object SystemInfo { get; set; }
    }
}

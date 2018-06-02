using System;

namespace KOR.ErrorReporter.Models
{
	public class Feedback
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
	}
}

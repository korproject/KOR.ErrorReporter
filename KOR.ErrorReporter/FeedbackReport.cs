using KOR.ErrorReporter.Controllers;
using KOR.ErrorReporter.JSON;
using KOR.ErrorReporter.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace KOR.ErrorReporter
{
	public class FeedbackReport
	{
		#region Feedback Reporter Constructors

		/// <summary>
		/// Updater response
		/// </summary>
		public ApiResponse FeedbackReportResponse { get; set; }

		/// <summary>
		/// JSON deseialized response data
		/// </summary>
		public RootobjectforReporter RespJsonObj { get; set; }

		/// <summary>
		/// Error contents
		/// </summary>
		public Feedback Feedback { get; set; }

		#endregion

		#region Reporter

		/// <summary>
		/// Check and parse updater json response data
		/// </summary>
		/// <returns></returns>
		public bool ReportFeedback()
		{
			if (InternetController.InternetCheck())
			{
				var settings = new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore,
					MissingMemberHandling = MissingMemberHandling.Ignore,
					PreserveReferencesHandling = PreserveReferencesHandling.Objects,
				};

				FeedbackReportResponse = new ApiResponse();

				#region API Request

				// request host
				var server = new RestClient("http://api.kor.onl/");
				// request relative url
				var request = new RestRequest("apps/error-reporter/1.0/", Method.POST);

				// add important parameters
				request.AddOrUpdateParameter("request", "feedback");
				request.AddOrUpdateParameter("type", Api.OutputType);
				request.AddOrUpdateParameter("api_key", Api.API_KEY);
				request.AddOrUpdateParameter("api_secret", Api.API_SECRET);

				// required params
				request.AddOrUpdateParameter("title", Feedback.Title);
				request.AddOrUpdateParameter("content", Feedback.Content);

				// user identifies
				request.AddOrUpdateParameter("client", Client.Username);
				request.AddOrUpdateParameter("machine", Client.CPUId);


				// get query result
				var response = server.Execute(request);

				// get response status code
				FeedbackReportResponse.ResponseStatus = response.StatusCode;
				FeedbackReportResponse.ResponseData = response.Content;

				#endregion

				#region JSON Parsing

				RespJsonObj = JsonConvert.DeserializeObject<RootobjectforReporter>(response.Content, settings);

				#endregion

				#region Updates JSON Parsing

				if (response.StatusCode == HttpStatusCode.OK)
				{
					return RespJsonObj.code == 1 && RespJsonObj.result == "OK" ? true : false;
				}
				else
				{
					// error message
					FeedbackReportResponse.ResponseAPIErrorMessage = (string)RespJsonObj.messages.error_message;
					// warning message
					FeedbackReportResponse.ResponseAPIWarningMessage = (string)RespJsonObj.messages.warning_message;
				}

				#endregion
			}

			return false;
		}

		#endregion
	}
}

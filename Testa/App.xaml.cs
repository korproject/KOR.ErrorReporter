using KOR.ErrorReporter;
using KOR.ErrorReporter.Models;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace Testa
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            AppDomain.CurrentDomain.UnhandledException += (s, e) => SendUnhandledError((Exception)e.ExceptionObject, "AppDomain.CurrentDomain.UnhandledException");

            DispatcherUnhandledException += (s, e) => SendUnhandledError(e.Exception, "Application.Current.DispatcherUnhandledException");

            TaskScheduler.UnobservedTaskException += (s, e) => SendUnhandledError(e.Exception, "TaskScheduler.UnobservedTaskException");
        }

        private void SendUnhandledError(Exception exp, string @event)
        {
            Error error = new Error()
            {
                Title = @event,
                Content = exp,
                Severity = 10,
                Comment = "Unhandled exception",
                Description = "Catched grom global error handlers"
            };

            MessageBox.Show(exp.Message);

            ErrorReport errorReporter = new ErrorReport()
            {
                Error = error
            };

            var report = errorReporter.ReportError();

            if (report)
            {
                MessageBox.Show("error reported");
            }
            else
            {
                MessageBox.Show("error report failed");
            }
        }
    }
}

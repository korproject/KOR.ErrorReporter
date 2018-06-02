using KOR.ErrorReporter;
using KOR.ErrorReporter.Models;
using System;
using System.Windows;

namespace Testa
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
    {
        /// <summary>
        /// Error contents
        /// </summary>
        public Error Error { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Api.OutputType = Api.OutputTypes.Json;
            Api.API_KEY = "12B697B4037EB4BC4E5CC1C0E2E6A90BEEDBE6EC7FFE34A1065E14EE6DE753B44116306874FDEC3D0841FCF5DC8EFA4224EA7399CC513E983852D4EE";
            Api.API_SECRET = "daed110249b5a1f88054ca021499e12f12edb21891ed851fd1fdee5a85afa0d075839a236d11728db9213c3dde7e5b1d491590e84c1e420553fca8f2d45bd815";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var val1 = int.Parse(Val1.Text);
                var val2 = int.Parse(Val2.Text);

                Result.Text = (val1 / val2).ToString();
            }
            catch (Exception exp)
            {
                Error error = new Error()
                {
                    Title = exp.Message,
                    Content = exp,
                    Severity = 10,
                    Comment = "User input",
                    Description = "Calculations"
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
}

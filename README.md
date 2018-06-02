# KOR.ErrorReporter
ErrorReporter API Client Library for .NET

## Documentation
See more info and documentation [KOR.ErrorReporter API](http://api.kor.onl/apps/error-reporter/).


## Basic Usage
```cshap
using KOR.ErrorReporter;
using KOR.ErrorReporter.Models;

...

Api.OutputType = Api.OutputTypes.Json;
Api.API_KEY = "{YOUR_API_KEY}";
Api.API_SECRET = "{YOUR_API_SECRET}";

...

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
```
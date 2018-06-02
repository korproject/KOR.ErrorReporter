namespace KOR.ErrorReporter.JSON
{
    public class RootobjectforReporter
    {
        public int code { get; set; }
        public string result { get; set; }
        public Messages messages { get; set; }
        public Dev_Tips dev_tips { get; set; }
    }

    public class Messages
    {
        public bool error { get; set; }
        public object error_message { get; set; }
        public bool warning { get; set; }
        public object warning_message { get; set; }
    }

    public class Dev_Tips
    {
        public object tip { get; set; }
        public object link { get; set; }
    }
}

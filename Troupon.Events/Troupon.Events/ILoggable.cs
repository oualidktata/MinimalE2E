namespace Troupon.Events
{
    public interface ILoggable
    {
        public LogLevel Level { get; set; }
    }

    public enum LogLevel
    {
        Debug,
        Info,
        Warning,
        Error,
        Critical
    }
}

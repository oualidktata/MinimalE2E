namespace Troupon.Events
{
    public class PublishDealRequest : ILoggable
    {
        public int DealId { get; set; }
        public LogLevel Level { get; set; } = LogLevel.Critical;
    }
}

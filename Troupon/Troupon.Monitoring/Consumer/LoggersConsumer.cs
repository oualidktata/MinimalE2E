using System;
using System.Threading.Tasks;
using MassTransit;
using Troupon.Events;

namespace Troupon.Monitoring.Consumer
{
    public class EventViewerLoggerConsumer : IConsumer<ILoggable>
    {
        public Task Consume(
            ConsumeContext<ILoggable> context)
        {
            if (context.Message.Level == LogLevel.Critical)
            {
                // Go in event viewer
                Console.WriteLine("[EventViewer Logger] Event received");
            }
            
            return Task.CompletedTask;
        }
    }
    
    public class ElasticSearchConsumer : IConsumer<ILoggable>
    {
        public Task Consume(
            ConsumeContext<ILoggable> context)
        {
            if (context.Message.Level >= LogLevel.Info) 
            {
                // Go to elastic search
                Console.WriteLine("[Elastic Search Logger] Event received");
            }
            return Task.CompletedTask;
        }
    }
    
    public class DebugLoggerConsumer : IConsumer<ILoggable>
    {
        public Task Consume(
            ConsumeContext<ILoggable> context)
        {
            if (context.Message.Level == LogLevel.Debug) 
            {
                // Go to Console
                Console.WriteLine("[Debug Logger] Event received");
            }
            return Task.CompletedTask;
        }
    }
}

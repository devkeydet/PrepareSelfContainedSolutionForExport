using Microsoft.Xrm.Sdk;
using System;

namespace SelfContainedSolutionTest.Plugins.Base
{
    // Specialized ITracingService implementation that prefixes all traced messages with a time delta for Plugin performance diagnostics
    public class LocalTracingService : ITracingService
    {
        private readonly ITracingService _tracingService;

        private DateTime _previousTraceTime;

        public LocalTracingService(IServiceProvider serviceProvider)
        {
            var utcNow = DateTime.UtcNow;

            var context = (IExecutionContext)serviceProvider.GetService(typeof(IExecutionContext));

            var initialTimestamp = context.OperationCreatedOn;

            if (initialTimestamp > utcNow)
            {
                initialTimestamp = utcNow;
            }

            _tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            _previousTraceTime = initialTimestamp;
        }

        public void Trace(string message, params object[] args)
        {
            var utcNow = DateTime.UtcNow;

            // The duration since the last trace.
            var deltaMilliseconds = utcNow.Subtract(_previousTraceTime).TotalMilliseconds;

            _tracingService.Trace($"[+{deltaMilliseconds:N0}ms)] - {message}");

            _previousTraceTime = utcNow;
        }
    }
}
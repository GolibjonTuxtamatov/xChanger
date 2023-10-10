﻿using System;
using Microsoft.Extensions.Logging;

namespace xChanger.Api.Brokers.Loggings
{
    public class LoggingBroker : ILoggingBroker
    {
        private readonly ILogger<ILoggingBroker> logger;

        public LoggingBroker(ILogger<ILoggingBroker> logger)
        {
            this.logger = logger;
        }

        public void LogError(Exception exception) =>
            this.logger.LogError(exception, exception.Message);
    }
}
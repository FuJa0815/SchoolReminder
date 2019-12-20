using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SchoolReminder.Extractor;

namespace SchoolReminder.Main
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var timer = new System.Timers.Timer {Interval = 1000 * 60 * 60, AutoReset = true};
            timer.Elapsed += (sender, args) =>
            {

            };
            timer.Start();
        }
    }
}

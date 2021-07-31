using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Monitor.Helpers;

namespace Monitor
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly Sites _sites;

        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _sites = configuration.GetSection("Sites").Get<Sites>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                HttpStatusCode statusCode = await Requesters.GetStatusFromUrl(_sites.Url);
                if (statusCode != HttpStatusCode.OK)
                {
                    string nameFile = string.Format("logfile_{0}.txt", DateTime.Now.ToString("yyyyMMdd"));
                    string path = Path.Combine(@"C:\Users\User\Documents\", nameFile);
                    StreamWriter logFile = new StreamWriter(path, true);
                    string message = string.Format("O site {0} ficou fora do ar no dia {1}", _sites.Url, DateTime.Now.ToString("yyyyMMdd"));
                    logFile.WriteLine(message);
                    logFile.Close();
                }

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                
                try
                {
                    await Task.Delay(1000, stoppingToken);
                }
                catch (OperationCanceledException)
                {
                    return;
                }
            }
        }
    }
}

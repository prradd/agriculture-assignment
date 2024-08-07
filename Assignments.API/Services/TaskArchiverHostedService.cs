using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Assignments.API.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Assignments.API.Services
{
    public class TaskArchiverHostedService : IHostedService, IDisposable
    {
        private readonly ILogger<TaskArchiverHostedService> _logger;
        private readonly IServiceProvider _serviceProvider;
        private Timer _timer;

        public TaskArchiverHostedService(ILogger<TaskArchiverHostedService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Start archiving tasks.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromDays(1)); // Runs daily

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            _logger.LogInformation("Archiving tasks in progress.");

            using (var scope = _serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ToDoContext>();

                var oneWeekAgo = DateTime.Now.AddDays(-7);
                var tasksToArchive = context.ToDoItems
                    .Where(t => t.CompleteDate <= oneWeekAgo && t.CompleteDate != null && !t.IsArchived)
                    .ToList();

                foreach (var task in tasksToArchive)
                {
                    task.IsArchived = true;
                }

                context.SaveChanges();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stop archiving tasks.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}

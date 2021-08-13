using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace BuildingBlocks.OpenTelemetry.Messaging
{
    public class Worker : BackgroundService
    {
        private readonly MessageReceiver messageReceiver;

        public Worker(MessageReceiver messageReceiver)
        {
            this.messageReceiver = messageReceiver;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            await base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            messageReceiver.StartConsumer();

            await Task.CompletedTask;
        }
    }
}
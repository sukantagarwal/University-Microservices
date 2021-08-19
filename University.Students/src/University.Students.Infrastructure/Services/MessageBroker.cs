using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingBlocks.CQRS.Events;
using BuildingBlocks.Types;
using DotNetCore.CAP;
using Microsoft.Extensions.Logging;
using University.Students.Application.Services;
using University.Students.Infrastructure.EfCore;

namespace University.Students.Infrastructure.Services
{
    public class MessageBroker : IMessageBroker
    {
        private readonly ICapPublisher _capPublisher;
        private readonly ILogger<MessageBroker> _logger;
        private readonly StudentDbContext _studentDbContext;
        private readonly Options.OutboxOptions _outbox;
        private readonly Options.RabbitMqOptions _rabbitMqOptions;

        public MessageBroker(ICapPublisher capPublisher, ILogger<MessageBroker> logger,
            StudentDbContext studentDbContext, Options.OutboxOptions outbox, Options.RabbitMqOptions rabbitMqOptions)
        {
            _capPublisher = capPublisher;
            _logger = logger;
            _studentDbContext = studentDbContext;
            _outbox = outbox;
            _rabbitMqOptions = rabbitMqOptions;
        }

        public Task PublishAsync(params IEvent[] events) => PublishAsync(events?.AsEnumerable());

        public async Task PublishAsync(IEnumerable<IEvent> events)
        {
            if (events is null)
            {
                return;
            }

            foreach (var @event in events)
            {
                if (@event is null)
                {
                    continue;
                }

                if (_outbox.Enabled)
                {
                    using (var trans = _studentDbContext.Database.BeginTransaction(_capPublisher, autoCommit: true))
                    {
                        await _capPublisher.PublishAsync(@event.GetType().Name, @event);
                    }

                    continue;
                }

                await _capPublisher.PublishAsync(@event.GetType().Name, @event);
            }
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.CAP;
using MicroPack.CQRS.Events;
using MicroPack.Types;
using Microsoft.Extensions.Logging;
using University.Instructors.Application.Services;
using University.Instructors.Infrastructure.EfCore;

namespace University.Instructors.Infrastructure.Services
{
    public class MessageBroker : IMessageBroker
    {
        private readonly ICapPublisher _capPublisher;
        private readonly ILogger<MessageBroker> _logger;
        private readonly InstructorDbContext _studentDbContext;
        private readonly OutboxOptions _outbox;


        public MessageBroker(ICapPublisher capPublisher, ILogger<MessageBroker> logger, InstructorDbContext studentDbContext, OutboxOptions outbox)
        {
            _capPublisher = capPublisher;
            _logger = logger;
            _studentDbContext = studentDbContext;
            _outbox = outbox;
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
using Actio.Common.Commands;
using Actio.Common.Events;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.Services.Activities.Handlers
{
    public class CreateActivityHandler : ICommandHandler<CreateActivity>
    {
        private readonly IBusClient _busClient;
        public CreateActivityHandler(IBusClient client)
        {
            _busClient = client;
        }
        public async Task HandleAsync(CreateActivity command)
        {
            Console.WriteLine($"Creating Activity {command.Id} for user : {command.UserId}");
            await _busClient.PublishAsync(new ActivityCreated(
                 command.Id,
                 command.UserId,
                 command.Category,
                 command.Name,
                 command.Description,
                 command.CreatedAt));
        }
    }
}

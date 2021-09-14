using Actio.Common.Commands;
using Actio.Common.Events;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Instantiation;
using RawRabbit.Pipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Actio.Common.RabbitMQ
{
    public static class Extensions
    {
        public static Task withCommandHandlerAsync<TCommand>(this IBusClient busClient,
            ICommandHandler<TCommand> handler) where TCommand : ICommand =>
            busClient.SubscribeAsync<TCommand>(msg => handler.HandleAsync(msg),
            ctx => ctx.UseConsumerConfiguration(cfg =>
              cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TCommand>()))
            ));

        public static Task withEventHandlerAsync<TEvent>(this IBusClient busClient,
    IEventHandler<TEvent> handler) where TEvent : IEvents =>
    busClient.SubscribeAsync<TEvent>(msg => handler.HandleAsync(msg),
    ctx => ctx.UseConsumerConfiguration(cfg =>
      cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TEvent>()))
    ));
        private static string GetQueueName<T>() => $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";


        public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            var options = new RabbitMqOptions();
            var section = configuration.GetSection("rabbitmq");
            section.Bind(options);

            var client = RawRabbitFactory.CreateSingleton(new RawRabbitOptions
            {
                ClientConfiguration = options
            });

            services.AddSingleton<IBusClient>(_ => client);

        }
    }
}

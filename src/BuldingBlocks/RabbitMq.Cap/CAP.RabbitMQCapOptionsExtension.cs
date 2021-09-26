// Copyright (c) .NET Core Community. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using BuildingBlocks.RabbitMq.Cap;
using DotNetCore.CAP.Transport;
using Microsoft.Extensions.DependencyInjection;
using ConnectionChannelPool = BuildingBlocks.RabbitMq.Cap.ConnectionChannelPool;
using IConnectionChannelPool = BuildingBlocks.RabbitMq.Cap.IConnectionChannelPool;

// ReSharper disable once CheckNamespace
namespace DotNetCore.CAP
{
    internal sealed class RabbitMQCapOptionsExtension : ICapOptionsExtension
    {
        private readonly Action<RabbitMQOptions> _configure;

        public RabbitMQCapOptionsExtension(Action<RabbitMQOptions> configure)
        {
            _configure = configure;
        }

        public void AddServices(IServiceCollection services)
        {
            services.AddSingleton<CapMessageQueueMakerService>();
             
            services.Configure(_configure);
            services.AddSingleton<ITransport, RabbitMQTransport>();
            services.AddSingleton<IConsumerClientFactory, RabbitMQConsumerClientFactory>();
            services.AddSingleton<IConnectionChannelPool, ConnectionChannelPool>();
        }
    }
}
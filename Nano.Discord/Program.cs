using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nano.Application;
using Nano.Discord;
using Nano.Discord.Handlers;

var config = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("config.json", false, true)
    .Build();

using var host = Host.CreateDefaultBuilder()
    .ConfigureServices((_, services) =>
        services
            .AddSingleton(config)
            .AddSingleton(c => new DiscordSocketClient(new DiscordSocketConfig
            {
                GatewayIntents = GatewayIntents.AllUnprivileged,
                AlwaysDownloadUsers = true
            }))
            .AddSingleton(s => new InteractionService(s.GetRequiredService<DiscordSocketClient>()))
            .AddSingleton<InteractionHandler>()
            .AddApplication()
            .AddDatabase(config["connectionString"]))
    .Build();

await Startup.RunAsync(host);
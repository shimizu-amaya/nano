using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nano.Application.Database;
using Nano.Discord.Handlers;

namespace Nano.Discord;

public static class Startup
{
    public static async Task RunAsync(IHost host)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;

        var dbInitializer = services.GetRequiredService<DbInitializer>();
        await dbInitializer.InitializeAsync();
        
        var config = services.GetRequiredService<IConfigurationRoot>();
        var client = services.GetRequiredService<DiscordSocketClient>();

        var commands = services.GetRequiredService<InteractionService>();
        await services.GetRequiredService<InteractionHandler>().InitializeAsync();
        commands.SlashCommandExecuted += SlashCommandHandler.SlashCommandExecuted;

        client.Log += async msg => { Console.WriteLine(msg.Message); };
        commands.Log += async msg => { Console.WriteLine(msg.Message); };

        client.Ready += async () => { await ClientHandler.HandleClientReady(client, commands, config); };

        await client.LoginAsync(TokenType.Bot, config["token"]);
        await client.StartAsync();

        await Task.Delay(Timeout.Infinite);
    }
}
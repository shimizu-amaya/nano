using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;

namespace Nano.Discord.Handlers;

public class ClientHandler
{
    public static async Task HandleClientReady(DiscordSocketClient client, InteractionService interactionService,
        IConfigurationRoot config)
    {
        await interactionService.RegisterCommandsToGuildAsync(ulong.Parse(config["testGuild"]));

        Console.WriteLine("Bot Ready!");
    }
}
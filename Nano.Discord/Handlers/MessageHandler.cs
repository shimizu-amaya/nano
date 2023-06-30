using Discord;
using Discord.WebSocket;

namespace Nano.Discord.Handlers;

public static class MessageHandler
{
    public static async Task HandleMessageUpdated(Cacheable<IMessage, ulong> before, SocketMessage after,
        ISocketMessageChannel channel)
    {
        var message = await before.GetOrDownloadAsync();

        Console.WriteLine($"[MessageUpdated] {message} -> {after}");
    }
}
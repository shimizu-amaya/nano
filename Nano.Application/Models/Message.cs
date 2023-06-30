namespace Nano.Application.Models;

public class Message
{
    public ulong Id { get; set; }
    public ulong ChannelId { get; set; }
    public ulong AuthorId { get; set; }
    public ulong GuildId { get; set; }
}
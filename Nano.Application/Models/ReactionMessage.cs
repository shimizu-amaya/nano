namespace Nano.Application.Models;

public class ReactionMessage
{
    public Guid Id { get; set; }
    public ulong MessageId { get; set; }
    public string Emoji { get; set; }
    public Guid ActionId { get; set; }
    public string ActionData { get; set; }
}
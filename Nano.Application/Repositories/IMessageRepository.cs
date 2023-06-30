using Discord;

namespace Nano.Application.Repositories;

public interface IMessageRepository
{
    Task<bool> CreateAsync(IMessage msg, CancellationToken cancellationToken = default);
    Task<IMessage?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default);
    Task<IEnumerable<IMessage>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(IMessage msg, CancellationToken cancellationToken = default);
    Task<bool> DeleteByIdAsync(ulong id, CancellationToken cancellationToken = default);
    Task<bool> ExistsByIdAsync(ulong id, CancellationToken cancellationToken = default);
}
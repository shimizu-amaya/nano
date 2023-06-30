using Discord;
using Nano.Application.Database;

namespace Nano.Application.Repositories;

public class MessageRepository : IMessageRepository
{
    private readonly IDbConnectionFactory _connectionFactory;
    
    public MessageRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }
    
    public async Task<bool> CreateAsync(IMessage msg, CancellationToken cancellationToken = default)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync(cancellationToken);
        using var transaction = connection.BeginTransaction();

        throw new NotImplementedException();
    }

    public Task<IMessage?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<IMessage>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(IMessage msg, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteByIdAsync(ulong id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsByIdAsync(ulong id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
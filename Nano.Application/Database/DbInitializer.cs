using Dapper;

namespace Nano.Application.Database;

public class DbInitializer
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public DbInitializer(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }
    
    public async Task InitializeAsync(CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);

        await connection.ExecuteAsync("""
            CREATE TABLE IF NOT EXISTS messages (
                id INTEGER PRIMARY KEY,
                author_id INTEGER NOT NULL,
                channel_id INTEGER NOT NULL,
                guild_id INTEGER NOT NULL
            );
        """);

        await connection.ExecuteAsync("""
            CREATE TABLE IF NOT EXISTS reaction_messages (
                id INTEGER PRIMARY KEY,
                message_id INTEGER NOT NULL,
                emoji TEXT NOT NULL,
                action_id INTEGER NOT NULL,
                action_data TEXT NOT NULL,
                FOREIGN KEY (message_id) REFERENCES messages (id)
            );
        """);
    }
}
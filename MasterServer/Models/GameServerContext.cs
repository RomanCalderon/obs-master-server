using Microsoft.EntityFrameworkCore;

namespace MasterServer.Models
{
    public class GameServerContext : DbContext
    {
        public GameServerContext ( DbContextOptions<GameServerContext> options )
            : base ( options )
        {
        }

        public DbSet<GameServer> GameServers { get; set; }

    }
}
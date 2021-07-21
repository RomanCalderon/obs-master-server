using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MasterServer.Models
{
    public class GameServer
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Ip { get; set; }

        [Required]
        public ushort Port { get; set; }

        [Required]
        public byte ClientSceneIndex { get; set; }

        [Required]
        public byte PlayerCount { get; set; }

        [Required]
        public byte MaxPlayers { get; set; }

        public GameServer ( string name, string ip, ushort port, byte clientSceneIndex, byte playerCount, byte maxPlayers )
        {
            Name = name;
            Ip = ip;
            Port = port;
            ClientSceneIndex = clientSceneIndex;
            PlayerCount = playerCount;
            MaxPlayers = maxPlayers;
        }
    }
}
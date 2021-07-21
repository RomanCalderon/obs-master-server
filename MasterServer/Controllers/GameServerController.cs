using MasterServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterServer.Controllers
{
    [Produces ( "application/json" )]
    [Route ( "api/[controller]" )]
    [ApiController]
    public class GameServerController : ControllerBase
    {
        private readonly GameServerContext _context;

        public GameServerController ( GameServerContext context )
        {
            _context = context;
            _context.SaveChanges ();
        }

        #region GET GetAll

        [HttpGet]
        public ActionResult<List<GameServer>> GetAll ()
        {
            return _context.GameServers.ToList ();
        }

        #endregion

        #region GET GetById

        [HttpGet ( "{id}", Name = "GetGameServer" )]
        public ActionResult<GameServer> GetById ( long id )
        {
            GameServer gameServer = _context.GameServers.Find ( id );

            if ( gameServer == null )
            {
                return NotFound ();
            }

            return gameServer;
        }

        #endregion

        #region POST Create

        /// <summary>
        /// Creates a GameServer.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /GameServer
        ///     {
        ///        "name": "Game Server",
        ///        "ip": "123.123.1.2",
        ///        "port": 12345,
        ///        "clientSceneIndex": 0,
        ///        "playerCount": 0,
        ///        "maxPlayers": 0
        ///     }
        ///
        /// </remarks>
        /// <param name="gameServer">New GameServer object</param>
        /// <returns>A newly created GameServer</returns>
        /// <response code="201">Returns the newly created game server</response>
        /// <response code="400">If the game server is null</response>            
        [HttpPost]
        [ProducesResponseType ( StatusCodes.Status201Created )]
        [ProducesResponseType ( StatusCodes.Status400BadRequest )]
        public async Task<ActionResult<GameServer>> Create ( GameServer gameServer )
        {
            _context.GameServers.Add ( gameServer );
            await _context.SaveChangesAsync ();

            return CreatedAtRoute ( "GetGameServer", new { id = gameServer.Id }, gameServer );
        }

        #endregion

        #region PUT Update

        [HttpPut ( "{id}" )]
        public async Task<IActionResult> Update ( long id, GameServer updatedGameServer )
        {
            if ( updatedGameServer == null || updatedGameServer.Id != id )
            {
                return BadRequest ();
            }

            GameServer locatedGameServer = _context.GameServers.Find ( id );

            if ( locatedGameServer == null )
            {
                return NotFound ();
            }

            locatedGameServer.Name = updatedGameServer.Name;
            locatedGameServer.Ip = updatedGameServer.Ip;
            locatedGameServer.Port = updatedGameServer.Port;
            locatedGameServer.ClientSceneIndex = updatedGameServer.ClientSceneIndex;
            locatedGameServer.PlayerCount = updatedGameServer.PlayerCount;
            locatedGameServer.MaxPlayers = updatedGameServer.MaxPlayers;

            _context.GameServers.Update ( locatedGameServer );
            _context.Entry ( locatedGameServer ).State = EntityState.Modified;

            await _context.SaveChangesAsync ();

            return NoContent ();
        }

        #endregion

        #region DELETE Delete

        /// <summary>
        /// Deletes a specific GameServer.
        /// </summary>
        /// <param name="id"></param>        
        [HttpDelete ( "{id}" )]
        public async Task<IActionResult> Delete ( long id )
        {
            GameServer gameServer = _context.GameServers.Find ( id );

            if ( gameServer == null )
            {
                return NotFound ();
            }

            _context.GameServers.Remove ( gameServer );
            await _context.SaveChangesAsync ();

            return NoContent ();
        }

        #endregion
    }
}

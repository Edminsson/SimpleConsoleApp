using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Team;

namespace SimpleWebApp.Controllers
{
    public class TeamController : ApiController
    {
        Player[] players = new Player[] 
        { 
            new Player { Id = 1, Name = "Tomato Soup", Position=Position.Midfield }, 
            new Player { Id = 2, Name = "Yo-yo", Position=Position.Defender }, 
            new Player { Id = 3, Name = "Hammer", Position=Position.GoalKeeper } 
        };

        public IEnumerable<Player> GetAllPlayers()
        {
            return players;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var player = players.FirstOrDefault((p) => p.Id == id);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }
    }
}

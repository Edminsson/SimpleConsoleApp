using SimpleWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleWebApi.Controllers
{
    public class TeamController : ApiController
    {
        TeamVM[] teams = new TeamVM[] 
        { 
            new TeamVM { Id = 1, Name = "Malmö FF", Country = "Sweden" }, 
            new TeamVM { Id = 2, Name = "Barca", Country="Spain" }, 
            new TeamVM { Id = 3, Name = "Juventus", Country="Italy" } 
        };

        public IEnumerable<TeamVM> GetAllPlayers()
        {
            return teams;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var team = teams.FirstOrDefault((p) => p.Id == id);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }

        public IHttpActionResult Put(TeamVM lag)
        {
            //Vi sparar inte posten, vi bara kollar att den är ok
            if (ModelState.IsValid)
                return Ok(lag);
            else
                return BadRequest(ModelState);
        }

    }
}

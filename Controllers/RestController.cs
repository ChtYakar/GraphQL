using GraphQL_Nsn.Interfaces;
using GraphQL_Nsn.Models;
using GraphQL_Nsn.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_Nsn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestController : ControllerBase
    {
        static IServiceProvider _sp;
        static IGenericRepository<Matches> matchesRepo;
        static IGenericRepository<Player> playerRepo;
        static IGenericRepository<Team> teamRepo;
        public RestController(IServiceProvider sp)
        {
            _sp = sp;
            matchesRepo = (IGenericRepository<Matches>)_sp.GetService(typeof(IGenericRepository<Matches>));
            playerRepo = (IGenericRepository<Player>)_sp.GetService(typeof(IGenericRepository<Player>));
            teamRepo = (IGenericRepository<Team>)_sp.GetService(typeof(IGenericRepository<Team>));
        }
        [HttpGet("Index")]
        public JsonResult Index()
        {
            var list = matchesRepo.GetAll();
            return new JsonResult(list);
        }
        [HttpGet("GetMatchesNameWithTeams")]
        public JsonResult GetMatchesNameWithTeams(int matchId)
        {
            var match = matchesRepo.GetById(matchId);
            if (match == null)
                return new JsonResult(null);
            var homeTeam = teamRepo.GetById(match.HomeTeamId);
            var awayTeam = teamRepo.GetById(match.AwayTeamId);            
            return new JsonResult(new { Match = match, Teams = new Team[] { homeTeam, awayTeam } });
        }

    }
}

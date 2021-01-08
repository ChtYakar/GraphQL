using GraphQL.Types;
using GraphQL_Nsn.Graph.Type;
using GraphQL_Nsn.Interfaces;
using GraphQL_Nsn.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_Nsn.Graph.Query
{
    public class MatchesQuery : IFieldQueryServiceItem
    {
        public void Activate(ObjectGraphType objectGraph, IWebHostEnvironment env, IServiceProvider sp)
        {
            objectGraph.Field<ListGraphType<MatchesGType>>("matches",
               arguments: new QueryArguments(
                 new QueryArgument<IntGraphType> { Name = "id" },
                 new QueryArgument<IntGraphType> { Name = "homeTeamId" },
                 new QueryArgument<IntGraphType> { Name = "awayTeamId" },
                 new QueryArgument<IntGraphType> { Name = "limit" },
                 new QueryArgument<IntGraphType> { Name = "htID"}
               ),
               resolve: context =>
               {
                   var matchesRepository = (IGenericRepository<Matches>)sp.GetService(typeof(IGenericRepository<Matches>));
                   var _id = context.GetArgument<int>("id");
                   if (_id > 0)
                   {
                       var match = matchesRepository.GetById(_id);
                       List<Matches> singleMatch = new List<Matches>() { match };
                       return singleMatch;
                   }
                   var baseQuery = matchesRepository.GetAll();
                   var _homeTeamId = context.GetArgument<int>("homeTeamId");
                   var _awayTeamId = context.GetArgument<int>("awayTeamId");
                   var _limit = context.GetArgument<int>("limit");
                   var _htId = context.GetArgument<int>("htID");
                   if (_homeTeamId > 0)
                   {
                       baseQuery = baseQuery.Where(w => w.HomeTeam.Id == _homeTeamId);
                   }
                   if (_awayTeamId > 0)
                   {
                       baseQuery = baseQuery.Where(w => w.AwayTeam.Id == _awayTeamId);
                   }
                   if (_limit > 0)
                   {
                       return baseQuery.Take(_limit).ToList();
                   }
                   else
                   {
                       return baseQuery.ToList();
                   }
               });
        }
    }
}

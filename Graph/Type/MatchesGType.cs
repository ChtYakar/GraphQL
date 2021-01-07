using GraphQL.Types;
using GraphQL_Nsn.Interfaces;
using GraphQL_Nsn.Models;
using GraphQL_Nsn.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_Nsn.Graph.Type
{
    public class MatchesGType : ObjectGraphType<Matches>
    {
        public IServiceProvider Provider { get; set; }
        public MatchesGType(IServiceProvider provider)
        {
            Field(x => x.Id, type: typeof(IntGraphType)).Description("Maç Id'si");
            Field(x => x.Score, type: typeof(StringGraphType));
            Field(x => x.Stadium, type: typeof(StringGraphType));
            Field<TeamGType>("HomeTeam", resolve: context =>
              {                
                  IGenericRepository<Team> teamRepo = (IGenericRepository<Team>)provider.GetService(typeof(IGenericRepository<Team>));
                  return teamRepo.GetById(context.Source.HomeTeamId);
              });
            Field<TeamGType>("AwayTeam", resolve: context =>
            {
                IGenericRepository<Team> teamRepo = (IGenericRepository<Team>)provider.GetService(typeof(IGenericRepository<Team>));
                return teamRepo.GetById(context.Source.AwayTeamId);
            });

        }
    }
}
